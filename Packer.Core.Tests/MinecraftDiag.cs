using Packer.Core.Model;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.ModProvider;
using Packer.Core.Model.ResourceFile;
using Serilog;

namespace Packer.Core.Tests;

public class MinecraftDiag
{
    static MinecraftDiag()
    {
        Environment.CurrentDirectory = @"C:\Users\16229\source\OpenSourceLibrary\Minecraft-Mod-Language-Package";
        Log.Logger = new LoggerConfiguration().WriteTo.Console().MinimumLevel.Warning().CreateLogger();
    }

    [Fact]
    public void Indirect_To_120_Produces_Font()
    {
        var ns21 = new AssetsNamespaceResource(
            @"projects/assets/minecraft/1.21/minecraft",
            "minecraft", "minecraft", "1.21");

        var targetPath = @"projects/assets/minecraft/1.20/minecraft";
        var targetDir = new DirectoryInfo(targetPath);
        var exists = targetDir.Exists;
        var hasFont = Directory.Exists(Path.Combine(targetPath, "font"));

        var targetNs = new AssetsNamespaceResource(
            targetDir.FullName, targetDir.Name, "minecraft", "1.20");

        var policies = targetNs.PackerPolicies.ToList();
        var policyTypes = policies.Select(p => p.GetType().Name).ToList();

        var globalFloating = new FloatingConfig(
            InclusionDomains: ["font", "textures", "gui"],
            ExclusionDomains: [],
            InclusionPaths: [],
            ExclusionPaths: [],
            CharacterReplacement: new Dictionary<string, string>(),
            DestinationReplacement: new Dictionary<string, string>());

        var providers = new List<string>();
        foreach (var policy in policies)
        {
            foreach (var p in policy.CreateProviders(ns21, globalFloating))
                providers.Add(p.Destination);
        }

        var msg = $"Target dir exists: {exists}\nHas font/: {hasFont}\n" +
                  $"Policy types: [{string.Join(", ", policyTypes)}]\n" +
                  $"Providers: {providers.Count}";
        if (providers.Count > 0)
            msg += "\n" + string.Join("\n", providers.OrderBy(x => x).Take(20));

        File.WriteAllText("diag_mc.txt", msg);
        Assert.Fail("See diag_mc.txt");
    }
}
