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
using Spider.Lib.FileLib;
using Spider.Lib.JsonLib;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var config = await ReadLib.ReadConfigAsync();
            var a = new Downloader(10, "1.12.2", config, new Timer(20000));
            a.Log += (s, e) => Log.Logger.Information($"已下载：{e.DownloadedCount}\t共：{e.ModCount}");
            var b = await a.Start();
            b.ForEach(_ => Console.WriteLine(_.Name));
            Console.ReadLine();
        }
    }
}