using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Fucker
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\repos\Minecraft-Mod-Language-Package/";
            var config = ReaderConfig(path);
            if (config.RunDelFiles)
            {
                Utils.DelFiles(path, config.TargetVersion);
            }

            if (config.RunSortFiles)
            {
                Utils.SortFiles(path, config.TargetVersion);
            }
        }

        static Addon ReaderConfig(string path)
        {
            var reader = File.ReadAllBytes(path + "config/fucker.json");
            return JsonSerializer.Deserialize<Addon>(reader);
        }
    }
}
