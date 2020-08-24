using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Processor
{
    public static class Reader
    {
        public static async Task<Configuration> ReadConfig()
        {
            var reader = await File.ReadAllBytesAsync(@"./config/processor.json");
            return JsonSerializer.Deserialize<Configuration>(reader);
        }

        public static async Task<List<Info>> ReadInfo(string rootPath)
        {
            //var configuration = ReadConfig();
            var reader = await File.ReadAllBytesAsync(Path.Combine(rootPath, "config", "mod_info.json"));
            return JsonSerializer.Deserialize<List<Info>>(reader);
        }
    }
}