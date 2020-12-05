using Serilog;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packer
{
    static class Utils
    {
        public static string Preprocess(this string file, string extension, Dictionary<string, string> mappings)
        { // 不知道需不需要 PostProcess...反正现在即使要写也是一个空方法
            if (!new List<string> { ".lang", ".json", ".txt" }.Contains(extension))
            {
                Log.Warning("检测到未预料到的拓展名：{0}", extension);
            }
            foreach (var mapping in mappings)
            {
                if (file.Contains(mapping.Key))
                {
                    Log.Information("正在进行特殊符号替换：{0} -> {1}", mapping.Key, mapping.Value);
                }
                switch (extension)
                {
                    case ".lang":
                    case ".txt":
                        file.Replace(mapping.Key, Regex.Unescape(mapping.Value));
                        break;
                    case ".json":
                        file.Replace(mapping.Key, mapping.Value);
                        break;
                    default:
                        break;
                }
            }
            return file;
        }

        public static void CreateLangFile(this ZipArchive archive, string destination, string content)
        {
            using var writer = new StreamWriter(
                archive.CreateEntry(destination)
                       .Open(),
                Encoding.UTF8);
            writer.Write(content);
            writer.Flush(); // 确保一下
        }

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
            string commonPrefix = $"./projects/{config.Version}";
            config.FilesToInitialize.ForEach(_ =>
            {
                var destination = _.Replace("/1UNKNOWN", ""); // 除掉一层文件夹（在 assets/ 里的各种 fix）
                Log.Information("初始化压缩包：添加 {0}", _.Replace("/1UNKNOWN",""));
                archive.CreateEntryFromFile($"{commonPrefix}/{_}", _.Replace("/1UNKNOWN", ""));
            });

            Log.Information("初始化完成");
        }

        public static async Task<Dictionary<string, string>> ReadReplaceFontMap() // 从隔壁弄过来改了一下，就放这里了
        {
            var mapping = new Dictionary<string, string>();
            foreach (string str in await File.ReadAllLinesAsync("./config/fontmap.txt", Encoding.UTF8))
            {
                var kv = str.Split('>', 2);
                var key = kv[0];
                var value = kv[1];
                mapping.Add(key, value);
            }
            return mapping;
        }
    }
}
