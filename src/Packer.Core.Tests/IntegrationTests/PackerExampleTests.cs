using Packer.Core.Model;
using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.PackerPolicys;

namespace Packer.Core.Tests.IntegrationTests;

/// <summary>
/// 使用 projects/packer-example 的数据做真实集成测试。
/// 在临时目录重建项目结构（CWD 已切换到临时项目根），跑完整打包流程。
/// </summary>
[Collection("CWD-sensitive tests")]
public class PackerExampleTests : IDisposable
{
    private readonly string _originalDir = Environment.CurrentDirectory;
    private readonly TempDir _tmp = new();

    public PackerExampleTests()
    {
        Environment.CurrentDirectory = _tmp.Path;
    }

    public void Dispose()
    {
        Environment.CurrentDirectory = _originalDir;
        _tmp.Dispose();
    }

    // 从 AppContext.BaseDirectory（bin/Debug/net10.0/）回溯到仓库根目录
    static readonly string _exampleRoot = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory,
            "..", "..", "..", "..", "..",
            "projects", "packer-example", "assets"));

    [Fact]
    public void DirectPolicy_IncludesZhCn_ExcludesEnUs()
    {
        CreateProject("example-direct");
        var config = LoadTestConfig();
        var ns = GetNamespace("example-direct", "direct");

        var providers = ns.PackerPolicies
            .CreateProviders(ns, config)
            .ToList();

        Assert.Contains(providers, p => p.Destination.EndsWith("direct/lang/zh_cn.json"));
        Assert.DoesNotContain(providers, p => p.Destination.EndsWith("direct/lang/en_us.json"));
        Assert.DoesNotContain(providers, p => p.Destination.EndsWith("direct/other.txt"));
    }

    [Fact]
    public void IndirectPolicy_RewritesNamespace()
    {
        CreateProject("example-direct", "example-indirect");
        var config = LoadTestConfig();
        var ns = GetNamespace("example-indirect", "indirect");

        var providers = ns.PackerPolicies
            .CreateProviders(ns, config)
            .ToList();

        Assert.NotEmpty(providers);
        foreach (var p in providers)
            Assert.Contains("indirect", p.Destination);
        Assert.Contains(providers, p => p.Destination.EndsWith("lang/zh_cn.json"));
    }

    [Fact]
    public void CompositePolicy_MergesMultipleSources()
    {
        CreateProject("example-direct", "example-indirect", "example-composition", "example-composite");
        var config = LoadTestConfig();
        var ns = GetNamespace("example-composite", "composite");

        var providers = ns.PackerPolicies
            .CreateProviders(ns, config)
            .ToList();

        var zhCn = providers.Where(p => p.Destination.Contains("composite") && p.Destination.EndsWith("lang/zh_cn.json"))
            .Cast<KVPFile>().ToList();
        Assert.Equal(2, zhCn.Count);

        // 第一个来自 composite 自身（Direct），key3 被覆盖为新值
        // 第二个来自 indirect（→direct），包含 direct 的全部 18 个 key
        var compositeEntries = zhCn[0].Entries;
        var directEntries = zhCn[1].Entries;
        Assert.Equal("new value3", compositeEntries["key3"]);
        Assert.Equal("value1", directEntries["key1"]);
    }

    [Fact]
    public void CompositionPolicy_ExpandsCartesianProduct()
    {
        CreateProject("example-composition");
        var config = LoadTestConfig();
        var ns = GetNamespace("example-composition", "composition");

        var providers = ns.PackerPolicies
            .CreateProviders(ns, config)
            .ToList();

        Assert.Single(providers);
        var provider = providers[0] as KVPFile;
        Assert.NotNull(provider);

        Assert.Equal(200, provider.Entries.Count);
        Assert.Equal("value_0_00", provider.Entries["key_0_00"]);
        Assert.Equal("altvalue_9_09", provider.Entries["altkey_9_09"]);
    }

    [Fact]
    public void FullPipeline_ProducesAllExpectedDestinations()
    {
        CreateProject("example-direct", "example-indirect", "example-composite", "example-composition");
        var config = LoadTestConfig();

        var mods = new[] { "example-direct", "example-indirect", "example-composite", "example-composition" };
        var allNamespaces = mods.Select(m => GetNamespace(m, m.Split('-').Last()));

        var allProviders = allNamespaces
            .SelectMany(ns => ns.PackerPolicies.CreateProviders(ns, config))
            .ToLookup(p => p.Destination);

        var dests = allProviders.Select(g => g.Key).ToList();
        Assert.Contains(dests, d => d.Contains("direct/lang/zh_cn.json"));
        Assert.Contains(dests, d => d.Contains("indirect/lang/zh_cn.json"));
        Assert.Contains(dests, d => d.Contains("composite/lang/zh_cn.json"));
        Assert.Contains(dests, d => d.Contains("composition/lang/zh_cn.json"));
    }

    // ── 辅助方法 ──

    private void CreateProject(params string[] modNames)
    {
        foreach (var mod in modNames)
        {
            var src = Path.Combine(_exampleRoot, mod);
            foreach (var nsDir in Directory.EnumerateDirectories(src))
            {
                var ns = Path.GetFileName(nsDir);
                var dest = Path.Combine(_tmp.Path, "projects", "assets", mod, "packer-example", ns);
                CopyDirectory(nsDir, dest);
            }
        }
    }

    private static Config LoadTestConfig()
    {
        return new Config(
            new BaseConfig(
                Version: "packer-example",
                TargetLanguages: ["zh_cn"],
                McMetaTemplate: "",
                McMetaParameters: [],
                ReadmeTemplate: "",
                ReadmeParameters: [],
                ExclusionMods: [],
                ExclusionNamespaces: []
            ),
            new FloatingConfig(
                InclusionDomains: [],
                ExclusionDomains: [],
                ExclusionPaths: ["local-config.json", "packer-policy.json"],
                InclusionPaths: [],
                CharacterReplacement: new Dictionary<string, string>
                {
                    ["REPLACEMENT"] = "被替换的内容"
                },
                DestinationReplacement: new Dictionary<string, string>()
            )
        );
    }

    private INamespaceResource GetNamespace(string modName, string nsName)
    {
        var nsDir = Path.Combine(_tmp.Path, "projects", "assets", modName, "packer-example", nsName);
        return new AssetsNamespaceResource(nsDir, nsName, modName, "packer-example");
    }

    private static void CopyDirectory(string src, string dest)
    {
        Directory.CreateDirectory(dest);
        foreach (var file in Directory.EnumerateFiles(src, "*", SearchOption.AllDirectories))
        {
            var relative = Path.GetRelativePath(src, file);
            var target = Path.Combine(dest, relative);
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            File.Copy(file, target);
        }
    }
}
