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

            var query = // 这就是查询表达式吗（
                from modDirectory in new DirectoryInfo($"./projects/{config.Version}/assets")
                                                   .EnumerateDirectories()
                let modIdentifier = modDirectory.Name
                where targetModIdentifiers is null                              // 未提供列表，全部打包 
                    || targetModIdentifiers.Contains(modIdentifier)             // 有列表，仅打包列表中的项
                where !config.ModBlackList.Contains(modIdentifier)              // 没有被明确排除
                from namespaceDirectory in modDirectory.EnumerateDirectories()
                let namespaceName = namespaceDirectory.Name
                where !config.DomainBlackList.Contains(namespaceName)           // 没有被明确排除
                where namespaceName.ValidateNamespace()                         // 不是非法名称
                from provider in namespaceDirectory.EnumerateProviders(config)
                group provider by provider.Destination into destinationGroup
                select destinationGroup
                    .Aggregate(seed: null as IResourceFileProvider,             // 合并文件
                               (accumlate, next)
                                   => next.ApplyTo(
                                       accumlate,
                                       overrideExisting: false)) into provider
                select config.CharatcerReplacement                              // 内容的字符替换
                             .Aggregate(seed: provider,
                                        (accumlate, replacement)
                                            => accumlate.ReplaceContent(
                                                replacement.Key,
                                                replacement.Value)) into provider
                select config.DestinationReplacement                            // 全局路径替换：预留
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
