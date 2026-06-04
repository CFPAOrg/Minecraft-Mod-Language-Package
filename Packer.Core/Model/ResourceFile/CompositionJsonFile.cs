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
            foreach (var template in entry.Templates)
            {
                foreach (var parameters in CartesianProduct(entry.Parameters))
                {
                    var paramArr = parameters.ToArray();
                    var finalKey = string.Format(template.Key, paramArr.Select(s => s.Key).ToArray());
                    var finalValue = string.Format(template.Value, paramArr.Select(s => s.Value).ToArray());
                    Entries.TryAdd(finalKey, finalValue);
                }
            }
        }
    }

    public override string Destination => _target;

    public override KVPFile Merge(KVPFile other)
    {
        var merged = new Dictionary<string, string>(Entries);
        if (other is JsonFile otherJson)
        {
            bool modifyOnly = other.PolicyItem?.ModifyOnly ?? false;
            EntriesMerge(merged, otherJson.Entries, modifyOnly);
        }
        return new CompositionJsonFile(_target, []) { Entries = merged, PolicyItem = PolicyItem, Namespace = Namespace };
    }

    private static void EntriesMerge(Dictionary<string, string> target, IEnumerable<KeyValuePair<string, string>> source, bool modifyOnly)
    {
        using var e = source.GetEnumerator();
        if (modifyOnly)
            while (e.MoveNext())
                if (target.ContainsKey(e.Current.Key))
                    target[e.Current.Key] = e.Current.Value;
        else
            while (e.MoveNext())
                target.TryAdd(e.Current.Key, e.Current.Value);
    }

    public override Stream GetContentStream()
        => base.GetContentStream();

    private static IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
    {
        return sequences.Aggregate(
            new[] { Enumerable.Empty<T>() }.AsEnumerable(),
            (accumulator, sequence) => accumulator
                .SelectMany(prefix => sequence, (prefix, item) => prefix.Append(item))
        );
    }
}

public record CompositionEntry(
    Dictionary<string, string> Templates,
    List<Dictionary<string, string>> Parameters
);
