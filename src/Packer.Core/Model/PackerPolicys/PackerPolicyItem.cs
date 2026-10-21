namespace Packer.Core.Model.PackerPolicys;

/// <summary>
/// 打包策略项的基类。
/// 通过 <c>[JsonDerivedType]</c> 实现 JSON type discriminator 多态反序列化，
/// <c>packer-policy.json</c> 中的 <c>"type"</c> 字段决定具体策略类型。
/// </summary>
/// <remarks>
/// 子类：<see cref="DirectPolicy"/>、<see cref="IndirectPolicy"/>、
/// <see cref="CompositionPolicy"/>、<see cref="SingletonPolicy"/>。
/// </remarks>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DirectPolicy), "direct")]
[JsonDerivedType(typeof(IndirectPolicy), "indirect")]
[JsonDerivedType(typeof(CompositionPolicy), "composition")]
[JsonDerivedType(typeof(SingletonPolicy), "singleton")]
public abstract record PackerPolicyItem
{
    /// <summary>
    /// 对于语言文件的合并，是否只修改已有的键而不添加新键。
    /// <see langword="true"/> 时，只覆盖已存在键的值，不引入本策略新增的键。
    /// 对其他文件类型无效。
    /// </summary>
    public bool ModifyOnly { get; init; }

    /// <summary>
    /// 对于文本文件，是否在已有内容后换行追加。
    /// <see langword="true"/> 时，将本步的文本追加到上一步内容的末尾。
    /// 对其他文件类型无效。
    /// </summary>
    public bool Append { get; init; }


    /// <summary>
    /// 根据文件扩展名和所在目录，创建对应类型的 <see cref="IResourceFileProvider"/>。
    /// </summary>
    /// <param name="filePath">源文件的完整路径</param>
    /// <param name="relativePath">相对于命名空间的路径</param>
    /// <param name="ns">所属命名空间</param>
    /// <returns>
    /// <c>lang/</c> 下的 <c>.json</c> → <see cref="JsonFile"/>
    /// <c>lang/</c> 下的 <c>.lang</c> → <see cref="LangFile"/>
    /// 其他文本文件（<c>.txt .json .md</c>）→ <see cref="TextFile"/>
    /// 其余 → <see cref="RawFile"/>
    /// </returns>
    protected IResourceFileProvider CreateProvider(string filePath, string relativePath, INamespaceResource ns)
    {
        var ext = Path.GetExtension(filePath);
        var parentDir = Path.GetFileName(Path.GetDirectoryName(filePath));

        switch (parentDir, ext)
        {
            case { parentDir: "lang", ext: ".json" }:
                var json = File.ReadAllText(filePath);
                var entries = new Dictionary<string, string>();
                foreach (var prop in JsonDocument.Parse(json).RootElement.EnumerateObject())
                    if (prop.Value.ValueKind == JsonValueKind.String)
                        entries[prop.Name] = prop.Value.GetString()!;
                return new JsonFile(entries, relativePath)
                {
                    Namespace = ns,
                    PolicyItem = this
                };

            case { parentDir: "lang", ext: ".lang" }:
                var content = File.ReadAllText(filePath);
                entries = LangFile.DeserializeFromLang(content);
                return new LangFile(entries, relativePath)
                {
                    Namespace = ns,
                    PolicyItem = this
                };

            case { parentDir: "lang" }:
            case { ext: ".txt" or ".json" or ".md" }:
                return new TextFile(File.ReadAllText(filePath), relativePath) { Namespace = ns, PolicyItem = this };

            default:
                return new RawFile(filePath, relativePath) { Namespace = ns };
        }
    }
}
