using System;
using System.IO;
using System.Text.Json;

namespace Spider
{
    static class Settings
    {

        public static string WorkPath => Utils.GetParentContainsSpecificDirectory(Environment.CurrentDirectory, ".git");
        public static JsonElement Config { get; private set; } = JsonDocument.Parse(File.ReadAllText(Path.Combine(WorkPath,"./config.json"))).RootElement;
    }
}
