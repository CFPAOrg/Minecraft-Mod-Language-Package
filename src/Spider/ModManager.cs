using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
                _logger.LogInformation($"下载了 {_.DownloadUrl} 到{_.Path}!");
                return _;
            });
            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public async Task<List<Mod>> GetModIdAsync(IEnumerable<Mod> mods)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(0,10);
            File.WriteAllBytes("./cfr.jar", Resources.cfr_0_150);
            var regex = new Regex("(?<=modid=\").*?(?=\")");
            var result = mods.Select(_ =>
            {
                return Task.Run(async () =>
                {
                    await semaphore.WaitAsync();
                    _logger.LogInformation($"开始对 {_.Path} 进行反编译以获得modid.");
                    var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = "java",
                            Arguments = $"-jar ./cfr.jar {_.Path}",
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
                    _.ModId = modid;
                    semaphore.Release(1);
                    return _;
                });
            });

            return (await Task.WhenAll(result)).ToList();
        }
    }
}
