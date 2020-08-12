using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Serilog;
using Serilog.Core;

namespace Processer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var folder = ReaderFolder();
            var langFiles = new List<LangFile>();
            var config = ReaderConfig(folder.Config);
            if (config.RunDelFiles)
            {
            }

            if (config.RunSortFiles)
            {
            }
        }

        static Config ReaderConfig(string path)
        {
            var reader = File.ReadAllBytes(path + "/processer.json");
            return JsonSerializer.Deserialize<Config>(reader);
        }

        static Folder ReaderFolder()
        {
            var reader = File.ReadAllBytes("./config/folder.json");
            return JsonSerializer.Deserialize<Folder>(reader);
        }
    }
}
