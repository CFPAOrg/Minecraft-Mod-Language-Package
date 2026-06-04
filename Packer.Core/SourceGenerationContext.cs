using System.Text.Json.Serialization.Metadata;

namespace Packer.Core;

internal partial class SourceGenerationContext
{
    public static JsonSerializerOptions Options { get; } = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        AllowOutOfOrderMetadataProperties = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver()
    };
}
