using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;
using Spider.Models;

namespace Spider.Types
{
    internal static class ModDownloadManager
    {
        public static async Task DownloadModsAsync(IEnumerable<Mod> mods)
        {
            var sw1 = Stopwatch.StartNew();
            var collection = mods.Where(_ => !_.IsInBlackList).ToList();
            await Task.WhenAll(collection.Select(async mod => await DownloadModAsync(mod)
           )).ContinueWith(t =>
            {
                sw1.Stop();
                Log.Information($"所有模组下载完成,耗时{sw1.ElapsedMilliseconds}ms");
            }).ConfigureAwait(false);
            Log.Information($"模组已全部下载完毕,共有{collection.Count}个模组被下载");
        }

        private static async Task DownloadModAsync(Mod mod)
        {
            var sw = Stopwatch.StartNew();
            using var httpClient = new HttpClient();
            try
            {
                mod.Stream = await httpClient.GetStreamAsync(mod.DownloadUrl).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Log.Warning(e,"");
                throw;
            }
            ExtractLangFile(mod);
            sw.Stop();
            Log.Information($"下载了一个模组: {mod.Name},耗时{sw.ElapsedMilliseconds}ms");
        }

        private static void ExtractLangFile(Mod mod)
        {
            var zipArchive = new ZipArchive(mod.Stream, ZipArchiveMode.Read);
            var zipArchiveEntries = zipArchive.Entries.Where(entry =>
                entry.Name.EndsWith("en_us.lang", StringComparison.OrdinalIgnoreCase)).ToList();
            if (zipArchiveEntries.Count == 0)
            {
                mod.IsInBlackList = true;
                mod.Stream.Dispose();
                Log.Information($"跳过了一个无语言文件的模组:{mod.Name}");
                return;
            }

            zipArchiveEntries.ForEach(s => mod.Languages.Add(new Language(mod, s.Open(), s.FullName)));
        }
    }
}