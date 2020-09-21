using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Processor
{
    public class Configuration
    {
        public static Configuration Debug = new Configuration()
        {
            VersionList = new List<string>(){"1.12.2"},
            CheckProjectsFolder = true,
            DownloadModFiles = true,
            CustomSittings = new CustomSittings()
            {
                ProjectsFolder = @"D:\repos\Minecraft-Mod-Language-Package\projects",
                RootFolder = @"D:\repos\Minecraft-Mod-Language-Package"
            }
        };
        [JsonPropertyName("custom_setting")]
        public CustomSittings CustomSittings { get; set; }

        [JsonPropertyName("targetVersion")]
        public List<string> VersionList { get; set; }

        [JsonPropertyName("check_project_folder")]
        public bool CheckProjectsFolder { get; set; }

        [JsonPropertyName("download_mod_files")]
        public bool DownloadModFiles { get; set; }

        [JsonPropertyName("black_list")]
        public List<string> BlackList { get; set; }
    }

    public class CustomSittings
    {
        [JsonPropertyName("projects_folder")]
        public string ProjectsFolder { get; set; }

        [JsonPropertyName("root_folder")]
        public string RootFolder { get; set; }
    }
}