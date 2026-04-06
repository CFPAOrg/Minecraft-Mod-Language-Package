using Packer.Extensions;
using Packer.Helpers;
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
        public static async Task Main(string version, bool increment = false)
        {
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .MinimumLevel.Debug()
             .CreateLogger();

            var config = await ConfigHelpers.RetrieveConfig(configTemplate: "./config/packer/{0}.json",
                                                    version: version);
            Log.Information("开始对版本 {0} 的打包", config.Base.Version);

            var targetModIdentifiers = increment ? GitHelpers.EnumerateChangedMods(config.Base.Version)
                : Enumerable.Empty<string>();

            var query = // 在这里加日志似乎开销太大了。暂时注释掉
                from modDirectory in new DirectoryInfo($"./projects/{config.Base.Version}/assets")
                                         .EnumerateDirectories()
                let modIdentifier = modDirectory.Name
                                                //.LogToDebug("[Enumerable]当前模组：{0}")
                where targetModIdentifiers.Count() == 0                             // 未提供列表，全部打包
                    || targetModIdentifiers.Contains(modIdentifier)                 // 有列表，仅打包列表中的项
                where !config.Base.ExclusionMods.Contains(modIdentifier)            // 没有被明确排除
                from namespaceDirectory in modDirectory.EnumerateDirectories()
                let namespaceName = namespaceDirectory.Name
                where !config.Base.ExclusionNamespaces.Contains(namespaceName)      // 没有被明确排除
                where namespaceName/*.LogToDebug("[Enumerable]当前命名空间：{0}")*/
                                   .ValidateNamespace()                             // 不是非法名称
                from provider in namespaceDirectory.EnumerateProviders(config)
                group provider by provider.Destination into destinationGroup
                select destinationGroup
                    .Aggregate(seed: null as IResourceFileProvider,                 // 合并文件
                               (accumulate, next)
                                   => next.ApplyTo(
                                       accumulate)) into provider
                select config.Floating.CharacterReplacement                         // 内容的字符替换
                             .Aggregate(seed: provider,
                                        (accumulate, replacement)
                                            => accumulate.ReplaceContent(
                                                replacement.Key,
                                                replacement.Value)) into provider
                select config.Floating.DestinationReplacement                       // 全局路径替换：预留
                             .Aggregate(seed: provider,
                                        (accumulate, replacement)
                                            => accumulate.ReplaceDestination(
                                                replacement.Key,
                                                replacement.Value));

            var initialsQuery = from file in new DirectoryInfo($"./projects/{config.Base.Version}")
                                                 .EnumerateFiles()
                                select (file.Name == "pack.mcmeta")
                                    ? McMetaProvider.Create(file, file.Name) // 类型推断不出要用接口
                                    : new RawFile(file, file.Name) as IResourceFileProvider;

            string packName = $"./Minecraft-Mod-Language-Modpack-{config.Base.Version}.zip";
            await using var stream = File.Create(packName);

            using (var archive = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true))
            {
                await Task.WhenAll(from provider in query.Concat(initialsQuery)
                                   select provider.WriteToArchive(archive));
            }

            Log.Information("对版本 {0} 的打包结束。", version);

            var md5 = stream.ComputeMD5();

            Log.Information("打包文件的 MD5 值：{0}", md5);
            File.WriteAllText($"./{config.Base.Version}.md5", md5);
        }
    }
}
