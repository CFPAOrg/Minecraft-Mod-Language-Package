using System.Text.Json.Serialization;

namespace Packer.Models {
    /// <summary>
    /// .mcmeta format
    /// </summary>
    public class McMeta {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("pack")] public McMetaPack Pack { get; set; }
    }

    /// <summary>
    /// pack format
    /// </summary>
    public class McMetaPack {
        /// <summary>
        /// version
        /// </summary>
        [JsonPropertyName("pack_format")] public int Format { get; set; }
        /// <summary>
        /// description
        /// </summary>
        [JsonPropertyName("description")] public string Description { get; set; }
    }
}