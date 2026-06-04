using System.Text;

namespace Packer.Core.Model.ResourceFile;

public class TextFile : ResourceFileProvider
{
    public string Content { get; protected set; } = string.Empty;

    public TextFile(string content, string relativePath)
    {
        Content = content;
        RelativePath = relativePath;
    }

    protected TextFile(string relativePath): base(relativePath) { }

    public override Stream GetContentStream()
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(Content));
    }
}
