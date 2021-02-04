using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using Formatter;
using Language.Core;
using Serilog;
using Spider.Lib.JsonLib;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var a = new Downloader(1000, "1.12.2", new Timer(20000));
            a.Log += (s, e) => Log.Logger.Information($"test{e.DownloadedCount},{e.ModCount}");
            var b = await a.Start();
            b.ForEach(_ => Console.WriteLine(_.Name));
            Console.ReadLine();
        }
    }
}