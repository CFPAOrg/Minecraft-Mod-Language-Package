using System;
using System.Text.Json.Serialization;

namespace Spider {
    public class ModBase {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("project_name")] public string ProjectName { get; set; }
        [JsonPropertyName("project_id")] public long ProjectId { get; set; }
        [JsonPropertyName("project_url")] public Uri ProjectUrl { get; set; }
        [JsonPropertyName("download_url")] public Uri DownloadUrl { get; set; }
    }

    public class DownloadMod : ModBase {
        [JsonIgnore]public string ModPath { get; set; }
    }
}
