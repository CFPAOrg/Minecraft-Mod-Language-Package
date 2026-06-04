using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;

namespace Packer.Core.Model.ModProvider;

/// <summary>
/// 基于 <c>./projects/assets</c> 目录的命名空间资源。
/// </summary>
/// <param name="LocalPath">文件系统上的完整路径</param>
/// <param name="NamespaceName">命名空间名称</param>
/// <param name="ModName">所属模组标识</param>
/// <param name="ModVersion">目标 Minecraft 版本</param>
public record AssetsNamespaceResource(
    string LocalPath,
    string NamespaceName,
    string ModName,
    string ModVersion
) : INamespaceResource
{
    public FloatingConfig LocalConfig => field ??= FloatingConfig.Load(this);

    public PackerPolicy PackerPolicies => field ??= PackerPolicy.Load(this);

    public IEnumerable<IResourceFileProvider> FileProviders => field ??= PackerPolicies.CreateProviders(this, LocalConfig);
}
