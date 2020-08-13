using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Spider.Properties;

namespace Spider
{
    public static class ModHelper
    {
        public static bool ShouldSkipMod(Mod mod, IEnumerable<Mod> mods)
        {

            var list = mods.ToList();
            var old = list.Find(_ => _.ProjectId == mod.ProjectId);
            if (old != default(Mod))
            {
                if (old!.LastCheckUpdateTime < mod.LastUpdateTime) //检查是否有更新
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public static Uri JoinDownloadUrl(string fileId, string fileName)
        {
            return new Uri($"https://edge.forgecdn.net/files/{fileId[..4]}/{fileId[4..]}/{fileName}");
        }

        public static async Task SaveModInfoAsync(string path, IEnumerable<Mod> mods)
        {
            var fullPath = Path.GetFullPath(path);
            await File.WriteAllBytesAsync(fullPath, JsonSerializer.SerializeToUtf8Bytes(mods,
                new JsonSerializerOptions()
                {
                    WriteIndented = true
                }));
        }

        public static async Task<List<Mod>> RestoreModInfoAsync(string path)
        {
            var fullPath = Path.GetFullPath(path);
            if (File.Exists(fullPath))
            {
                return JsonSerializer.Deserialize<List<Mod>>(await File.ReadAllBytesAsync(path));
            }

            throw new Exception();
        }

        public static string GetAssetDomain(string path)
        {
            try
            {
                var paths = GetAssetPaths(path);
                if (paths == null || paths.Count == 0)
                {
                    return null;
                }
                var assetDomain = paths.Select(_ => _.Split("/")).GroupBy(_ => _[1]).OrderByDescending(_ => _.Count()).First().Key;
                Log.Information($"拿到了assetdomain: {assetDomain}");
                return assetDomain;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string GetAssetDomain(Mod mod)
        {
            return GetAssetDomain(mod.Path);
        }
        public static HashSet<string> GetAssetPaths(Mod mod)
        {
            return GetAssetPaths(mod?.Path);
        }

        public static HashSet<string> GetAssetPaths(string path)
        {
            try
            {
                using var fs = File.OpenRead(path);
                using var zipArchive = new ZipArchive(fs, ZipArchiveMode.Read, true, Encoding.UTF8);
                var entries = zipArchive.Entries
                    .Where(_ => _.FullName.StartsWith("assets/", StringComparison.OrdinalIgnoreCase))
                    .Where(_ => _.FullName.Contains("/lang/")).ToList();
                return entries.Select(_ => _.FullName).Where(Path.HasExtension).ToHashSet();
            }
            catch (Exception e)
            {
                Log.Error(e, "");
                throw;
            }
        }

        public static async Task<List<Addon>> GetModInfoAsync(int modCount, string gameVersion)
        {
            using var httpClient = new HttpClient();
            var uriBuilder = new UriBuilder("https://addons-ecs.forgesvc.net/api/v2/addon/search")
            {
                Query =
                    $"categoryId=0&gameId=432&index=0&pageSize={modCount}&gameVersion={gameVersion}&sectionId=6&sort=1"
            };
            return await httpClient.GetFromJsonAsync<List<Addon>>(uriBuilder.Uri);
        }

        public static async Task<IEnumerable<Mod>> DownloadModAsync(IEnumerable<Mod> mods)
        {
            var tasks = mods.Select(async mod =>
            {
                using var httpClient = new HttpClient();
                var bytes = await httpClient.GetByteArrayAsync(mod.DownloadUrl);
                var oldPath = Path.GetTempFileName();
                var newPath = Path.ChangeExtension(oldPath, Path.GetExtension(mod.DownloadUrl.ToString()));
                File.Move(oldPath, newPath);
                await File.WriteAllBytesAsync(newPath, bytes);
                mod.Path = newPath;
                return mod;
            });
            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public static async Task<IEnumerable<Mod>> GetModIdAsync(IEnumerable<Mod> mods)
        {
            var cfrPath = Path.Combine(Directory.GetCurrentDirectory(), "cfr.jar");
            Log.Information("开始反编译.");
            await File.WriteAllBytesAsync(cfrPath, Resources.cfr_0_150);
            Log.Information("释放了cfr到当前目录.");
            var semaphore = new SemaphoreSlim(10);
            var regex = new Regex("(?<=modid=\").*?(?=\")");
            var tasks = new List<Task<Mod>>();
            foreach (var mod in mods)
            {
                var task = Task.Run(async () =>
                {
                    try
                    {
                        await semaphore.WaitAsync();
                        Log.Information($"开始对 {mod.Name} 进行反编译以获得modid,当前还有{semaphore.CurrentCount}个信号量.");
                        var process = new Process
                        {
                            StartInfo =
                            {
                                FileName = "java",
                                Arguments = $"-jar ./cfr.jar {mod.Path}",
                                RedirectStandardOutput = true,
                                UseShellExecute = false
                            }
                        };
                        process.Start();
                        var modid = String.Empty;
                        while (!process.StandardOutput.EndOfStream)
                        {
                            var line = process.StandardOutput.ReadLine();
                            if (!String.IsNullOrEmpty(line))
                            {
                                if (regex.IsMatch(line))
                                {
                                    modid = regex.Match(line).Value;
                                    break;
                                }
                            }
                        }
                        process.Kill();
                        Log.Information($"找到了modid: {modid}");
                        mod.ModId = modid;
                        
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                    return mod;
                });
                tasks.Add(task);

            }
            var result = await Task.WhenAll(tasks);

            return result.ToList();
        }
    }
}
