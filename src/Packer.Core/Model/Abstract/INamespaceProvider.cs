namespace Packer.Core.Model.Abstract;

/// <summary>
/// 模组资源提供者。以 <see cref="ILookup{TKey, TElement}"/> 作为契约，
/// 不暴露目录树结构和中间模型。
/// </summary>
public interface INamespaceProvider
{
    /// <summary>
    /// 获取指定版本下的所有命名空间，按模组名分组。
    /// 返回的 <see cref="ILookup{TKey, TElement}"/> 是延迟的：
    /// 在 <c>SelectMany</c> 展开 <see cref="IGrouping{TKey, TElement}"/> 时才扫描对应目录。
    /// </summary>
    /// <param name="version">Minecraft 版本号</param>
    /// <returns>
    /// Key = 模组标识（如 "jei", "minecraft"）
    /// Value = 该模组在该版本下的所有命名空间
    /// </returns>
    ILookup<string, INamespaceResource> GetModsByVersion(string version);

    /// <summary>
    /// 获取指定模组的所有版本下的命名空间，按版本分组。
    /// </summary>
    /// <param name="modName">模组标识</param>
    /// <returns>
    /// Key = 版本号
    /// Value = 该模组在该版本下的所有命名空间
    /// </returns>
    ILookup<string, INamespaceResource> GetVersionsByMod(string modName);

    /// <summary>
    /// 直接获取指定模组 + 版本的命名空间枚举。
    /// 等价于 <c>GetModsByVersion(version)[modName]</c>，但不构造分组结构。
    /// </summary>
    IEnumerable<INamespaceResource> GetNamespaces(string modName, string version);
}

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
