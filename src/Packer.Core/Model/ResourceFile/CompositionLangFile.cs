namespace Packer.Core.Model.ResourceFile;

/// <summary>
/// 由组合文件生成的 .lang 格式语言文件。与 <see cref="CompositionJsonFile"/> 对应。
/// 直接使用原本的 <c>target</c> 值作为路径，不参与 Namespace 拼接。
/// </summary>
public class CompositionLangFile : LangFile
{
    private readonly string _target;

    public CompositionLangFile(string target, List<CompositionEntry> entries)
        : base(Path.GetFileName(target) ?? target)
    {
        _target = target;
        foreach (var entry in entries)
            entry.BuildDictionary(Entries);
    }

    private CompositionLangFile(string target, Dictionary<string, string> entries)
        : base(Path.GetFileName(target) ?? target)
    {
        _target = target;
        Entries = entries;
    }

    public override string Destination => _target;
    
    public override KVPFile Merge(KVPFile other)
    {
        var merged = new Dictionary<string, string>(Entries);
        if (other is LangFile otherLang)
        {
            bool modifyOnly = other.PolicyItem?.ModifyOnly ?? false;
            if (modifyOnly)
            {
                foreach (var kv in otherLang.Entries)
                    if (merged.ContainsKey(kv.Key))
                        merged[kv.Key] = kv.Value;
            }
            else
            {
                foreach (var kv in otherLang.Entries)
                    merged.TryAdd(kv.Key, kv.Value);
            }
        }
        return new CompositionLangFile(_target, merged) { PolicyItem = PolicyItem, Namespace = Namespace };
    }
}
