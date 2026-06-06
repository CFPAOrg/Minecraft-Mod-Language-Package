using System;
using System.IO.Compression;
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
        /// <param name="baseProvider">需要添加的新<see cref="IResourceFileProvider"/></param>
        /// <param name="options">冲突解决选项</param>
        /// <returns>合并得到的新<see cref="IResourceFileProvider"/></returns>
        public IResourceFileProvider ApplyTo(IResourceFileProvider? baseProvider, ApplyOptions options = default)
            // 默认实现；如果来源是null，无论冲突配置如何，都不应返回null
            => baseProvider ?? this;

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
        public IResourceFileProvider ReplaceDestination(string searchPattern, string replacement);

        /// <summary>
        /// 将该提供器的内容写入到资源包的正确位置
        /// </summary>
        /// <param name="archive"></param>
        /// <exception cref="InvalidOperationException">资源包中已有同名文件</exception>
        public Task WriteToArchive(ZipArchive archive);

        /// <summary>
        /// 目标在资源包中的相对位置，从根目录算起
        /// </summary>
        public string Destination { get; }
    }

    /// <summary>
    /// 在合并供应器时，使用的选项。理论上可以拓展，只要加默认值。
    /// </summary>
    public readonly struct ApplyOptions
    {
        // CS8983  具有字段初始值设定项的“结构”必须包含显式声明的构造函数。
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public ApplyOptions(bool modifyOnly, bool append)
        {
            ModifyOnly = modifyOnly;
            Append = append;
        }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

        /// <summary>
        /// 对于<see cref="Providers.TermMappingProvider{TValue}"/>，是否包含选入的新键。
        /// </summary>
        public bool ModifyOnly { get; } = false;
        /// <summary>
        /// 对于<see cref="Providers.TextFile"/>，是否将文本相连。
        /// </summary>
        public bool Append { get; } = false;
    }
}
