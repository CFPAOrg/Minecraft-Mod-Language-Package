using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Packer.Core.Model.ResourceFile;

public class JsonFile : KVPFile
{
    public JsonFile(Dictionary<string, string> entries, string relativePath) : base(entries, relativePath) { }

    protected JsonFile(string relativePath) : base(relativePath) { }

    public override KVPFile Merge(KVPFile other)
    {
        var merged = new Dictionary<string, string>(Entries);
        if (other is JsonFile otherJson)
        {
            bool modifyOnly = other.PolicyItem?.ModifyOnly ?? false;
            if (modifyOnly)
            {
                foreach (var (key, value) in otherJson.Entries)
                    if (merged.ContainsKey(key))
                        merged[key] = value;
            }
            else
            {
                foreach (var (key, value) in otherJson.Entries)
                    merged.TryAdd(key, value);
            }
        }
        return new JsonFile(merged, RelativePath) { PolicyItem = PolicyItem };
    }

    public override Stream GetContentStream()
    {
        var json = JsonSerializer.Serialize(Entries, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
        return new MemoryStream(Encoding.UTF8.GetBytes(json));
    }
}
