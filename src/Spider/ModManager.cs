using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
            var httpClinet = _httpClientFactory.CreateClient();
            var tasks = mods.Select(async _ =>
            {
                var bytes = await httpClinet.GetByteArrayAsync(_.DownloadUrl);
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
    }
}
