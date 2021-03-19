using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Packer
{
    class Config
    {
        [JsonPropertyName("targetVersion")]
        public string Version { get; set; }

        [JsonPropertyName("additionalContent")]
        public List<string> FilesToInitialize { get; set; }

        [JsonPropertyName("modNameBlackList")]
        public List<string> ModBlackList { get; set; }

        [JsonPropertyName("domainBlackList")]
        public List<string> DomainBlackList { get; set; }

        [JsonPropertyName("noProcessNamespace")]
        public List<string> BypassedNamespace { get; set; }
    }
}
