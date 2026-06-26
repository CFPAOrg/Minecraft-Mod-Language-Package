namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 遍历 <c>./projects/assets/*/{version}/</c> 目录，按模组名分组。
/// 如果指定了 <paramref name="fallbackVersions"/>，当模组在目标版本下不存在时，
/// 依次尝试回退版本，取第一个存在的版本。
/// </summary>
internal class ModsByVersionLookup(
    string version,
    IEnumerable<string>? fallbackVersions = null
) : ILookup<string, INamespaceResource>
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
                    var versionChain = new List<string> { version };
                    if (fallbackVersions is not null)
                        versionChain.AddRange(fallbackVersions);

                    field = Directory.EnumerateDirectories(_assetsRoot)
                        .Select(modDir =>
                        {
                            var modName = Path.GetFileName(modDir);
                            foreach (var v in versionChain)
                            {
                                var versionDir = Path.Combine(modDir, v);
                                if (Directory.Exists(versionDir))
                                    return (modName,
                                        foundVersion: v,
                                        versionDir: versionDir,
                                        found: true);
                            }
                            return (modName,
                                foundVersion: "",
                                versionDir: "",
                                found: false);
                        })
                        .Where(t => t.found)
                        .ToDictionary(
                            t => t.modName,
                            t => new NamespaceGroup(
                                t.versionDir, t.foundVersion, t.modName, GroupKey.ModName));
                }
            }
            return field;
        }
    }

    public IEnumerable<INamespaceResource> this[string key] =>
        Dictionary.GetValueOrDefault(key)?.AsEnumerable() ?? [];

    public int Count => Dictionary.Count;

    public bool Contains(string key) => Dictionary.ContainsKey(key);

    public IEnumerator<IGrouping<string, INamespaceResource>> GetEnumerator() =>
        Dictionary.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
