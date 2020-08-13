using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;

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
                if (old!.LastCheckUpdateTime < mod.LastUpdateTime)//检查是否有更新
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
            await File.WriteAllBytesAsync(fullPath, JsonSerializer.SerializeToUtf8Bytes(mods,new JsonSerializerOptions()
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
                return entries.Select(_ => _.FullName).ToHashSet();
            }
            catch (Exception e)
            {
                Log.Error(e, "");
                throw;
            }
        }
    }
}
