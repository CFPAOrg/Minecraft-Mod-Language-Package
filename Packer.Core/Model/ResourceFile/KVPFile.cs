namespace Packer.Core.Model.ResourceFile;

public abstract class KVPFile : TextFile
{
    public Dictionary<string, string> Entries { get; protected set; } = [];

    public PackerPolicyItem? PolicyItem { get; set; }

    protected KVPFile(Dictionary<string, string> entries, string relativePath)  : this(relativePath)
    {
        Entries = entries; 
    }

    protected KVPFile(string relativePath) :base(relativePath) 
    {
        RelativePath = relativePath;
    } 

    public abstract KVPFile Merge(KVPFile other);
}
