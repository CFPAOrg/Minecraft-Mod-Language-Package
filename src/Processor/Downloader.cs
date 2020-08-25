using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace Processor
{
    public static class Downloader
    {
        public static async Task<List<PendingMod>> ParseModFile(Configuration configuration, List<Info> mods)
        {
            var pr = configuration.CustomSittings.ProjectsFolder;
            var version = configuration.VersionList[0];
            var semaphore = new Semaphore(50, 60);
            //foreach (var info in mods)
            //{
            //    await Console.Out.WriteLineAsync(info.ShortProjectUrl);
            //}
            var tasks = mods.Select(async mod =>
            {
                try
                {
                    semaphore.WaitOne();
                    var httpCli = new HttpClient();
                    var random = new Random();
                    var ranO = new PendingMod();
                    Log.Logger.Information($"下载：{mod.ShortProjectUrl}");
                    var bytes = await httpCli.GetByteArrayAsync(mod.DownloadUrl);
                    var path = Path.Combine(Path.GetTempPath(),
                        random.Next().ToString() + Path.GetExtension(mod.DownloadUrl.ToString()));
                    await File.WriteAllBytesAsync(path, bytes);
                    ranO.ModPath = path;
                    ranO.Name = mod.ShortProjectUrl;
                    ranO.Domains = mod.AssetDomains;
                    return ranO;
                }
                catch (HttpRequestException e)
                {
                    Log.Logger.Error(e.Message);
                    return null;
                }
                finally
                {
                    semaphore.Release();
                }
            });
            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public static void ExJar(Configuration configuration, List<PendingMod> pm)
        {
            foreach (var pendingMod in pm)
            {
                //ZipFile.ExtractToDirectory(pendingMod.ModPath,Path.Combine(configuration.CustomSittings.ProjectsFolder,configuration.VersionList[0],"temp",pendingMod.Name));
                if (pendingMod.Domains.Count == 0)
                {
                    continue;
                }
                var archive = ZipFile.OpenRead(pendingMod.ModPath);
                foreach (var zipArchiveEntry in archive.Entries)
                {
                    foreach (var domain in pendingMod.Domains)
                    {
                        if (zipArchiveEntry.FullName.Contains($"assets/{domain}/lang/") && zipArchiveEntry.FullName != $"assets/{domain}/lang/")
                        {
                            if (zipArchiveEntry.Name.ToLower() == "en_us.lang" || zipArchiveEntry.Name.ToLower() == "en_us.json")
                            {
                                Console.WriteLine(zipArchiveEntry.FullName);
                                if (!Directory.Exists(Path.Combine(configuration.CustomSittings.ProjectsFolder, configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang")))
                                {
                                    Directory.CreateDirectory(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                        configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang"));
                                }

                                if (File.Exists(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                    configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang", zipArchiveEntry.Name)))
                                {
                                    File.Delete(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                        configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang", zipArchiveEntry.Name));
                                }
                                zipArchiveEntry.ExtractToFile(Path.Combine(configuration.CustomSittings.ProjectsFolder, configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang", zipArchiveEntry.Name));
                                Log.Logger.Information($"已更新{pendingMod.Name}的英文文件");
                            }
                        }
                    }
                }
            }
        }
    }

    public class PendingMod
    {
        public string ModPath { get; set; }
        public string Name { get; set; }
        public List<string> Domains { get; set; }
    }
}