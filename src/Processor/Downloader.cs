using System;
using System.Collections.Generic;
using System.IO;
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
            var semaphore = new SemaphoreSlim(50);
            //foreach (var info in mods)
            //{
            //    await Console.Out.WriteLineAsync(info.ShortProjectUrl);
            //}
            var tasks = mods.Select(async mod =>
            {
                try
                {
                    await semaphore.WaitAsync();
                    var httpCli = new HttpClient();
                    var random = new Random();
                    var ranO = new PendingMod();
                    Log.Logger.Information($"下载：{mod.ShortProjectUrl},信号量：{semaphore.CurrentCount}");
                    var bytes = await httpCli.GetByteArrayAsync(mod.DownloadUrl);
                    var path = Path.Combine(Path.GetTempPath(),
                        random.Next().ToString() + Path.GetExtension(mod.DownloadUrl.ToString()));
                    await File.WriteAllBytesAsync(path, bytes);
                    ranO.ModPath = path;
                    ranO.Name = mod.ShortProjectUrl;
                    semaphore.Release();
                    return ranO;
                }
                catch (HttpRequestException e)
                {
                    Log.Logger.Error(e.Message);
                }
            });
            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }
    }

    public class PendingMod
    {
        public string ModPath { get; set; }
        public string Name { get; set; }
    }
}