namespace Packer.Core.Model.Abstract;

/// <summary>
/// 表示可以被添加到资源包中的内容
/// </summary>
public interface IResourceFileProvider
{
    /// <summary>
    /// 目标在资源包中的相对位置
    /// </summary>
    string Destination => string.IsNullOrEmpty(Namespace?.NamespaceName)
        ? RelativePath
        : Path.Combine("assets", Namespace.NamespaceName, RelativePath);

    /// <summary>
    /// 命名空间
    /// </summary>
    /// <remarks>若无，<see cref="Destination"/>生成的路径不会携带"assets"</remarks>
    INamespaceResource? Namespace { get; }

    /// <summary>
    /// 相对于命名空间的路径（如 "lang/zh_cn.json"）。若没有命名空间，则相对于根目录的路径
    /// </summary>
    string RelativePath { get; }
    // <summary>
    /// 获取文件内容流
    /// </summary>
    /// <returns>内容流，调用者负责释放</returns>
    Stream GetContentStream();
}
