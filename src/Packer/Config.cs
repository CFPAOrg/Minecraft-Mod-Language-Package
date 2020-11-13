using System;
using System.Collections.Generic;
using System.Text;
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
        public List<String> ModBlackList { get; set; }

        [JsonPropertyName("domainBlackList")]
        public List<String> DomainBlackList { get; set; }
    }
}
