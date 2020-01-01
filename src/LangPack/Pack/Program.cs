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
            if (Directory.Exists("./out"))
            {
                Directory.Delete(@"./out",true);
            }
            Console.WriteLine("Start packing!");
            DirectoryInfo root = new DirectoryInfo(@"./project");
            var files = root.EnumerateFiles("*",SearchOption.AllDirectories).ToAsyncEnumerable().Where(f => f.FullName.EndsWith("zh_cn.lang")).Where(f => f.Length != 0);
            Directory.CreateDirectory(@"./out");
            Console.WriteLine($"Totall found {await files.CountAsync()} files ");
            await foreach (var file in files)
            {
                var newFile = new FileInfo(Path.Combine(@"./out", Path.GetRelativePath(@"./project", file.FullName)));
                Directory.CreateDirectory(newFile.Directory.FullName);
                var s = newFile.Create();
                await file.OpenRead().CopyToAsync(s);
                s.Close();
                Console.WriteLine($"Added {file.FullName}!");
            }
            
            File.Copy(@"./project/pack.png", Path.Combine(@"./out", "pack.png"));
            File.Copy(@"./project/pack.mcmeta", Path.Combine(@"./out", "pack.mcmeta"));
            Directory.CreateDirectory(Path.Combine(@"./out", @"./assets/i18nmod/asset_map/"));
            File.Copy(@"./database/asset_map.json", Path.Combine(@"./out", @"./assets/i18nmod/asset_map/asset_map.json"));

            ZipFile.CreateFromDirectory(@"./out", @"./Minecraft-Mod-Language-Modpack.zip", CompressionLevel.Optimal, includeBaseDirectory: false);
            Console.WriteLine("Finished!");
            var access_key = Environment.GetEnvironmentVariable("Access_Key");
            var secret_key = Environment.GetEnvironmentVariable("Secret_Key");
        }
    }
}