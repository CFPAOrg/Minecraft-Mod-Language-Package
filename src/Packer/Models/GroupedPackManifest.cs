using System.Collections.Generic;

#nullable disable

namespace Packer.Models
{
    /// <summary>
    /// 组合包根目录的 <c>Manifest.json</c>，供客户端增量下载、维护本地缓存时使用。
    /// </summary>
    public class GroupedPackManifest
    {
        /// <summary>
        /// 客户端应从本地缓存清除的命名空间（原始名），
        /// 来自 <see cref="BaseConfig.ExclusionNamespaces"/> 与
        /// <see cref="BaseConfig.ExclusionMods"/> 解析出的命名空间
        /// </summary>
        public List<string> BlackList { get; set; }

        /// <summary>
        /// 从原始命名空间到区分标识符（author / displayName / 文件路径）的映射，
        /// 即 <see cref="NamespaceDiscriminator.Operator"/> 的透传
        /// </summary>
        public Dictionary<string, string> Rules { get; set; }
    }
}
