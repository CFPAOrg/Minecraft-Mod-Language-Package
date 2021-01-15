
using Newtonsoft.Json;

namespace Spider.JsonLib {
    public class Configuration {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("spider_conf")]
        public SpiderConfiguration SpiderConfiguration { get; set; }
    }

    public class SpiderConfiguration {
        [JsonProperty("base_mod_count")]
        public int ModCount { get; set; }
        [JsonProperty("black_list")]
        public string[] BlackList { get; set; }
        [JsonProperty("white_list")]
        public string[] WhiteList { get; set; }
    }
}