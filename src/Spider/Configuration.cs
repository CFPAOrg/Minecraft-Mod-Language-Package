using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Spider
{
    public class Configuration
    {
        private static Configuration _current;

        public static Configuration Current => _current ?? Default;

        public Configuration()
        {
            
        }
        public static Configuration Default { get; }=new Configuration()
        {
            EnabledGameVersions = new List<string>{"1.12.2"},
            ModCount = 5,
            VersionsPath = "./projects/versions.json",
            ModInfoPath = "./modInfo.json"
        };

        public static async Task InitializeConfigurationAsync(string configPath)
        {
            var fullPath = Path.GetFullPath(configPath);
            try
            {
                _current = JsonSerializer.Deserialize<Configuration>(await File.ReadAllBytesAsync(fullPath));
            }
            catch (Exception e)
            {
                Log.Error(e, "");
            }
            
        }

        [JsonPropertyName("enabledGameVersions")]
        public List<string> EnabledGameVersions { get; set; }

        [JsonPropertyName("modCount")]
        public int ModCount { get; set; }

        [JsonPropertyName("versionsPath")]
        public string VersionsPath { get; set; }

        [JsonPropertyName("modInfoPath")]
        public string ModInfoPath { get; set; }
    }
}
