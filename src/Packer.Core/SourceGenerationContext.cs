using System.Text.Json.Serialization.Metadata;

namespace Packer.Core;


[JsonSerializable(typeof(PackerPolicy))]
[JsonSerializable(typeof(Config))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
    public static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        AllowOutOfOrderMetadataProperties = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        TypeInfoResolver = JsonTypeInfoResolver.Combine(
            Default,
            new DefaultJsonTypeInfoResolver())
    };
}
