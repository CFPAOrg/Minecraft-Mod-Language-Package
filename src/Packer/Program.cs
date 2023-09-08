using Packer.Extensions;
using Packer.Models;
using Serilog;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packer
{
    class Program
    {
        // 由于某些魔法，这里可以直接加参数
        public static async Task Main(string version, string[]? targets)
        {
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .MinimumLevel.Information() // 以便 debug 时修改这一等级
             .CreateLogger();

            if (version is null)
                throw new ArgumentNullException(nameof(version));
            var targetModIdentifiers = targets?.ToList();

            var config = await Utils.RetrieveConfig(configTemplate: "./config/packer/{0}.json",
                                                    version: version);

            Log.Information("开始对版本 {0} 的打包", config.Version);

            var rawQuery = Lib.RetrieveContent(config, targetModIdentifiers);
            var query = // 这就是查询表达式吗（
                from modDirectory in new DirectoryInfo($"./projects/{config.Version}/assets")
                                                   .EnumerateDirectories()
                let modIdentifier = modDirectory.Name
                // 模组筛选，按模组标识符
                where targetModIdentifiers is null // 未提供列表，全部打包 
                    || targetModIdentifiers.Contains(modIdentifier) // 有列表，仅打包列表中的项
                where !config.ModBlackList.Contains(modIdentifier) // 没有被明确排除
                from namespaceDirectory in modDirectory.EnumerateDirectories()
                let namespaceName = namespaceDirectory.Name
                where !config.DomainBlackList.Contains(modIdentifier) // 没有被明确排除
                // 检查命名空间格式，拒绝错误格式
                // 但是写成表达式以后，没法现场丢异常了...
                where !Regex.IsMatch(namespaceName,
                                     @"^[a-z0-9_\-.]+$",
                                     RegexOptions.Singleline)
                from provider in namespaceDirectory.EnumerateProviders(config)
                group provider by namespaceName into namespaceGroup// 合并文件；我猜没写错
                select namespaceGroup
                    .Aggregate(seed: null as IResourceFileProvider, // 好家伙 类型推断系统推断不出TAggregate
                               (accumlate, next) // 为什么这个参数叫func不叫accumlator或者aggregator...
                                   => next.Append(accumlate, overrideExisting: false)) into provider
                // 替换内容中的特殊字符
                select config.CharatcerReplacement
                             .Aggregate(seed: provider,
                                        (accumlate, replacement)
                                            => accumlate.ReplaceContent(
                                                replacement.Key,
                                                replacement.Value)) into provider
                // 替换目标路径中的对象
                select config.DestinationReplacement
                             .Aggregate(seed: provider,
                                        (accumlate, replacement)
                                            => accumlate.ReplaceContent(
                                                replacement.Key,
                                                replacement.Value));

            // TODO 把初始化内容也做成IEnumerable，尤其是pack.mcmeta
            // var initializers = from fileName in config.FilesToInitialize select new ...

            string packName = $"./Minecraft-Mod-Language-Package-{config.Version}.zip";
            await using var stream = File.Create(packName);
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true))
            {
                archive.Initialize(config);
                await Task.WhenAll(from provider in query select provider.WriteToArchive(archive));
            }

            Log.Information("对版本 {0} 的打包结束。共包含了 {1} 个文件",
                            config.Version,
                            query.Count());
            var md5 = stream.ComputeMD5();
            Log.Information("打包文件的 MD5 值：{0}", md5);
            File.WriteAllText($"./{config.Version}.md5", md5);
        }
    }
}
