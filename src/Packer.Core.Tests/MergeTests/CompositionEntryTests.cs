using Packer.Core.Model.ResourceFile;
using System.Text.Json;

namespace Packer.Core.Tests.MergeTests;

/// <summary>测试 10：CompositionEntry 笛卡尔积</summary>
public class CompositionEntryTests
{
    static CompositionEntry ParseEntry(string json)
    {
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        var templates = new Dictionary<string, string>();
        foreach (var t in root.GetProperty("templates").EnumerateObject())
            templates[t.Name] = t.Value.GetString()!;

        var parameters = new List<Dictionary<string, string>>();
        foreach (var p in root.GetProperty("parameters").EnumerateArray())
        {
            var dict = new Dictionary<string, string>();
            foreach (var kv in p.EnumerateObject())
                dict[kv.Name] = kv.Value.GetString()!;
            parameters.Add(dict);
        }
        return new CompositionEntry(templates, parameters);
    }

    [Fact]
    public void SingleParam_SingleTemplate()
    {
        var entry = ParseEntry("""
            { "templates": { "item.{0}.name": "{0}" }, "parameters": [{ "apple": "苹果", "banana": "香蕉" }] }
            """);
        var r = entry.BuildDictionary();
        Assert.Equal(2, r.Count);
        Assert.Equal("苹果", r["item.apple.name"]);
    }

    [Fact]
    public void TwoParams_CartesianProduct()
    {
        var entry = ParseEntry("""
            { "templates": { "{0}.{1}": "{1}.{0}" }, "parameters": [{ "a": "1", "b": "2" }, { "x": "!", "y": "?" }] }
            """);
        var r = entry.BuildDictionary();
        Assert.Equal(4, r.Count);
        Assert.Equal("!.1", r["a.x"]);
    }

    [Fact]
    public void ThreeParams_FullProduct()
    {
        var entry = ParseEntry("""
            {"templates":{"{0}{1}{2}":"{0}{1}{2}"},"parameters":[{"A":"a"},{"1":"1"},{"@":"@"}]}
            """);
        var r = entry.BuildDictionary();
        Assert.Single(r);
        Assert.Equal("a1@", r["A1@"]);
    }

    [Fact]
    public void TwoTemplates_FourEntriesEach()
    {
        var entry = ParseEntry("""
            {"templates":{"{0}.name":"{1}","{0}.desc":"{1}描述"},"parameters":[{"sword":"剑","pickaxe":"镐"},{"iron":"铁"}]}
            """);
        var r = entry.BuildDictionary();
        Assert.Equal(4, r.Count); // 2×1 参数 × 2 模板
    }
}
