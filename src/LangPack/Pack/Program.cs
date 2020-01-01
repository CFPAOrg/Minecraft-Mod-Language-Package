using Octokit;
using Qiniu.CDN;
using Qiniu.Storage;
using Qiniu.Util;
using System;
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
            var access_key = Environment.GetEnvironmentVariable("Access_Key");
            var secret_key = Environment.GetEnvironmentVariable("Secret_Key");
            var reference = Environment.GetEnvironmentVariable("GITHUB_REF");
            var sha = Environment.GetEnvironmentVariable("GITHUB_SHA");
            var github_actor = Environment.GetEnvironmentVariable("GITHUB_ACTOR");
            var github_token = Environment.GetEnvironmentVariable("repo-token");
            if (Directory.Exists(@"./out"))
            {
                Directory.Delete(@"./out", recursive: true);
            }
            if (File.Exists(@"./Minecraft-Mod-Language-Modpack.zip"))
            {
                File.Delete(@"./Minecraft-Mod-Language-Modpack.zip");
            }
            Console.WriteLine("Start packing!");

            var paths = Directory.EnumerateFiles(@"./project", "*", SearchOption.AllDirectories)
                .Where(_ => _.EndsWith("zh_cn.lang"));
            Directory.CreateDirectory(@"./out");
            Console.WriteLine($"Totall found {paths.Count()} files ");
            foreach (var path in paths)
            {
                var newPath = Path.Combine(@"./out", Path.GetRelativePath(@"./project", path));
                Directory.CreateDirectory(Path.GetDirectoryName(newPath));
                File.Copy(path, newPath);
                Console.WriteLine($"Added {path}!");
            }
            File.Copy(@"./project/pack.png", @"./out/pack.png");
            File.Copy(@"./project/pack.mcmeta", @"./out/pack.mcmeta");
            File.Copy(@"./README.md", @"./out/README.md");
            File.Copy(@"./LICENSE", @"./out/LICENSE");
            Directory.CreateDirectory(@"./out/assets/i18nmod/asset_map/");
            File.Copy(@"./database/asset_map.json", @"./out/assets/i18nmod/asset_map/asset_map.json");

            ZipFile.CreateFromDirectory(@"./out", @"./Minecraft-Mod-Language-Modpack.zip", CompressionLevel.Optimal, includeBaseDirectory: false);
            Console.WriteLine("Completed!");

            
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

            
            if (!string.IsNullOrEmpty(github_token))
            {
                var client = new GitHubClient(new ProductHeaderValue("CFPA"));
                var tokenAuth = new Credentials(github_token);
                client.Credentials = tokenAuth;
                var user = await client.User.Current();
                var actor = await client.User.Get(github_actor);
                var repo = await client.Repository.Get(user.Name, "Minecraft-Mod-Language-Package");
                var commitMessage = (await client.Repository.Commit.Get(repo.Id, reference)).Commit.Message;
                var comment = string.Join("\n",
                    (await client.Repository.Comment.GetAllForCommit(repo.Id, sha)).Select(c => c.Body));
                var tagName = $"汉化资源包-Snapshot-{DateTime.UtcNow.ToString("yyyyMMddhhmmss")}";
                var tag = new NewTag
                {
                    Object = sha,
                    Message = comment,
                    Tag = tagName,
                    Type = TaggedType.Commit,
                    Tagger = new Committer(name: actor.Name, email: actor.Email, date: DateTimeOffset.UtcNow)
                };
                var tagResult = await client.Git.Tag.Create(repo.Id, tag);
                Console.WriteLine("Created a tag for {0} at {1}", tagResult.Tag, tagResult.Sha);
                var newRelease = new NewRelease(tagName)
                {
                    Name = tagName+$":{commitMessage}",
                    Body = tag.Message,
                    Draft = false,
                    Prerelease = false
                };
                var releaseResult = await client.Repository.Release.Create(repo.Id, newRelease);
                Console.WriteLine("Created release id {0}", releaseResult.Id);

                await using var archiveContents = File.OpenRead("./Minecraft-Mod-Language-Modpack.zip");
                var assetUpload = new ReleaseAssetUpload()
                {
                    FileName = "Minecraft-Mod-Language-Modpack.zip",
                    ContentType = "application/zip",
                    RawData = archiveContents
                };
                var release = await client.Repository.Release.Get(repo.Id,releaseResult.Id);
                var asset = await client.Repository.Release.UploadAsset(release, assetUpload);
            }

        }
    }
}