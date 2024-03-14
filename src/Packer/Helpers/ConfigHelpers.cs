using Packer.Extensions;
using Packer.Models;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Packer.Helpers
{
    /// <summary>
    /// 配置相关的工具类
    /// </summary>
    public static class ConfigHelpers
    {
        /// <summary>
        /// 从给定的命名空间获取局域配置
        /// </summary>
        /// <param name="directory">命名空间目录</param>
        /// <returns>若文件存在，返回<see cref="FloatingConfig"/>；否则，返回<see langword="null"/></returns>
        public static FloatingConfig? RetrieveLocalConfig(DirectoryInfo directory)
        {
            var configFile = directory.GetFiles("local-config.json").FirstOrDefault();

            if (configFile is null) return null;

            configFile.FullName.LogToDebug("读取文件：{0}");
            
            using var reader = configFile.OpenText();
            return JsonSerializer.Deserialize<FloatingConfig>(
                reader.ReadToEnd().LogToDebug(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        /// <summary>
        /// 从仓库根目录获取全局配置
        /// </summary>
        /// <param name="configTemplate">配置路径模板</param>
        /// <param name="version">打包版本，用于定位全局配置</param>
        public static async Task<Config> RetrieveConfig(string configTemplate, string version)
        {
            Log.Information("正在获取配置。目标版本：{0}", version);

            var configPath = string.Format(configTemplate, version);

            Log.Information("配置位置：{0}", configPath);

            var content = await File.ReadAllBytesAsync(configPath);
            return JsonSerializer.Deserialize<Config>(
                content,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
        }

        /// <summary>
        /// 从给定的命名空间获取策略内容
        /// </summary>
        /// <param name="directory">命名空间目录</param>
        /// <returns>若文件存在，返回对应的内容；否则，返回<c>[Direct]</c></returns>
        /// <exception cref="InvalidDataException">策略文件非法</exception>
        public static List<PackerPolicy> RetrievePolicy(DirectoryInfo directory)
        {
            var file = directory.GetFiles("packer-policy.json").FirstOrDefault();

            if (file is null)
                return new List<PackerPolicy>
                {
                    new PackerPolicy { Type = PackerPolicyType.Direct }
                };

            file.FullName.LogToDebug("读取文件：{0}");

            using var reader = file.OpenText();
            var result = JsonSerializer.Deserialize<List<PackerPolicy>>(
                reader.ReadToEnd().LogToDebug(),
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                });
            if (result is null)
                throw new InvalidDataException($"The policy file {file.FullName} cannot have null values.");
            return result;
        }
    }
}
