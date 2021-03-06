using Serilog;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packer
{
    static class Utils
    {

        public static string Preprocess(this string file, string extension, Dictionary<string, string> mappings)
        { // 不知道需不需要 PostProcess...反正现在即使要写也是一个空方法
            // 特殊符号置换
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
                    case ".txt": // 替换为 unicode 字符
                        file = file.Replace(mapping.Key, Regex.Unescape(mapping.Value));
                        break;
                    case ".json": // 替换为 unicode 转义码
                        file = file.Replace(mapping.Key, mapping.Value);
                        break;
                    default:
                        break;
                }

            }
            return file;
        }

        public static async Task CreateLangFile(this ZipArchive archive, string destination, string content)
        {
            using var writer = new StreamWriter(
                archive.CreateEntry(destination)
                       .Open(),
                Encoding.UTF8);
            await writer.WriteAsync(content);
            writer.Flush(); // 确保一下
        }

        public static string CombineLangFiles(string destination, string added, string extension)
        {
            if (!new List<string> { ".json", ".lang" }.Contains(extension))
            {
                Log.Warning("检测到暂不支持的拓展名（{0}），取消合并", extension);
                return destination;
            }
            Log.Information("正在反序列化目标文件");
            var destMap = AssetSerializer.Deserialize(destination, extension);
            Log.Information("正在反序列化目标文件");
            var addMap = AssetSerializer.Deserialize(added, extension);
            foreach (var pair in addMap)
            {
                if (!destMap.TryAdd(pair.Key, pair.Value))
                {
                    Log.Warning("检测到相同 key 的条目：{0} -> {1} | {2}，选取 {1}", pair.Key, destMap[pair.Key], pair.Value);
                }
            }
            Log.Information("正在序列化合并后的文件");
            return AssetSerializer.Serialize(destMap, extension);
        }

        public static void Initialize(this ZipArchive archive, Config config)
        {
            Log.Information("开始初始化压缩包");
            string commonPrefix = $"./projects/{config.Version}";
            config.FilesToInitialize.ForEach(_ =>
            {
                var destination = _.Replace("/1UNKNOWN", ""); // 除掉一层文件夹（在 assets/ 里的各种 fix）
                Log.Information("初始化压缩包：添加 {0}", destination);
                archive.CreateEntryFromFile($"{commonPrefix}/{_}", destination);
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
                Log.Verbose("添加了映射：{0} -> {1}", key, value);
                mapping.Add(key, value);
            }
            return mapping;
        }

        public static bool NeedBypass(this string location, Config config)
        {
            foreach (var @namespace in config.BypassedNamespace)
            {
                if (location.Contains("/" + @namespace + "/")) return true;
            }
            return false;
        }

        public static Config RetrieveConfig()
        {
            var reader = File.ReadAllBytes(".\\config\\packer.json");
            return JsonSerializer.Deserialize<Config>(reader);
        }
    }
}
