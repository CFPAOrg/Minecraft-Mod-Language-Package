namespace Packer.Core.Model.PackerPolicys;

/// <summary>
/// 单文件引用策略。将任意位置的一个文件引用到当前命名空间下的指定路径。
/// 不会读取目标文件的 <c>packer-policy.json</c>，只引用单个文件。
/// </summary>
/// <param name="Source">源文件的完整路径</param>
/// <param name="RelativePath">在当前命名空间下的相对路径</param>
/// <remarks>
/// 典型用途：从另一个命名空间只取某个文件（而非整个 Indirect），
/// 或者作为 Indirect 的前置策略来覆盖个别文件。
/// </remarks>
public record SingletonPolicy(string Source, string RelativePath) : PackerPolicyItem
{
    /// <summary>
    /// 引用单个文件到当前命名空间下的指定路径。
    /// 不读取目标文件的 <c>packer-policy.json</c>，只引用该文件本身。
    /// </summary>
    /// <param name="ns">当前命名空间</param>
    /// <param name="config">合并后的浮动配置，用于设置 <see cref="TextFile.EffectiveConfig"/></param>
    public IEnumerable<IResourceFileProvider> CreateProviders(
        INamespaceResource ns, FloatingConfig config)
    {
        if (!File.Exists(Source))
        {
            Log.Logger.Warning("Singleton 源文件不存在: {Source}", Source);
            yield break;
        }
        var provider = CreateProvider(Source, RelativePath, ns);
        if (provider is TextFile tf)
            tf.EffectiveConfig = config;
        yield return provider;
    }
}
