using Packer.Models;
using Packer.Models.Providers;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Packer.Helpers
{
    /// <summary>
    /// 组合包 Manifest.json 的生成工具
    /// </summary>
    internal static class ManifestHelpers
    {
        private static readonly JsonSerializerOptions manifestSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        /// 生成组合包根目录的 Manifest.json 提供器
        /// </summary>
        /// <param name="config">当前版本的全局配置</param>
        /// <param name="applicableDiscriminators">已按当前目标平台过滤的命名空间区分规则</param>
        /// <param name="acceptableVersions">可接受版本（当前版本 + 回退版本），用于解析被排除模组的命名空间</param>
        /// <exception cref="InvalidDataException">同一命名空间存在多条适用规则</exception>
        public static TextFile BuildGroupedPackManifest(Config config,
            IReadOnlyCollection<NamespaceDiscriminator> applicableDiscriminators,
            IEnumerable<string> acceptableVersions)
        {
            var blackList = config.Base.ExclusionNamespaces
                .Concat(EnumerateNamespacesOfExcludedMods(config.Base.ExclusionMods, acceptableVersions))
                .Distinct()
                .OrderBy(namespaceName => namespaceName, StringComparer.Ordinal)
                .ToList();

            var rules = new Dictionary<string, string>();
            foreach (var discriminator in applicableDiscriminators
                         .OrderBy(entry => entry.Namespace, StringComparer.Ordinal))
            {
                if (!rules.TryAdd(discriminator.Namespace, discriminator.Operator))
                    throw new InvalidDataException(
                        $"Duplicate discriminator entries for namespace {discriminator.Namespace} " +
                        "matching the current pack version.");
            }

            var manifest = new GroupedPackManifest { BlackList = blackList, Rules = rules };
            var manifestContent = JsonSerializer.Serialize(manifest, manifestSerializerOptions);

            Log.Information("已生成 Manifest.json：{0} 个黑名单命名空间，{1} 条区分规则",
                            blackList.Count, rules.Count);

            return new TextFile(manifestContent, "Manifest.json");
        }

        /// <summary>
        /// 将被排除模组（CurseForge slug）解析为其在可接受版本下提供的全部命名空间。<br />
        /// 取各版本目录的并集：客户端缓存可能包含由旧包（含回退版本内容）安装的命名空间，
        /// 多删缓存是无害的空操作，漏删则会残留脏数据。
        /// </summary>
        private static IEnumerable<string> EnumerateNamespacesOfExcludedMods(
            IEnumerable<string> exclusionMods,
            IEnumerable<string> acceptableVersions)
        {
            foreach (var projectSlug in exclusionMods)
            {
                var projectDirectory = new DirectoryInfo(Path.Combine("./projects/assets", projectSlug));
                if (!projectDirectory.Exists)
                {
                    Log.Warning("被排除的模组 {0} 在 projects/assets 下不存在，跳过其黑名单解析。", projectSlug);
                    continue;
                }

                var namespaceNames = acceptableVersions
                    .SelectMany(version => projectDirectory.GetDirectories(version))
                    .SelectMany(versionedDirectory => versionedDirectory.EnumerateDirectories())
                    .Select(namespaceDirectory => namespaceDirectory.Name)
                    .Distinct()
                    .ToList();

                if (namespaceNames.Count == 0)
                    Log.Warning("被排除的模组 {0} 在可接受版本下没有任何命名空间目录。", projectSlug);

                foreach (var namespaceName in namespaceNames)
                    yield return namespaceName;
            }
        }
    }
}
