using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using Serilog;

namespace Packer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            var config = RetrieveConfig();
            Log.Information("Starting packaging......");
            // 可以改这个zip的名字吗？有可能是breaking
            ZipFile.CreateFromDirectory($"./projects/langresource/{config.Version}", "./Minecraft-Mod-Language-Package.zip");
            Log.Information("Successfully wrote the pack to ./Minecraft-Mod-Language-Package.zip .")
        }

        static Config RetrieveConfig()
        {
            var reader = File.ReadAllBytes("./config/packer.json");
            return JsonSerializer.Deserialize<Config>(reader);
        }
    }
}
