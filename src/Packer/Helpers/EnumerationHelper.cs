using Packer.Extensions;
using Packer.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Packer.Helpers
{
    internal static class EnumerationHelper
    {
        public static IEnumerable<IResourceFileProvider> EnumerateUnmerged(IEnumerable<string> targetModIdentifiers,
                                                                           Config config,
                                                                           IEnumerable<string> acceptableVersions,
                                                                           IReadOnlyCollection<NamespaceDiscriminator>? namespaceDiscriminators = null)
        {
            return
                // ./projects/assets/<projectSlug>...
                from modDirectory in new DirectoryInfo("./projects/assets").EnumerateDirectories()
                let modIdentifier = modDirectory.Name
                where targetModIdentifiers.Count() == 0                             // 未提供列表，全部打包
                    || targetModIdentifiers.Contains(modIdentifier)                 // 有列表，仅打包列表中的项
                where !config.Base.ExclusionMods.Contains(modIdentifier)            // 没有被明确排除
                // .../<version>
                // 在此只选择可选版本中最新的一个，其他的不参与打包
                let versionedDirectory = acceptableVersions.Select(version => modDirectory.GetDirectories(version).FirstOrDefault())
                                                           .FirstOrDefault(_ => _ is not null)
                where versionedDirectory is not null
                // .../<namespace>
                from namespaceDirectory in versionedDirectory.EnumerateDirectories()
                let namespaceName = namespaceDirectory.Name
                where !config.Base.ExclusionNamespaces.Contains(namespaceName)      // 没有被明确排除
                where namespaceName.ValidateNamespace()                             // 不是非法名称
                // 命名空间区分：若命中规则，将 assets/<namespace>/ 改写为 assets/<namespace>-CFPA-<区分名>/
                let discriminatedNamespaceName = ResolveDiscriminatedNamespaceName(namespaceDiscriminators,
                                                                                   namespaceName,
                                                                                   modIdentifier)
                // .../*
                from provider in namespaceDirectory.EnumerateProviders(config)
                select discriminatedNamespaceName is null
                    ? provider
                    : provider.ReplaceDestination($"^assets/{Regex.Escape(namespaceName)}(?=/)",
                                                  $"assets/{discriminatedNamespaceName.Replace("$", "$$")}");
        }

        /// <summary>
        /// 解析（命名空间, 项目）应使用的区分后名称。传入的规则应已按当前打包平台过滤。
        /// </summary>
        /// <param name="namespaceDiscriminators">适用于当前平台的命名空间区分规则</param>
        /// <param name="namespaceName">原始命名空间</param>
        /// <param name="modIdentifier">CurseForge 项目 slug</param>
        /// <returns>命中规则时返回 <c>&lt;namespace&gt;-CFPA-&lt;区分名&gt;</c>；否则返回 <see langword="null"/>（保持原名）</returns>
        private static string? ResolveDiscriminatedNamespaceName(IReadOnlyCollection<NamespaceDiscriminator>? namespaceDiscriminators,
                                                                 string namespaceName,
                                                                 string modIdentifier)
        {
            var matchedDiscriminator = namespaceDiscriminators?
                .FirstOrDefault(entry => entry.Namespace == namespaceName);
            if (matchedDiscriminator is null) return null;

            if (!matchedDiscriminator.MappingRule.TryGetValue(modIdentifier, out var discriminatedName))
            {
                Log.Warning("命名空间 {0}（项目 {1}）命中了区分规则，但 mappingRule 未包含该项目；保留原始命名空间。",
                            namespaceName, modIdentifier);
                return null;
            }
            return $"{namespaceName}-CFPA-{discriminatedName}";
        }

        public static IEnumerable<IResourceFileProvider> PostProcess(this IEnumerable<IResourceFileProvider> providers, Config config)
        {
            return 
                from provider in providers
                select config.Floating.CharacterReplacement                         // 内容的字符替换
                             .Aggregate(seed: provider,
                                        (accumulate, replacement)
                                            => accumulate.ReplaceContent(
                                                replacement.Key,
                                                replacement.Value)) into provider
                select config.Floating.DestinationReplacement                       // 全局路径替换：预留
                             .Aggregate(seed: provider,
                                        (accumulate, replacement)
                                            => accumulate.ReplaceDestination(
                                                replacement.Key,
                                                replacement.Value));
        }

        public static IEnumerable<IResourceFileProvider> MergeDeep(this IEnumerable<IResourceFileProvider> providers)
        {
            return
                from provider in providers
                group provider by provider.Destination into destinationGroup
                select destinationGroup
                    .Aggregate(seed: null as IResourceFileProvider,                 // 合并文件
                               (accumulate, next)
                                   => next.ApplyTo(
                                       accumulate));
        }

        public static IEnumerable<IResourceFileProvider> MergeShallow(this IEnumerable<IResourceFileProvider> providers)
        {
            return from provider in providers
                   group provider by provider.Destination into destinationGroup
                   select destinationGroup.First();
        }
    }
}
