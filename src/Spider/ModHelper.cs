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
using LangPack.Core;
using Serilog;

namespace Spider
{
    public static class ModHelper
    {
        public static string GetShortUrl(Uri uri)
        {
            var url = uri.ToString();
            var start = url.LastIndexOf('/') + 1;
            return url[start..];
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
            try
            {
                return JsonSerializer.Deserialize<List<Mod>>(await File.ReadAllBytesAsync(path));
            }
            catch (Exception e)
            {
                Log.Error(e,"");
                throw;
            }
        }

        public static List<string> GetAssetDomains(string path)
        {
            try
            {
                var paths = GetAssetPaths(path);
                if (paths == null || paths.Count == 0)
                {
                    return null;
                }
                var assetDomains = paths.Select(_ => _.Split("/")).GroupBy(_ => _[1]).Select(_=>_.Key).ToList();
                Log.Information($"拿到了assetdomain: {assetDomains}");
                return assetDomains;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<string> GetAssetDomains(Mod mod)
        {
            return GetAssetDomains(mod.Path);
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

        

    }
}
