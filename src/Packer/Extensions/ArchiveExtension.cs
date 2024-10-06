using System;
using System.IO.Compression;

namespace Packer.Extensions
{
    /// <summary>
    /// 用于压缩包的拓展方法
    /// </summary>
    static public class ArchiveExtension
    {
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
