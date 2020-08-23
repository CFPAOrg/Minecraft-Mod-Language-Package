using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Processor
{
    public abstract class Configuration
    {
        [JsonPropertyName("custom_setting")]
        public CustomSittings CustomSittings { get; set; }

        [JsonPropertyName("targetVersion")]
        public List<string> VersionList { get; set; }

        [JsonPropertyName("check_project_folder")]
        public bool CheckProjectsFolder { get; set; }

        [JsonPropertyName("download_mod_files")]
        public bool DownloadModFiles { get; set; }
    }

    public abstract class CustomSittings
    {
        [JsonPropertyName("projects_folder")]
        public string ProjectsFolder { get; set; }

        [JsonPropertyName("root_folder")]
        public string RootFolder { get; set; }
    }
}