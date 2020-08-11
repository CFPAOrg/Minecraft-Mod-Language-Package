using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Processer
{
    public class Addon
    {
        [JsonPropertyName("targetVersion")]
        public string TargetVersion { get; set; }

        [JsonPropertyName("runDelFiles")]
        public bool RunDelFiles { get; set; }

        [JsonPropertyName("runSortFiles")]
        public bool RunSortFiles { get; set; }

        [JsonPropertyName("modBlackList")]
        public List<string> ModBlackList { get; set; }

        [JsonPropertyName("pathBlackList")]
        public List<string> PathBlackList { get; set; }
    }
}