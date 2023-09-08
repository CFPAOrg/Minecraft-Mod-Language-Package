using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packer.Models
{
    /// <summary>
    /// 表示可以被添加到资源包中的内容<br />
    /// 可以有很多实现：文本文件、非文本文件、组合表......
    /// </summary>
    /// <remarks>
    /// 这是IMMUTABLE！
    /// </remarks>
    public interface IResourceFileProvider
    {
        /// <summary>
        /// 在本提供器的基础上，尝试添加新提供器中的内容
        /// </summary>
        /// <param name="incoming">需要添加的新<see cref="IResourceFileProvider"/></param>
        /// <param name="overrideExisting">冲突解决方案。若为<see langword="false"/>，保留本文件的内容；否则，保留新文件的内容</param>
        /// <returns>合并得到的新<see cref="IResourceFileProvider"/></returns>
        public IResourceFileProvider Append(IResourceFileProvider? incoming, bool overrideExisting = false)
            // 默认实现
            => overrideExisting 
                ? (incoming ?? this) // 如果来源是null，无论冲突配置如何，都不应返回null
                : this;

        /// <summary>
        /// 在该提供器的内容中执行替换
        /// </summary>
        /// <param name="searchPattern">替换的匹配模式，使用<see cref="Regex"/></param>
        /// <param name="replacement">替换文本</param>
        /// <returns>替换得到的新<see cref="IResourceFileProvider"/></returns>
        public IResourceFileProvider ReplaceContent(string searchPattern, string replacement)
            // 默认实现
            => this;

        /// <summary>
        /// 在该提供器的目标地址中执行替换
        /// </summary>
        /// <param name="searchPattern">替换的匹配模式，使用<see cref="Regex"/></param>
        /// <param name="replacement">替换文本</param>
        /// <returns>替换得到的新<see cref="IResourceFileProvider"/></returns>
        public IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
            // 默认实现
            => this;

        /// <summary>
        /// 将该提供器的内容写入到资源包的正确位置
        /// </summary>
        /// <param name="archive"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">资源包中已有同名文件</exception>
        public Task WriteToArchive(ZipArchive archive);
    }
}
