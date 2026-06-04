using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.ResourceFile;

namespace Packer.Core.Model;

public sealed class PackerPolicy : ICollection<PackerPolicyItem>
{
    private readonly List<PackerPolicyItem> _items = new();
    public const string DefaultFileName = "packer-policy.json";
    public static PackerPolicy Shared { get; } = [new DirectPolicy()];
    public int Count => _items.Count;
    public bool IsReadOnly => false;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Add(PackerPolicyItem item) => _items.Add(item);
    public void Clear() => _items.Clear();
    public bool Contains(PackerPolicyItem item) => _items.Contains(item);
    public void CopyTo(PackerPolicyItem[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
    public bool Remove(PackerPolicyItem item) => _items.Remove(item);

    public static PackerPolicy Load(string namespaceDirPath)
    {
        var policyFile = Path.Combine(namespaceDirPath, DefaultFileName);
        if (!File.Exists(policyFile)) return Shared;
        try
        {
            var json = File.ReadAllText(policyFile);
            Log.Debug("策略文件内容: {Json}", json);
            var policies = JsonSerializer.Deserialize<PackerPolicy>(
                json, SourceGenerationContext.Options);
            if (policies is null) { Log.Warning("策略反序列化结果为 null: {File}", policyFile); return Shared; }
            if (policies._items.Count == 0) { Log.Warning("策略列表为空: {File}", policyFile); return Shared; }
            Log.Debug("成功加载 {Count} 条策略: {File}", policies._items.Count, policyFile);
            return policies;
        }
        catch (Exception ex) { Log.Warning(ex, "策略加载异常: {File}", policyFile); return Shared; }
    }
    public static PackerPolicy Load(INamespaceResource ns) => Load(ns.LocalPath);

    public IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource ns, FloatingConfig config)
        => _items.SelectMany(item => item.CreateProviders(ns, config));

    public IEnumerator<PackerPolicyItem> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DirectPolicy), "direct")]
[JsonDerivedType(typeof(IndirectPolicy), "indirect")]
[JsonDerivedType(typeof(CompositionPolicy), "composition")]
[JsonDerivedType(typeof(SingletonPolicy), "singleton")]
public abstract record PackerPolicyItem
{
    public bool ModifyOnly { get; init; }
    public bool Append { get; init; }

    public abstract IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config);

    protected IResourceFileProvider CreateProvider(
        string filePath, string relativePath, INamespaceResource ns)
    {
        var ext = Path.GetExtension(filePath);
        var parentDir = Path.GetFileName(Path.GetDirectoryName(filePath));

        switch (parentDir, ext)
        {
            case { parentDir: "lang", ext: ".json" }:
                var json = File.ReadAllText(filePath);
                var entries = new Dictionary<string, string>();
                foreach (var prop in JsonDocument.Parse(json).RootElement.EnumerateObject())
                    if (prop.Value.ValueKind == System.Text.Json.JsonValueKind.String)
                        entries[prop.Name] = prop.Value.GetString()!;
                return new JsonFile(entries, relativePath)
                {
                    Namespace = ns,
                    PolicyItem = this
                };

            case { parentDir: "lang", ext: ".lang" }:
                var content = File.ReadAllText(filePath);
                var entries2 = new Dictionary<string, string>();
                foreach (var line in content.EnumerateLines())
                {
                    var eq = line.IndexOf('=');
                    if (eq == -1) continue;
                    entries2.TryAdd(line[..eq].Trim().ToString(), line[(eq + 1)..].Trim().ToString());
                }
                return new LangFile(entries2, relativePath)
                {
                    Namespace = ns,
                    PolicyItem = this
                };

            case { parentDir: "lang" }:
            case { ext: ".txt" or ".json" or ".md" }:
                return new TextFile(File.ReadAllText(filePath), relativePath) { Namespace = ns };

            default:
                return new RawFile(filePath, relativePath) { Namespace = ns };
        }
    }
}

public record DirectPolicy : PackerPolicyItem
{
    public override IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
    {
        foreach (var domainDir in Directory.EnumerateDirectories(namespaceResource.LocalPath))
        {
            var domainName = Path.GetFileName(domainDir);
            if (config.ExclusionDomains.Contains(domainName)) continue;
            bool domainForceInclude = config.InclusionDomains.Contains(domainName);

            foreach (var file in Directory.EnumerateFiles(domainDir, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(namespaceResource.LocalPath, file).Replace('\\', '/');
                if (config.ExclusionPaths.Contains(relativePath)) continue;
                if (!domainForceInclude)
                {
                    bool inTargetLang = relativePath.Contains("zh_cn", StringComparison.OrdinalIgnoreCase);
                    if (!config.InclusionPaths.Contains(relativePath) && !inTargetLang) continue;
                }
                yield return CreateProvider(file, relativePath, namespaceResource);
            }
        }
    }
}

public record IndirectPolicy(string Source) : PackerPolicyItem
{
    public override IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
    {
        var targetDir = new DirectoryInfo(Source);
        if (!targetDir.Exists) yield break;
        var targetNs = new AssetsNamespaceResource(
            targetDir.FullName, targetDir.Name, targetDir.Parent?.Name ?? "", namespaceResource.ModVersion);
        foreach (var policy in targetNs.PackerPolicies)
            foreach (var provider in policy.CreateProviders(targetNs, config))
            {
                if (provider is ResourceFileProvider rfp)
                    rfp.Namespace = namespaceResource;
                yield return provider;
            }
    }
}

public record CompositionPolicy(string Source, string DestType) : PackerPolicyItem
{
    public override IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
    {
        if (DestType != "json")
            throw new NotSupportedException($"不支持的目标类型: {DestType}");
        var json = File.ReadAllText(Source);
        var doc = JsonDocument.Parse(json);
        var target = doc.RootElement.GetProperty("target").GetString()!;
        var entries = new List<CompositionEntry>();
        foreach (var e in doc.RootElement.GetProperty("entries").EnumerateArray())
        {
            var templates = new Dictionary<string, string>();
            foreach (var t in e.GetProperty("templates").EnumerateObject())
                templates[t.Name] = t.Value.GetString()!;
            var parameters = new List<Dictionary<string, string>>();
            foreach (var p in e.GetProperty("parameters").EnumerateArray())
            {
                var dict = new Dictionary<string, string>();
                foreach (var kv in p.EnumerateObject())
                    dict[kv.Name] = kv.Value.GetString()!;
                parameters.Add(dict);
            }
            entries.Add(new CompositionEntry(templates, parameters));
        }
        var composition = new CompositionJsonFile(target, entries)
        {
            Namespace = namespaceResource,
            PolicyItem = this
        };
        return [composition];
    }
}

public record SingletonPolicy(string Source, string RelativePath) : PackerPolicyItem
{
    public override IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
    {
        if (!File.Exists(Source))
        {
            Log.Logger.Warning("Singleton 源文件不存在: {Source}", Source);
            yield break;
        }
        yield return CreateProvider(Source, RelativePath, namespaceResource);
    }
}
