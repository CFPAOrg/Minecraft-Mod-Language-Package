namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 基于 <c>./projects/assets/{modName}/{version}/{namespace}/</c> 目录结构的模组提供者。
/// </summary>
/// <param name="fallbackVersions">回退版本列表，当主版本不存在时依次尝试</param>
public class AssetsModProvider(IEnumerable<string>? fallbackVersions = null) : INamespaceProvider
{
    private const string _assetsRoot = "./projects/assets";

    public ILookup<string, INamespaceResource> GetModsByVersion(string version)
    {
        return new ModsByVersionLookup(version, fallbackVersions);
    }

    public ILookup<string, INamespaceResource> GetVersionsByMod(string modName)
    {
        return new VersionsByModLookup(modName);
    }

    public IEnumerable<INamespaceResource> GetNamespaces(string modName, string version)
    {
        var modPath = Path.Combine(_assetsRoot, modName, version);
        if (!Directory.Exists(modPath))
        {
            if (fallbackVersions is not null)
            {
                foreach (var fb in fallbackVersions)
                {
                    var fbPath = Path.Combine(_assetsRoot, modName, fb);
                    if (Directory.Exists(fbPath))
                    {
                        Log.Logger.Debug("模组 {ModName}/{Version} 不存在，使用回退版本 {Fallback}",
                            modName, version, fb);
                        return new NamespaceGroup(fbPath, fb, modName, GroupKey.ModName);
                    }
                }
            }
            Log.Logger.Debug("模组资源不存在: {ModName}/{Version}", modName, version);
            return [];
        }
        return new NamespaceGroup(modPath, version, modName, GroupKey.ModName);
    }
}
