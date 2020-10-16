using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Serilog;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var config = await JsonSerializer.DeserializeAsync<Configuration[]>(File.OpenRead("./config/spider/config.json"));
            foreach (var configuration in config) {
                var baseMod = await UrlLib.GetModInfoAsync(configuration.SpiderConfiguration.ModCount, configuration.Version);
                var allMod = await UrlLib.GetModInfoWhenInWhiteList(configuration.SpiderConfiguration.WhiteList);
                allMod.AddRange(baseMod);
                await (await (await allMod.ToArray().GenerateBases(configuration.Version).DownloadModAsync()).ParseModAsync(
                    configuration.Version, configuration.SpiderConfiguration.BlackList)).ExtractResource(configuration.Version).WriteToAsync(configuration.Version,"mod_info.json");
            }
        }
    }
}