namespace Packer.Core.Model.Configuration;

/// <summary>
/// 配置项
/// </summary>
/// <param name="Base">基础配置，版本唯一</param>
/// <param name="Floating">浮动配置，可与命名空间下的文件合并</param>
public record Config(BaseConfig Base, FloatingConfig Floating)
{
    /// <summary>
    /// 从命名空间下的局域配置加载内容。
    /// </summary>
    public Config Modify(FloatingConfig? floatingConfig)
    {
        return this with { Floating = Floating.Merge(floatingConfig) };
    }
}
