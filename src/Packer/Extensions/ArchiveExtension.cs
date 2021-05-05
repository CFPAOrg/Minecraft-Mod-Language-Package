using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

using Packer.Models;
using Serilog;

namespace Packer.Extensions
{
    static public class ArchiveExtension
    {
        public static async Task CreateLangFile(this ZipArchive archive, string destination, string content)
        {
            destination = destination.ToLower() // 确保大小写正确
                                     .Replace('\\', '/'); // 修复正反斜杠导致的问题
            Log.Information("正在添加 {0}", destination);
            using var writer = new StreamWriter(
                archive.CreateEntry(destination)
                       .Open());
            await writer.WriteAsync(content);
            writer.Flush(); // 确保一下
        }

        public static void Initialize(this ZipArchive archive, Config config)
        {
            Log.Information("开始初始化压缩包");
            string commonPrefix = $"./projects/{config.Version}";
            config.FilesToInitialize.ForEach(path =>
            {
                var destination = path.Replace('\\', '/').Replace("/1UNKNOWN", ""); // 除掉一层文件夹（在 assets/ 里的各种 fix）
                Log.Information("初始化压缩包：添加 {0}", destination);
                archive.CreateEntryFromFile($"{commonPrefix}/{path}", destination);
            });

            Log.Information("初始化完成");
        }

        public static async Task WriteContent(this ZipArchive archive, IEnumerable<Asset> content)
        {
            var tasks = new List<Task>();
            foreach (var asset in content)
            {
                Log.Information("正在添加 asset-domain: {0}", asset.domainName);
                foreach (var file in asset.contents)
                {
                    if (file.relativePath is null) continue; // 无效文件
                    tasks.Add(archive.CreateLangFile(Path.Combine("assets",
                                                                  asset.domainName,
                                                                  file.relativePath),
                                                     file.stringifiedContent));
                }
            }
            await Task.WhenAll(tasks);
        }

        public static void WriteBypassed(this ZipArchive archive, Dictionary<string, string> bypassed)
        {
            foreach (var pair in bypassed)
            {
                Log.Information("正在添加 {0}", pair.Value);
                archive.CreateEntryFromFile(sourceFileName: pair.Key,
                                            entryName: pair.Value);
            }
        }
    }
}
