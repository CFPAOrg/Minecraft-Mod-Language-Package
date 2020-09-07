using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Spider {
    public class Conf {
        [JsonPropertyName("version")] public string Version { get; set; }
        [JsonPropertyName("base_mod_count")] public long ModCount { get; set; }
        [JsonPropertyName("black_list")] public List<string> BlackList { get; set; }
        [JsonPropertyName("white_list")] public List<string> WhiteList { get; set; }
    }

    public class ScanConf {
        [JsonPropertyName("black_list")] public List<string> BlackList { get; set; }
        [JsonPropertyName("white_list")] public List<string> WhiteList { get; set; }
    }

    public class Info {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("project_name")] public string ProjectName { get; set; }
        [JsonPropertyName("project_id")] public long ProjectId { get; set; }
        [JsonPropertyName("mod_id")] public string ModId { get; set; }
        [JsonPropertyName("mod_domain")] public List<string> Domain { get; set; }
        [JsonPropertyName("has_language_folder")]
        public bool HasLang { get; set; }
    }
}