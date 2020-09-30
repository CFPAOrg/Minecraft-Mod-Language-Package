using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Spider {
    public static class UrlLib {
        public static async Task<List<Addon>> GetModInfoAsync(int modCount, string gameVersion)
        {
            using var httpClient = new HttpClient();
            var uriBuilder = new UriBuilder("https://addons-ecs.forgesvc.net/api/v2/addon/search")
            {
                Query =
                    $"categoryId=0&gameId=432&index=0&pageSize={modCount}&gameVersion={gameVersion}&sectionId=6&sort=1"
            };
            return await httpClient.GetFromJsonAsync<List<Addon>>(uriBuilder.Uri);
        }

        public static async Task<List<Addon>> GetModInfoWhenInWhiteList(List<string> whiteList) {
            var res = new List<Addon>();
            foreach (var id in whiteList) {
                using var httpClient = new HttpClient();
                var uri = new Uri($"https://addons-ecs.forgesvc.net/api/v2/addon/{id}");
                var result = await httpClient.GetFromJsonAsync<Addon>(uri);
                res.Add(result);
            }

            return res;
        }

        public static Uri GetDownloadUrl(string fileId, string fileName)
        {
            return new Uri($"https://edge.forgecdn.net/files/{fileId[..4]}/{fileId[4..]}/{fileName}");
        }

        public static string GetProjectName(Uri uri) {
            var url = uri.ToString();
            var start = url.LastIndexOf('/') + 1;
            return url[start..];
        }
    }
}