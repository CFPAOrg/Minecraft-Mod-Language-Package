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
                if (pendingMod.Domains == null || pendingMod.Domains.Count == 0)
                {
                    Log.Logger.Information($"跳过：{pendingMod.Name}");
                    continue;
                }

                if (pendingMod.ModPath == "")
                {
                    Log.Logger.Information($"跳过：{pendingMod.Name}");
                    continue;
                }

                var archive = ZipFile.OpenRead(pendingMod.ModPath);
                try
                {
                    foreach (var zipArchiveEntry in archive.Entries)
                    {
                        foreach (var domain in pendingMod.Domains)
                        {
                            if (zipArchiveEntry.FullName.Contains($"assets/{domain}/lang/") && zipArchiveEntry.FullName != $"assets/{domain}/lang/")
                            {
                                if (configuration.VersionList[0] == "1.12.2")
                                {
                                    if (Path.GetExtension(zipArchiveEntry.Name) == ".lang")
                                    {
                                        if (zipArchiveEntry.Name.ToLower().Contains("en_us.lang", StringComparison.OrdinalIgnoreCase))
                                        {
                                            var folder = Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang");
                                            var name = Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang",
                                                zipArchiveEntry.Name);
                                            //Console.WriteLine(zipArchiveEntry.FullName);
                                            if (!Directory.Exists(folder))
                                            {
                                                Directory.CreateDirectory(folder);
                                            }

                                            if (File.Exists(name))
                                            {
                                                try
                                                {
                                                    File.Delete(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                        configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                        "lang", "en_us.lang"));
                                                }
                                                finally
                                                {
                                                    Log.Information($"尝试删除{folder}下的旧文件");
                                                }

                                                try
                                                {
                                                    File.Delete(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                        configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                        "lang", "en_US.lang"));
                                                }
                                                finally
                                                {
                                                    Log.Information($"尝试删除{folder}下的旧文件");
                                                }
                                            }
                                            zipArchiveEntry.ExtractToFile(Path.Combine(configuration.CustomSittings.ProjectsFolder, configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang", zipArchiveEntry.Name));
                                            try
                                            {
                                                File.Move(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                    configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                    "lang", zipArchiveEntry.Name), Path.Combine(
                                                    configuration.CustomSittings.ProjectsFolder,
                                                    configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                    "lang", zipArchiveEntry.Name.ToLower()));
                                            }
                                            finally
                                            {
                                                Log.Logger.Information($"将{pendingMod.Name}的文件转为小写");
                                            }
                                            Log.Logger.Information($"已更新{pendingMod.Name}的英文文件");
                                        }
                                    }
                                }
                                else
                                {
                                    if (Path.GetExtension(zipArchiveEntry.Name) == ".json")
                                    {
                                        if (zipArchiveEntry.Name.ToLower().Contains("en_us.json", StringComparison.OrdinalIgnoreCase))
                                        {
                                            var folder = Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang");
                                            var name = Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang",
                                                zipArchiveEntry.Name);
                                            //Console.WriteLine(zipArchiveEntry.FullName);
                                            if (!Directory.Exists(folder))
                                            {
                                                Directory.CreateDirectory(folder);
                                            }

                                            if (File.Exists(name))
                                            {
                                                try
                                                {
                                                    File.Delete(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                        configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                        "lang", "en_us.json"));
                                                }
                                                finally
                                                {
                                                    Log.Information($"尝试删除{folder}下的旧文件");
                                                }

                                                try
                                                {
                                                    File.Delete(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                        configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                        "lang", "en_US.json"));
                                                }
                                                finally
                                                {
                                                    Log.Information($"尝试删除{folder}下的旧文件");
                                                }
                                            }
                                            zipArchiveEntry.ExtractToFile(Path.Combine(configuration.CustomSittings.ProjectsFolder, configuration.VersionList[0], "assets", pendingMod.Name, domain, "lang", zipArchiveEntry.Name));
                                            try
                                            {
                                                File.Move(Path.Combine(configuration.CustomSittings.ProjectsFolder,
                                                    configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                    "lang", zipArchiveEntry.Name), Path.Combine(
                                                    configuration.CustomSittings.ProjectsFolder,
                                                    configuration.VersionList[0], "assets", pendingMod.Name, domain,
                                                    "lang", zipArchiveEntry.Name.ToLower()));
                                            }
                                            finally
                                            {
                                                Log.Logger.Information($"将{pendingMod.Name}的文件转为小写");
                                            }
                                            Log.Logger.Information($"已更新{pendingMod.Name}的英文文件");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e.Message);
                    Log.Logger.Error($"{pendingMod.Name}更新失败！");
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