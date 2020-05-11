using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Spider
{
    internal static class Configuration
    {
        public static FileInfo ConfigFileInfo { get; } =
            new FileInfo(Path.Combine(RepositoryPath, "config.json"));

        public static FileInfo LangFileInfo { get; }=new FileInfo(Path.Combine(RepositoryPath,"lang_file_info.json"));
        
        private static JsonElement JsonConfig { get; } = JsonDocument.Parse(
            ConfigFileInfo.OpenRead(), new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            }).RootElement;

        public static string RepositoryPath => Utils.GetTargetParentDirectory(Directory.GetCurrentDirectory(), ".git");
        public static string OutputPath => Path.Combine(RepositoryPath, "project");

        public static int ModCount => JsonConfig.GetProperty("mod_count").GetInt32();
        public static string Version => JsonConfig.GetProperty("game_version").GetString();

        public static List<string> ModBlackList { get; } = JsonConfig.GetProperty("mod_blacklist").EnumerateArray()
            .Select(_ => _.GetString()).ToList();

        public static List<string> AssetDomainBlackList { get; } = JsonConfig.GetProperty("assetdomain_blacklist")
            .EnumerateArray().Select(_ => _.GetString()).ToList();

        public static List<string> LangEntryBlackList { get; } = JsonConfig.GetProperty("key_blacklist")
            .EnumerateArray().Select(_ => _.GetString()).ToList();
    }
}