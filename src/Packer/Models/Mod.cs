using System.Collections.Generic;

namespace Packer.Models
{
    /// <summary>
    /// 模组译文的抽象表示
    /// </summary>
    public class Mod
    {
        /// <summary>
        /// 模组名
        /// </summary>
        public string modName;
        /// <summary>
        /// 采用的<c>asset</c>，按<c>asset-domain</c>分
        /// </summary>
        public IEnumerable<Asset> assets;
    }

    /// <summary>
    /// <c>asset</c>的抽象表示
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// <c>asset-domain</c>名
        /// </summary>
        public string domainName;
        /// <summary>
        /// 该<c>asset-domain</c>下的文件
        /// </summary>
        public IEnumerable<TranslatedFile> contents;
        /// <summary>
        /// <c>domain</c>合并，并解决重复文件问题
        /// </summary>
        /// <param name="other">要合并的对象</param>
        /// <returns></returns>
        public Asset Combine(Asset other)
        {

            return new Asset()
            {
                domainName = this.domainName,
                contents = Utils.MergeFiles(this.contents, other.contents)
            };
        }
    }
}
