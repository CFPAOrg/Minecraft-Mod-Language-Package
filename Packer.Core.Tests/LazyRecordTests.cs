namespace Packer.Core.Tests;

/// <summary>
/// 每次访问都输出并返回随机值——不缓存。
/// record 相等性不会触发此属性。
/// </summary>
public record LazyRecord(string Id)
{
    public int LazyValue
    {
        get
        {
            Console.WriteLine("你好");
            return Random.Shared.Next(100);
        }
    }
}

public class LazyRecordTests
{
    [Fact]
    public void Record_Equality_Does_Not_Trigger_Properties()
    {
        var a = new LazyRecord("x");
        var b = new LazyRecord("x");

        // Equals 只比较 Id，不访问 LazyValue → "你好" 不会输出
        Assert.Equal(a, b);
    }

    [Fact]
    public void Property_Is_Reevaluated_Each_Access()
    {
        var r = new LazyRecord("x");
        var v1 = r.LazyValue;  // 输出 "你好"
        var v2 = r.LazyValue;  // 再次输出 "你好"，值可能不同
        Assert.NotEqual(v1, v2); // 随机值，两次不一样
    }
}
