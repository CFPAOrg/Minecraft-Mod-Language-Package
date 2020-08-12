using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
            var uriBuilder = new UriBuilder("https://addons-ecs.forgesvc.net/api/v2/addon/search")
            {
                Query =
                $"categoryId=0&gameId=432&index=0&pageSize={modCount}&gameVersion={gameVersion}&sectionId=6&sort=1"
            };
            return await httpClinet.GetFromJsonAsync<List<Addon>>(uriBuilder.Uri);
        }

        public async Task<List<Mod>> DownloadModAsync(IEnumerable<Mod> mods)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var tasks = mods.Select(async mod =>
            {
                var bytes = await httpClient.GetByteArrayAsync(mod.DownloadUrl);
                var oldPath = Path.GetTempFileName();
                var newPath = Path.ChangeExtension(oldPath, Path.GetExtension(mod.DownloadUrl.ToString()));
                File.Move(oldPath, newPath);
                await File.WriteAllBytesAsync(newPath, bytes);
                mod.Path = newPath;
                return mod;
            });
            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public async Task<List<Mod>> GetModIdAsync(IEnumerable<Mod> mods)
        {
            var cfrPath = Path.Combine(Directory.GetCurrentDirectory(), "cfr.jar");
            _logger.LogInformation("开始反编译.");
            await File.WriteAllBytesAsync(cfrPath, Resources.cfr_0_150);
            _logger.LogInformation("释放了cfr到当前目录.");
            var semaphore = new SemaphoreSlim(10);
            var regex = new Regex("(?<=modid=\").*?(?=\")");
            var tasks = new List<Task<Mod>>();
            foreach (var mod in mods)
            {
                var task = Task.Run(async () =>
                {
                    try
                    {
                        await semaphore.WaitAsync();
                        _logger.LogInformation($"开始对 {mod.Path} 进行反编译以获得modid,当前还有{semaphore.CurrentCount}个信号量.");
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
                        process.Kill();
                        _logger.LogInformation($"找到了modid: {modid}");
                        mod.ModId = modid;
                        
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                    return mod;
                });
                tasks.Add(task);

            }
            var result = await Task.WhenAll(tasks);

            return result.ToList();
        }


        public async Task<List<Mod>> RestoreModInfoAsync(string path)
        {
            var fullPath = Path.GetFullPath(path);
            if (File.Exists(fullPath))
            {
                return JsonSerializer.Deserialize<List<Mod>>(await File.ReadAllBytesAsync(path));
            }
            throw new Exception();
        }

        public async Task SaveModInfoAsync(string path, IEnumerable<Mod> mods)
        {
            var fullPath = Path.GetFullPath(path);
            await File.WriteAllBytesAsync(fullPath, JsonSerializer.SerializeToUtf8Bytes(mods,new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }
        
    }
}
