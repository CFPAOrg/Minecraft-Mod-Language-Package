using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using Spider.Lib.JsonLib;

namespace Spider.Lib.FileLib
{
    public static class JsonReader
    {
        /// <summary>
        /// 读取对应版本的name->id映射
        /// </summary>
        /// <param name="version"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<Dictionary<string, long>> ReadIntroAsync(string version, string path)
        {
            if (!File.Exists(@$"{Directory.GetCurrentDirectory()}\config\spider\{path}\intro.json"))
            {
                await UrlLib.GetAllModIntroAsync(version, path);
            }
            var obj = await JsonSerializer.DeserializeAsync<ModIntro[]>(File.OpenRead(@$"{Directory.GetCurrentDirectory()}\config\spider\{path}\intro.json"));
            var dict = new Dictionary<string, long>();
            foreach (var modIntro in obj!)
            {
                dict.TryAdd(modIntro.Name, modIntro.Id);
            }

            return dict;
        }

        /// <summary>
        /// 读取爬虫配置
        /// </summary>
        /// <returns></returns>
        public static async Task<Config[]> ReadConfigAsync()
        {
            return await JsonSerializer.DeserializeAsync<Config[]>(
                File.OpenRead(@$"{Directory.GetCurrentDirectory()}\config\spider\config.json"));
        }
    }
}