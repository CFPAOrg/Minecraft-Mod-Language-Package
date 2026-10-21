using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.ModProvider;

namespace Packer.Core.Tests.ProviderTests;

/// <summary>测试 FallbackVersions 回退版本逻辑</summary>
[Collection("CWD-sensitive tests")]
public class FallbackTests
{
    // ── ModsByVersionLookup 回退测试 ──

    [Fact]
    public void ModsByVersionLookup_ExactVersion_FindsMod()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/testmod/1.21/testns/lang/zh_cn.json", "{}");

            var lookup = new ModsByVersionLookup(
                version: "1.21",
                fallbackVersions: ["1.20", "1.19"]);

            var mods = lookup["testmod"].ToList();
            Assert.NotEmpty(mods);
            Assert.Equal("1.21", mods[0].ModVersion);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    [Fact]
    public void ModsByVersionLookup_FallbackVersion_FindsMod()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/testmod/1.20/testns/lang/zh_cn.json", "{}");

            var lookup = new ModsByVersionLookup(
                version: "1.21",
                fallbackVersions: ["1.20", "1.19"]);

            var mods = lookup["testmod"].ToList();
            Assert.NotEmpty(mods);
            Assert.Equal("1.20", mods[0].ModVersion);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    [Fact]
    public void ModsByVersionLookup_FallbackChain_RespectsOrder()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/testmod/1.19/testns/lang/zh_cn.json", "{}");
            root.Write("projects/assets/testmod/1.20/testns/lang/zh_cn.json", "{}");

            var lookup = new ModsByVersionLookup(
                version: "1.21",
                fallbackVersions: ["1.20", "1.19"]);

            var mods = lookup["testmod"].ToList();
            Assert.NotEmpty(mods);
            Assert.Equal("1.20", mods[0].ModVersion);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    [Fact]
    public void ModsByVersionLookup_NoFallback_SkipsMissingMod()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/testmod/1.20/testns/lang/zh_cn.json", "{}");

            var lookup = new ModsByVersionLookup(
                version: "1.21",
                fallbackVersions: null);

            Assert.Empty(lookup["testmod"]);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    [Fact]
    public void ModsByVersionLookup_NoVersionsExist_ReturnsEmpty()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/testmod/1.20/testns/lang/zh_cn.json", "{}");

            var lookup = new ModsByVersionLookup(
                version: "1.22",
                fallbackVersions: ["1.21"]);

            Assert.Empty(lookup["testmod"]);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    [Fact]
    public void ModsByVersionLookup_MultipleMods_EachRespectsOwnFallback()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/mod_a/1.21/ns/lang/zh_cn.json", "{}");
            root.Write("projects/assets/mod_b/1.20/ns/lang/zh_cn.json", "{}");

            var lookup = new ModsByVersionLookup(
                version: "1.21",
                fallbackVersions: ["1.20"]);

            var modA = lookup["mod_a"].ToList();
            Assert.Single(modA);
            Assert.Equal("1.21", modA[0].ModVersion);

            var modB = lookup["mod_b"].ToList();
            Assert.Single(modB);
            Assert.Equal("1.20", modB[0].ModVersion);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    // ── AssetsModProvider.GetNamespaces 回退测试 ──

    [Fact]
    public void AssetsModProvider_GetNamespaces_FallsBack()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/testmod/1.20/testns/lang/zh_cn.json", "{}");

            var provider = new AssetsModProvider(fallbackVersions: ["1.20"]);
            var nss = provider.GetNamespaces("testmod", "1.21").ToList();

            Assert.NotEmpty(nss);
            Assert.Equal("1.20", nss[0].ModVersion);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    [Fact]
    public void AssetsModProvider_GetNamespaces_ExactVersionTakesPriority()
    {
        using var root = new TempDir();
        var oldCwd = Environment.CurrentDirectory;
        try
        {
            Environment.CurrentDirectory = root.Path;
            root.Write("projects/assets/testmod/1.21/testns/lang/zh_cn.json", "{}");
            root.Write("projects/assets/testmod/1.20/testns/lang/zh_cn.json", "{}");

            var provider = new AssetsModProvider(fallbackVersions: ["1.20"]);
            var nss = provider.GetNamespaces("testmod", "1.21").ToList();

            Assert.NotEmpty(nss);
            Assert.Equal("1.21", nss[0].ModVersion);
        }
        finally { Environment.CurrentDirectory = oldCwd; }
    }

    // ── BaseConfig 序列化测试 ──

    [Fact]
    public void BaseConfig_Deserializes_FallbackVersions()
    {
        var json = """
        {
            "version": "1.21",
            "targetLanguages": ["zh_cn"],
            "mcMetaTemplate": "",
            "mcMetaParameters": [],
            "readmeTemplate": "",
            "readmeParameters": [],
            "exclusionMods": [],
            "exclusionNamespaces": [],
            "fallbackVersions": ["1.20", "1.19"]
        }
        """;

        var config = System.Text.Json.JsonSerializer.Deserialize<BaseConfig>(
            json, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
            });

        Assert.NotNull(config);
        Assert.Equal(["1.20", "1.19"], config!.FallbackVersions);
    }

    [Fact]
    public void BaseConfig_Deserializes_WithoutFallbackVersions()
    {
        var json = """
        {
            "version": "1.21",
            "targetLanguages": ["zh_cn"],
            "mcMetaTemplate": "",
            "mcMetaParameters": [],
            "readmeTemplate": "",
            "readmeParameters": [],
            "exclusionMods": [],
            "exclusionNamespaces": []
        }
        """;

        var config = System.Text.Json.JsonSerializer.Deserialize<BaseConfig>(
            json, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
            });

        Assert.NotNull(config);
        Assert.Null(config!.FallbackVersions);
    }
}
