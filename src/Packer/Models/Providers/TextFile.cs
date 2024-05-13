using Packer.Extensions;
using Serilog;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packer.Models.Providers
{
    /// <summary>
    /// 文本文件的提供器，支持内容替换，但不支持文件合并
    /// </summary>
    /// <remarks>
    /// 对于普通的文本文件，使用该类
    /// </remarks>
    public class TextFile : IResourceFileProvider
    {
        /// <summary>
        /// 提供器所携带的文本内容
        /// </summary>
        public virtual string Content { get; }

        /// <inheritdoc/>
        public virtual string Destination { get; }

        /// <summary>
        /// 从给定的<see cref="FileInfo"/>构造提供器
        /// </summary>
        /// <param name="file">读取源</param>
        /// <param name="destination">目标地址</param>
        public static TextFile Create(FileInfo file, string destination)
        {
            using var stream = file.OpenRead();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            var content = reader.ReadToEnd();
            return new TextFile(content, destination);
        }

        /// <summary>
        /// 从给定的文本内容构造提供器
        /// </summary>
        /// <param name="content">来源文本</param>
        /// <param name="destination">目标地址</param>
        public TextFile(string content, string destination)
        {
            Content = content;
            Destination = destination;
        }

        /// <inheritdoc/>
        public virtual IResourceFileProvider ApplyTo(IResourceFileProvider? baseProvider, ApplyOptions options)
        {
            if (baseProvider is null) return this;

            if (!options.Append) return baseProvider;

            if (baseProvider is not TextFile baseTextFile)
                throw new ArgumentException($"Argument not an instance of {typeof(TextFile)}.",
                                            nameof(baseProvider));
            var baseText = baseTextFile.Content;
            var appendedText = string.Concat(baseText, Environment.NewLine, Content);
            return new TextFile(appendedText, Destination);
        }

        /// <inheritdoc/>
        public virtual IResourceFileProvider ReplaceContent(string searchPattern, string replacement)
            => new TextFile(Regex.Replace(Content,
                                  searchPattern,
                                  replacement,
                                  RegexOptions.Singleline),
                            Destination);
        /// <inheritdoc/>
        public virtual IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
            => new TextFile(Content,
                            Regex.Replace(Destination,
                                          searchPattern,
                                          replacement,
                                          RegexOptions.Singleline));
        /// <inheritdoc/>
        public virtual async Task WriteToArchive(ZipArchive archive)
        {
            var destination = Destination.NormalizePath();
            Log.Debug("[TextFile]写入路径 {0}", destination);

            archive.ValidateEntryDistinctness(destination);

            using var writer = new StreamWriter(
                archive.CreateEntry(destination)
                       .Open(),
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            await writer.WriteAsync(Content);
        }
    }
}
