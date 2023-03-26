using System.Text.Json.Serialization;

namespace Packer.Models
{
    /// <summary>
    /// MCMETA格式<br></br>
    /// 唯一用处是写修改日期
    /// </summary>
    public class McMeta
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("pack")] public McMetaPack Pack { get; set; }
    }

    /// <summary>
    /// </summary>
    public class McMetaPack
    {
        /// <summary>
        /// </summary>
        [JsonPropertyName("pack_format")] public int Format { get; set; }
        /// <summary>
        /// </summary>
        [JsonPropertyName("description")] public string Description { get; set; }
    }
}