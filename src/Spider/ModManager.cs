using System;
using System.Collections.Generic;
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
    }
}
