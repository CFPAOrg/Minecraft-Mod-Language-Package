namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 基于 git diff 的增量命名空间提供器。
/// 只产出相对于 <c>origin/main</c> 有变更的命名空间。
/// </summary>
public class GitChangedModProvider : INamespaceProvider
{
    private const string _assetsRoot = "./projects/assets";

    public ILookup<string, INamespaceResource> GetModsByVersion(string version)
    {
        return GetChangedNamespaces()
                .Where(ns => ns.ModVersion == version)
                .Cast<INamespaceResource>()
                .ToLookup(ns => ns.ModName);
    }

    public ILookup<string, INamespaceResource> GetVersionsByMod(string modName)
    {
        return GetChangedNamespaces()
                .Where(ns => ns.ModName == modName)
                .Cast<INamespaceResource>()
                .ToLookup(ns => ns.ModVersion);
    }

    public IEnumerable<INamespaceResource> GetNamespaces(string modName, string version)
    {
        return GetChangedNamespaces()
                .Where(ns => ns.ModName == modName && ns.ModVersion == version)
                .Cast<INamespaceResource>();
    }

    /// <summary>
    /// 枚举 origin/main 与当前 HEAD 之间，有变更的命名空间资源。
    /// 路径结构：<c>projects/assets/{mod}/{version}/{ns}/...</c>
    /// </summary>
    private static IEnumerable<AssetsNamespaceResource> GetChangedNamespaces()
    {
        using var repo = new Repository(".");
        var headTree = repo.Head.Tip?.Tree;
        var baseTree = repo.Branches["origin/main"]?.Tip?.Tree;
        if (headTree is null || baseTree is null)
        {
            return Array.Empty<AssetsNamespaceResource>();
        }

        var seen = new HashSet<AssetsNamespaceResource>();

        foreach (var change in repo.Diff.Compare<TreeChanges>(baseTree, headTree))
        {
            foreach (var path in new[] { change.Path, change.OldPath })
            {
                var segments = path.Split(['\\', '/']);
                if (segments is ["projects", "assets", var mod, var ver, var ns, ..])
                {
                    var dir = Path.Combine(_assetsRoot, mod, ver, ns);
                    if (!Directory.Exists(dir))
                        continue;
                    seen.Add(new AssetsNamespaceResource(dir, ns, mod, ver));
                }
            }
        }

        return seen;
    }
}
