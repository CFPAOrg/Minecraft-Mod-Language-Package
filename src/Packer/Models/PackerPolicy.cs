using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Packer.Models
{
    /// <summary>
    /// Packer 的局域打包策略类型
    /// </summary>
    public enum PackerPolicyType
    {
        /// <summary>
        /// 从当前位置加载文件。
        /// </summary>
        Direct,
        /// <summary>
        /// 从指定位置加载文件。
        /// </summary>
        Indirect,
        /// <summary>
        /// 从组合文件创建指定语言文件。
        /// </summary>
        Composition,
        /// <summary>
        /// 加载单个文件。
        /// </summary>
        Singleton
    }

    /// <summary>
    /// Packer的局域打包策略。包含策略类型，以及不同策略使用的额外参数
    /// </summary>
    public class PackerPolicy
    {
        /// <summary>
        /// 打包策略的类型参数
        /// </summary>
        public PackerPolicyType Type { get; set; }

        /// <summary>
        /// 打包策略的额外参数
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement>? Parameters { get; set; }
        // JsonExtensionData要求以此种格式传入
    }
}
