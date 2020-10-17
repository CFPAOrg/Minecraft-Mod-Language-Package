using Serilog;
using System.IO;
using System.IO.Compression;

namespace Packer
{
    static class Utils
    {
        public static void CombineLangFiles(Stream destination, Stream added, string extension)
        {
            // 需要注意的是，不同格式的文件需要不同的处理，因此需要传入拓展名
            switch (extension)
            {
                case ".json":
                    if (destination.Length < 5)
                    { // 说明目标文件是个空 object，直接把 added 覆盖过去，不需要裁剪
                        destination.Seek(0, SeekOrigin.Begin); // 确保一下
                        added.CopyTo(destination);
                        break;
                    }
                    // 在 Json 中，想要合并需要移除源文件最后的花括号（}）
                    // 值得注意的是，从一个 Stream 的中间开始 Write 会将原 Stream 的后面内容覆盖掉
                    // 另外的，还需要去掉 2 个 \n\r
                    // 因此，将目标文件seek到末尾前 2 + 2 + 1 = 5 位才可以把花括号覆盖掉（offset -5）
                    destination.Seek(-5, SeekOrigin.End);
                    // 在此之上，还需要一个逗号（,）在条目之间
                    {   // CS8647  using 变量不能直接在 switch 部分中使用
                        using var writer = new StreamWriter(destination);
                        writer.Write(',');
                        writer.Flush(); // 避免留存在 buffer 中
                        // 同样的，还需要移除添加文件的开头的花括号（{），通过跳过该字符处理
                        added.Seek(1, SeekOrigin.Begin);
                        // 现在可以合并了：
                        added.CopyTo(destination);
                    }
                    break;
                case ".lang": // 对于 lang，可以直接合并
                default: // 其他格式也直接合并（出问题的提出来再弄）
                    destination.Seek(0, SeekOrigin.End);
                    added.CopyTo(destination);
                    break;
            }
        }

        public static void InitializeArchive(ZipArchive archive, Config config)
        {
            Log.Information("开始初始化压缩包");
            string commonPrefix = $".\\projects\\{config.Version}";
            config.FilesToInitialize.ForEach(_ =>
            {
                Log.Information("初始化压缩包：添加 {0}", _);
                archive.CreateEntryFromFile($"{commonPrefix}\\{_}", _, CompressionLevel.Fastest);
            });
            Log.Information("初始化完成");
        }
    }
}
