using System.Text;

namespace Packer.Core.Model.ResourceFile;

public class LangFile : KVPFile
{
    public LangFile(Dictionary<string, string> entries, string relativePath)
        : base(entries, relativePath) { }

    public override KVPFile Merge(KVPFile other)
    {
        var merged = new Dictionary<string, string>(Entries);
        if (other is LangFile otherLang)
        {
            bool modifyOnly = other.PolicyItem?.ModifyOnly ?? false;
            if (modifyOnly)
            {
                foreach (var (key, value) in otherLang.Entries)
                    if (merged.ContainsKey(key)) merged[key] = value;
            }
            else
            {
                foreach (var (key, value) in otherLang.Entries)
                    merged.TryAdd(key, value);
            }
        }
        return new LangFile(merged, RelativePath) { PolicyItem = PolicyItem };
    }

    public override Stream GetContentStream()
    {
        var sb = new StringBuilder();
        foreach (var (key, value) in Entries)
        {
            sb.Append(key);
            sb.Append('=');
            sb.AppendLine(value);
        }
        return new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
    }
}
