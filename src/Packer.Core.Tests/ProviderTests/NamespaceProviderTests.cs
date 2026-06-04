using Packer.Core.Model;
using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.ModProvider;

namespace Packer.Core.Tests.ProviderTests;

/// <summary>测试 9/13：命名空间提供程序和命名空间资源</summary>
public class NamespaceProviderTests
{
    // ── 测试 13：错误参数的命名空间类 ──

    [Fact]
    public void NamespaceResource_WithInvalidPath_HasNoProviders()
    {
        var ns = new AssetsNamespaceResource(@"Z:\nonexistent\ns", "ns", "mod", "1.21");

        // LocalConfig 应为 Shared（文件不存在）
        Assert.Same(FloatingConfig.Shared, ns.LocalConfig);

        // PackerPolicies 应为 Shared
        Assert.Same(PackerPolicy.Shared, ns.PackerPolicies);
    }

    [Fact]
    public void NamespaceResource_WithEmptyLocalPath_DoesNotCrash()
    {
        var ns = new AssetsNamespaceResource("", "ns", "mod", "1.21");
        Assert.NotNull(ns);
        Assert.Equal("", ns.LocalPath);
    }

    [Fact]
    public void NamespaceResource_Equality_Is_ValueBased()
    {
        var a = new AssetsNamespaceResource("/path/a", "ns1", "mod1", "1.21");
        var b = new AssetsNamespaceResource("/path/a", "ns1", "mod1", "1.21");
        var c = new AssetsNamespaceResource("/path/b", "ns2", "mod2", "1.21");

        Assert.Equal(a, b);
        Assert.NotEqual(a, c);
    }

    // ── 测试 3（补充）：没有文件和目录时行为 ──

    [Fact]
    public void EmptyNamespace_Directory_Returns_NoFileProviders()
    {
        using var dir = new TempDir();
        var ns = new AssetsNamespaceResource(dir.Path, "ns", "mod", "1.21");

        var providers = ns.PackerPolicies.CreateProviders(ns, FloatingConfig.Shared).ToList();
        Assert.Empty(providers);
    }
}
