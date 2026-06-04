namespace Packer.Core.Model.ResourceFile;

public abstract class KVPFile(string relativePath) : TextFile(relativePath)
{
    public Dictionary<string, string> Entries { get; protected set; } = [];

    public PackerPolicyItem? PolicyItem { get; set; }

    protected KVPFile(Dictionary<string, string> entries, string relativePath)  : this(relativePath)
    {
        Entries = entries; 
    }

    public abstract KVPFile Merge(KVPFile other);
}
