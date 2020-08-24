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
            var semaphore = new Semaphore(50,60);
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
                ZipFile.ExtractToDirectory(pendingMod.ModPath,Path.Combine(configuration.CustomSittings.ProjectsFolder,configuration.VersionList[0],"temp",pendingMod.Name));
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