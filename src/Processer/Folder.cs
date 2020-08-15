using System.Text.Json.Serialization;

namespace Processer
{
    public class Folder
    {
        [JsonPropertyName("root")]
        public string Root { get; set; }

        [JsonPropertyName("projects")]
        public string Projects { get; set; }

        [JsonPropertyName("config")]
        public string Config { get; set; }

        [JsonPropertyName("pending")]
        public string Pending { get; set; }
    }
}