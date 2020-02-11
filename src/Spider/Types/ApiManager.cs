using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Spider.Models;

namespace Spider.Types
{
    internal static class ApiManager
    {
        public static async Task<IEnumerable<Mod>> GetModsAsync()
        {
            var sw = Stopwatch.StartNew();
            Log.Information("开始从Api获取模组信息.");
            var count = Configuration.ModCount;
            var counter = count;
            using var httpClient = new HttpClient();
            var str = await httpClient.GetStringAsync(
                $"https://addons-ecs.forgesvc.net/api/v2/addon/search?categoryId=0&gameId=432&index=0&pageSize={count}&gameVersion={Configuration.Version}&sectionId=6&sort=1");
            var json = JsonDocument.Parse(str).RootElement;
            var result =  json.EnumerateArray().Select(j =>
            {
                var gameVersionLatestFiles = j.GetProperty("gameVersionLatestFiles").EnumerateArray().ToList();
                var gameVersionLatestFile = gameVersionLatestFiles.First(_ => _.GetProperty("gameVersion").GetString()==Configuration.Version);
                var projectFileId = gameVersionLatestFile.GetProperty("projectFileId").GetInt32().ToString();
                var projectFileName = gameVersionLatestFile.GetProperty("projectFileName").GetString();
                var downloadUrl = Utils.GetDownloadUrl(projectFileId, projectFileName);
                var id = j.GetProperty("id").GetInt64();
                var name = j.GetProperty("name").GetString();
                var url = j.GetProperty("websiteUrl").GetString();
                var mod = new Mod(id) { Name = name, DownloadUrl = downloadUrl, Url = url };
                if (!Configuration.ModBlackList.Contains(mod.ShortUrl)) return mod;
                Interlocked.Decrement(ref counter);
                Log.Information($"跳过了一个黑名单中的模组:{mod.Name}");
                mod.IsInBlackList = true;
                return mod;
            });
            sw.Stop();
            Log.Information($"成功获取所有模组信息，耗时{sw.ElapsedMilliseconds}ms.");
            return result;
        }
    }
}