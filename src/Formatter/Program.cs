using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Serilog;

namespace Formatter
{
    static class Program
    {
        static async Task Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .CreateLogger();
            var bl = await Util.ReadBlackKey();
            var l = Util.SearchLangFiles();
            var j = Util.SearchJsonFiles();
            await Util.FormatLangFile(l, bl);
            await Util.FormatJsonFile(j, bl);
        }
    }
}
