using Packer.Core.Model;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.PackerPolicys;
using Packer.Core.Model.ResourceFile;

namespace Packer.Core.Tests.PolicyTests;

/// <summary>测试 4~7：每种策略的执行结果</summary>
public class PolicyTypeTests
{
    static readonly FloatingConfig EmptyConfig = new([], [], [], [],
        new Dictionary<string, string>(), new Dictionary<string, string>());

    static readonly Config EmptyGlobal = new(
        new BaseConfig("", ["zh_cn"], "", [], "", [], [], []), EmptyConfig);

    // ── 测试 4：默认打包策略（Direct）与浮动配置组合时过滤正确 ──

    [Fact]
    public void DirectPolicy_WithFilters_ExcludesCorrectly()
    {
        using var dir = new TempDir();
        dir.Write("lang/zh_cn.json", """{"key":"val"}""");
        dir.Write("lang/en_us.json", """{"key":"val"}""");
        dir.Write("packer-policy.json", "ignored");

        var ns = new AssetsNamespaceResource(dir.Path, "ns", "mod", "1.21");
        var config = new FloatingConfig([], [], [], ["packer-policy.json", "local-config.json"],
            new Dictionary<string, string>(), new Dictionary<string, string>());

        var providers = new DirectPolicy().CreateProviders(ns, EmptyGlobal, config).ToList();
        Assert.Contains(providers, p => p.Destination.Contains("zh_cn"));
        Assert.DoesNotContain(providers, p => p.Destination.Contains("en_us"));
    }

    // ── 测试 5：多个打包策略时执行正确 ──

    [Fact]
    public void MultiplePolicies_ExecuteAll()
    {
        using var dir = new TempDir();
        dir.Write("lang/base.json", """{"a":"1"}""");
        dir.Write("lang/comp.json", """{"target":"lang/zh_cn.json","entries":[{"templates":{"{0}.n":"{0}"},"parameters":[{"x":"y"}]}]}""");

        var policyList = new PackerPolicy();
        policyList.Add(new SingletonPolicy(
            System.IO.Path.Combine(dir.Path, "lang/base.json"), "lang/zh_cn.json"));
        policyList.Add(new CompositionPolicy(
            System.IO.Path.Combine(dir.Path, "lang/comp.json"), "json"));

        var ns = new AssetsNamespaceResource(dir.Path, "ns", "mod", "1.21");
        var providers = policyList.CreateProviders(ns, EmptyGlobal).ToList();

        Assert.Equal(2, providers.Count);
        Assert.IsType<JsonFile>(providers[0]);
        Assert.IsType<CompositionJsonFile>(providers[1]);
    }

    // ── 测试 6：每一种打包方式的结果预期 ──

    [Fact]
    public void DirectPolicy_Produces_ExpectedProviders()
    {
        using var dir = new TempDir();
        dir.Write("lang/zh_cn.json", """{"k":"v"}""");
        dir.Write("lang/zh_cn.lang", "k=v");

        var ns = new AssetsNamespaceResource(dir.Path, "ns", "mod", "1.21");
        var config = new FloatingConfig([], [], [], ["packer-policy.json", "local-config.json"],
            new Dictionary<string, string>(), new Dictionary<string, string>());

        var providers = new DirectPolicy().CreateProviders(ns, EmptyGlobal, config).ToList();

        Assert.Contains(providers, p => p is JsonFile);
        Assert.Contains(providers, p => p is LangFile);
    }

    // ── 测试 7：重定向多递归 ──

    [Fact]
    public void IndirectPolicy_Recursion_Works()
    {
        using var target = new TempDir();
        target.Write("lang/zh_cn.json", """{"key":"来自目标"}""");

        using var source = new TempDir();
        source.Write("packer-policy.json",
            $$"""[{"type":"indirect","source":"{{target.Path.Replace("\\","/")}}"}]""");

        var ns = new AssetsNamespaceResource(source.Path, "srcns", "srcmod", "1.21");
        var config = new FloatingConfig([], [], [], ["packer-policy.json", "local-config.json"],
            new Dictionary<string, string>(), new Dictionary<string, string>());

        var providers = ns.PackerPolicies.CreateProviders(ns, EmptyGlobal).ToList();

        var dests = providers.Select(p => p.Destination).ToList();
        Assert.Contains(dests, d => d.Contains("srcns"));
    }

    // ── 测试 12：字符串替换 ──

    [Fact]
    public void TextFile_CharacterReplacement_Works()
    {
        var file = new TextFile("[[旧]]", "x.txt")
        {
            EffectiveConfig = new FloatingConfig(
                [], [], [], [],
                new Dictionary<string, string> { ["\\[\\[旧\\]\\]"] = "新" },
                new Dictionary<string, string>())
        };

        using var stream = file.GetContentStream();
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();

        Assert.Equal("新", content);
    }

    [Fact]
    public void JsonFile_Replaces_Values_Only()
    {
        var file = new JsonFile(
            new() { ["a"] = "[[旧]]", ["b"] = "不变" }, "x.json")
        {
            EffectiveConfig = new FloatingConfig(
                [], [], [], [],
                new Dictionary<string, string> { ["\\[\\[旧\\]\\]"] = "新" },
                new Dictionary<string, string>())
        };

        using var stream = file.GetContentStream();
        using var reader = new StreamReader(stream);
        var json = reader.ReadToEnd();

        Assert.Contains("新", json);
        Assert.Contains("不变", json);
        Assert.DoesNotContain("旧", json);
    }
}
