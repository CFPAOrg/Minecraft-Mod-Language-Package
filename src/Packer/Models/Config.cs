using System.Collections.Generic;
using System.Linq;

// 要null就抛异常吧（逃）
#nullable disable

namespace Packer
{
    /// <summary>
    /// 配置项
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 基础配置，版本唯一
        /// </summary>
        public BaseConfig Base { get; set; }
        /// <summary>
        /// 浮动配置，可与命名空间下的文件合并
        /// </summary>
        public FloatingConfig Floating { get; set; }

        /// <summary>
        /// 从命名空间下的局域配置加载内容。
        /// </summary>
        public Config Modify(FloatingConfig floatingConfig)
        {
            if (floatingConfig is null) return this;
            return new()
            {
                Base = Base,
                Floating = Floating.Merge(floatingConfig)
            };
        }
    }

    /// <summary>
    /// 基础配置，版本唯一
    /// </summary>
    public class BaseConfig
    {
        /// <summary>
        /// 打包的目标版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 打包的目标语言
        /// </summary>
        public string[] TargetLanguages { get; set; }

        /// <summary>
        /// 不进行打包的mod（按<c>[curseforge-]name</c>）
        /// </summary>
        public IEnumerable<string> ExclusionMods { get; set; }

        /// <summary>
        /// 不进行打包的<c>namespace</c>
        /// </summary>
        public IEnumerable<string> ExclusionNamespaces { get; set; }
    }

    /// <summary>
    /// 浮动配置，可与命名空间下的文件合并
    /// </summary>
    public class FloatingConfig
    {
        /// <summary>
        /// 强制包含的domain
        /// </summary>
        public IEnumerable<string> InclusionDomains { get; set; }
        /// <summary>
        /// 强制排除的domain
        /// </summary>
        public IEnumerable<string> ExclusionDomains { get; set; }
        /// <summary>
        /// 强制包含的路径
        /// </summary>
        public IEnumerable<string> ExclusionPaths { get; set; }
        /// <summary>
        /// 强制排除的路径
        /// </summary>
        public IEnumerable<string> InclusionPaths { get; set; }

        /// <summary>
        /// 文本字符替换表
        /// </summary>
        public Dictionary<string, string> CharacterReplacement { get; set; }
        /// <summary>
        /// 内容替换表
        /// </summary>
        public Dictionary<string, string> DestinationReplacement { get; set; }

        /// <summary>
        /// 从另一对象合并配置
        /// </summary>
        public FloatingConfig Merge(FloatingConfig other) => new()
        {
            ExclusionPaths = ExclusionPaths.Concat(other.ExclusionPaths).Distinct(),
            ExclusionDomains = ExclusionDomains.Concat(other.ExclusionDomains).Distinct(),
            InclusionDomains = InclusionDomains.Concat(other.InclusionDomains).Distinct(),
            InclusionPaths = InclusionPaths.Concat(other.InclusionPaths).Distinct(),
            CharacterReplacement = CharacterReplacement.Concat(other.CharacterReplacement).DistinctBy(_ => _.Key)
                                                       .ToDictionary(_ => _.Key, _ => _.Value),
            DestinationReplacement = DestinationReplacement.Concat(other.DestinationReplacement).DistinctBy(_ => _.Key)
                                                           .ToDictionary(_ => _.Key, _ => _.Value)
        };


    }
}
