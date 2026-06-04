using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.ResourceFile;

namespace Packer.Core.Model;

/// <summary>
/// 打包策略集合。对 JSON 数组 <c>[{ "type": "..." }, ...]</c> 的封装。
/// </summary>
public sealed class PackerPolicy : IEnumerable<PackerPolicyItem>
{
    private readonly List<PackerPolicyItem> _items = new();

    /// <summary>文件路径在 <c>{模组目录}/{版本}/{命名空间}/packer-policy.json</c> 下</summary>
    public const string DefaultFileName = "packer-policy.json";

    /// <summary>默认策略：单条 DirectPolicy</summary>
    public static PackerPolicy Shared { get; } = [new DirectPolicy()];

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Add(PackerPolicyItem item) => _items.Add(item);

    public static PackerPolicy Load(string namespaceDirPath)
    {
        var policyFile = Path.Combine(namespaceDirPath, DefaultFileName);
        if (!File.Exists(policyFile))
            return Shared;

        try
        {
            var policies = JsonSerializer.Deserialize<PackerPolicy>(
                File.ReadAllText(policyFile), SourceGenerationContext.Options);
            if (policies is null || policies._items.Count == 0)
                return Shared;

            Log.Logger.Debug("加载打包策略: {PolicyFile}, 策略数: {Count}", policyFile, policies._items.Count);
            return policies;
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, "加载打包策略失败: {PolicyFile}", policyFile);
            return Shared;
        }
    }

    public static PackerPolicy Load(INamespaceResource ns) => Load(ns.LocalPath);

    public IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
        => _items.SelectMany(item => item.CreateProviders(namespaceResource, config));

    public IEnumerator<PackerPolicyItem> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
}


/// <summary>
/// 打包策略基类。每个策略定义了一种从源文件到资源包产物的映射方式。
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DirectPolicy), "direct")]
[JsonDerivedType(typeof(IndirectPolicy), "indirect")]
[JsonDerivedType(typeof(CompositionPolicy), "composition")]
[JsonDerivedType(typeof(SingletonPolicy), "singleton")]
public abstract record PackerPolicyItem
{
    /// <summary>合并选项：只修改已有键（仅对 <c>TermMappingProvider</c> 生效）</summary>
    public bool ModifyOnly { get; init; }
    /// <summary>合并选项：追加内容（仅对 <c>TextFile</c> 生效）</summary>
    public bool Append { get; init; }

    /// <summary>为指定命名空间生成资源文件提供器。</summary>
    public abstract IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config);
}


/// <summary>
/// 直接扫描当前命名空间的目录树，按浮动配置中的过滤规则筛选文件并打包。
/// 扫描以第一级子目录（domain）为粒度：先检查 domain 排除/包含，再在 domain 内逐文件检查路径排除和目标语言。
/// <code>
/// lang/zh_cn.json         ← domain = "lang"，检查目标语言 "zh_cn"
/// textures/block/stone.png ← domain = "textures"，在 inclusionDomains 中 → 无条件进包
/// </code>
/// </summary>
public record DirectPolicy : PackerPolicyItem
{
    public override IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
    {
        foreach (var domainDir in Directory.EnumerateDirectories(namespaceResource.LocalPath))
        {
            var domainName = Path.GetFileName(domainDir);

            if (config.ExclusionDomains.Contains(domainName))
                continue;

            bool domainForceInclude = config.InclusionDomains.Contains(domainName);

            foreach (var file in Directory.EnumerateFiles(domainDir, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(namespaceResource.LocalPath, file);

                if (config.ExclusionPaths.Contains(relativePath))
                    continue;

                if (!domainForceInclude)
                {
                    bool inTargetLanguage = relativePath.Contains("zh_cn", StringComparison.OrdinalIgnoreCase);
                    if (!config.InclusionPaths.Contains(relativePath) && !inTargetLanguage)
                        continue;
                }

                yield return new RawFile(file, relativePath)
                {
                    Namespace = namespaceResource
                };
            }
        }
    }
}


/// <summary>
/// 间接引用另一个目录的打包结果。
///
/// 在目标目录位置构造一个命名空间，读取该目录的 packer-policy.json 和 local-config.json，
/// 但执行策略时传入的是当前命名空间。产出的 Provider 其 Namespace 直接就是当前命名空间。
/// </summary>
/// <param name="Source">目标目录路径</param>
public record IndirectPolicy(string Source) : PackerPolicyItem
{
    public override IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
    {
        var targetDir = new DirectoryInfo(Source);
        if (!targetDir.Exists)
            yield break;

        var targetNs = new AssetsNamespaceResource(
            targetDir.FullName, targetDir.Name, targetDir.Parent?.Name ?? "", namespaceResource.ModVersion);

        foreach (var policy in targetNs.PackerPolicies)
        {
            foreach (var provider in policy.CreateProviders(namespaceResource, config))
            {
                yield return provider;
            }
        }
    }
}


/// <summary>
/// 组合生成：通过模板与参数的笛卡尔积批量生成语言文件条目。
///
/// parameters 数组的第 n 个字典提供模板中 {n} 的值——Key 填入 Key 模板，Value 填入 Value 模板。
/// 多个参数字典之间做笛卡尔积。
///</summary>
///<remarks>
/// 单参数示例（英→中映射）：
/// <code>
/// {
///   "target": "lang/zh_cn.json",
///   "entries": [{
///     "templates": { "item.{0}.name": "{0}" },
///     "parameters": [{ "apple": "苹果", "banana": "香蕉" }]
///   }]
/// }
/// </code>
/// 生成 <c>item.apple.name = 苹果</c>、<c>item.banana.name = 香蕉</c>。
///
/// 多参数示例（笛卡尔积）：
/// <code>
/// {
///   "target": "lang/zh_cn.json",
///   "entries": [{
///     "templates": { "item.{0}{1}{2}.name": "{0}{1}{2}" },
///     "parameters": [
///       { "apple": "苹果", "banana": "香蕉", "pear": "梨" },
///       { ".long": "长", ".short": "短", "": "" },
///       { ".sword": "剑", ".pickaxe": "镐" }
///     ]
///   }]
/// }
/// </code>
/// 3 × 3 × 2 = 18 条记录。如 (apple, .long, .sword) → <c>item.apple.long.sword.name = 苹果长剑</c>。
/// </remarks>
public record CompositionPolicy(string Source, string DestType) : PackerPolicyItem
{
    public override IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource namespaceResource, FloatingConfig config)
    {
        if (DestType != "json")
            throw new NotSupportedException($"不支持的目标类型: {DestType}");

        var composition = JsonSerializer.Deserialize<CompositionJsonFile>(
            File.ReadAllText(Source), SourceGenerationContext.Options);
        if (composition == null)
        {
            Log.Logger.Warning("Composition 文件不存在: {Source}", Source);
            return [];
        }

        composition.Namespace = namespaceResource;
        composition.PolicyItem = this;
        return [composition];
    }
}


/// <summary>
/// 单个文件重定向：将一个源文件复制到资源包内的指定路径。
/// 不过滤，不检查浮动配置中的排除规则。
/// </summary>
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

        yield return new RawFile(Source, RelativePath)
        {
            Namespace = namespaceResource
        };
    }
}
