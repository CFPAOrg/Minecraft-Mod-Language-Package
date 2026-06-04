using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization.Metadata;

namespace Packer.Core;

[JsonSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, 
    AllowOutOfOrderMetadataProperties = true
    )]
[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(PackerPolicyItem))]
[JsonSerializable(typeof(PackerPolicy))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
    public static JsonSerializerOptions Options { get; } = new JsonSerializerOptions(Default.GeneratedSerializerOptions)
    { 
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        TypeInfoResolver = JsonTypeInfoResolver.Combine(
                Default.GeneratedSerializerOptions.TypeInfoResolver,  // 优先使用源生成
                new DefaultJsonTypeInfoResolver()), // 回退到反射 		
    };
}
