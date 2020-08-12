using System.Text.Json.Serialization;

namespace Processer
{
    public class Folder
    {
        [JsonPropertyName("rubbish")]
        public string Rubbish { get; set; }

        [JsonPropertyName("extendResource")]
        public string ExtendResource { get; set; }

        [JsonPropertyName("langResource")]
        public string LangResource { get; set; }

        [JsonPropertyName("config")]
        public string Config { get; set; }

        [JsonPropertyName("pullRequests")]
        public string PullRequests { get; set; }
    }
}