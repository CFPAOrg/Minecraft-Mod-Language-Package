using System.Text;
using System.Text.RegularExpressions;

namespace Packer.Core.Model.ResourceFile;

/// <summary>
/// .lang 格式语言文件提供器。写入时按键排序，保证输出确定性。
/// </summary>
public class LangFile : KVPFile
{
    public LangFile(Dictionary<string, string> entries, string relativePath)
        : base(entries, relativePath) { }

    /// <summary>合并另一个 .lang 语言文件</summary>
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

    /// <summary>序列化为 <c>key=value</c> 格式，按键排序，写入前执行字符替换</summary>
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
    internal static Dictionary<string, string> DeserializeFromLang(string content)
    {
        var result = new Dictionary<string, string>();
        var escapeMode = false;
        var state = LangParseState.Normal;
        string pendingKey = "";
        StringBuilder pendingValue = new StringBuilder();


        foreach (var line in content.EnumerateLines())
        {
            switch (state)
            {
                case LangParseState.LineContinuation when line.EndsWith("\\"):
                    pendingValue.Append(line.TrimStart()[..^1]);
                    continue;

                case LangParseState.LineContinuation:
                    pendingValue.Append(line.TrimStart());
                    result.TryAdd(pendingKey, pendingValue.ToString());
                    pendingValue.Clear();
                    state = LangParseState.Normal;
                    continue;

                case LangParseState.MultiLineComment when line.Trim().EndsWith("*/"):
                    state = LangParseState.Normal;
                    continue;

                case LangParseState.MultiLineComment:
                    continue;
            }

            // ── Normal 状态 ──

            switch (line)
            {
                case "#PARSE_ESCAPES":
                    escapeMode = true;
                    continue;
                case ['/', '*', ..]:
                    state = LangParseState.MultiLineComment;
                    continue;
                case ['#' or '<', ..] or ['/', '/', ..]:
                    continue;
            }



            var eq = line.IndexOf('=');
            if (eq == -1)
            {
                continue;
            }

            var key = line[..eq];
            var value = eq + 1 < line.Length ? line[(eq + 1)..] : "";

            if (escapeMode && value.EndsWith("\\"))
            {
                state = LangParseState.LineContinuation;
                pendingKey = key.ToString();
                pendingValue.Append(value[..^1]);
            }
            else
            {
                result.TryAdd(key.ToString(), value.ToString());
            }
        }

        return result;
    }

    private enum LangParseState { Normal, MultiLineComment, LineContinuation }
}
