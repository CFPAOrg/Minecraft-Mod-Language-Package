using Packer.Models;
using Serilog;
using SharpCompress.Writers;
using SharpCompress.Writers.Tar;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packer.Extensions
{
    /// <summary>
    /// 用于压缩包的拓展方法
    /// </summary>
    static public class ArchiveExtension
    {

        public static ZipArchiveEntry CreateEntryValidated(this ZipArchive archive, string entryName)
        {
            var normalized = entryName.NormalizePath();
            if (archive.GetEntry(entryName) != null)
            {
                throw new InvalidOperationException($"An entry named {entryName} already exists.");
            }
            Log.Debug("写入路径 {0}", normalized);
            return archive.CreateEntry(normalized);
        }

        public static async Task WriteDirect(this ZipArchive archive, IEnumerable<IResourceFileProvider> providers)
        {
            foreach (var provider in providers)
            {
                var entry = archive.CreateEntryValidated(provider.Destination);
                using var stream = entry.Open();
                await provider.WriteToStream(stream);
            }
        }

        public static async Task WriteGrouped(this ZipArchive archive, IEnumerable<IResourceFileProvider> providers)
        {
            var grouped =
                from provider in providers
                group provider by provider.Destination.GetNamespace();
            foreach (var group in grouped)
            {
                var targetPath = $"assets/{group.Key}.tar.lzma";
                var entry = archive.CreateEntryValidated(targetPath);
                using var stream = await entry.OpenAsync();
                using (var entryWriter = new TarWriter(stream, new TarWriterOptions(SharpCompress.Common.CompressionType.LZip)))
                {
                    foreach (var provider in group)
                    {
                        using var dataStream = new MemoryStream();
                        await provider.WriteToStream(dataStream);
                        dataStream.Seek(0, SeekOrigin.Begin);
                        await entryWriter.WriteAsync(provider.Destination.Split('/', 3)[2], dataStream);
                    }
                }

                var md5 = stream.ComputeMD5();
                var md5Entry = archive.CreateEntryValidated($"assets/{group.Key}.md5");
                using var md5Writer = new StreamWriter(md5Entry.Open(), 
                    new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
                md5Writer.Write(md5);
            }
        }
    }
}
