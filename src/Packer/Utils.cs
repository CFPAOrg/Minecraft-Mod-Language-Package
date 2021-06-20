using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
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

        public static async Task WriteMd5(Stream stream, Config config)
        {
            Log.Information("开始生成 md5 值");
            var md5 = MD5.Create();
            var hash = await md5.ComputeHashAsync(stream);
            var md5Hex = string.Concat(hash.Select(x => x.ToString("X2")));
            await File.WriteAllTextAsync($"./{config.Version}.md5", md5Hex);
            Log.Information("生成结束。md5: {0}", md5Hex);
        }
        public static async Task WriteMd5(byte[] bytes, Config config)
        {
            Log.Information("开始生成 md5 值");
            var md5 = MD5.Create();
            //var md5 = SHA256.Create();
            var hash = md5.ComputeHash(bytes);
            var md5Hex = string.Concat(hash.Select(x => x.ToString("X2")));
            await File.WriteAllTextAsync($"./{config.Version}.md5", md5Hex);
            Log.Information("生成结束。md5: {0}", md5Hex);
        }

        public static void CreateTimeStamp(string version) {
            var mcmeta = $"./projects/{version}/pack.mcmeta";
            var meta = JsonSerializer.Deserialize<McMeta>(File.ReadAllText(mcmeta));
            var time = DateTime.UtcNow.AddHours(8);
            meta.Pack.Description += $"打包时间：{time.Year}-{time.Month}-{time.Day}-{time.Hour}-{time.Minute}";
            var result = JsonSerializer.Serialize(meta,new JsonSerializerOptions() {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            });
            File.WriteAllText(result,mcmeta);
        }
    }
}
