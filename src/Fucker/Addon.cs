using System.Text.Json.Serialization;

namespace Fucker
{
    public class Addon
    {
        [JsonPropertyName("targetVersion")] 
        public string TargetVersion { get; set; }
        [JsonPropertyName("deleteFile")] 
        public bool DeleteFile { get; set; }
        [JsonPropertyName("sortFile")]
        public bool SortFile { get; set; }
    }
}