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

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            //var a= new Downloader(1500,new Timer(1000));
            //a.Log += (s, e) => Log.Logger.Information($"test{e.DownloadedCount},{e.ModCount}");
            //var l = new LangFormatter(new StreamReader(File.OpenRead(@"C:\Users\Nullpinter\Desktop\ProcessMonitor\z.lang")),new StreamWriter(File.OpenWrite(@"C:\Users\Nullpinter\Desktop\ProcessMonitor\a.lang")));
            //l.Format();
            var b = new JsonFormatter(new StreamReader(@"C:\Users\Nullpinter\Desktop\ProcessMonitor\2.json"),new StreamWriter(@"C:\Users\Nullpinter\Desktop\ProcessMonitor\3.json"),"nms");
            b.Format();
            Console.ReadLine();
        }
    }
}