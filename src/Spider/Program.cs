using System.Collections.Generic;
using System.Threading.Tasks;

using Serilog;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var list = new List<Configuration>();
            list.Add(new Configuration { BlackKeyList = new []{"null"}, SpiderConfiguration = new SpiderConfiguration { BlackList = new[] { "null" }, ModCount = 10, WhiteList = new[] { "null" } }, Version = "1.16.1" });
            list.Add(new Configuration { BlackKeyList = new[] { "null" }, SpiderConfiguration = new SpiderConfiguration { BlackList = new[] { "null" }, ModCount = 10, WhiteList = new[] { "null" } }, Version = "1.12.2" });
            foreach (var configuration in list) {
                var mods = await UrlLib.GetModInfoAsync(20, configuration.Version);
                var wl = await UrlLib.GetModInfoWhenInWhiteList(configuration.SpiderConfiguration.WhiteList);
                wl.AddRange(mods);
                var p = wl.ToArray();
                Log.Logger.Information("已获取10个mod信息");
                await (await (await p.GenerateBases(configuration.Version).DownloadModAsync()).ParseModAsync(configuration.Version,configuration.SpiderConfiguration.BlackList))
                    .ExtractResource(configuration.Version).WriteToAsync(configuration.Version,"mod_info.json");
            }
        }
    }
}