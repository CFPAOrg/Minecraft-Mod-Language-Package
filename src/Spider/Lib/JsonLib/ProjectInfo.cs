using System.Text.Json.Serialization;

namespace Spider.Lib.JsonLib {
    public class ProjectInfo {
        [JsonPropertyName("curseforge_id")]
        public long CfId { get; set; }

        [JsonPropertyName("curseforge_name")]
        public string CfName { get; set; }

        [JsonPropertyName("domain")]
        public string[] Domains { get; set; }
    }
}