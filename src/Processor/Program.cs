using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (args.Length == 0)
            {
                Log.Logger.Information("请输入参数!");
                return;
            }
            else
            {
                foreach (var s in args)
                {
                    Log.Logger.Information($"参数 {s}");
                }
            }

            if (args.Contains("--DEBUG"))
            {
                //var a = await Reader.ReadInfo(Configuration.Debug.CustomSittings.RootFolder);
                var b = await Reader.ReadConfig();
                //a.ForEach(async _ => await Console.Out.WriteLineAsync(_.ShortProjectUrl));
                //var c = FolderBuilder.CheckProjectFolder(Configuration.Debug);
                var d = await Downloader.ParseModFile(b, await Reader.ReadInfo(b.CustomSittings.RootFolder));
                //d.ForEach(async _ =>await Console.Out.WriteLineAsync(_.Name));
                Downloader.ExJar(b, d);
                //Downloader.ExJar(Configuration.Debug, new List<PendingMod>() { new PendingMod() { Domains = new List<string>() { "chisel_guide", "chisel" }, ModPath = @"C:\Users\Nullpinter\Downloads\Chisel-MC1.12.2-1.0.2.45.jar", Name = "1919810" } });
                //Console.WriteLine(c);
            }

            if (args.Contains("--update"))
            {
                var conf = await Reader.ReadConfig();
                var ms = await Downloader.ParseModFile(conf, await Reader.ReadInfo(conf.CustomSittings.RootFolder));
                Downloader.ExJar(conf, ms);
            }
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
    }
}
