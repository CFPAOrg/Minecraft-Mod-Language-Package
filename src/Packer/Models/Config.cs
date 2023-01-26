using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Packer
{
    /// <summary>
    /// 配置文件
    /// <i>主要</i>从<c>config/packer.json</c>加载
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 打包的目标版本
        /// </summary>
        [JsonPropertyName("targetVersion")]
        public string Version { get; set; }

        /// <summary>
        /// 打包的<c>非</c>目标语言<br></br>
        /// 为了尽量减少功能变动（避免以后秃头），尽量保持原方式<br></br>
        /// 为<c>1.20</c>准备，因为据说语言文件名要改
        /// </summary>
        [JsonPropertyName("unTargetLang")]
        public string[] SkippedLanguages { get; set; }

        /// <summary>
        /// 打包过程的基础文件（如在assets/以外的文件，或不宜通过打包流程的）
        /// </summary>
        [JsonPropertyName("additionalContent")]
        public List<string> FilesToInitialize { get; set; }

        /// <summary>
        /// 不进行打包的mod（按<c>[curseforge-]name</c>处理）<br></br>
        /// 有可能作为基础文件
        /// </summary>
        [JsonPropertyName("modNameBlackList")]
        public List<string> ModBlackList { get; set; }

        /// <summary>
        /// 不进行打包的<c>asset-domain</c><br></br>
        /// 有可能作为基础文件
        /// </summary>
        [JsonPropertyName("domainBlackList")]
        public List<string> DomainBlackList { get; set; }

        /// <summary>
        /// <i>（这不是基础文件！）</i><br></br>
        /// 进入打包流程，但不按照语言文件格式化（也就不回避重复文件）<br></br>
        /// 图片文件必须经过此流程！<br></br>
        /// 按照<c>namespace</c>识别
        /// </summary>
        [JsonPropertyName("noProcessNamespace")]
        public List<string> BypassedNamespace { get; set; }

        /// <summary>
        /// 字符替换表，从外源加载
        /// </summary>
        public Dictionary<string, string> CharatcerReplacement { get; set; } // 该项似乎无法通过 json 初始化
    }
}
