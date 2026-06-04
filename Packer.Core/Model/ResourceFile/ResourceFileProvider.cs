using Packer.Core.Model.Abstract;

namespace Packer.Core.Model.ResourceFile;

public abstract class ResourceFileProvider(string relativePath) : IResourceFileProvider
{
    public INamespaceResource? Namespace { get; set; }
    public string RelativePath { get; } = relativePath.Replace('\\', '/');

    public virtual string Destination
        => string.IsNullOrEmpty(Namespace?.NamespaceName)
               ? RelativePath
               : $"assets/{Namespace.NamespaceName}/{RelativePath}";

    public abstract Stream GetContentStream();
}
