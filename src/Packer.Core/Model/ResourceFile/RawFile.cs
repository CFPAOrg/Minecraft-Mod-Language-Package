using Packer.Core.Model.Abstract;

namespace Packer.Core.Model.ResourceFile;

/// <summary>二进制文件提供器。不参与合并与字符替换。</summary>
internal class RawFile(string filePath, string relativePath) : ResourceFileProvider(relativePath)
{
    /// <summary>源文件路径</summary>
    public string FilePath { get; } = filePath;

    public override Stream GetContentStream() => File.OpenRead(FilePath);
}
