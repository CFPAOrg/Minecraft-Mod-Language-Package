using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace Spider {
    public class Configuration {
        [JsonPropertyName("version")] public string Version { get; set; }
        [JsonPropertyName("spider_conf")] public SpiderConfiguration SpiderConfiguration { get; set; }
        [JsonPropertyName("black_key_list")] public List<string> BlackKeyList { get; set; }
    }

    public class SpiderConfiguration {
        [JsonPropertyName("base_mod_count")] public long ModCount { get; set; }
        [JsonPropertyName("black_list")] public List<string> BlackList { get; set; }
        [JsonPropertyName("white_list")] public List<string> WhiteList { get; set; }
    }
}