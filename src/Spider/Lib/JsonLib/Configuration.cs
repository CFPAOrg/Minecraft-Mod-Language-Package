
using System.Text.Json.Serialization;

namespace Spider.Lib.JsonLib {
    public class Configuration {
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("spider_conf")]
        public SpiderConfiguration SpiderConfiguration { get; set; }
    }

    public class SpiderConfiguration {
        [JsonPropertyName("base_mod_count")]
        public int ModCount { get; set; }
        [JsonPropertyName("black_list")]
        public string[] BlackList { get; set; }
        [JsonPropertyName("white_list")]
        public string[] WhiteList { get; set; }
    }
}