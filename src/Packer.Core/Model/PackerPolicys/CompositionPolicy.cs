namespace Packer.Core.Model.PackerPolicys;

/// <summary>
/// 组合策略。从一个组合文件中读取模板和参数，
/// 笛卡尔积展开后生成语言文件条目。
/// 适用于有大量重复格式的翻译（如颜色名、物品系列）。
/// </summary>
/// <param name="Source">组合文件的完整路径</param>
/// <param name="DestType">目标文件类型，支持 <c>"json"</c> 和 <c>"lang"</c></param>
/// <remarks>
/// 组合文件格式参见 <c>Packer-Doc.md</c> 的「组合文件」章节。
/// 组合文件本身不会被自动排除，需要在 <c>local-config.json</c> 中
/// 将组合文件的路径加入 <c>exclusionPaths</c>。
/// </remarks>
public record CompositionPolicy(string Source, string DestType) : PackerPolicyItem
{
    /// <summary>
    /// 从组合文件中读取模板和参数，笛卡尔积展开后生成语言文件条目。
    /// 组合文件本身不会被自动排除，需通过 <c>local-config.json</c> 的 <c>exclusionPaths</c> 排除。
    /// </summary>
    /// <param name="ns">当前命名空间</param>
    /// <param name="config">合并后的浮动配置，用于设置 <see cref="TextFile.EffectiveConfig"/></param>
    public IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource ns, FloatingConfig config)
    {
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

        IResourceFileProvider provider = DestType switch
        {
            "json" => new CompositionJsonFile(target, entries)
            {
                Namespace = ns,
                PolicyItem = this,
                EffectiveConfig = config
            },
            "lang" => CreateLangFile(target, entries, ns, config),
            _ => throw new NotSupportedException($"不支持的目标类型: {DestType}")
        };
        return [provider];
    }

    private CompositionLangFile CreateLangFile(string target, List<CompositionEntry> entries, INamespaceResource ns, FloatingConfig config)
    {
        return new CompositionLangFile(target, entries)
        {
            PolicyItem = this,
            EffectiveConfig = config
        };
    }
}
