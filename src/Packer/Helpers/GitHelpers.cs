using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibGit2Sharp;
using Serilog;

namespace Packer.Helpers
{
    /// <summary>
    /// Git操作相关的工具类
    /// </summary>
    public static class GitHelpers
    {
        /// <summary>
        /// 枚举相对与主分支<c>main</c>，给定版本下有更改的模组。
        /// </summary>
        public static IEnumerable<string> EnumerateChangedMods(string version)
        {
            Log.Information("对版本 {0} 加载更改模组", version);
            using var repo = new Repository(".");
            var headTree = repo.Head.Tip.Tree;
            var baseTree = repo.Branches["main"].Tip.Tree;
            var changedFiles = repo.Diff.Compare<TreeChanges>(baseTree, headTree);
            var query = from change in changedFiles
                        from path in new List<string> { change.Path, change.OldPath }
                        where path.IsInTargetVersion(version)
                        select path.ExtractModIdentifier(version);
            var result = query.Distinct();
            Log.Information("更改模组列表：{0}", result);
            return result;
        }

        internal static bool IsInTargetVersion(this string location, string version)
            => location.StartsWith($"projects/{version}/assets");

        internal static string ExtractModIdentifier(this string location, string version)
            => Path.GetRelativePath($"projects/{version}/assets", location)
                   .Split(Path.DirectorySeparatorChar)[0];
        
    }
}
