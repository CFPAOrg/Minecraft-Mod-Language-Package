using Packer.Core.Model.Abstract;
using System.Collections;

namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 命名空间分组。实现 <see cref="IGrouping{TKey, TElement}"/>，
/// 延迟枚举第一级子目录下所有 <see cref="AssetsNamespaceResource"/>。
/// Key 由 <see cref="GroupKey"/> 决定是模组名还是版本名。
/// </summary>
class NamespaceGroup(
    string localPath,
    string version,
    string modName,
    GroupKey groupKey
) : IGrouping<string, INamespaceResource>, IReadOnlyCollection<INamespaceResource>
{
    /// <summary>命名空间在磁盘上的路径</summary>
    public string LocalPath { get; } = localPath;

    /// <summary>Minecraft 版本</summary>
    public string Version { get; } = version;

    /// <summary>所属模组</summary>
    public string ModName { get; } = modName;

    /// <summary>延迟加载：首次访问时扫描 <see cref="LocalPath"/> 下的子目录</summary>
    INamespaceResource[] NamespaceResource => field ??= Directory.EnumerateDirectories(LocalPath)
        .Select(dir => new AssetsNamespaceResource(dir, Path.GetFileName(dir), ModName, Version))
        .ToArray();

    string IGrouping<string, INamespaceResource>.Key { get; } = groupKey switch
    {
        GroupKey.ModName => modName,
        GroupKey.Version => version,
        _ => throw new ArgumentOutOfRangeException(nameof(groupKey), groupKey, $"Unsupported group key: {groupKey}")
    };

    /// <summary>命名空间数量（触发懒加载）</summary>
    public int Count => NamespaceResource.Length;

    public IEnumerator<INamespaceResource> GetEnumerator()
        => NamespaceResource.AsEnumerable().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>指定 <see cref="NamespaceGroup"/> 的 Key 使用哪个字段</summary>
enum GroupKey
{
    /// <summary>Key = 模组名</summary>
    ModName,
    /// <summary>Key = 版本号</summary>
    Version
}
