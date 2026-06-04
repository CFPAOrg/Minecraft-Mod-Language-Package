using System.Text;
using System.Text.RegularExpressions;

namespace Packer.Core.Model.ResourceFile;

public class LangFile : KVPFile
{
    public LangFile(Dictionary<string, string> entries, string relativePath)
        : base(entries, relativePath) { }

    public override KVPFile Merge(KVPFile other)
    {
        var merged = new Dictionary<string, string>(Entries);
        if (other is LangFile o)
        {
            if (o.PolicyItem?.ModifyOnly ?? false)
            {
                foreach (var e in o.Entries)
                    if (merged.ContainsKey(e.Key))
                        merged[e.Key] = e.Value;
            }
            else
            {
                foreach (var e in o.Entries)
                    merged.TryAdd(e.Key, e.Value);
            }
        }
        return new LangFile(merged, RelativePath) { PolicyItem = PolicyItem };
    }

    public override Stream GetContentStream()
    {
        var entries = Entries;
        if (EffectiveConfig is not null)
        {
            entries = new Dictionary<string, string>(Entries.Count);
            foreach (var kv in Entries)
            {
                var replaced = kv.Value;
                foreach (var rep in EffectiveConfig.CharacterReplacement)
                    replaced = Regex.Replace(replaced, rep.Key, rep.Value);
                entries[kv.Key] = replaced;
            }
        }

        var sb = new StringBuilder();
        foreach (var kv in new SortedDictionary<string, string>(entries))
        {
            sb.Append(kv.Key);
            sb.Append('=');
            sb.AppendLine(kv.Value);
        }
        return new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
    }
}
