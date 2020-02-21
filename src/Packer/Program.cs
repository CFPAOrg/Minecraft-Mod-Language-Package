using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using Renci.SshNet;
using FileMode = System.IO.FileMode;

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
            var zipFile = File.Open(@"./Minecraft-Mod-Language-Modpack.zip",FileMode.Create,FileAccess.ReadWrite);
            var zipArchive = new ZipArchive(zipFile, ZipArchiveMode.Create);
            foreach (var path in paths)
            {
                await using var fs = File.OpenRead(path.src);
                var entry = zipArchive.CreateEntry(path.dest, CompressionLevel.Optimal);
                await using var zipStream = entry.Open();
                fs.CopyTo(zipStream);
                Console.WriteLine($"Added {path.dest}!");
            }
            zipArchive.Dispose();
            Upload();
            await ReleaseAsync();
            
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
                using var raw = File.OpenRead("./Minecraft-Mod-Language-Modpack.zip");
                var assetUpload = new ReleaseAssetUpload
                {
                    FileName = "Minecraft-Mod-Language-Modpack.zip",
                    ContentType = "application/zip",
                    RawData = raw
                };
                var release = await client.Repository.Release.Get(owner, repoName, releaseResult.Id);
                await client.Repository.Release.UploadAsset(release, assetUpload);
            }
        }
        private static void Upload()
        {
            var keyFile = Environment.GetEnvironmentVariable("sshprivatekey");
            var passPhrase = Environment.GetEnvironmentVariable("passphrase");
            if (string.IsNullOrEmpty(keyFile) || string.IsNullOrEmpty(passPhrase)) return;
            using var stream = new MemoryStream();
            using var sw = new StreamWriter(stream);
            sw.Write(keyFile);
            using var client = new ScpClient("115.231.219.184", "root", new PrivateKeyFile(stream))
            {
                RemotePathTransformation = RemotePathTransformation.ShellQuote
            };
            client.Connect();
            var fi = new FileInfo("./Minecraft-Mod-Language-Modpack.zip");
            client.Upload(fi, "/var/www/html/Minecraft-Mod-Language-Modpack.zip");
            Console.WriteLine("上传完成.");
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