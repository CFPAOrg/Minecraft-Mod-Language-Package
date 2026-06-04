using Packer.Core.Model.Abstract;
using System.Collections;

namespace Packer.Core.Model.ModProvider;

class NamespaceGroup(
    string localPath,
    string version,
    string modName,
    GroupKey groupKey
) : IGrouping<string, INamespaceResource>, IReadOnlyCollection<INamespaceResource>
{
    public string LocalPath { get; } = localPath;
    public string Version { get; } = version;
    public string ModName { get; } = modName;
    INamespaceResource[] NamespaceResource => field ??= Directory.EnumerateDirectories(LocalPath)
                    .Select(dir => new AssetsNamespaceResource(dir, Path.GetFileName(dir), ModName, Version))
                    .ToArray();

    string IGrouping<string, INamespaceResource>.Key { get; } = groupKey switch
    {
        GroupKey.ModName => modName,
        GroupKey.Version => version,
        _ => throw new ArgumentOutOfRangeException(nameof(groupKey), groupKey, $"Unsupported group key: {groupKey}")
    };
    public int Count => NamespaceResource.Length;

    public IEnumerator<INamespaceResource> GetEnumerator()
    {
        return NamespaceResource.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

enum GroupKey
{
    ModName,
    Version
}
