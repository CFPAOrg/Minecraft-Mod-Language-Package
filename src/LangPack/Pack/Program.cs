using Octokit;
using Qiniu.CDN;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Pack
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var repoPath = GetTargetParentDirectory(Environment.CurrentDirectory, ".git");
            Directory.SetCurrentDirectory(repoPath);
            if (File.Exists(@"./Minecraft-Mod-Language-Modpack.zip"))
                File.Delete(@"./Minecraft-Mod-Language-Modpack.zip");
            Console.WriteLine("Start packing!");

            var paths = Directory.EnumerateFiles(@"./project", "*", SearchOption.AllDirectories)
                .Where(_ => _.EndsWith("zh_cn.lang"))
                .Append(@"./project/pack.png")
                .Append(@"./project/pack.mcmeta")
                .Select(_ => new {src = _, dest = Path.GetRelativePath(@"./project", _)})
                .Append(new {src = @"./README.md", dest = @"README.md"})
                .Append(new {src = @"./LICENSE", dest = @"LICENSE"})
                .Append(new {src = @"./database/asset_map.json", dest = @"assets/i18nmod/asset_map/asset_map.json"})
                .ToList();

            Directory.CreateDirectory(@"./out");
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
            var githubToken = Environment.GetEnvironmentVariable("repo_token");
            var identity = Environment.GetEnvironmentVariable("repo")?.Split("/");
            if (!string.IsNullOrEmpty(githubToken))
            {
                var owner = identity?[0];
                var repoName = identity?[1];
                var client = new GitHubClient(new ProductHeaderValue(owner))
                {
                    Credentials = new Credentials(githubToken)
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
                    Tagger = new Committer("tartaric_acid", "bakabaka943@gmail.com", DateTimeOffset.UtcNow)
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
                var asset = await client.Repository.Release.UploadAsset(release, assetUpload);
            }
        }

        private static async Task UploadQiniuAsync()
        {
            var accessKey = Environment.GetEnvironmentVariable("ak");
            var secretKey = Environment.GetEnvironmentVariable("sk");
            if (string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey)) return;
            var mac = new Mac(accessKey, secretKey);
            const string bucket = "langpack";
            const string key = "Minecraft-Mod-Language-Modpack.zip";
            var putPolicy = new PutPolicy
            {
                Scope = bucket
            };
            putPolicy.SetExpires(120);
            var token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            var uploadManager = new UploadManager(new Config());
            var result = await uploadManager.UploadFile(@"./Minecraft-Mod-Language-Modpack.zip",
                key, token, null);
            Console.WriteLine(result.Text);
            var cdnManager = new CdnManager(mac);
            var refreshResult = await cdnManager.RefreshUrls(new[]
                {"http://downloader.meitangdehulu.com/Minecraft-Mod-Language-Modpack.zip"});
            Console.WriteLine(refreshResult.Result);
        }


        private static string GetTargetParentDirectory(string path, string containDir)
        {
            while (true)
            {
                if (Directory.Exists(Path.Combine(path, containDir))) return path;

                if (Path.GetPathRoot(path) == path) throw new DirectoryNotFoundException($"The {nameof(containDir)} doesn't contain in any parent of {nameof(path)}");
                path = Directory.GetParent(path).FullName;
            }
        }
    }
}