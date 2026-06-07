namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 基于 <c>./projects/assets/{modName}/{version}/{namespace}/</c> 目录结构的模组提供者。
/// </summary>
public class AssetsModProvider : INamespaceProvider
{
    private const string _assetsRoot = "./projects/assets";

    public ILookup<string, INamespaceResource> GetModsByVersion(string version)
    {
        return new ModsByVersionLookup(version);
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
            Log.Logger.Debug("模组资源不存在: {ModName}/{Version}", modName, version);
            return [];
        }
        return new NamespaceGroup(modPath, version, modName, GroupKey.ModName);
    }
}
