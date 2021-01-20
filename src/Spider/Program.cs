using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using Formatter;
using Serilog;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var a= new Downloader(1500,new Timer(1000));
            a.Log += (s, e) => Log.Logger.Information($"test{e.DownloadedCount},{e.ModCount}");
            Console.ReadLine();
        }
    }
}