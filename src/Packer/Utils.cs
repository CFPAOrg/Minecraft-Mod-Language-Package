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
        public static async Task<Config> RetrieveConfig(string configTemplate, string version)
        {
            Log.Information("正在获取配置。目标版本：{0}", version);
            
            var configPath = string.Format(configTemplate, version);

            Log.Information("配置位置：{0}", configPath);

            var reader = await File.ReadAllBytesAsync(configPath);
            return JsonSerializer.Deserialize<Config>(reader);
        }

        public static PackerStrategy RetrieveStrategy(FileInfo? file)
        {
            if (file is null)
            {
                return new PackerStrategy { Type = PackerStrategyType.NoAction };
            }
            else
            {
                var result = JsonSerializer.Deserialize<PackerStrategy>(
                    file.OpenText().ReadToEnd(),
                    new JsonSerializerOptions
                       {
                           Converters = { new JsonStringEnumConverter() }
                       });
            }
        }

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

        /// <summary>
        /// 基于原位置的文件key，用incoming的词条进行替换。未被替换的保持原文。
        /// </summary>
        /// <param name="baseFile">原位置的基准文件</param>
        /// <param name="incoming">更新文件</param>
        /// <returns></returns>
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

        // 下面的这些...其实都不是我写的...

        public static string AppendTimestamp(string path)
        {
            var mcmeta = path;
            var meta = JsonSerializer.Deserialize<McMeta>(File.ReadAllText(mcmeta));
            var time = DateTime.UtcNow.AddHours(8); // UTC+8:00
            meta.Pack.Description += $"\n打包时间：{time:yyyy-MM-ddTHH:mm:ssZ}";
            return JsonSerializer.Serialize(meta, new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            });
        }
    }
}
