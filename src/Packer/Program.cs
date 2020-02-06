using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using Qiniu.CDN;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;

namespace Packer
{
    internal class Program
    {
        public static async Task Main()
        {
            var sw = Stopwatch.StartNew();
            var repoPath = GetTargetParentDirectory(Environment.CurrentDirectory, ".git");
            Directory.SetCurrentDirectory(repoPath);
            var paths = Directory.EnumerateFiles(@"./project", "*", SearchOption.AllDirectories)
                .Where(_ => !_.EndsWith("en_us.lang",StringComparison.OrdinalIgnoreCase))
                .Select(_ => new {src = _, dest = Path.GetRelativePath(@"./project", _)})
                .Append(new {src = @"./README.md", dest = @"README.md"})
                .Append(new {src = @"./LICENSE", dest = @"LICENSE"})
                .Append(new {src = @"./data/asset_map.json", dest = @"assets/i18nmod/asset_map/asset_map.json"})
                .ToList();

            Console.WriteLine($"Totally found {paths.Count} files ");
            await using (var zipFile = File.OpenWrite(@"./Minecraft-Mod-Language-Modpack.zip"))
            {
                using var zipArchive = new ZipArchive(zipFile, ZipArchiveMode.Create);
                foreach (var path in paths)
                {
                    await using var fs = File.OpenRead(path.src);
                    var entry = zipArchive.CreateEntry(path.dest, CompressionLevel.Optimal);
                    await using var zipStream = entry.Open();
                    await fs.CopyToAsync(zipStream);
                    Console.WriteLine($"Added {path.dest}!");
                }
            }

            var upload = UploadQiniuAsync();
            var release = ReleaseAsync();
            Task.WaitAll(release, upload);
            sw.Stop();
            Console.WriteLine($"All works finished in {sw.Elapsed.Milliseconds}ms");
        }

        private static async Task ReleaseAsync()
        {
            var sha = Environment.GetEnvironmentVariable("sha");
            var token = Environment.GetEnvironmentVariable("token");
            var identity = Environment.GetEnvironmentVariable("repo")?.Split("/");
            if (!string.IsNullOrEmpty(token))
            {
                var owner = identity?[0];
                var repoName = identity?[1];
                var client = new GitHubClient(new ProductHeaderValue(owner))
                {
                    Credentials = new Credentials(token)
                };
                var comment = string.Join("\n",
                    (await client.Repository.Comment.GetAllForCommit(owner, repoName, sha)).Select(c => c.Body));
                var tagName = $"汉化资源包-Snapshot-{DateTime.UtcNow:yyyyMMddhhmmss}";
                var tag = new NewTag
                {
                    Object = sha,
                    Message = comment,
                    Tag = tagName,
                    Type = TaggedType.Commit,
                    Tagger = new Committer("CFPABot", "bot@cfpa.team", DateTimeOffset.UtcNow)
                };
                var tagResult = await client.Git.Tag.Create(owner, repoName, tag);
                Console.WriteLine($"Created a tag for {tagResult.Tag} at {tagResult.Sha}");
                var newRelease = new NewRelease(tagName)
                {
                    Name = tagName,
                    Body = tag.Message,
                    Draft = false,
                    Prerelease = false
                };
                var releaseResult = await client.Repository.Release.Create(owner, repoName, newRelease);
                Console.WriteLine($"Created release id {releaseResult.Id}");
                await using var rawData = File.OpenRead(@"./Minecraft-Mod-Language-Modpack.zip");
                var assetUpload = new ReleaseAssetUpload
                {
                    FileName = "Minecraft-Mod-Language-Modpack.zip",
                    ContentType = "application/zip",
                    RawData = rawData
                };
                var release = await client.Repository.Release.Get(owner, repoName, releaseResult.Id);
                await client.Repository.Release.UploadAsset(release, assetUpload);
            }
        }

        private static async Task UploadQiniuAsync()
        {
            var accessKey = Environment.GetEnvironmentVariable("ak");
            var secretKey = Environment.GetEnvironmentVariable("sk");
            if (string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey)) return;
            var mac = new Mac(accessKey, secretKey);
            const string key = "Minecraft-Mod-Language-Modpack.zip";
            const string filePath = @"./Minecraft-Mod-Language-Modpack.zip";
            const string bucket = "langpack";
            var putPolicy = new PutPolicy {Scope = bucket + ":" + key};
            putPolicy.SetExpires(120);
            var token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            var config = new Config
            {
                Zone = Zone.ZoneCnSouth,
                UseHttps = true,
                UseCdnDomains = true,
                ChunkSize = ChunkUnit.U512K
            };
            var target = new FormUploader(config);
            var result = await target.UploadFile(filePath, key, token, null);
            Console.WriteLine("form upload result: " + result.Text);
            var manager = new CdnManager(mac);
            string[] urls = {"http://downloader.meitangdehulu.com/Minecraft-Mod-Language-Modpack.zip"};
            var ret = await manager.RefreshUrls(urls);
            if (ret.Code != (int) HttpCode.OK) Console.WriteLine(ret.ToString());
            Console.WriteLine(ret.Result.Code);
            Console.WriteLine(ret.Result.Error);
            if (ret.Result.InvalidUrls != null)
                foreach (var url in ret.Result.InvalidUrls)
                    Console.WriteLine(url);
        }


        private static string GetTargetParentDirectory(string path, string containDir)
        {
            while (true)
            {
                if (Directory.Exists(Path.Combine(path, containDir))) return path;

                if (Path.GetPathRoot(path) == path)
                    throw new DirectoryNotFoundException(
                        $"The {nameof(containDir)} doesn't contain in any parent of {nameof(path)}");
                path = Directory.GetParent(path).FullName;
            }
        }
    }
}