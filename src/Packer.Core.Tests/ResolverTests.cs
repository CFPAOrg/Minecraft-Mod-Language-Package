using Packer.Core.Model.PackerPolicys;
using System.Text.Json;

namespace Packer.Core.Tests;

public class ResolverTests
{
    [Fact]
    public void JsonOptions_Can_Deserialize_PackerPolicy()
    {
        var json = """[{ "type": "direct" }]""";
        var result = JsonSerializer.Deserialize<PackerPolicy>(json, SourceGenerationContext.JsonOptions);
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public void UnregisteredType_FallsBack_To_Reflection()
    {
        var json = """{ "name": "张三", "age": 18 }""";
        var result = JsonSerializer.Deserialize<Student>(json, SourceGenerationContext.JsonOptions);
        Assert.NotNull(result);
        Assert.Equal("张三", result.Name);
        Assert.Equal(18, result.Age);
    }

    class Student
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
