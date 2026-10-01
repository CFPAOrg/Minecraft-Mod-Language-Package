namespace Packer.Core.Model.ResourceFile;

public class CompositionJsonFile : JsonFile
{
    private readonly string _target;

    public CompositionJsonFile(string target, List<CompositionEntry> entries)
        : base(Path.GetFileName(target) ?? target)
    {
        _target = target;
        foreach (var entry in entries)
        {
            entry.BuildDictionary(Entries);
        }
    }

    private CompositionJsonFile(string target, Dictionary<string, string> entries)
        : base(Path.GetFileName(target) ?? target)
    {
        _target = target;
        Entries = entries;
    }

    public override string Destination => _target;

    public override KVPFile Merge(KVPFile other)
    {
        var merged = new Dictionary<string, string>(Entries);
        if (other is JsonFile otherJson)
        {
            bool modifyOnly = other.PolicyItem?.ModifyOnly ?? false;
            if (modifyOnly)
            {
                foreach (var kv in otherJson.Entries)
                {
                    if (merged.ContainsKey(kv.Key))
                    {
                        merged[kv.Key] = kv.Value;
                    }
                }
            }
            else
            {
                foreach (var kv in otherJson.Entries)
                {
                    merged.TryAdd(kv.Key, kv.Value);
                }
            }
        }
        return new CompositionJsonFile(_target, merged) { PolicyItem = PolicyItem, Namespace = Namespace };
    }

}

public record CompositionEntry(
    Dictionary<string, string> Templates,
    List<Dictionary<string, string>> Parameters
)
{
    public Dictionary<string, string> BuildDictionary(Dictionary<string, string>? dic = null)
    {
        dic ??= [];
        foreach (var tpl in Templates)
        {
            foreach (var prm in CartesianProduct(Parameters))
            {
                var arr = prm.ToArray();
                var k = string.Format(tpl.Key, arr.Select(s => s.Key).ToArray());
                var v = string.Format(tpl.Value, arr.Select(s => s.Value).ToArray());
                dic[k] = v;
            }
        }
        return dic;
    }

    private static IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
    {
        return sequences.Aggregate(
            new[] { Enumerable.Empty<T>() }.AsEnumerable(),
            (accumulator, sequence) => accumulator
                .SelectMany(prefix => sequence, (prefix, item) => prefix.Append(item))
        );
    }
}
