using Packer.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Packer
{
    static class Utils
    {
        public static async Task<Config> RetrieveConfig(string configPath, string mappingPath, string version)
        {
            Log.Information("正在获取配置");
            var reader = await File.ReadAllBytesAsync(configPath);
            var configs = JsonSerializer.Deserialize<List<Config>>(reader);
            var replacement = await ReadReplaceFontMap(mappingPath);
            configs.ForEach(_ => _.CharatcerReplacement = replacement);
            return configs.Where(_ => _.Version == version).FirstOrDefault(); // 仅选取指定版本，忽略重复
        }

        public static PackerStrategy RetrieveStrategy(FileInfo file)
            => file is null
               ? new PackerStrategy { Type = PackerStrategyType.NoAction } // 默认类型
               : JsonSerializer.Deserialize<PackerStrategy>(file.OpenText().ReadToEnd(), new JsonSerializerOptions
               {
                   Converters = { new JsonStringEnumConverter() }
               });

        /// <summary>
        /// 将两个带有<c>TranslatedFile</c>的列表合并，对冲突项按照target优先进行合并。
        /// </summary>
        /// <param name="baseFile">合并对象，优先选择</param>
        /// <param name="incoming">合并对象，非优先</param>
        /// <returns></returns>
        public static IEnumerable<TranslatedFile> MergeFiles(IEnumerable<TranslatedFile> baseFile, IEnumerable<TranslatedFile> incoming)
        {
            var mapping = new Dictionary<string, TranslatedFile>(); // asset-domain下的目标位置 -> 文件
            if (!baseFile.Any()) return incoming;
            if (!incoming.Any()) return baseFile;
            foreach (var file in baseFile)
            {
                mapping.Add(file.RelativePath, file);
            }
            foreach (var file in incoming)
            {
                if (!mapping.TryAdd(file.RelativePath, file))
                {
                    mapping.Remove(file.RelativePath, out var existing);
                    mapping.Add(existing.RelativePath, existing.Combine(file));
                }
            }
            return mapping.Values;
        }

        public static IEnumerable<TranslatedFile> PortFiles(IEnumerable<TranslatedFile> baseFile, IEnumerable<TranslatedFile> incoming)
        {
            var mapping = new Dictionary<string, TranslatedFile>(); // asset-domain下的目标位置 -> 文件
            if (!incoming.Any()) return baseFile;
            foreach (var file in baseFile)
            {
                mapping.Add(file.RelativePath, file);
            }
            foreach (var file in incoming)
            {
                if (!mapping.TryAdd(file.RelativePath, file))
                {
                    mapping.Remove(file.RelativePath, out var existing);
                    mapping.Add(existing.RelativePath, existing.Port(file));
                }
            }
            return mapping.Values;
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
