using Packer.Core.Model;
using Packer.Core.Model.Abstract;
using Packer.Core.Model.Configuration;
using Packer.Core.Model.ModProvider;
using Packer.Core.Model.ResourceFile;
using Serilog;
using System.IO.Compression;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Packer.Core.Tests;

public class IntegrationTests
{
    private static readonly Lazy<HashSet<string>> _dests = new(() => RunPack("1.21"));
    private static readonly HashSet<string> _empty = [];

    static IntegrationTests()
    {
        Environment.CurrentDirectory = @"C:\Users\16229\source\OpenSourceLibrary\Minecraft-Mod-Language-Package";
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Warning()
            .CreateLogger();
    }

    private static HashSet<string> RunPack(string version)
    {
        var config = JsonSerializer.Deserialize<Config>(
            File.ReadAllText($"config/packer/{version}.json"),
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver()
            })!;

        var provider = new AssetsModProvider();
        var namespaces = provider.GetModsByVersion(version);
        var filtered = namespaces.Where(g => !config.Base.ExclusionMods.Contains(g.Key));
        var allProviders = filtered
            .SelectMany(g => g)
            .Where(ns => !config.Base.ExclusionNamespaces.Contains(ns.NamespaceName))
            .SelectMany(ns => ns.PackerPolicies
                .SelectMany(p => p.CreateProviders(ns, config.Floating.Merge(ns.LocalConfig))))
            .ToList();

        var groups = allProviders.ToLookup(p => p.Destination);
        var merged = groups.Select(group =>
        {
            if (!group.Skip(1).Any()) return group.First();
            if (group.All(p => p is KVPFile))
            {
                var r = group.Cast<KVPFile>().Aggregate((a, n) => a.Merge(n));
                if (r is ResourceFileProvider rfp) rfp.Namespace = group.Cast<KVPFile>().First().Namespace;
                return r;
            }
            return group.First();
        }).ToList();

        foreach (var p in merged.OfType<TextFile>())
            p.EffectiveConfig = config.Floating;

        var initial = new List<IResourceFileProvider>
        {
            new RawFile("./projects/templates/pack.png", "pack.png"),
            new TextFile(File.ReadAllText("./projects/templates/LICENSE"), "LICENSE"),
            config.Base.LoadReadmeTemp(),
            config.Base.LoadMetaTemp()
        };

        var dests = new HashSet<string>();
        using var ms = new MemoryStream();
        using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, leaveOpen: true))
        {
            foreach (var p in merged.Concat(initial))
            {
                using var content = p.GetContentStream();
                var entry = archive.CreateEntry(p.Destination);
                using var es = entry.Open();
                content.CopyTo(es);
                dests.Add(p.Destination);
            }
        }
        return dests;
    }

    private HashSet<string> Dests => _dests.Value;

    [Fact]
    public void Createdeco_Composition_Output()
        => Assert.Contains("assets/createdeco/lang/zh_cn.json", Dests);

    [Fact]
    public void Justhammers_Indirect_Output()
        => Assert.Contains("assets/justhammers/lang/zh_cn.json", Dests);

    [Fact]
    public void Minecraft_Font_Assets()
    {
        Assert.Contains("assets/minecraft/font/default.json", Dests);
        Assert.Contains("assets/minecraft/font/uniform.json", Dests);
        Assert.Contains("assets/minecraft/textures/font/2em_dash.png", Dests);
    }

    [Fact]
    public void No_Composition_Source_Files()
    {
        Assert.DoesNotContain("assets/createdeco/lang/zh_cn-composition.json", Dests);
        Assert.DoesNotContain("assets/bibliobiomes/lang/zh_cn-composition.json", Dests);
    }
}
