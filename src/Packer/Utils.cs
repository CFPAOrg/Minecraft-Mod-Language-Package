using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

using Packer.Models;
using Serilog;

namespace Packer
{
    static class Utils
    {
        static async public Task<Config> RetrieveConfig(string configPath, string mappingPath, string version)
        {
            Log.Information("正在获取配置");
            var reader = await File.ReadAllBytesAsync(configPath);
            var configs = JsonSerializer.Deserialize<List<Config>>(reader);
            var replacement = await ReadReplaceFontMap(mappingPath);
            configs.ForEach(_ =>
            { // 提取特殊字符替换，并加入 Config 中
                _.CharatcerReplacement = replacement;
            });
            return configs.Where(_ => _.Version == version).FirstOrDefault(); // 仅选取指定版本，忽略重复
        }

        public static async Task<Dictionary<string, string>> ReadReplaceFontMap(string path) // 从隔壁弄过来改了一下，就放这里了
        {
            var mapping = new Dictionary<string, string>();
            foreach (string str in await File.ReadAllLinesAsync(path))
            {
                var kv = str.Split('>', StringSplitOptions.TrimEntries);
                var key = kv[0];
                var value = kv[1];
                Log.Verbose("添加了映射：{0} -> {1}", key, value);
                mapping.Add(key, value);
            }
            return mapping;
        }

        // 下面的这些...其实都不是我写的...

        public static void CreateTimeStamp(string version)
        {
            var mcmeta = $"./projects/{version}/pack.mcmeta";
            var meta = JsonSerializer.Deserialize<McMeta>(File.ReadAllText(mcmeta));
            var time = DateTime.UtcNow.AddHours(8);
            meta.Pack.Description += $"\n打包时间：{time:yyyy-MM-ddTHH:mm:ssZ}";
            var result = JsonSerializer.Serialize(meta, new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            });
            File.WriteAllText(mcmeta, result);
        }
    }
}
