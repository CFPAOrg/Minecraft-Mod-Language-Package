using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

namespace Processor
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var langFiles = new List<LangFile>();
            var config = ReaderConfig();
            Utils.ProcessFiles();
            Utils.UpdateInfo();
            if (config.RunDelFiles)
            {
            }

            if (config.RunSortFiles)
            {
                //Utils.DelDeduplicationFiles(path, config.TargetVersion);
                //var files = Utils.SearchAllFiles("./", config.TargetVersion);
                //files.ForEach(_ => langFiles.Add(new LangFile(_, config.ModBlackList, config.PathBlackList)));
                //langFiles.ForEach(_ => Log.Information("路径:{0}语言:{1}是否需要处理：{2}",_.LangPath,_.Language,_.IsNeeded));
                //langFiles.ForEach(_ => _.ProcessLangFile());
            }
        }

        public static Configuration ReaderConfig()
        {
            //var reader = File.ReadAllBytes(Path.Combine(foder.Config, "processer.json"));
            //return JsonSerializer.Deserialize<Configuration>(reader);
        }
    }
}
