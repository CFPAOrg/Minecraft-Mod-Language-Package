using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;
using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public class Utils {
        public static async Task ParseMods((ModInfo,Configuration) tuple) {

            if (tuple.Item2.NonUpdate) {
                return;
            }

            var cfg = tuple.Item2;
            var mod = tuple.Item1;
            var version = cfg.Version;
            Uri downloadUrl;
            var httpCli = new HttpClient();

            var path = $"{Path.GetTempFileName()}".Replace(".tmp", ".jar");
            {
                var file = mod.GameVersionLatestFiles.First(_ => _.GameVersion == version);
                downloadUrl = UrlLib.GetDownloadUrl(file.ProjectFileId.ToString(), file.ProjectFileName);
            }
            if (downloadUrl is not null) {

                try
                {
                    var bytes = await httpCli.GetByteArrayAsync(downloadUrl);
                    await File.WriteAllBytesAsync(path, bytes);
                }
                catch (Exception e)
                {
                    Serilog.Log.Logger.Error(e.ToString());
                }

                var res = new Mod()
                {
                    Version = version,
                    DownloadUrl = downloadUrl,
                    Name = mod.Name,
                    ProjectId = mod.Id,
                    ProjectName = mod.ShortWebsiteUrl,
                    ProjectUrl = mod.WebsiteUrl,
                    TempPath = path,
                };
            }
        }

        public static void ParseFiles(Mod mod, Configuration cfg,string rootPath) {
            var zipArchive = new ZipArchive(File.OpenRead(mod.TempPath));
            var tmpDirectories = $"{Path.GetTempPath()}extracted\\{Path.GetFileName(mod.TempPath)}";
            Log.Logger.Debug(tmpDirectories);
            zipArchive.ExtractToDirectory(tmpDirectories,true);
            var directories = cfg.IncludedPath.ToList()
                .Select(_ => new DirectoryInfo($"{tmpDirectories}\\{_}"));
            var include = cfg.ExtractPath.ToList();
            foreach (var info in directories) {
                foreach (var directory in info.GetDirectories()) {
                    if (directory.Name == "minecraft") {
                        continue;
                    }

                    var root = directory.EnumerateDirectories()
                        .Where(_ => include.Contains(_.Name))
                        .Select(_ => _.FullName);

                    root.ToList().ForEach(Console.WriteLine);
                }
            }
        }
    }
}