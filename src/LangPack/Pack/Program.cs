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
    class Program
    {
        public static async Task Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var repoPath = GetTargetParentDirectory(Environment.CurrentDirectory, ".git");
            Directory.SetCurrentDirectory(repoPath);
            if (File.Exists(@"./Minecraft-Mod-Language-Modpack.zip"))
            {
                File.Delete(@"./Minecraft-Mod-Language-Modpack.zip");
            }
            Console.WriteLine("Start packing!");

            var paths = Directory.EnumerateFiles(@"./project", "*", SearchOption.AllDirectories).ToAsyncEnumerable()
                .Where(_ => _.EndsWith("zh_cn.lang"))
                .Append(@"./project/pack.png")
                .Append(@"./project/pack.mcmeta")
                .Select(_ => new { src = _, dest = Path.GetRelativePath(@"./project", _) })
                .Append(new { src = @"./README.md", dest = @"README.md" })
                .Append(new { src = @"./LICENSE", dest = @"LICENSE" })
                .Append(new { src = @"./database/asset_map.json", dest = @"assets/i18nmod/asset_map/asset_map.json" });

            Directory.CreateDirectory(@"./out");
            Console.WriteLine($"Totall found {paths.CountAsync()} files ");
            await using (var zipFile = File.OpenWrite(@"./Minecraft-Mod-Language-Modpack.zip"))
            {
                using var zipArchive = new ZipArchive(zipFile, ZipArchiveMode.Create);
                await foreach (var path in paths)
                {
                    await using var fs = File.OpenRead(path.src);
                    var entry = zipArchive.CreateEntry(path.dest, CompressionLevel.Optimal);
                    await using var zipStream = entry.Open();
                    await fs.CopyToAsync(zipStream);
                    Console.WriteLine($"Added {path.dest}!");
                }
                Console.WriteLine("Completed!");
            }
            var upload = Task.Run(() => UploadQiniu());
            var release = ReleaseAsync();
            Task.WaitAll(release, upload);
            sw.Stop();
            Console.WriteLine($"All works finished in {sw.Elapsed.Milliseconds}ms");
        }

        private static async Task ReleaseAsync()
        {
            var reference = Environment.GetEnvironmentVariable("ref");
            var sha = Environment.GetEnvironmentVariable("sha");
            var github_actor = Environment.GetEnvironmentVariable("actor");
            var github_token = Environment.GetEnvironmentVariable("repo_token");
            var identity = Environment.GetEnvironmentVariable("repo").Split("/");
            var owner = identity[0];
            var repoName = identity[1];
            if (!string.IsNullOrEmpty(github_token))
            {
                var client = new GitHubClient(new ProductHeaderValue(owner))
                {
                    Credentials = new Credentials(github_token)
                };
                var actor = await client.User.Get(github_actor);
                Console.WriteLine($"This build is triggered by {actor.Name}:{actor.Email}");
                var commitMessage = (await client.Repository.Commit.Get(owner, repoName, reference)).Commit.Message;
                var comment = string.Join("\n",
                    (await client.Repository.Comment.GetAllForCommit(owner, repoName, sha)).Select(c => c.Body));
                var tagName = $"汉化资源包-Snapshot-{DateTime.UtcNow.ToString("yyyyMMddhhmmss")}";
                var tag = new NewTag
                {
                    Object = sha,
                    Message = comment,
                    Tag = tagName,
                    Type = TaggedType.Commit,
                    Tagger = new Committer(name: actor.Name, email: actor.Email, date: DateTimeOffset.UtcNow)
                };
                var tagResult = await client.Git.Tag.Create(owner, repoName, tag);
                Console.WriteLine("Created a tag for {0} at {1}", tagResult.Tag, tagResult.Sha);
                var newRelease = new NewRelease(tagName)
                {
                    Name = tagName + $":{commitMessage}",
                    Body = tag.Message,
                    Draft = false,
                    Prerelease = false
                };
                var releaseResult = await client.Repository.Release.Create(owner, repoName, newRelease);
                Console.WriteLine("Created release id {0}", releaseResult.Id);
                await using var rawData = File.OpenRead(@"./Minecraft-Mod-Language-Modpack.zip");
                var assetUpload = new ReleaseAssetUpload()
                {
                    FileName = "Minecraft-Mod-Language-Modpack.zip",
                    ContentType = "application/zip",
                    RawData = rawData
                };
                var release = await client.Repository.Release.Get(owner, repoName, releaseResult.Id);
                var asset = await client.Repository.Release.UploadAsset(release, assetUpload);
            }
        }

        private static void UploadQiniu()
        {
            var access_key = Environment.GetEnvironmentVariable("ak");
            var secret_key = Environment.GetEnvironmentVariable("sk");
            if ((!string.IsNullOrEmpty(access_key)) && (!string.IsNullOrEmpty(secret_key)))
            {
                Mac mac = new Mac(access_key, secret_key);
                PutPolicy putPolicy = new PutPolicy
                {
                    Scope = "langpack"
                };
                putPolicy.SetExpires(120);
                string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
                UploadManager um = new UploadManager(new Config());
                var result = um.UploadFile(@"./Minecraft-Mod-Language-Modpack.zip",
                    "Minecraft-Mod-Language-Modpack.zip", token, new PutExtra());
                Console.WriteLine(result.Text);
                var cdnm = new CdnManager(mac);
                var refreshResult = cdnm.RefreshUrls(new[] { "http://downloader.meitangdehulu.com/Minecraft-Mod-Language-Modpack.zip" });
                Console.WriteLine(refreshResult.Text);
            }

        }


        private static string GetTargetParentDirectory(string path, string containDir)
        {
            if (Directory.Exists(Path.Combine(path, containDir)))
            {
                return path;
            }
            else
            {
                if (Path.GetPathRoot(path) == path)
                {
                    throw new DirectoryNotFoundException($"The {nameof(containDir)} doesn't contain in any parent of {nameof(path)}");
                }
                return GetTargetParentDirectory(Directory.GetParent(path).FullName, containDir);
            }
        }
    }
}