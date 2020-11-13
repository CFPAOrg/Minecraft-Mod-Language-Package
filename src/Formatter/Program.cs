using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;

namespace Formatter
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var config = await JsonSerializer.DeserializeAsync<Configuration[]>(File.OpenRead("./config/spider/config.json"));
            var bl = await Util.ReadBlackKey();
            foreach (var configuration in config) {
                var file = Util.SearchLangFiles(configuration.Version);
                await Util.FormatLangFile(file, bl);
                var a = await Util.ReadReplaceFontMap();
                await Util.ReplaceFontInLang(configuration.Version, a);
            }
        }
    }
}
