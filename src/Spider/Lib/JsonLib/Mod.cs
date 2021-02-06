using System;
using System.Text.Json.Serialization;

namespace Spider.Lib.JsonLib {
    public class Mod {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("project_name")] public string ProjectName { get; set; }
        [JsonPropertyName("project_id")] public long ProjectId { get; set; }
        [JsonPropertyName("project_url")] public Uri ProjectUrl { get; set; }
        [JsonPropertyName("download_url")] public Uri DownloadUrl { get; set; }
        [JsonPropertyName("tmp_path")] public string TempPath { get; set; }
        [JsonPropertyName("version")] public string Version { get; set; }
    }
}