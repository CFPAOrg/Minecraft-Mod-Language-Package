using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public static class UrlLib {
        /// <summary>
        /// 使用定义的游戏版本和模组数量批量获取模组信息
        /// </summary>
        /// <param name="modCount"></param>
        /// <param name="gameVersion"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static async Task<ModInfo[]> GetModInfoAsync(int modCount, string gameVersion,int index)
        {
            using var httpClient = new HttpClient();
            var uriBuilder = new UriBuilder("https://addons-ecs.forgesvc.net/api/v2/addon/search")
            {
                Query =
                    $"categoryId=0&gameId=432&index={index}&pageSize={modCount}&gameVersion={gameVersion}&sectionId=6&sort=1"
            };
            return await httpClient.GetFromJsonAsync<ModInfo[]>(uriBuilder.Uri);
        }

        /// <summary>
        /// 获取单个模组的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<ModInfo> GetModInfoAsync(long id) {
            var httpClient = new HttpClient();
            var uri = new Uri($"https://addons-ecs.forgesvc.net/api/v2/addon/{id}");
            var result = await httpClient.GetFromJsonAsync<ModInfo>(uri);

            return result;
        }

        /// <summary>
        /// 获取下载链接
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Uri GetDownloadUrl(string fileId, string fileName)
        {
            return new Uri($"https://edge.forgecdn.net/files/{fileId[..4]}/{fileId[4..]}/{fileName}");
        }

        /// <summary>
        /// 获取项目名称（已弃用）
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        [Obsolete]
        public static string GetProjectName(Uri uri) {
            var url = uri.ToString();
            var start = url.LastIndexOf('/') + 1;
            return url[start..];
        }

        /// <summary>
        /// 暴力获取前9999个mod的id映射表
        /// </summary>
        /// <param name="version"></param>
        /// <param name="path"></param>
        public static async Task GetAllModIntroAsync(string version,string path) {
            using var httpClient = new HttpClient();
            var uriBuilder = new UriBuilder("https://addons-ecs.forgesvc.net/api/v2/addon/search") {
                Query =
                    $"categoryId=0&gameId=432&index=0&pageSize=9999&gameVersion={version}&sectionId=6&sort=1"
            };
            var tmp = ((await httpClient.GetFromJsonAsync<ModInfo[]>(uriBuilder.Uri)) ?? Array.Empty<ModInfo>()).ToList();
            var intro = tmp.Select(_ => {
                var c = new ModIntro() {
                    Id = _.Id,
                    Name = _.ShortWebsiteUrl
                };
                return c;
            });
            var str = JsonSerializer.SerializeToUtf8Bytes(intro, new JsonSerializerOptions() { WriteIndented = true });
            if (Directory.Exists(@$"{Directory.GetCurrentDirectory()}\config\spider\{path}")) {
                Directory.CreateDirectory(@$"{Directory.GetCurrentDirectory()}\config\spider\{path}");
            }
            await File.WriteAllBytesAsync(@$"{Directory.GetCurrentDirectory()}\config\spider\{path}\intro.json",
                str);
        }

        /// <summary>
        /// 下载mod
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [Obsolete]
        public static async Task<(Mod, bool)> DownloadAsync(this ModInfo mod, string version) {
            var httpCli = new HttpClient();
            var path = $"{Path.GetTempFileName()}".Replace(".tmp", ".jar");

            var file = mod.GameVersionLatestFiles.First(_ => _.GameVersion == version);
            var downloadUrl = GetDownloadUrl(file.ProjectFileId.ToString(), file.ProjectFileName);
            try {
                var bytes = await httpCli.GetByteArrayAsync(downloadUrl);
                await File.WriteAllBytesAsync(path, bytes);
            } catch (Exception e) {
                Serilog.Log.Logger.Error(e.ToString());
                return (null, false);
            }

            var res = new Mod() {
                Version = version,
                DownloadUrl = downloadUrl,
                Name = mod.Name,
                ProjectId = mod.Id,
                ProjectName = mod.ShortWebsiteUrl,
                ProjectUrl = mod.WebsiteUrl,
                TempPath = path,
            };
            return (res, true);
        }
    }
}