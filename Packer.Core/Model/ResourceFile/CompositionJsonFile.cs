namespace Packer.Core.Model.ResourceFile;

/// <summary>
/// 组合生成的 JSON 语言文件。通过模板 + 参数笛卡尔积批量生成条目。
/// </summary>
public class CompositionJsonFile : JsonFile
{
    private bool _computed;
    private readonly List<CompositionEntry> _entries;

    public CompositionJsonFile(string target, List<CompositionEntry> entries)
        : base(target)
    {
        _entries = entries;
    }

    private void Compute()
    {
        if (_computed) return;
        _computed = true;

        foreach (var entry in _entries)
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

    public override Stream GetContentStream()
    {
        Compute();
        return base.GetContentStream();
    }

    public override KVPFile Merge(KVPFile other)
    {
        Compute();
        return base.Merge(other);
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

/// <summary>
/// Composition 条目：一组模板 + 多组参数。
/// </summary>
/// <param name="Templates">模板字典，key 和 value 中可包含 {0} {1} 等占位符</param>
/// <param name="Parameters">参数列表，第 n 个字典提供 {n} 的值</param>
public record CompositionEntry(
    Dictionary<string, string> Templates,
    List<Dictionary<string, string>> Parameters
)
{
    public Dictionary<string, string> ToDictionary(Dictionary<string, string>? dic = null)
    {
        dic ??= [];
        foreach (var (templateKey, templateValue) in Templates)
        {
            foreach (var parameters in CartesianProduct(Parameters))
            {
                var paramArr = parameters.ToArray();
                var finalKey = string.Format(templateKey, paramArr.Select(s => s.Key).ToArray());
                var finalValue = string.Format(templateValue, paramArr.Select(s => s.Value).ToArray());
                dic[finalKey] = finalValue;
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
