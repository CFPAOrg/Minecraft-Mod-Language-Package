// ============================================================
// Packer.Core — CFPA 模组翻译资源包构建工具
// 入口：解析参数 → 加载配置 → 获取命名空间（全量/增量）
//       → 按策略展开 Provider → 合并 → 替换 → 写 ZIP → MD5
// ============================================================
 
// -- 参数解析 ------------------------------------------------------------------
var versionOpt = new Option<string>("--version", "--v");
var incrementOpt = new Option<bool>("--increment", "--i");
var rootCmd = new Command("pack") { versionOpt, incrementOpt };
var result = rootCmd.Parse(args);
var version = result.GetValue(versionOpt)!;
var increment = result.GetValue(incrementOpt);

// -- 日志 ---------------------------------------------------------------------
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .MinimumLevel.Debug()
    .CreateLogger();

Log.Information("开始对版本 {0} 的打包", version);

// -- 加载全局配置 -------------------------------------------------------------
var config = JsonSerializer.Deserialize<Config>(
    File.ReadAllText($"config/packer/{version}.json"),
    SourceGenerationContext.JsonOptions)!;

// -- 获取命名空间提供器（全量扫磁盘 / 增量 git diff） ---------------------------
INamespaceProvider nsProvider = increment
    ? new GitChangedModProvider()
    : new AssetsModProvider();

// -- 展开所有 Provider --------------------------------------------------------
// 流 程：ILookup<模组, 命名空间>
//      → 过滤 ExclusionMods / ExclusionNamespaces
//      → 每个命名空间执行其 PackerPolicies
//      → 每个 Policy 调用 CreateProviders 产出 IResourceFileProvider
//      → 物化到 List 以便分组合并
var allProviders = nsProvider.GetModsByVersion(version)
    .SelectMany(g => g)
    .Where(ns => !config.Base.ExclusionMods.Contains(ns.ModName))
    .Where(ns => !config.Base.ExclusionNamespaces.Contains(ns.NamespaceName))
    .SelectMany(ns => ns.PackerPolicies
        .SelectMany(p => p.CreateProviders(ns, config.Floating.Merge(ns.LocalConfig))))
    .ToLookup(p => p.Destination);

// -- 按 Destination 合并同名文件 ----------------------------------------------
// 同类型 KVPFile（JsonFile/LangFile）走 Merge 方法合并词条
// 其他类型冲突时保留第一个，打出警告
var merged = allProviders.Select(group =>
{
    if (!group.Skip(1).Any()) return group.First();
    if (group.All(p => p is KVPFile))
    {
        var r = group.Cast<KVPFile>().Aggregate((a, n) => a.Merge(n));
        if (r is ResourceFileProvider rfp)
            rfp.Namespace = group.Cast<KVPFile>().First().Namespace;
        return r;
    }
    Log.Warning("Destination 冲突但无法合并: {Dest}, 保留第一个", group.Key);
    return group.First();
}).ToList();

// -- 设置字符替换配置 ---------------------------------------------------------
foreach (var p in merged.OfType<TextFile>())
    p.EffectiveConfig = config.Floating;

// -- 初始文件（pack.png / LICENSE / README.txt / pack.mcmeta）--------------------
var initialFiles = new List<IResourceFileProvider>
{
    new RawFile("./projects/templates/pack.png", "pack.png"),
    new TextFile(File.ReadAllText("./projects/templates/LICENSE"), "LICENSE"),
    config.Base.LoadReadmeTemp(),
    config.Base.LoadMetaTemp()
};

// -- 写入 ZIP -----------------------------------------------------------------
var packName = $"./Minecraft-Mod-Language-Modpack-{config.Base.Version}.zip";
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

// -- 计算 MD5 并写入校验文件 ---------------------------------------------------
stream.Seek(0, SeekOrigin.Begin);
var md5 = Convert.ToHexString(MD5.Create().ComputeHash(stream));
Log.Information("打包文件的 MD5 值：{0}", md5);
File.WriteAllText($"./{config.Base.Version}.md5", md5);
Log.Information("对版本 {0} 的打包结束", version);
