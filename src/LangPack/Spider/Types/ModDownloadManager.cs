using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spider.Data;

namespace Spider.Types
{
    static class ModDownloadManager
    {
        public async static Task DownloadMods()
        {
            var modInfos = DataStore.Mods.FindAll();
            var count = modInfos.Count();
            var tasks = modInfos.Select(async (modInfo, index) =>
            {
                using var httpClient = new HttpClient();
                await using var stream = await httpClient.GetStreamAsync(modInfo.DownloadUrl).ConfigureAwait(false);
                Console.WriteLine($"下载了一个模组:{modInfo.Name}({index + 1}/{count})");
                using var zipArchive = new ZipArchive(stream, ZipArchiveMode.Read);
                var langFileEntries =
                    zipArchive.Entries.Where(entry =>
                        entry.Name.EndsWith("en_us.lang",StringComparison.Ordinal));
                foreach (var entry in langFileEntries)
                {
                    await using var srcStream = entry.Open();
                    var localPath = Path.GetFullPath(Path.Combine(Settings.WorkPath, "project", entry.FullName));
                    Console.WriteLine($"复制了一个模组的语言文件到{localPath}");
                    Directory.CreateDirectory(Directory.GetParent(localPath).FullName);
                    await using var destFileStream = File.Open(localPath, FileMode.Create);
                    await srcStream.CopyToAsync(destFileStream).ConfigureAwait(false);
                }
            });
            await Task.WhenAll(tasks).ContinueWith(task => Console.WriteLine("所有模组下载完成"));
        } 
    }
}
