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
    static class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var a = await ReadInfo();
            a.ForEach(_ => Console.WriteLine(_.ShortProjectUrl));
            //Utils.ProcessFiles();
            //Utils.UpdateInfo();
            //if (config.RunDelFiles)
            //{
            //}

            //if (config.RunSortFiles)
            //{
            //Utils.DelDeduplicationFiles(path, config.TargetVersion);
            //var files = Utils.SearchAllFiles("./", config.TargetVersion);
            //files.ForEach(_ => langFiles.Add(new LangFile(_, config.ModBlackList, config.PathBlackList)));
            //langFiles.ForEach(_ => Log.Information("路径:{0}语言:{1}是否需要处理：{2}",_.LangPath,_.Language,_.IsNeeded));
            //langFiles.ForEach(_ => _.ProcessLangFile());
            //}
        }

        public static async Task<Configuration> ReadConfig()
        {
            var reader = await File.ReadAllBytesAsync(@"./config/processor.json");
            return JsonSerializer.Deserialize<Configuration>(reader);
        }

        public static async Task<List<Info>> ReadInfo()
        {
            //var configuration = ReadConfig();
            var reader = await File.ReadAllBytesAsync(Path.Combine(Configuration.Debug.CustomSittings.RootFolder,"config", "mod_info.json"));
            return JsonSerializer.Deserialize<List<Info>>(reader);
        }
    }
}
