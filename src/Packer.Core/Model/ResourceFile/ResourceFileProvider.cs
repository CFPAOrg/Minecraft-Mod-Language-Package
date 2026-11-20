namespace Packer.Core.Model.ResourceFile;

/// <summary>
/// 资源文件提供器基类。持有命名空间引用和相对路径，自动拼接目标路径。
/// </summary>
/// <param name="relativePath">相对于命名空间的路径（如 <c>lang/zh_cn.json</c>）</param>
public abstract class ResourceFileProvider(string relativePath) : IResourceFileProvider
{
    /// <summary>所属命名空间，用于拼接 <see cref="Destination"/></summary>
    public INamespaceResource? Namespace { get; set; }

    /// <summary>相对路径，构造时统一为 <c>/</c> 分隔符</summary>
    public string RelativePath { get; } = relativePath.Replace('\\', '/');

    /// <summary>资源包内的完整目标路径</summary>
    public virtual string Destination
        => string.IsNullOrEmpty(Namespace?.NamespaceName)
               ? RelativePath
               : $"assets/{Namespace.NamespaceName}/{RelativePath}";

    /// <summary>获取文件内容流</summary>
    public abstract Stream GetContentStream();
}
