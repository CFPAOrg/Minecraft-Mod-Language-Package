using Packer.Core.Model.Abstract;

namespace Packer.Core.Model.ResourceFile;

public abstract class ResourceFileProvider : IResourceFileProvider
{
    public ResourceFileProvider() { }
    public ResourceFileProvider(string relativePath)
    {
        RelativePath = relativePath;
    }

    public INamespaceResource? Namespace { get; set; }

    public string RelativePath { get; protected set; } = string.Empty;

    public string Destination
        => string.IsNullOrEmpty(Namespace?.NamespaceName)
               ? RelativePath
               : Path.Combine("assets", Namespace.NamespaceName, RelativePath);

    public abstract Stream GetContentStream();
}
