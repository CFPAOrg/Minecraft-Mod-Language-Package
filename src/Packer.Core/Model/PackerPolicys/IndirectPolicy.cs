namespace Packer.Core.Model.PackerPolicys;

/// <summary>
/// 引用策略。将另一个命名空间的所有文件引用到当前命名空间下。
/// 被引用的文件的目标路径中的命名空间会被自动替换为当前命名空间。
/// 支持递归：被引用的命名空间若有自己的 <c>packer-policy.json</c> 也会被执行。
/// </summary>
/// <param name="Source">被引用命名空间文件夹的完整路径</param>
/// <remarks>
/// 典型用途：多版本同模组复用翻译文件。
/// 示例：<c>{ "type": "indirect", "source": "projects/assets/jei/1.20/jei" }</c>
/// </remarks>
public record IndirectPolicy(string Source) : PackerPolicyItem
{
    /// <summary>
    /// 引用目标命名空间的所有文件，将其 <see cref="ResourceFileProvider.Namespace"/> 改写为当前命名空间。
    /// 被引用目录的 <c>packer-policy.json</c> 会递归生效。
    /// </summary>
    /// <param name="ns">当前命名空间（引用发起方），产出的文件路径会将命名空间改写为此值</param>
    /// <param name="globalConfig">全局配置（未合并局域配置），传递给目标的 <see cref="PackerPolicy"/> 由其自行合并</param>
    public IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource ns, Config globalConfig)
    {
        var targetDir = new DirectoryInfo(Source);
        if (!targetDir.Exists)
        {
            return Array.Empty<IResourceFileProvider>();
        }
        var targetNs = new AssetsNamespaceResource(targetDir.FullName, targetDir.Name, targetDir.Parent?.Name ?? "", ns.ModVersion);
        return targetNs.PackerPolicies.CreateProviders(targetNs, globalConfig)
                 .Select(policy =>
                 {
                     if (policy is ResourceFileProvider rfp)
                     {
                         rfp.Namespace = ns;
                     }
                     return policy;
                 });
    }
}
