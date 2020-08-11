using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Spider
{
    public class Mod
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("projectId")]
        public long ProjectId { get; set; }
        [JsonPropertyName("projectUrl")]
        public Uri ProjectUrl { get; set; }
        [JsonPropertyName("downloadUrl")]
        public Uri DownloadUrl { get; set; }
        [JsonPropertyName("modId")]
        public string ModId { get; set; }
        [JsonPropertyName("languageFilePaths")]
        public List<string> LanguageFilePaths { get; set; }
        [JsonIgnore]
        public string Path { get; set; }
    }
}
