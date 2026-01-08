using Renci.SshNet;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Octokit;

namespace Uploader
{
    static class Program
    {
        static async Task Main(string host, string name, string password)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");

            var tokenAuth = new Credentials(token);
            // https://docs.github.com/en/rest/using-the-rest-api/troubleshooting-the-rest-api?apiVersion=2022-11-28&productId=rest#user-agent-required
            var client = new GitHubClient(new ProductHeaderValue("cfpaorg-actions-uploader"))
            {
                Credentials = tokenAuth
            };

            var artifactDirectory = new DirectoryInfo(Path.Join(Directory.GetCurrentDirectory(), "artifacts"));
            if (!artifactDirectory.Exists)
            {
                Log.Warning("未找到 artifact 文件夹。可能是所有版本都没有触发打包。");
                return;
            }

            var packs = artifactDirectory
                           .EnumerateFiles("Minecraft-Mod-Language-Modpack-*.zip", SearchOption.AllDirectories)
                           .Select(_ =>
                           {
                               var fileExtensionName = _.Extension; // 带点名称，应当为 ".zip"
                               var fileName = _.Name[0..^fileExtensionName.Length]
                                               .RegulateFileName();
                               return (name: fileName + fileExtensionName, file: _);
                           });
            var md5s = artifactDirectory
                          .EnumerateFiles("*.md5", SearchOption.AllDirectories)
                          .Select(_ => (name: _.Name, file: _));
            var files = packs.Concat(md5s);

            Console.WriteLine("待上传的文件数目：{0}", files.Count());

            await UploadToServer(host, name, password, files);
            await UploadSnapshotAssets(client, files);
            await UpdateAutobuildAssets(client, files);
        }

        async static Task UploadToServer(string host, string username, string password, IEnumerable<(string name, FileInfo file)> files)
        {
            using var scpClient = new ScpClient(host, port: 22, username, password);
            scpClient.Connect(); // 与下载服务器建立连接

            // 确认连接状态
            if (scpClient.IsConnected)
            {
                Log.Information("SCP服务器连接成功");
            }
            else
            {
                Log.Error("SCP服务器连接失败");
                throw new InvalidOperationException();
            }

            foreach (var (name, file) in files)
            {
                var destinationName = $"/var/www/html/files/{name}";
                scpClient.Upload(file, destinationName); // 没有async :(
                Log.Information("<Server> 写入文件：{0}", destinationName);
            }
        }

        async static Task UploadSnapshotAssets(GitHubClient client, IEnumerable<(string name, FileInfo file)> files)
        {
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            Log.Information("<Snapshot> 时间戳：{0}", timestamp);
            var newRelease = new NewRelease($"Snapshot-{timestamp}")
            {
                TargetCommitish = Environment.GetEnvironmentVariable("SHA"),
                Name = $"汉化资源包-{timestamp}"
            };
            var result = await client.Repository.Release.Create(long.Parse(Environment.GetEnvironmentVariable("REPO_ID")!), newRelease);
            Log.Information("<Snapshot> 创建 Release");
            foreach (var (name, file) in files)
            {
                using var fileStream = file.OpenRead();
                var newAsset = new ReleaseAssetUpload(
                    name,
                    file.Extension switch
                    {
                        ".zip" => "application/zip",
                        ".md5" => "text/plain",
                        _ => throw new ArgumentException($"Unexpected extension: {file.Extension}")
                    },
                    fileStream,
                    timeout: null);
                await client.Repository.Release.UploadAsset(result, newAsset);
                Log.Information("<Snapshot> 上传文件：{0}", name);
            }
        }

        async static Task UpdateAutobuildAssets(GitHubClient client, IEnumerable<(string name, FileInfo file)> files)
        {
            var repoId = long.Parse(Environment.GetEnvironmentVariable("REPO_ID")!);
            var release = await client.Repository.Release.Get(repoId, "autobuild");
            Log.Information("<Autobuild> 获取 autobuild Release");

            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            var desc = new ReleaseUpdate()
            {
                Body = $"""
                ## 汉化资源包 Autobuild

                ### 最后更新时间

                - {timestamp}
                """,
                MakeLatest = MakeLatestQualifier.True
            };
            await client.Repository.Release.Edit(repoId, release.Id, desc);
            Log.Information("<Autobuild> 更新 Release 简介：时间 {0}", timestamp);

            var assets = release.Assets;
            var lookup = assets.Select(_ => (_.Name, _)).ToDictionary();
            foreach (var (name, file) in files)
            {
                using var fileStream = file.OpenRead();

                if (lookup.TryGetValue(name, out ReleaseAsset? asset)) 
                {
                    await client.Repository.Release.DeleteAsset(repoId, asset.Id);
                    Log.Information("<Autobuild> 删除旧文件：{0}", name);
                }
                var newAsset = new ReleaseAssetUpload(
                    name,
                    file.Extension switch
                    {
                        ".zip" => "application/zip",
                        ".md5" => "text/plain",
                        _ => throw new ArgumentException($"Unexpected extension: {file.Extension}")
                    },
                    fileStream,
                    timeout: null);
                await client.Repository.Release.UploadAsset(release, newAsset);
                Log.Information("<Autobuild> 上传文件：{0}", name);
                
            }
        }

        public static string RegulateFileName(this string fileName)
        {
            // 历史遗留问题：全部单词都要大小写
            return CapitalizeGroup(fileName.Replace('.', '-') // 历史遗留问题：版本号需要输杠
                                          .Replace("-1-12-2", "") // 历史遗留问题：1.12.2文件没有版本号
                                          .Split('-'));

            // 将一组字符串的各项大小写，用'-'连接
            string CapitalizeGroup(string[] texts) => string.Join('-', texts.Select(_ => Capitalize(_)));

            // 将一段文本的首字母大写，其余不动
            string Capitalize(string text) => string.Join("",
                                                          text[0..1].ToUpper(),
                                                          text[1..]);
        }
    }
}
