#if DEBUG 
Environment.CurrentDirectory = @"C:\Users\16229\source\OpenSourceLibrary\Minecraft-Mod-Language-Package";
#endif

var versionOpt = new Option<string>("--version", "--v");
var incrementOpt = new Option<bool>("--increment", "--i");
var rootCmd = new Command("pack") { versionOpt, incrementOpt };
var result = rootCmd.Parse(args);
var version = result.GetValue(versionOpt)!;
var increment = result.GetValue(incrementOpt);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .MinimumLevel.Debug()
    .CreateLogger();

Log.Information("开始对版本 {0} 的打包", version);

var config = JsonSerializer.Deserialize<Config>(
    File.ReadAllText($"config/packer/{version}.json"),
    SourceGenerationContext.Options)!;

INamespaceProvider nsProvider = increment
    ? new GitChangedModProvider()
    : new AssetsModProvider();

var allProviders = nsProvider.GetModsByVersion(version)
    .SelectMany(g => g)
    .Where(ns => !config.Base.ExclusionMods.Contains(ns.ModName))
    .Where(ns => !config.Base.ExclusionNamespaces.Contains(ns.NamespaceName))
    .SelectMany(ns => ns.PackerPolicies
        .SelectMany(p => p.CreateProviders(ns, config.Floating.Merge(ns.LocalConfig))))
    .ToList();

var merged = allProviders.ToLookup(p => p.Destination).Select(group =>
{
    if (!group.Skip(1).Any()) return group.First();
    if (group.All(p => p is KVPFile))
    {
        var r = group.Cast<KVPFile>().Aggregate((a, n) => a.Merge(n));
        if (r is ResourceFileProvider rfp) rfp.Namespace = group.Cast<KVPFile>().First().Namespace;
        return r;
    }
    Log.Warning("Destination 冲突但无法合并: {Dest}, 保留第一个", group.Key);
    return group.First();
}).ToList();

foreach (var p in merged.OfType<TextFile>())
    p.EffectiveConfig = config.Floating;

var initialFiles = new List<IResourceFileProvider>
{
    new RawFile("./projects/templates/pack.png", "pack.png"),
    new TextFile(File.ReadAllText("./projects/templates/LICENSE"), "LICENSE"),
    config.Base.LoadReadmeTemp(),
    config.Base.LoadMetaTemp()
};

var packName = $"./test/packer.core/{config.Base.Version}.zip";
await using var stream = File.Create(packName);
using (var archive = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true))
{
    foreach (var p in merged.Concat(initialFiles))
    {
        using var content = p.GetContentStream();
        var entry = archive.CreateEntry(p.Destination);
        using var es = entry.Open();
        await content.CopyToAsync(es);
    }
}

stream.Seek(0, SeekOrigin.Begin);
var md5 = Convert.ToHexString(MD5.Create().ComputeHash(stream));
Log.Information("打包文件的 MD5 值：{0}", md5);
File.WriteAllText($"./test/packer.core/{config.Base.Version}.md5", md5);
Log.Information("对版本 {0} 的打包结束", version);
