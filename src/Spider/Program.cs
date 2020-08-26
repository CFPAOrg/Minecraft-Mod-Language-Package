using Serilog;
using Spider.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Spider
{
    internal static class Program
    {
        private static async Task Main()
        {
            Directory.CreateDirectory(Configuration.OutputPath);
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var mods = (await GetModsAsync()).ToList();
            await DownloadModsAsync(mods);
            ProcessLangFiles(mods);
            var languages = mods.SelectMany(_ => _.Languages).Where(_ => !_.IsInBlackList).ToList();
            Log.Information($"共收集到了{languages.Count}个语言文件.");
            foreach (var language in languages)
            {
                try
                {
                    _  = languages.Single(_ => _.AssetDomain == language.AssetDomain);
                }
                catch
                {
                    language.AssetDomain = $"{language.AssetDomain}-{language.BaseMod.ShortUrl}";
                }
                var path = $"assets/{language.AssetDomain}/lang/";
                var directoryInfo = Directory.CreateDirectory(Path.Combine(Configuration.OutputPath, path));
                if (!directoryInfo.EnumerateFiles().Any(_=>_.Name.EndsWith("zh_cn.lang")))
                {
                    File.Create(Path.Combine(Configuration.OutputPath, path, "zh_cn.lang")).Dispose();
                }
                var fullPath = Path.Combine(Configuration.OutputPath, path, "en_us.lang");
                File.WriteAllText(fullPath, language.OutPutText);
                Log.Information($"写入了一个语言文件到: {fullPath}");
            }

            var sw = Configuration.LangFileInfo.CreateText();
            var str = JsonSerializer.Serialize(languages);
            sw.Write(str);
            Log.Information($"写入了一个语言文件信息到: {Configuration.LangFileInfo.FullName}");
            sw.Dispose();
            foreach (var mod in mods)
            {
                mod.Dispose();
            }
            Log.CloseAndFlush();
        }

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
            }).ToList();
            sw.Stop();
            Log.Information($"成功获取所有{result.Count}个模组的信息，耗时{sw.ElapsedMilliseconds}ms.");
            return result;
        }

        public static void ProcessLangFiles(IEnumerable<Mod> mods)
        {
            var sw1 = Stopwatch.StartNew();
            var collection = mods.Where(_ => !_.IsInBlackList).SelectMany(_ => _.Languages).ToList();
            var assetDomainBlackList = Configuration.AssetDomainBlackList;
            collection.ForEach(_ =>
            {
                var assetDomain = _.AssetDomain;
                if (assetDomain == null) return;

                if (assetDomainBlackList.Contains(assetDomain))
                {
                    Log.Information($"跳过了黑名单中的assetdomain:{assetDomain}.");
                    _.IsInBlackList = true;
                }
            });
            Log.Information($"语言文件已全部处理完毕,共有{collection.Count}个语言文件被处理，其中有{collection.Count(_=>_.IsInBlackList)}文件在黑名单中");
        }

        public static async Task DownloadModsAsync(IEnumerable<Mod> mods)
        {
            var sw1 = Stopwatch.StartNew();
            var collection = mods.Where(_ => !_.IsInBlackList).ToList();
            await Task.WhenAll(collection.Select(async mod =>
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

                var zipArchive = new ZipArchive(mod.Stream, ZipArchiveMode.Read);
                var zipArchiveEntries = zipArchive.Entries.Where(entry =>
                    entry.Name.EndsWith("en_us.lang", StringComparison.OrdinalIgnoreCase)).ToList();
                if (zipArchiveEntries.Count == 0)
                {
                    mod.IsInBlackList = true;
                    mod.Stream.Dispose();
                    Log.Information($"跳过了一个无语言文件的模组:{mod.Name}");
                }
                else
                {
                    foreach (var zipArchiveEntry in zipArchiveEntries)
                    {
                        var stream = new MemoryStream();
                        var s = zipArchiveEntry.Open();
                        s.CopyTo(stream);
                        s.Dispose();
                        mod.Languages.Add(new Language(mod, stream, zipArchiveEntry.FullName));
                    }
                }

                sw.Stop();
                Log.Information($"下载了一个模组: {mod.Name},耗时{sw.ElapsedMilliseconds}ms");
            })).ContinueWith(t =>
            {
                sw1.Stop();
                Log.Information($"所有模组下载完成,耗时{sw1.ElapsedMilliseconds}ms");
            }).ConfigureAwait(false);
            Log.Information($"模组已全部下载完毕,共有{collection.Count}个模组被下载");
        }
    }
}