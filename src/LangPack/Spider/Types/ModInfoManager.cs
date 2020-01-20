using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Spider.Data;
using Spider.Models;

namespace Spider.Types
{
    internal static class ModInfoManager
    {
        public static async Task DownloadModInfosAsync()
        {
            foreach (var mod in await GetModFilesAsync()) //装入所有mod到数据库
                if (DataStore.Mods.Exists(m => m == mod))
                {
                    if (DataStore.Mods.FindById(mod.Id).Modified < mod.Modified) DataStore.Mods.Update(mod);
                }
                else
                {
                    DataStore.Mods.Insert(mod);
                }
        }

        private static async Task<IEnumerable<Mod>> GetModFilesAsync()
        {
            var pageCount = int.Parse(Settings.Config.GetProperty("mod_page").ToString());
            var version = Settings.Config.GetProperty("version").ToString();
            var pageSize = Settings.Config.GetProperty("mod_pagesize").ToString();
            var tasks = Enumerable.Range(0, pageCount).Select(n => n * pageCount)
                .Select(async n =>
                {
                    using var httpClient = new HttpClient
                    {
                        BaseAddress = new Uri("https://addons-ecs.forgesvc.net")
                    };
                    var str = await httpClient.GetStringAsync(
                        $"/api/v2/addon/search?categoryId=0&gameId=432&gameVersion={version}&index={n}&pageSize={pageSize}&sectionId=6&sort=1");
                    return JsonDocument.Parse(str).RootElement;
                });
            var jsons = await Task.WhenAll(tasks);
            return jsons.SelectMany(GetMods);
        }

        static IEnumerable<Mod> GetMods(JsonElement json)
        {
            foreach (var entry in json.EnumerateArray())
            {
                Console.WriteLine($"找到了名为{entry.GetProperty("name").GetString()}的mod");
                yield return new Mod
                {
                    Id = entry.GetProperty("id").GetInt64(),
                    Modified = DateTime.Parse(entry.GetProperty("dateModified").GetString(), null,
                        DateTimeStyles.RoundtripKind),
                    Name = entry.GetProperty("name").GetString(),
                    FileId = entry.GetProperty("latestFiles")[0].GetProperty("id").GetInt64().ToString(),
                    DownloadUrl = entry.GetProperty("latestFiles")[0].GetProperty("downloadUrl").GetString()
                };
            }
        }
    }
}