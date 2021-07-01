
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spider.Lib.JsonLib {
    public class Config {
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("list")]
        public List List { get; set; }
        [JsonPropertyName("default_configuration")]
        public Configuration Configuration { get; set; }
        [JsonPropertyName("custom_configuration")]
        public IncompleteConfiguration[] CustomConfigurations { get; set; }
    }

    public class List {
        [JsonPropertyName("black_list")] public string[] BlackList { get; set; }
        [JsonPropertyName("white_list")] public string[] WhiteList { get; set; }
    }

    public class Configuration:IncompleteConfiguration {
        [JsonPropertyName("included_path")] public string[] IncludedPath { get; set; }
        [JsonPropertyName("extract_path")] public string[] ExtractPath { get; set; }
        [JsonPropertyName("update_chinese")] public bool UpdateChinese { get; set; }
        [JsonPropertyName("non_update")] public bool NonUpdate { get; set; }
    }

    public class IncompleteConfiguration {
        [JsonPropertyName("project_name")] public string ProjectName { get; set; }
        [JsonPropertyName("version")] public string Version { get; set; }
        [JsonExtensionData] public Dictionary<string,JsonElement> ExtensionData { get; set; }
    }
}