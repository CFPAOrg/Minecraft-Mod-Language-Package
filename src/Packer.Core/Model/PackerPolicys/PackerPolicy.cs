namespace Packer.Core.Model.PackerPolicys;

/// <summary>
/// 表示一个命名空间下的打包策略集合。
/// 策略按添加顺序执行，冲突时前者优先。
/// 当 <c>packer-policy.json</c> 不存在时，使用 <see cref="Shared"/>（等效于 <see cref="DirectPolicy"/>）。
/// </summary>
/// <remarks>
/// 实现 <see cref="ICollection{T}"/> 以支持集合表达式语法（如 <c>[new DirectPolicy()]</c>）。
/// 序列化时由 STJ 的 <c>[JsonDerivedType]</c> 多态分发到具体策略类型。
/// </remarks>
public sealed class PackerPolicy : ICollection<PackerPolicyItem>
{
    private readonly List<PackerPolicyItem> _items = new();

    /// <summary>策略文件的文件名</summary>
    public const string DefaultFileName = "packer-policy.json";

    /// <summary>
    /// 默认策略，等效于一条 <see cref="DirectPolicy"/>。
    /// 当命名空间下无 <c>packer-policy.json</c> 时使用。
    /// </summary>
    public static PackerPolicy Shared { get; } = [new DirectPolicy()];

    /// <summary>策略条数</summary>
    public int Count => _items.Count;

    /// <summary>集合是否为只读。始终为 <see langword="false"/></summary>
    public bool IsReadOnly => false;

    /// <summary>添加一条策略。供 STJ 反序列化和集合表达式使用。</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Add(PackerPolicyItem item)
    {
        _items.Add(item);
    }

    /// <summary>清空所有策略</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Clear()
    {
        _items.Clear();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    /// <summary>检查策略是否已存在</summary>
    public bool Contains(PackerPolicyItem item)
    {
        return _items.Contains(item);
    }

    /// <inheritdoc/>
    public void CopyTo(PackerPolicyItem[] array, int arrayIndex)
    {
        _items.CopyTo(array, arrayIndex);
    }

    /// <summary>移除一条策略</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Remove(PackerPolicyItem item)
    {
        return _items.Remove(item);
    }

    /// <summary>
    /// 从命名空间文件夹加载 <c>packer-policy.json</c>。
    /// 文件不存在、内容为 null、或解析失败时返回 <see cref="Shared"/>。
    /// </summary>
    /// <param name="namespaceDirPath">命名空间的本地路径</param>
    /// <returns>解析后的策略集合，不会为 <see langword="null"/></returns>
    public static PackerPolicy Load(string namespaceDirPath)
    {
        var policyFile = Path.Combine(namespaceDirPath, DefaultFileName);
        if (!File.Exists(policyFile))
            return Shared;
        try
        {
            var json = File.ReadAllText(policyFile);
            Log.Debug("策略文件内容: {Json}", json);
            var policies = JsonSerializer.Deserialize<PackerPolicy>(
                json, SourceGenerationContext.JsonOptions);
            if (policies is null)
            { Log.Warning("策略反序列化结果为 null: {File}", policyFile); return Shared; }
            if (policies._items.Count == 0)
            { Log.Warning("策略列表为空: {File}", policyFile); return Shared; }
            Log.Debug("成功加载 {Count} 条策略: {File}", policies._items.Count, policyFile);
            return policies;
        }
        catch (Exception ex) { Log.Warning(ex, "策略加载异常: {File}", policyFile); return Shared; }
    }

    /// <summary><see cref="Load(string)"/> 的 <see cref="INamespaceResource"/> 重载。</summary>
    public static PackerPolicy Load(INamespaceResource ns)
    {
        return Load(ns.LocalPath);
    }

    /// <summary>
    /// 按顺序执行所有策略，产出 <see cref="IResourceFileProvider"/>。
    /// </summary>
    /// <param name="ns">当前命名空间资源</param>
    /// <param name="globalConfig">全局浮动配置，必须来自 <c>Config.Floating</c>（未与局域配置合并）。</param>
    /// <remarks>
    /// 对于 <see cref="IndirectPolicy"/> 引用策略，直接传入 <paramref name="globalConfig"/>（未合并），
    /// 由引用策略内部自行与目标命名空间的局域配置合并。
    /// 对于其他策略（如 <see cref="DirectPolicy"/>），
    /// 自动与 <c>ns.LocalConfig</c> 合并后再传入。
    /// </remarks>
    public IEnumerable<IResourceFileProvider> CreateProviders(INamespaceResource ns, Config globalConfig)
    {
        var mergedConfig = globalConfig.Floating.Merge(ns.LocalConfig);
        return _items.SelectMany(item => item switch
        {
            DirectPolicy d => d.CreateProviders(ns, globalConfig, mergedConfig),
            IndirectPolicy i => i.CreateProviders(ns, globalConfig),
            CompositionPolicy c => c.CreateProviders(ns, mergedConfig),
            SingletonPolicy s => s.CreateProviders(ns, mergedConfig),
            _ => throw new InvalidOperationException($"Unknown policy type: {item.GetType()}")
        });
    }

    /// <inheritdoc/>
    public IEnumerator<PackerPolicyItem> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}
