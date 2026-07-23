namespace Packer.Core.Model.Configuration;

/// <summary>
/// 浮动配置，可与命名空间下的文件合并
/// </summary>
/// <param name="InclusionDomains">强制包含的domain</param>
/// <param name="ExclusionDomains">强制排除的domain</param>
/// <param name="InclusionPaths">强制包含的路径</param>
/// <param name="ExclusionPaths">强制排除的路径</param>
/// <param name="CharacterReplacement">文本字符替换表</param>
/// <param name="DestinationReplacement">目标地址替换表</param>
public record FloatingConfig(
    IEnumerable<string> InclusionDomains,
    IEnumerable<string> ExclusionDomains,
    IEnumerable<string> InclusionPaths,
    IEnumerable<string> ExclusionPaths,
    IReadOnlyDictionary<string, string> CharacterReplacement,
    IReadOnlyDictionary<string, string> DestinationReplacement
)
{
    /// <remarks>在命名空间文件夹中，叫<c>local-config.json</c>的文件</remarks>
    public const string DefaultFileName = "local-config.json";
    public static FloatingConfig Shared { get; } = new FloatingConfig(
        Array.Empty<string>(),
        Array.Empty<string>(),
        Array.Empty<string>(),
        Array.Empty<string>(),
        new Dictionary<string, string>(),
        new Dictionary<string, string>()
        );

    /// <summary>
    /// 从目录加载局域配置。文件不存在或解析失败时返回 <see cref="Shared"/>。
    /// </summary>
    public static FloatingConfig Load(string directoryPath)
    {
        var configFile = Path.Combine(directoryPath, DefaultFileName);
        if (!File.Exists(configFile))
        {
            return Shared;
        }

        try
        {
            var json = File.ReadAllText(configFile);
            var config = JsonSerializer.Deserialize<FloatingConfig>(json, SourceGenerationContext.JsonOptions)!;
            Log.Logger.Debug("加载局部配置: {ConfigFile}", configFile);
            return config;
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, "加载局部配置失败: {ConfigFile}", configFile);
            return Shared;
        }
    }

    /// <summary>
    /// 从命名空间资源加载局域配置。
    /// </summary>
    public static FloatingConfig Load(INamespaceResource ns)
    {
        return Load(ns.LocalPath);
    }

    /// <summary>
    /// 从另一对象合并配置
    /// </summary>
    public FloatingConfig Merge(FloatingConfig? other)
    {

        if ((other ??= Shared) == Shared)
        {
            return this;
        }
        if (this == Shared)
        {
            return other;
        }

        return new FloatingConfig(
            InclusionDomains: InclusionDomains.Union(other.InclusionDomains).ToFrozenSet(),
            ExclusionDomains: ExclusionDomains.Union(other.ExclusionDomains).ToFrozenSet(),
            InclusionPaths: InclusionPaths.Union(other.InclusionPaths).ToFrozenSet(),
            ExclusionPaths: ExclusionPaths.Union(other.ExclusionPaths).ToFrozenSet(),
            CharacterReplacement: CharacterReplacement.Concat(other.CharacterReplacement)
                .DistinctBy(kv => kv.Key)
                .ToFrozenDictionary(),
            DestinationReplacement: DestinationReplacement.Concat(other.DestinationReplacement)
                .DistinctBy(kv => kv.Key)
                .ToFrozenDictionary()
        );
    }
}
