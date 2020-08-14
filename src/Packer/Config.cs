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

        [JsonPropertyName("blockList")]
        public List<string> BlockList { get; set; }
    }
}
