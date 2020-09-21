using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Processor
{
    public class Info
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("projectId")]
        public long ProjectId { get; set; }

        [JsonIgnore]
        public string ProjectUrl { get; set; }

        [JsonPropertyName("downloadUrl")]
        public string DownloadUrl { get; set; }

        [JsonPropertyName("shortProjectUrl")]
        public string ShortProjectUrl { get; set; }

        [JsonPropertyName("modId")]
        public string ModId { get; set; }

        [JsonPropertyName("assetDomains")]
        public List<string> AssetDomains { get; set; }

        [JsonPropertyName("langAssetsPaths")] public List<string> LangAssetsPaths { get; set; }
    }
}