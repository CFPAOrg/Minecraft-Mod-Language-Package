namespace Packer.Core.Model.PackerPolicys;

/// <summary>
/// 原位检索策略。直接扫描命名空间文件夹下的文件结构，
/// 按文档定义的文件容斥顺序（ExclusionDomains → ExclusionPaths
/// → InclusionPaths/InclusionDomains → targetLanguages）过滤。
/// 这是默认策略，当 <c>packer-policy.json</c> 不存在时等效于 <see cref="PackerPolicy.Shared"/>。
/// </summary>
public record DirectPolicy : PackerPolicyItem
{
    /// <summary>
    /// 原位检索命名空间目录，按文件容斥顺序过滤并产出 Provider。
    /// </summary>
    /// <param name="ns">当前命名空间</param>
    /// <param name="globalConfig">全局配置，用于读取 <c>Base.TargetLanguages</c> 等基础配置</param>
    /// <param name="mergedConfig">全局浮动配置与局域配置合并后的结果，用于 Domain/Path 过滤和字符替换</param>
    public IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource ns, Config globalConfig, FloatingConfig mergedConfig)
    {
        foreach (var domainDir in Directory.EnumerateDirectories(ns.LocalPath))
        {
            var domainName = Path.GetFileName(domainDir);
            bool domainForceInclude = mergedConfig.InclusionDomains.Contains(domainName);
            if (!domainForceInclude && mergedConfig.ExclusionDomains.Contains(domainName))
                continue;

            foreach (var file in Directory.EnumerateFiles(domainDir, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(ns.LocalPath, file).Replace('\\', '/');
                if (mergedConfig.ExclusionPaths.Contains(relativePath))
                    continue;
                if (!domainForceInclude)
                {
                    bool inTargetLang = globalConfig.Base.TargetLanguages.Any(lang =>
                        relativePath.Contains(lang, StringComparison.OrdinalIgnoreCase));
                    if (!mergedConfig.InclusionPaths.Contains(relativePath) && !inTargetLang)
                        continue;
                }
                var provider = CreateProvider(file, relativePath, ns);
                if (provider is TextFile tf)
                    tf.EffectiveConfig = mergedConfig;
                yield return provider;
            }
        }
    }
}
