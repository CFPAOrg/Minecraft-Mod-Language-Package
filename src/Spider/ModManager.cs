using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Spider.Properties;

namespace Spider
{
    public class ModManager
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ModManager(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Addon>> GetModInfoAsync(int modCount, string gameVersion)
        {
            var httpClinet = _httpClientFactory.CreateClient();
            var uriBuilder = new UriBuilder("https://addons-ecs.forgesvc.net/api/v2/addon/search");
            uriBuilder.Query =
                $"categoryId=0&gameId=432&index=0&pageSize={modCount}&gameVersion={gameVersion}&sectionId=6&sort=1";
            var uri = uriBuilder.Uri;
            return await httpClinet.GetFromJsonAsync<List<Addon>>(uri);
        }

        public async Task<List<Mod>> DownloadModAsync(IEnumerable<Mod> mods)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var tasks = mods.Select(async _ =>
            {
                var bytes = await httpClient.GetByteArrayAsync(_.DownloadUrl);
                var oldPath = Path.GetTempFileName();
                var newPath = Path.ChangeExtension(oldPath, Path.GetExtension(_.DownloadUrl));
                File.Move(oldPath, newPath);
                await File.WriteAllBytesAsync(newPath, bytes);
                _.Path = newPath;
                return _;
            });
            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public async Task<List<Mod>> GetModIdAsync(IEnumerable<Mod> mods)
        {
            _logger.LogCritical("开始反编译");
            await File.WriteAllBytesAsync("./cfr.jar", Resources.cfr_0_150);
            _logger.LogCritical("释放了cfr到当前目录.");
            var semaphore = new SemaphoreSlim(0, 5);
            var regex = new Regex("(?<=modid=\").*?(?=\")");
            var tasks = new List<Task<Mod>>();
            foreach (var mod in mods)
            {
                await semaphore.WaitAsync();
                try
                {
                    var task = Task.Run(() =>
                    {
                        _logger.LogInformation($"开始对 {mod.Path} 进行反编译以获得modid.");
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
                        var modid = string.Empty;
                        while (!process.StandardOutput.EndOfStream)
                        {
                            var line = process.StandardOutput.ReadLine();
                            if (!string.IsNullOrEmpty(line))
                            {
                                if (regex.IsMatch(line))
                                {
                                    modid = regex.Match(line).Value;
                                    break;
                                }
                            }
                        }

                        _logger.LogCritical($"找到了modid: {modid}");
                        mod.ModId = modid;
                        return mod;
                    }); 
                    tasks.Add(task);
                }
                finally
                {
                    semaphore.Release(1);
                }
            }
            var result = await Task.WhenAll(tasks);
            if (File.Exists("./cfr.jar"))
            {
                File.Delete("./cfr.jar");
            }
            return result.ToList();
        }
    }
}
