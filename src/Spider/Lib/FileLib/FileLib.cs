using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Spider.Lib.JsonLib;

namespace Spider.Lib.FileLib {
    public static partial class FileLib {
        public static async Task<Dictionary<string, long>> ReadIntro(string version) {
            var obj = await JsonSerializer.DeserializeAsync<ModIntro[]>(File.OpenRead(@$"{Directory.GetCurrentDirectory()}\config\spider\{version}\intro.json"));
            var dict = new Dictionary<string, long>();
            foreach (var modIntro in obj) {
                dict.Add(modIntro.Name,modIntro.Id);
            }

            return dict;
        }
    }
}