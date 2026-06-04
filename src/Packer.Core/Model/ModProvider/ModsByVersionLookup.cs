namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 遍历 <c>./projects/assets/*/{version}/</c> 目录，按模组名分组。
/// </summary>
internal class ModsByVersionLookup(string version) : ILookup<string, INamespaceResource>
{
    private const string _assetsRoot = "./projects/assets";
    private Dictionary<string, NamespaceGroup> Dictionary
    {
        get
        {
            if (field is null)
            {
                if (!Directory.Exists(_assetsRoot))
                {
                    Log.Logger.Warning("资源目录不存在: {AssetsRoot}", _assetsRoot);
                    field = [];
                }
                else
                {
                    field = Directory.EnumerateDirectories(_assetsRoot)
                        .Select(dir => (
                            modName: Path.GetFileName(dir),
                            versionDir: Path.Combine(dir, version)))
                        .Where(t => Directory.Exists(t.versionDir))
                        .ToDictionary(t => t.modName,
                        t => new NamespaceGroup(t.versionDir, version, t.modName, GroupKey.ModName));
                }
            }
            return field;
        }
    }

    public IEnumerable<INamespaceResource> this[string key] => Dictionary.GetValueOrDefault(key)!.AsEnumerable() ?? [];

    public int Count => Dictionary.Count;

    public bool Contains(string key)
    {
        return Dictionary.ContainsKey(key);
    }

    public IEnumerator<IGrouping<string, INamespaceResource>> GetEnumerator()
    {
        return Dictionary.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
