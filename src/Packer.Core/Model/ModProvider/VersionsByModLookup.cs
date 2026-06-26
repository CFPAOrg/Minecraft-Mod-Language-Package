namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 遍历 <c>./projects/assets/{modName}/*/</c> 目录，按版本分组。
/// </summary>
internal class VersionsByModLookup(string modName) : ILookup<string, INamespaceResource>
{
    private const string _assetsRoot = "./projects/assets";

    private Dictionary<string, NamespaceGroup> Dictionary
    {
        get
        {
            if (field is null)
            {
                var modPath = Path.Combine(_assetsRoot, modName);
                if (!Directory.Exists(modPath))
                {
                    Log.Logger.Debug("模组目录不存在: {ModPath}", modPath);
                    field = [];
                }
                else
                {
                    field = Directory.EnumerateDirectories(modPath)
                        .Select(vec => new NamespaceGroup(
                            vec, Path.GetFileName(vec), modName, GroupKey.Version))
                        .ToDictionary(g => g.Version, g => g);
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
