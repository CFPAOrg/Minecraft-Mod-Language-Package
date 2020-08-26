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

            }

            if (args.Contains("--update"))
            {
                var conf = await Reader.ReadConfig();
                var ms = await Downloader.ParseModFile(conf, await Reader.ReadInfo(conf.CustomSittings.RootFolder));
                Downloader.ExJar(conf, ms);
            }

            if (args.Contains("--formatLow"))
            {
                var conf = await Reader.ReadConfig();
                var ls = Utils.SearchLangFiles(conf);
                await Format.FormatLangFile(ls);
            }

            if (args.Contains("--Ce"))
            {
                var conf = await Reader.ReadConfig();
                await Format.CrateEmptyLangFile(conf);
            }

            if (args.Contains("--Cen"))
            {
                var conf = await Reader.ReadConfig();
                await Format.CrateEmptyJsonFile(conf);
            }
        }
    }
}
