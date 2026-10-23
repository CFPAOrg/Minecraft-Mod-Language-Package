namespace Packer.Models
{
    /// <summary>
    /// 打包目标平台：加载器 + 游戏版本，从打包版本字符串（即配置文件名）解析。<br />
    /// 例：<c>"1.16-fabric"</c> → (fabric, 1.16)；<c>"1.12.2"</c> → (forge, 1.12.2)。
    /// </summary>
    /// <param name="Loader">加载器名，与 namespace-discriminator.json 中 versionScope 的键对应</param>
    /// <param name="GameVersion">游戏版本，与 versionScope 值列表中的项对应</param>
    public record PackTargetPlatform(string Loader, string GameVersion)
    {
        private const string FabricSuffix = "-fabric";

        /// <summary>
        /// 从打包版本字符串解析目标平台。
        /// 以 <c>-fabric</c> 结尾视为 fabric，其余视为 forge。
        /// </summary>
        /// <param name="packVersion">打包版本字符串，即 <see cref="BaseConfig.Version"/></param>
        public static PackTargetPlatform FromPackVersion(string packVersion)
            => packVersion.EndsWith(FabricSuffix)
                ? new PackTargetPlatform("fabric", packVersion[..^FabricSuffix.Length])
                : new PackTargetPlatform("forge", packVersion);
    }
}
