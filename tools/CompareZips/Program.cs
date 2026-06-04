using System.IO.Compression;
using System.Text;
using System.Text.Json;

var orig = ZipFile.OpenRead("test/packer/1.21.zip");
var core = ZipFile.OpenRead("test/packer.core/1.21.zip");

int sameCount = 0, diffCount = 0;

foreach (var oe in orig.Entries.OrderBy(e => e.FullName))
{
    var ce = core.GetEntry(oe.FullName);
    if (ce is null) { Console.WriteLine($"缺失: {oe.FullName}"); diffCount++; continue; }

    var oBytes = ReadAllBytes(oe);
    var cBytes = ReadAllBytes(ce);

    if (oBytes.AsSpan().SequenceEqual(cBytes))
    { sameCount++; continue; }

    if (oe.FullName is "pack.mcmeta" or "README.txt")
    { sameCount++; continue; }

    // 按字典排序后对比
    if (oe.FullName.EndsWith(".json"))
    {
        try
        {
            var oDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(oBytes)!;
            var cDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(cBytes)!;
            var oKeys = oDict.Keys.OrderBy(k => k).ToList();
            var cKeys = cDict.Keys.OrderBy(k => k).ToList();
            if (oKeys.SequenceEqual(cKeys) && oKeys.All(k => oDict[k].ToString() == cDict[k].ToString()))
            { sameCount++; continue; }
        }
        catch { }
    }

    if (oe.FullName.EndsWith(".lang"))
    {
        try
        {
            var oDict = Encoding.UTF8.GetString(oBytes).Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.StartsWith('#')).Select(l => l.Split('=', 2)).Where(a => a.Length == 2)
                .ToDictionary(a => a[0], a => a[1]);
            var cDict = Encoding.UTF8.GetString(cBytes).Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !l.StartsWith('#')).Select(l => l.Split('=', 2)).Where(a => a.Length == 2)
                .ToDictionary(a => a[0], a => a[1]);
            if (oDict.Count == cDict.Count && oDict.OrderBy(k => k.Key).SequenceEqual(cDict.OrderBy(k => k.Key)))
            { sameCount++; continue; }
        }
        catch { }
    }

    Console.WriteLine($"差异: {oe.FullName} ({oBytes.Length}B vs {cBytes.Length}B)");
    diffCount++;
}

Console.WriteLine($"\n相同: {sameCount}, 差异: {diffCount}, 总计: {sameCount + diffCount}");

static byte[] ReadAllBytes(ZipArchiveEntry e) { using var s = e.Open(); using var m = new MemoryStream(); s.CopyTo(m); return m.ToArray(); }
