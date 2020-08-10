using System.Text.Json.Serialization;

namespace Fucker
{
    public class Addon
    {
        [JsonPropertyName("targetVersion")]
        public string TargetVersion { get; set; }

        [JsonPropertyName("runDelFiles")]
        public bool RunDelFiles { get; set; }

        [JsonPropertyName("runSortFiles")]
        public bool RunSortFiles { get; set; }
    }
}