using Packer.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packer.Extensions
{
    static public class ArchiveExtension
    {
        public static async Task CreateLangFile(this ZipArchive archive, string destination, string content)
        {
            destination = destination.ToLower() // 确保大小写正确
                                     .Replace('\\', '/'); // 修复正反斜杠导致的问题
            if (destination.Contains("en_us", StringComparison.OrdinalIgnoreCase))
            {
                Log.Information("跳过了英文原文文件：{0}", destination);
                return;
            }
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
            config.FilesToInitialize.ForEach(_ =>
            {
                var destination = _.Replace("/1UNKNOWN", ""); // 除掉一层文件夹（在 assets/ 里的各种 fix）
                Log.Information("初始化压缩包：添加 {0}", destination);
                archive.CreateEntryFromFile($"{commonPrefix}/{_}", destination);
            });

            Log.Information("初始化完成");
        }

        public static async Task WriteContent(this ZipArchive archive, IEnumerable<Asset> content)
        {
            var tasks = new List<Task>();
            foreach(var asset in content)
            {
                Log.Information("正在添加 asset-domain: {0}", asset.domainName);
                try
                {
                    foreach (var file in asset.contents)
                    {
                        if (file.relativePath is null) continue;
                        tasks.Add(archive.CreateLangFile(Path.Combine("assets",
                                                                      asset.domainName,
                                                                      file.relativePath),
                                                         file.stringifiedContent));
                    }
                }
                catch(Exception ex)
                {
                    Log.Error(ex, "添加文件失败。");
                }
            }
            await Task.WhenAll(tasks);
        }

        public static void WriteBypassed(this ZipArchive archive, Dictionary<string, string> bypassed)
        {
            foreach(var pair in bypassed)
            {
                archive.CreateEntryFromFile(pair.Key, pair.Value);
            }
        }
    }
}
