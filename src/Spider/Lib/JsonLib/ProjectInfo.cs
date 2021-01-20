using Newtonsoft.Json;

namespace Spider.Lib.JsonLib {
    public class ProjectInfo {
        [JsonProperty("curseforge_id")]
        public long CFId { get; set; }

        [JsonProperty("patchouli_book")]
        public bool PatchouliBook { get; set; }

        [JsonProperty("update_chinese")]
        public bool UpdateChinese { get; set; }

        [JsonProperty("non_update")]
        public bool NonUpdate { get; set; }
    }
}