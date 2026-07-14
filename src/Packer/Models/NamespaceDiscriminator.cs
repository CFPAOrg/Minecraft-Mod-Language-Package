using System.Collections.Generic;

// 与 Config.cs 一致：要null就抛异常吧（逃）
#nullable disable

namespace Packer.Models
{
    /// <summary>
    /// 命名空间区分规则。当多个 CurseForge 项目共用同一命名空间时，
    /// 组合包依据该规则将命名空间改写为 <c>&lt;namespace&gt;-CFPA-&lt;区分名&gt;</c>，
    /// 使各变体分别打包；客户端按 <see cref="Operator"/> 从本地模组元数据计算区分名。<br />
    /// 对应 <c>config/packer/namespace-discriminator.json</c> 中的一个条目。
    /// </summary>
    public class NamespaceDiscriminator
    {
        /// <summary>
        /// 被区分的原始命名空间（不含识别段）
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// 客户端计算区分名所用的标识符：
        /// <c>"author"</c>（authors 字典序第一个）、<c>"displayName"</c>，
        /// 或一个文件路径（表示对模组内该文件取 MD5）。
        /// 原样写入 Manifest.json 的 rules。
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 从 CurseForge 项目 slug 到区分名的映射；仅打包器重命名时使用，不写入 Manifest.json
        /// </summary>
        public Dictionary<string, string> MappingRule { get; set; }

        /// <summary>
        /// 规则生效范围：键为加载器名（forge / fabric），值为游戏版本列表
        /// </summary>
        public Dictionary<string, List<string>> VersionScope { get; set; }

        /// <summary>
        /// 判断该规则是否适用于给定的打包目标平台
        /// </summary>
        /// <param name="targetPlatform">当前打包的目标平台</param>
        public bool AppliesTo(PackTargetPlatform targetPlatform)
            => VersionScope is not null
               && VersionScope.TryGetValue(targetPlatform.Loader, out var gameVersions)
               && gameVersions.Contains(targetPlatform.GameVersion);
    }
}
