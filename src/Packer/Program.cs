using Serilog;

using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Packer {
    class Program {
        static async Task Main(string[] args) {
            var command = new RootCommand() {
                new Option<string>(
                    "--version",
                    getDefaultValue: (() => "1.12.2"),
                    description: "Set pack version.")
            };

            command.Description = "Config of packer";

            command.Handler = CommandHandler.Create<string>(async version => {
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();
                var mapping = await Utils.ReadReplaceFontMap();
                var config = Utils.RetrieveConfig(version);
                Log.Information("开始打包。版本：{0}", config.Version);
                using var stream = File.Create($".\\Minecraft-Mod-Language-Package-{version}.zip"); // 生成空 zip 文档
                using var archive = new ZipArchive(stream, ZipArchiveMode.Update);
                archive.Initialize(config);
                var existingDomains = new Dictionary<string, string>();
                var assetsToBePacked = new DirectoryInfo($".\\projects\\{config.Version}\\assets")
                    .EnumerateDirectories()
                    .SelectMany(_ => _.GetDirectories()
                        .Select(descend => new {
                            domainName = descend.Name,
                            name = _.Name,
                            assetPath = descend,
                            prefixLength = _.FullName.Length
                        })
                    );
                foreach (var asset in assetsToBePacked) {
                    if (asset is null) {
                        continue;
                    }
                    var domain = asset.domainName;
                    var name = asset.name;
                    if (!domain.IsDomainValid(config)) {
                        // 检查 asset-domain 并非下层的 namespace
                        // 此处去除掉由于少掉一层文件夹导致的打包问题，需要自行查看日志后修复
                        Log.Warning("检测到错误的 asset-domain（{0}），mod 名：{1}。跳过该项", domain, name);
                        continue;
                    }
                    if (config.ModBlackList.Contains(name)) {
                        Log.Information("跳过了黑名单中的 mod：{0}（asset-domain：{1}", name, domain);
                        continue;
                    }
                    if (config.DomainBlackList.Contains(domain)) {
                        Log.Information("跳过了黑名单中的 asset-domain：{0}（对应 mod：{1}）", domain, name);
                        continue;
                    }
                    Log.Information("正在打包 {0}（asset-domain：{1}）", name, domain);
                    bool conflict = existingDomains.ContainsKey(domain);
                    if (conflict) {
                        Log.Warning("检测到 asset-domain 与 {0} 重合", existingDomains[domain]);
                    }
                    foreach (var file in asset.assetPath.EnumerateFiles("*", SearchOption.AllDirectories)) {
                        if (file.FullName.Contains("en_us", StringComparison.OrdinalIgnoreCase)) {
                            Log.Information("跳过了英文原文：{0}", file.FullName[(asset.prefixLength + 1)..]);
                            continue;
                        }
                        var destinationPath = $"assets\\{file.FullName[(asset.prefixLength + 1)..]}"
                            .Replace("zh_CN", "zh_cn") // 修复大小写
                            .Replace('\\', '/'); // 修复 Java 平台读取 CentralDirectory 部分时正反斜杠的问题
                        if (destinationPath.NeedBypass(config)) {
                            Log.Information("直接添加标记为不被处理的命名空间：{0}", destinationPath);
                            archive.CreateEntryFromFile(file.FullName, destinationPath);
                            continue;
                        }
                        var fileContent = (await File.ReadAllTextAsync(file.FullName, Encoding.UTF8))
                            .Preprocess(file.Extension, mapping);

                        if (conflict) {
                            var existingFile = archive.GetEntry(destinationPath);
                            if (existingFile is null) // null 代表没有找到文件，也就是该文件没有重合
                            {
                                await archive.CreateLangFile(destinationPath, fileContent);
                                Log.Information("添加了暂未重合的 {0}", destinationPath);
                            }
                            else {
                                Log.Warning("检测到重合文件：{0}", destinationPath);
                                if (!destinationPath.Contains("/lang/")) {
                                    Log.Warning("检测到暂不支持合并的文件（{0}），取消合并", file.FullName);
                                    continue;
                                }
                                string existingContent;
                                using (var reader = new StreamReader(existingFile.Open(),
                                                                    Encoding.UTF8,
                                                                    leaveOpen: false)) {
                                    existingContent = await reader.ReadToEndAsync();
                                }
                                existingFile.Delete(); // 在添加新文件前提前删除，以规避重名文件导致的问题
                                var result = Utils.CombineLangFiles(existingContent, fileContent, file.Extension);
                                await archive.CreateLangFile(destinationPath, result);
                                Log.Information("完成合并");
                            }
                        }
                        else {
                            await archive.CreateLangFile(destinationPath, fileContent);
                            Log.Information("添加了 {0}", destinationPath);
                        }
                    }
                    if (!conflict) {
                        Log.Information("向 asset-domain 映射表中加入：{0} -> {1}", domain, name);
                        existingDomains.Add(domain, name);
                    }
                }
                Log.Information("打包结束。开始生成 md5 值");
                var md5 = new MD5CryptoServiceProvider();
                var hash = await md5.ComputeHashAsync(stream);
                var md5Hex = string.Concat(hash.Select(x => x.ToString("X2")));
                await File.WriteAllTextAsync($"./{config.Version}.md5", md5Hex);
                Log.Information("生成结束。md5: {0}", md5Hex);
            });

        }
    }
}
