using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Packer.Models
{
    /// <summary>
    /// Packer 的局域打包策略类型
    /// </summary>
    public enum PackerStrategyType
    {
        /// <summary>
        /// 不进行额外操作，直接按照本处的文件结构打包<br></br>
        /// 附加参数：无
        /// </summary>
        NoAction,
        /// <summary>
        /// 仅从某处复制文件，忽略当前目录的内容<br></br>
        /// 附加参数：<br></br>
        /// "source": string 复制源地址
        /// </summary>
        PlainClone,
        /// <summary>
        /// 使用本处的文件结构，随后从源地址补充文件<br></br>
        /// 全体文件以本处优先<br></br>
        /// 附加参数：<br></br>
        /// "source": string 复制源地址
        /// </summary>
        CloneMissing,
        /// <summary>
        /// 使用此处的文件结构，仅对此处存在的条目从源地址更新<br></br>
        /// 附加参数：<br></br>
        /// "source": string 复制源地址
        /// </summary>
        BackPort,
        /// <summary>
        /// 从某处复制文件，然后应用由Google Diff-Match-Patch算法生成的修改项<br></br>
        /// 附加参数：<br></br>
        /// "source": string 复制源地址<br></br>
        /// "patches": Dictionary&lt;string, string&gt; patch列表: patch目标 -> patch文本
        /// </summary>
        Patch
    }

    /// <summary>
    /// Packer的局域打包策略。包含策略类型，以及不同策略使用的额外参数
    /// </summary>
    public class PackerStrategy
    {
        /// <summary>
        /// 打包策略的类型参数
        /// </summary>
        [JsonPropertyName("type")]
        public PackerStrategyType Type { get; set; }

        /// <summary>
        /// 打包策略的额外参数
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> Parameters { get; set; }
        // JsonExtensionData要求以此种格式传入
    }
}
