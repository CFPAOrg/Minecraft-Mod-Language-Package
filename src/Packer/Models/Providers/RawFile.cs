using Packer.Extensions;
using Serilog;
using System.IO;
using System.IO.Compression;
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

        /// <inheritdoc/>
        public string Destination { get; }

        /// <summary>
        /// 从给定的<see cref="FileInfo" />构造提供器
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
                           Regex.Replace(Destination,
                                         searchPattern,
                                         replacement,
                                         RegexOptions.Singleline));

        /// <inheritdoc/>
        public async Task WriteToStream(Stream stream)
        {
            using var source = SourceFile.OpenRead();
            await source.CopyToAsync(stream);
        }
    }
}
