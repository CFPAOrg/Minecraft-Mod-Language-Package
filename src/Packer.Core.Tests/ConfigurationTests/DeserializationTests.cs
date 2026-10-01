using Packer.Core.Model.Configuration;
using Packer.Core.Model.PackerPolicys;
using Packer.Core.Model.ResourceFile;
using System.Text.Json;

namespace Packer.Core.Tests.ConfigurationTests;

/// <summary>测试 1/2/3：配置与策略的解析与组合行为</summary>
public class DeserializationTests
{
    static readonly FloatingConfig EmptyConfig = new([], [], [], [],
        new Dictionary<string, string>(), new Dictionary<string, string>());
    static readonly Config EmptyGlobal = new(
        new BaseConfig("", ["zh_cn"], "", [], "", [], [], []), EmptyConfig);

    static readonly JsonSerializerOptions Opts = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver()
    };

    // ── 测试 1：浮动配置和打包策略在命名空间文件夹里时可以解析 ──

    [Fact]
    public void NamespaceFolder_Loads_LocalConfig_And_Policy()
    {
        using var tmp = new TempDir();
        // 造一个命名空间目录，带 local-config.json 和 packer-policy.json
        tmp.Write("local-config.json", """{ "inclusionDomains": ["font"] }""");
        tmp.Write("packer-policy.json", """[{ "type": "singleton", "source": "a.json", "relativePath": "lang/zh_cn.json" }]""");

        var ns = new AssetsNamespaceResource(tmp.Path, "myns", "mymod", "1.21");

        // 验证 local-config 被加载
        Assert.Contains("font", ns.LocalConfig.InclusionDomains);

        // 验证策略被加载（不会是 Shared）
        Assert.NotSame(PackerPolicy.Shared, ns.PackerPolicies);

        // 验证策略类型正确
        var policy = Assert.Single(ns.PackerPolicies);
        Assert.IsType<SingletonPolicy>(policy);
    }

    // ── 测试 2：全局配置和浮动配置组合正确 ──

    [Fact]
    public void GlobalConfig_Merges_With_LocalConfig()
    {
        var global = new FloatingConfig(
            ["font"], [], [], ["README.md"],
            new Dictionary<string, string> { ["旧"] = "新" },
            new Dictionary<string, string>());

        var local = new FloatingConfig(
            ["gui"], [], [], ["packer-policy.json"],
            new Dictionary<string, string>(),
            new Dictionary<string, string>());

        var merged = global.Merge(local);

        // domain 取并集
        Assert.Contains("font", merged.InclusionDomains);
        Assert.Contains("gui", merged.InclusionDomains);

        // exclusionPaths 取并集
        Assert.Contains("README.md", merged.ExclusionPaths);
        Assert.Contains("packer-policy.json", merged.ExclusionPaths);

        // 全局的 replacement 保留
        Assert.Equal("新", merged.CharacterReplacement["旧"]);
    }

    // ── 测试 3：没有浮动配置和打包策略时结果正确 ──

    [Fact]
    public void NoLocalConfig_Returns_Shared()
    {
        using var tmp = new TempDir();
        // 空目录，没有 local-config.json
        var ns = new AssetsNamespaceResource(tmp.Path, "ns", "mod", "1.21");

        Assert.Same(FloatingConfig.Shared, ns.LocalConfig);
        Assert.Same(PackerPolicy.Shared, ns.PackerPolicies);
    }

    // ── 测试 8：TryAdd 和 ModifyOnly ──

    [Fact]
    public void JsonFile_Merge_TryAdd_FirstWins()
    {
        var a = new JsonFile(new() { ["a"] = "1", ["b"] = "2" }, "x.json");
        var b = new JsonFile(new() { ["a"] = "x", ["c"] = "3" }, "x.json");

        var r = a.Merge(b);
        Assert.Equal("1", r.Entries["a"]); // 第一个赢
        Assert.Equal("2", r.Entries["b"]);
        Assert.Equal("3", r.Entries["c"]);
    }

    [Fact]
    public void JsonFile_Merge_ModifyOnly_OverwritesExisting()
    {
        var a = new JsonFile(new() { ["a"] = "1", ["b"] = "2" }, "x.json");
        var b = new JsonFile(new() { ["a"] = "x", ["c"] = "3" }, "x.json")
        {
            PolicyItem = new DirectPolicy { ModifyOnly = true }
        };

        var r = a.Merge(b);
        Assert.Equal("x", r.Entries["a"]); // 覆盖已有
        Assert.Equal("2", r.Entries["b"]); // 不动
        Assert.False(r.Entries.ContainsKey("c")); // 不添加新键
    }

    [Fact]
    public void LangFile_Merge_TryAdd_FirstWins()
    {
        var a = new LangFile(new() { ["k1"] = "v1", ["k2"] = "v2" }, "x.lang");
        var b = new LangFile(new() { ["k1"] = "x", ["k3"] = "v3" }, "x.lang");

        var r = a.Merge(b);
        Assert.Equal("v1", r.Entries["k1"]);
        Assert.Equal("v3", r.Entries["k3"]);
    }

    // ── 测试 11：全局配置的过滤 ──
    // 此测试需要在真实目录中放置文件，用 AssetsNamespaceResource + DirectPolicy
    // 验证 inclusionDomains / exclusionDomains / exclusionPaths 生效

    [Fact]
    public void GlobalFilter_InclusionDomain_ForceIncludes()
    {
        using var dir = new TempDir();
        dir.Write("font/extra.txt", "should be included via domain");
        dir.Write("sounds/ambient.ogg", "should NOT be included");

        var ns = new AssetsNamespaceResource(dir.Path, "testns", "testmod", "1.21");
        var config = new FloatingConfig(
            InclusionDomains: ["font"],  // font 之下无条件进包
            ExclusionDomains: [],
            InclusionPaths: [],
            ExclusionPaths: ["packer-policy.json", "local-config.json"],
            CharacterReplacement: new Dictionary<string, string>(),
            DestinationReplacement: new Dictionary<string, string>());

        // DirectPolicy 默认共享
        var providers = new DirectPolicy().CreateProviders(ns, EmptyGlobal, config).ToList();

        Assert.Contains(providers, p => p.Destination.EndsWith("font/extra.txt"));
        Assert.DoesNotContain(providers, p => p.Destination.EndsWith("sounds/ambient.ogg"));
    }
}

/// <summary>临时目录辅助类</summary>
public class TempDir : IDisposable
{
    public string Path { get; } = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());

    public TempDir()
    {
        Directory.CreateDirectory(Path);
    }

    /// <summary>在临时目录下创建一个文件（自动创建父目录）</summary>
    public void Write(string relativePath, string content)
    {
        var full = System.IO.Path.Combine(Path, relativePath);
        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(full)!);
        File.WriteAllText(full, content);
    }

    public void Dispose()
    {
        try { Directory.Delete(Path, recursive: true); }
        catch { /* 清理失败忽略 */ }
    }
}
