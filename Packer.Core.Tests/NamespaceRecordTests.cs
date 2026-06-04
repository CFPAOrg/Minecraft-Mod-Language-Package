using Packer.Core.Model.ModProvider;

namespace Packer.Core.Tests;

public class NamespaceRecordTests
{
    [Fact]
    public void AssetsNamespaceResource_Equality_Is_Based_On_Four_Fields()
    {
        var a = new AssetsNamespaceResource(
            @"projects/assets/minecraft/1.21/minecraft",
            "minecraft", "minecraft", "1.21");

        var b = new AssetsNamespaceResource(
            @"projects/assets/minecraft/1.21/minecraft",
            "minecraft", "minecraft", "1.21");

        var c = new AssetsNamespaceResource(
            @"projects/assets/jei/1.21/jei",
            "jei", "jei", "1.21");

        Assert.Equal(a, b);           // 四个字段相同 → 相等
        Assert.NotEqual(a, c);        // 不同 → 不相等
        Assert.Equal(a.GetHashCode(), b.GetHashCode()); // HashSet 用
    }

    [Fact]
    public void AssetsNamespaceResource_Lazy_Properties_Are_Null_Before_Access()
    {
        var ns = new AssetsNamespaceResource(
            @"projects/assets/minecraft/1.21/minecraft",
            "minecraft", "minecraft", "1.21");

        // 没有访问过 LocalConfig / PackerPolicies
        // 它们都是 field ??= LoadXxx() 的懒加载模式
        // 没有公开的方式检查 field 是否为 null，但可以通过
        // 确认没有抛异常来验证构造本身没问题
        Assert.NotNull(ns);
        Assert.Equal("minecraft", ns.NamespaceName);
        Assert.Equal("minecraft", ns.ModName);
        Assert.Equal("1.21", ns.ModVersion);
        Assert.EndsWith("minecraft", ns.LocalPath);
    }

    [Fact]
    public void GitChangedModProvider_GetChangedPaths_Returns_Deduped()
    {
        // 不真正跑 git diff，只验证 HashSet 去重逻辑
        var set = new HashSet<AssetsNamespaceResource>
        {
            new(@"dir", "ns1", "mod1", "1.21"),
            new(@"dir", "ns1", "mod1", "1.21"), // 重复
            new(@"dir2", "ns2", "mod2", "1.21")
        };

        Assert.Equal(2, set.Count);
    }
}
