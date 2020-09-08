using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Serilog;

namespace Spider {
    public class Filelib {
        public static string GetProjectName(Uri uri) {
            var url = uri.ToString();
            var start = url.LastIndexOf('/') + 1;
            return url[start..];
        }

        public static async Task<List<DownloadMod>> DownloadModAsync(List<ModBase> modBases) {
            var semaphore = new Semaphore(50, 60);
            var tasks = modBases.Select(async _ => {
                try {
                    semaphore.WaitOne();
                    var httpCli = new HttpClient();
                    Log.Logger.Information($"œ¬‘ÿ£∫{_.Name}");
                    var bytes = await httpCli.GetByteArrayAsync(_.DownloadUrl);
                    var path = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
                    await File.WriteAllBytesAsync(path, bytes);
                    var downloadMod = new DownloadMod() {
                        DownloadUrl = _.DownloadUrl,
                        ModPath = path,
                        Name = _.Name,
                        ProjectId = _.ProjectId,
                        ProjectName = _.ProjectName,
                        ProjectUrl = _.ProjectUrl
                    };
                    return downloadMod;
                } catch (Exception e) {
                    Log.Logger.Error(e.Message);
                    return null;
                } finally {
                    semaphore.Release();
                }
            });

            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public static List<ModBase> GenerateModBase(List<Addon> addons, string version) {
            var bases = new List<ModBase>();
            foreach (var addon in addons) {
                var name = addon.Name;
                var projectName = Filelib.GetProjectName(addon.WebsiteUrl);
                var projectId = addon.Id;
                var projectUrl = addon.WebsiteUrl;
                var mod = addon.GameVersionLatestFiles.First(_ => _.GameVersion == version);
                var downloadUrl = Urllib.GetDownloadUrl(mod.ProjectFileId.ToString(), mod.ProjectFileName);
                var modBase = new ModBase() { DownloadUrl = downloadUrl, Name = name, ProjectId = projectId, ProjectName = projectName, ProjectUrl = projectUrl };
                bases.Add(modBase);
            }

            return bases;
        }

        public static async Task<List<Info>> GenerateInfo() {
            return null;
        }
    }
}