using Packer.Extensions;
using Packer.Models;
using Packer.Models.Providers;
using Serilog;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Packer
{
    class Program
    {
        // System.CommandLine.DragonFruit支持
        public static async Task Main(string version, string[]? targets)
        {
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .MinimumLevel.Information() // 以便 debug 时修改这一等级
             .CreateLogger();

            var targetModIdentifiers = targets?.ToList();

            var config = await Utils.RetrieveConfig(configTemplate: "./config/packer/{0}.json",
                                                    version: version);

            Log.Information("开始对版本 {0} 的打包", config.Base.Version);

            var query = // 这就是查询表达式吗（
                from modDirectory in new DirectoryInfo($"./projects/{config.Base.Version}/assets")
                                         .EnumerateDirectories()
                let modIdentifier = modDirectory.Name
                where targetModIdentifiers is null                                  // 未提供列表，全部打包 
                    || targetModIdentifiers.Contains(modIdentifier)                 // 有列表，仅打包列表中的项
                where !config.Base.ExclusionMods.Contains(modIdentifier)            // 没有被明确排除
                from namespaceDirectory in modDirectory.EnumerateDirectories()
                let namespaceName = namespaceDirectory.Name
                where !config.Base.ExclusionNamespaces.Contains(namespaceName)      // 没有被明确排除
                where namespaceName.ValidateNamespace()                             // 不是非法名称
                from provider in namespaceDirectory.EnumerateProviders(config)
                group provider by provider.Destination into destinationGroup
                select destinationGroup
                    .Aggregate(seed: null as IResourceFileProvider,                 // 合并文件
                               (accumulate, next)
                                   => next.ApplyTo(
                                       accumulate,
                                       overrideExisting: false)) into provider
                select config.Floating.CharatcerReplacement                         // 内容的字符替换
                             .Aggregate(seed: provider,
                                        (accumulate, replacement)
                                            => accumulate.ReplaceContent(
                                                replacement.Key,
                                                replacement.Value)) into provider
                select config.Floating.DestinationReplacement                       // 全局路径替换：预留
                             .Aggregate(seed: provider,
                                        (accumulate, replacement)
                                            => accumulate.ReplaceContent(
                                                replacement.Key,
                                                replacement.Value));


            var initialsQuery = from file in new DirectoryInfo($"./projects/{config.Base.Version}")
                                                 .EnumerateFiles()
                                select (file.Name == "pack.mcmeta")
                                    ? McMetaProvider.Create(file, file.Name) // 类型推断不出要用接口
                                    : new RawFile(file, file.Name) as IResourceFileProvider;

            string packName = $"./Minecraft-Mod-Language-Package-{config.Base.Version}.zip";
            await using var stream = File.Create(packName);

            using (var archive = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true))
            {
                await Task.WhenAll(from provider in query.Concat(initialsQuery)
                                   select provider.WriteToArchive(archive));
            }

            Log.Information("对版本 {0} 的打包结束。共写入了 {1} 个文件",
                            config.Base.Version,
                            query.Count());
            var md5 = stream.ComputeMD5();

            Log.Information("打包文件的 MD5 值：{0}", md5);
            File.WriteAllText($"./{config.Base.Version}.md5", md5);
        }
    }
}
