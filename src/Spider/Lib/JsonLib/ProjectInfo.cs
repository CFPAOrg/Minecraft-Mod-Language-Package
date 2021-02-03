using System.Text.Json.Serialization;

namespace Spider.Lib.JsonLib {
    public class ProjectInfo {
        [JsonPropertyName("curseforge_id")]
        public long CFId { get; set; }

        [JsonPropertyName("patchouli_book")]
        public bool PatchouliBook { get; set; }

        [JsonPropertyName("update_chinese")]
        public bool UpdateChinese { get; set; }

        [JsonPropertyName("non_update")]
        public bool NonUpdate { get; set; }
    }
}