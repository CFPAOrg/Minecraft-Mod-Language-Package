namespace Packer.Core.Model.ResourceFile;

public class TextFile : ResourceFileProvider
{
    public string Content { get; protected set; } = string.Empty;

    /// <summary>生效的浮动配置，<see cref="GetContentStream"/> 写入前根据此配置做字符替换。</summary>
    public FloatingConfig? EffectiveConfig { get; set; }

    /// <summary>创建此 provider 的策略项，合并时读取 <c>Append</c></summary>
    public PackerPolicyItem? PolicyItem { get; set; }

    public TextFile(string content, string relativePath)
        : base(relativePath)
    {
        Content = content;
    }

    protected TextFile(string relativePath)
        : base(relativePath) { }

    /// <summary>与另一个 TextFile 合并。</summary>
    public virtual TextFile Merge(TextFile other)
    {
        if (this is KVPFile selfKvp && other is KVPFile otherKvp)
            return selfKvp.Merge(otherKvp);
        return other.PolicyItem?.Append == true
            ? new TextFile(string.Concat(Content, Environment.NewLine, other.Content), RelativePath)
            : this;
    }

    public override Stream GetContentStream()
    {
        var text = Content;
        if (EffectiveConfig is not null)
        {
            foreach (var (pattern, replacement) in EffectiveConfig.CharacterReplacement)
                text = Regex.Replace(text, pattern, replacement);
        }
        return new MemoryStream(Encoding.UTF8.GetBytes(text));
    }
}
