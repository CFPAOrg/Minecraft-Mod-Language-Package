namespace Packer.Core.Model.Configuration;

/// <summary>
/// 基础配置，版本唯一
/// </summary>
/// <param name="Version">打包的目标版本</param>
/// <param name="TargetLanguages">打包的目标语言</param>
/// <param name="McMetaTemplate">将用于生成pack.mcmeta的模板位置</param>
/// <param name="McMetaParameters">将用于生成pack.mcmeta的参数列表；会自动在前面附加一个时间戳</param>
/// <param name="ReadmeTemplate">将用于生成readme.txt的模板位置</param>
/// <param name="ReadmeParameters">将用于生成readme.txt的参数列表</param>
/// <param name="ExclusionMods">不进行打包的mod（按[cursforge-]name）</param>
/// <param name="ExclusionNamespaces">不进行打包的namespace</param>
/// <param name="FallbackVersions">回退版本列表，当该版本不存在相应命名空间时从这些版本尝试获取</param>
public record BaseConfig(
    string Version,
    string[] TargetLanguages,
    string McMetaTemplate,
    object[] McMetaParameters,
    string ReadmeTemplate,
    object[] ReadmeParameters,
    IEnumerable<string> ExclusionMods,
    IEnumerable<string> ExclusionNamespaces,
    IEnumerable<string>? FallbackVersions = null
)
{
    public IResourceFileProvider LoadMetaTemp()
    {
        var template = File.ReadAllText(McMetaTemplate);
        object[] parameters = [DateTime.UtcNow.AddHours(8), .. McMetaParameters];
        var file = new TextFile(string.Format(template, parameters), "pack.mcmeta");
        return file;
    }
    public IResourceFileProvider LoadReadmeTemp()
    {
        var template = File.ReadAllText(ReadmeTemplate);
        var file = new TextFile(string.Format(template, ReadmeParameters), "README.txt");
        return file;
    }
}
