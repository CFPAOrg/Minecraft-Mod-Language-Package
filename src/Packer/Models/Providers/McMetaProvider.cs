using Packer.Extensions;
using Serilog;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace Packer.Models.Providers
{
    /// <summary>
    /// 用于表示<c>pack.mcmeta</c>的提供器。写入时将会附加打包时间
    /// </summary>
    public class McMetaProvider : TextFile
    {
        internal McMetaProvider(string content, string destination) : base(content, destination) { }

        /// <summary>
        /// 从给定的<see cref="FileInfo"/>构造提供器。
        /// </summary>
        /// <param name="file">读取源</param>
        /// <param name="destination">目标地址</param>
        public static new McMetaProvider Create(FileInfo file, string destination)
        {
            using var stream = file.OpenRead();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            var content = reader.ReadToEnd();
            return new McMetaProvider(content, destination);
        }

        /// <inheritdoc/>
        public override string Destination => "pack.mcmeta";
        /// <inheritdoc/>
        public override IResourceFileProvider ReplaceContent(string searchPattern, string replacement)
            => this;
        /// <inheritdoc/>
        public override IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
            => this;
        /// <inheritdoc/>
        public override async Task WriteToArchive(ZipArchive archive)
        {
            var destination = Destination.NormalizePath();
            Log.Debug("[McMetaProvider]写入路径 {0}", destination);

            var content = string.Format(Content, DateTime.UtcNow.AddHours(8) /* UTC +8:00 */);

            archive.ValidateEntryDistinctness(destination);

            using var writer = new StreamWriter(
                archive.CreateEntry(destination)
                       .Open(),
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            await writer.WriteAsync(content);
        }
    }
}
