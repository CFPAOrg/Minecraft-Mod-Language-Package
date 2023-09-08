using Packer.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Packer.Extensions
{
    /// <summary>
    /// 用于创建压缩包的各种拓展方法
    /// </summary>
    static public class ArchiveExtension
    {
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

                // pack.mcmeta 特殊处理：添加时间戳
                if(destination == "pack.mcmeta")
                {
                    using var writer = new StreamWriter(
                        archive.CreateEntry(destination)
                               .Open());

                    writer.Write(Utils.AppendTimestamp($"{commonPrefix}/{path}"));
                    return;
                }

                archive.CreateEntryFromFile($"{commonPrefix}/{path}", destination);
            });

            Log.Information("初始化完成");
        }
        /// <summary>
        /// 校验将要传入压缩包的的文件是否存在重名<br />
        /// </summary>
        /// <param name="archive">所查询的压缩包</param>
        /// <param name="entryName">所查询的路径</param>
        /// <exception cref="InvalidOperationException">传入文件存在重名。</exception>
        public static void ValidateEntryDistinctness(this ZipArchive archive, string entryName)
        {
            if (archive.GetEntry(entryName) != null)
            {
                throw new InvalidOperationException($"An entry named {entryName} already exists.");
            }
        }
    }
}
