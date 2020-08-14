using System.Text.Json.Serialization;

namespace Processer
{
    public class Folder
    {
        [JsonPropertyName("rubbish")]
        public string Rubbish { get; set; }

        [JsonPropertyName("projects")]
        public string Projects { get; set; }

        [JsonPropertyName("config")]
        public string Config { get; set; }

        [JsonPropertyName("pending")]
        public string Pending { get; set; }
    }
}