using System;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Serilog;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            var mods = await Urllib.GetModInfoAsync(10, "1.12.2");
            Log.Logger.Information("已获取10个mod信息");
            var a = Filelib.GenerateModBase(mods, "1.12.2");
            a.ForEach(_ => Console.WriteLine(_.ProjectName));
            var b = await Filelib.DownloadModAsync(a);
            b.ForEach(_ => Console.WriteLine(_.ModPath));
        }
    }
}