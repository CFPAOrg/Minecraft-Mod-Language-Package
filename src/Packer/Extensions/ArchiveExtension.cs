using Packer.Models;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Packer.Extensions
{
    /// <summary>
    /// 用于创建压缩包的各种拓展方法
    /// </summary>
    static public class ArchiveExtension
    {
        /// <summary>
        /// 按要求写入语言文件，并加Log
        /// </summary>
        /// <param name="archive">压缩文件</param>
        /// <param name="destination">目标路径</param>
        /// <param name="content">写入内容</param>
        /// <returns></returns>
        public static async Task CreateLangFile(this ZipArchive archive, string destination, string content)
        {
            destination = destination.NormalizePath();
            Log.Information("正在添加 {0}", destination);
            using var writer = new StreamWriter(
                archive.CreateEntry(destination)
                       .Open());
            await writer.WriteAsync(content);
            writer.Flush(); // 确保一下
        }

        /// <summary>
        /// 初始化压缩包<br></br>
        /// 包括压缩包的基础文件
        /// </summary>
        /// <param name="archive">压缩文件</param>
        /// <param name="config">所使用的配置</param>
        public static void Initialize(this ZipArchive archive, Config config)
        {
            Log.Information("开始初始化压缩包");
            string commonPrefix = $"./projects/{config.Version}";
            config.FilesToInitialize.ForEach(path =>
            {
                var destination = path.StripModName() // 除掉一层文件夹（在 assets/ 里的各种 fix）
                                      .NormalizePath();
                Log.Information("初始化压缩包：添加 {0}", destination);
                archive.CreateEntryFromFile($"{commonPrefix}/{path}", destination);
            });

            Log.Information("初始化完成");
        }

        /// <summary>
        /// 写入选出的Asset们
        /// </summary>
        /// <param name="archive">压缩文件</param>
        /// <param name="content">选出的内容</param>
        /// <returns></returns>
        public static async Task WriteContent(this ZipArchive archive, IEnumerable<Asset> content)
        {
            Log.Information("添加处理后的文件");
            var tasks = new List<Task>();
            foreach (var asset in content)
            {
                Log.Information("正在添加 asset-domain: {0}", asset.domainName);
                foreach (var file in asset.contents)
                {
                    tasks.Add(archive.CreateLangFile(Path.Combine("assets",
                                                                  asset.domainName,
                                                                  file.RelativePath),
                                                     file.StringifiedContent));
                }
            }
            await Task.WhenAll(tasks);
            Log.Information("添加完毕");
        }

        /// <summary>
        /// 写入非文本处理的文件
        /// </summary>
        /// <param name="archive">压缩文件</param>
        /// <param name="bypassed">非文本处理的文件</param>
        public static void WriteBypassed(this ZipArchive archive, Dictionary<string, string> bypassed)
        {
            Log.Information("添加未经处理的文件");
            foreach (var pair in bypassed)
            {
                Log.Information("正在添加 {0}", pair.Value);
                archive.CreateEntryFromFile(sourceFileName: pair.Key,
                                            entryName:      pair.Value.NormalizePath());
            }
            Log.Information("添加完毕");
        }
    }
}
