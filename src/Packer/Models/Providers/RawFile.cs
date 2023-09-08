using Packer.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packer.Models.Providers
{
    /// <summary>
    /// 一般文件的提供器。不提供合并、替换支持
    /// </summary>
    /// <remarks>
    /// 对于非文本文件，使用该类
    /// </remarks>
    public class RawFile : IResourceFileProvider
    {
        /// <summary>
        /// 文件的源地址
        /// </summary>
        public FileInfo SourceFile { get; }

        /// <summary>
        /// 目标地址
        /// </summary>
        public string Destination { get; }

        /// <summary>
        /// 从给定的文件引用构造提供器
        /// </summary>
        /// <param name="sourceFile">源文件的引用</param>
        /// <param name="destination">目标地址</param>
        public RawFile(FileInfo sourceFile, string destination)
        {
            SourceFile = sourceFile;
            Destination = destination;
        }


        /// <inheritdoc/>
        public IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
            => new RawFile(SourceFile,
                           Regex.Replace(Destination, searchPattern, replacement));

        /// <inheritdoc/>
        public async Task WriteToArchive(ZipArchive archive)
        {
            var destination = Destination.NormalizePath();
            Log.Information("正在添加 {0}", destination);

            archive.ValidateEntryDistinctness(destination);

            // 为什么这ZipArchive.CreateEntryFromFile没有Async变种...只有手动实现了
            using var source = SourceFile.OpenRead();
            using var entry = archive.CreateEntry(destination)
                                     .Open();
            await source.CopyToAsync(entry);
        }
    }
}
