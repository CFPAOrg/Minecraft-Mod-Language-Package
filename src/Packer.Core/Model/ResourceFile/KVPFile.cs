namespace Packer.Core.Model.ResourceFile;

/// <summary>
/// 键值对文件提供器基类。用于语言文件等由 Key → Value 映射组成的文件。
/// 支持合并：<c>TryAdd</c>（先到先得）/ <c>ModifyOnly</c>（只覆盖已有键）。
/// </summary>
public abstract class KVPFile : TextFile
{
    /// <summary>键值对条目</summary>
    public Dictionary<string, string> Entries { get; protected set; } = [];

    /// <param name="relativePath">在资源包中的相对路径</param>
    protected KVPFile(string relativePath) : base(relativePath)
    {
    }

    /// <summary>
    /// 从已有字典构造。
    /// </summary>
    protected KVPFile(Dictionary<string, string> entries, string relativePath)
        : this(relativePath)
    {
        Entries = entries;
    }

    /// <summary>
    /// 与另一个 KVPFile 合并，返回新实例。
    /// </summary>
    public abstract KVPFile Merge(KVPFile other);
}
