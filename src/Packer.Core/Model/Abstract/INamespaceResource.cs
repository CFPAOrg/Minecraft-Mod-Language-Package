namespace Packer.Core.Model.Abstract;

/// <summary>
/// 命名空间资源。是资源包产出物的基本单元。
/// </summary>
public interface INamespaceResource
{
    /// <summary>所属模组标识（如 "jei", "minecraft"）</summary>
    string ModName { get; }

    /// <summary>命名空间名称（如 "minecraft", "cfpa"）</summary>
    string NamespaceName { get; }

    /// <summary>目标 Minecraft 版本（如 "1.21"）</summary>
    string ModVersion { get; }

    /// <summary>文件系统上的完整路径</summary>
    string LocalPath { get; }

    /// <summary>命名空间下的局域浮动配置（local-config.json），无则为 <see cref="FloatingConfig.Shared"/></summary>
    FloatingConfig LocalConfig { get; }

    /// <summary>打包策略集合，无则为 <see cref="PackerPolicy.Shared"/></summary>
    PackerPolicy PackerPolicies { get; }

}
