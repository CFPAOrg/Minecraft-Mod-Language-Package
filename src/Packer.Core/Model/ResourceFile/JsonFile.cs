namespace Packer.Core.Model.ResourceFile;

/// <summary>
/// JSON 格式语言文件提供器。写入时按键排序，保证输出确定性。
/// </summary>
public class JsonFile : KVPFile
{
    public JsonFile(Dictionary<string, string> entries, string relativePath)
        : base(entries, relativePath) { }

    /// <summary>供子类（如 <see cref="CompositionJsonFile"/>）使用，不传字典</summary>
    protected JsonFile(string relativePath)
        : base(relativePath) { }

    /// <summary>合并另一个 JSON 语言文件</summary>
    public override KVPFile Merge(KVPFile other)
    {
        var merged = new Dictionary<string, string>(Entries);
        if (other is JsonFile otherJson)
        {
            bool modifyOnly = other.PolicyItem?.ModifyOnly ?? false;
            if (modifyOnly)
            {
                foreach (var (k, v) in otherJson.Entries)
                    if (merged.ContainsKey(k))
                        merged[k] = v;
            }
            else
            {
                foreach (var (k, v) in otherJson.Entries)
                    merged.TryAdd(k, v);
            }
        }
        return new JsonFile(merged, RelativePath) { PolicyItem = PolicyItem };
    }

    /// <summary>序列化为 JSON，按键排序，写入前执行字符替换</summary>
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

        var sorted = new SortedDictionary<string, string>(entries);
        var json = JsonSerializer.Serialize(sorted, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
        return new MemoryStream(Encoding.UTF8.GetBytes(json));
    }
}
