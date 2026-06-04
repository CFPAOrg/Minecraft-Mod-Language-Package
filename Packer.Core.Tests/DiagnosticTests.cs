using Packer.Core.Model;
using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.ModProvider;
using Packer.Core.Model.ResourceFile;
using Serilog;

namespace Packer.Core.Tests;

public class DiagnosticTests
{
    static DiagnosticTests()
    {
        Environment.CurrentDirectory = @"C:\Users\16229\source\OpenSourceLibrary\Minecraft-Mod-Language-Package";
        Log.Logger = new LoggerConfiguration().WriteTo.Console().MinimumLevel.Warning().CreateLogger();
    }

    [Fact]
    public void Createdeco_Composition_TargetPath()
    {
        var ns = new AssetsNamespaceResource(
            @"projects/assets/create-deco/1.21/createdeco",
            "createdeco", "create-deco", "1.21");

        foreach (var policy in ns.PackerPolicies)
        {
            foreach (var provider in policy.CreateProviders(ns, new FloatingConfig(
                [], [], [], [], new Dictionary<string, string>(), new Dictionary<string, string>())))
            {
                var dest = provider.Destination;
                Assert.Equal("assets/createdeco/lang/zh_cn.json", dest);
            }
        }
    }

    [Fact]
    public void Justhammers_Policy_Resolves()
    {
        var ns = new AssetsNamespaceResource(
            @"projects/assets/justhammers/1.21/justhammers",
            "justhammers", "justhammers", "1.21");

        // Indirect target: projects/assets/justhammers/1.19/justhammers
        // Verify the policy loads
        Assert.NotEmpty(ns.PackerPolicies);
    }

    [Fact]
    public void Minecraft_Font_Domain_Is_Included()
    {
        var globalFloating = new FloatingConfig(
            InclusionDomains: ["font", "textures", "gui"],
            ExclusionDomains: [],
            InclusionPaths: [],
            ExclusionPaths: [],
            CharacterReplacement: new Dictionary<string, string>(),
            DestinationReplacement: new Dictionary<string, string>());

        var ns = new AssetsNamespaceResource(
            @"projects/assets/minecraft/1.21/minecraft",
            "minecraft", "minecraft", "1.21");

        var merged = globalFloating.Merge(ns.LocalConfig);

        foreach (var policy in ns.PackerPolicies)
        {
            foreach (var provider in policy.CreateProviders(ns, merged))
            {
                if (provider.Destination.Contains("font/default.json"))
                {
                    return; // found it
                }
            }
        }
        Assert.Fail("assets/minecraft/font/default.json not produced");
    }
}
