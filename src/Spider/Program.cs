using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

using Serilog;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            var list = new List<Configuration>() { new Configuration() { SpiderConfiguration = null, Version = "1.12.2" } };
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var mods = await UrlLib.GetModInfoAsync(10, "1.12.2");
            Log.Logger.Information("已获取10个mod信息");
            await (await (await mods.GenerateBases("1.12.2").DownloadModAsync()).ParseModAsync()).ExtractResource("1.12.2").WriteToAsync("./a.json");
        }
    }
}