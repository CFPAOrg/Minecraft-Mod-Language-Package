using System.Collections.Generic;
using System.Linq;

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
            var mapping = new Dictionary<string, TranslatedFile>(); // asset-domain下的目标位置 -> 文件
            if (!contents.Any()) return other;
            if (!other.contents.Any()) return this;
            foreach (var file in contents)
            {
                //if (file.relativePath is null) continue; // 无效文件  // 预备删去该行？
                mapping.Add(file.relativePath, file);
            }
            foreach (var file in other.contents)
            {
                //if (file.relativePath is null) continue; // 无效文件  // 预备删去该行？
                if (!mapping.TryAdd(file.relativePath, file))
                {
                    mapping.Remove(file.relativePath, out var existing);
                    mapping.Add(existing.relativePath, existing.Combine(file));
                }
            }
            return new Asset()
            {
                domainName = this.domainName,
                contents = mapping.Select(_ => _.Value)
            };
        }
    }
}
