using Packer.Core.Model;
using Packer.Core.Model.Abstract;

namespace Packer.Core.Model.ResourceFile;

internal class RawFile(string filePath, string relativePath) : ResourceFileProvider(relativePath)
{
    public string FilePath { get; } = filePath;

    public override Stream GetContentStream()
    {
        return File.OpenRead(FilePath);
    }
}