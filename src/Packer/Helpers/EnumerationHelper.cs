using Packer.Extensions;
using Packer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Packer.Helpers
{
    internal static class EnumerationHelper
    {
        public static IEnumerable<IResourceFileProvider> EnumerateUnmerged(IEnumerable<string> targetModIdentifiers, Config config, string version)
        {
            return
                // ./projects/assets/<projectSlug>...
                from modDirectory in new DirectoryInfo("./projects/assets").EnumerateDirectories()
                let modIdentifier = modDirectory.Name
                where targetModIdentifiers.Count() == 0                             // 未提供列表，全部打包
                    || targetModIdentifiers.Contains(modIdentifier)                 // 有列表，仅打包列表中的项
                where !config.Base.ExclusionMods.Contains(modIdentifier)            // 没有被明确排除
                // .../<version>
                let versionedDirectory = modDirectory.GetDirectories(version).FirstOrDefault(defaultValue: null)
                where versionedDirectory is not null
                // .../<namespace>-CFPA-<author>
                from namespaceDirectory in versionedDirectory.EnumerateDirectories()
                let namespaceName = namespaceDirectory.Name
                where !config.Base.ExclusionNamespaces.Contains(namespaceName)      // 没有被明确排除
                where namespaceName.ValidateNamespace()                             // 不是非法名称
                // .../*
                from provider in namespaceDirectory.EnumerateProviders(config)
                select provider;
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
