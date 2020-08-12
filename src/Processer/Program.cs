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
            var langFiles = new List<LangFile>();
            var path = @"./";
            var config = ReaderConfig(path);
            if (config.RunDelFiles)
            {
            }

            if (config.RunSortFiles)
            {
                //Utils.DelDeduplicationFiles(path, config.TargetVersion);
                var files = Utils.SearchAllFiles(path, config.TargetVersion);
                files.ForEach(_ => langFiles.Add(new LangFile(_, config.ModBlackList, config.PathBlackList)));
                //langFiles.ForEach(_ => Log.Information("路径:{0}语言:{1}是否需要处理：{2}",_.LangPath,_.Language,_.IsNeeded));
                langFiles.ForEach(_ => _.ProcessLangFile(_));
            }
        }

        static Config ReaderConfig(string path)
        {
            var reader = File.ReadAllBytes(path + "config/processer.json");
            return JsonSerializer.Deserialize<Config>(reader);
        }
    }
}
