using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Formatter;
using static Packer.Utils;

namespace Packer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            var hashmap = await Util.ReadReplaceFontMap();
            var config = RetrieveConfig();
            if (config.Version == "1.12.2") {
                await Util.ReplaceFontInLang(config.Version, hashmap);
            }
            else {
                await Util.ReplaceFontInJson(config.Version, hashmap);
            }
            Log.Information("开始打包。版本：{0}", config.Version);
            using var stream = File.Create(".\\Minecraft-Mod-Language-Package-1-16.zip"); // 生成空 zip 文档
            using var archive = new ZipArchive(stream, ZipArchiveMode.Update);
            InitializeArchive(archive, config);
            var existingDomains = new Dictionary<string, string>();
            var assetsToBePacked = new DirectoryInfo($".\\projects\\{config.Version}\\assets")
                .EnumerateDirectories()
                .SelectMany(_ => _.GetDirectories()
                    .Select(descend => new
                    {
                        domainName = descend.Name,
                        name = _.Name,
                        assetPath = descend,
                        prefixLength = _.FullName.Length
                    })
                );
            foreach (var asset in assetsToBePacked)
            {
                if (asset is null)
                {
                    continue;
                }
                var domain = asset.domainName;
                var name = asset.name;
                if (config.ModBlackList.Contains(name))
                {
                    Log.Information("跳过了黑名单中的 mod：{0}（asset-domain：{1}", name, domain);
                    continue;
                }
                if (config.DomainBlackList.Contains(domain))
                {
                    Log.Information("跳过了黑名单中的 asset-domain：{0}（对应 mod：{1}）", domain, name);
                    continue;
                }
                Log.Information("正在打包 {0}（asset-domain：{1}）", name, domain);
                if (existingDomains.ContainsKey(domain))
                {
                    Log.Warning("检测到 asset-domain 与 {0} 重合", existingDomains[domain]);
                    foreach (var file in asset.assetPath.EnumerateFiles("*", SearchOption.AllDirectories))
                    {
                        if (file.FullName.Contains("en_us", StringComparison.OrdinalIgnoreCase))
                        {
                            Log.Information("跳过了英文原文：{0}", file.FullName[(asset.prefixLength + 1)..]);
                            continue;
                        }
                        var destinationPath = $"assets\\{file.FullName[(asset.prefixLength + 1)..]}"
                            .Replace("zh_CN", "zh_cn") // 修复大小写
                            .Replace('\\', '/'); // 修复 Java 平台读取 CentralDirectory 部分时正反斜杠的问题
                        var existingFile = archive.GetEntry(destinationPath);
                        if (existingFile is null) // null 代表没有找到文件，也就是该文件没有重合
                        {
                            archive.CreateEntryFromFile(file.FullName, destinationPath);
                            Log.Information("添加了暂未重合的 {0}", destinationPath);
                        }
                        else
                        {
                            Log.Warning("检测到重合文件：{0}", destinationPath);
                            using var reader = File.OpenRead(file.FullName);
                            using var writer = existingFile.Open();
                            CombineLangFiles(writer, reader, file.Extension);
                            Log.Information("完成合并");
                        }
                    }
                }
                else
                {
                    foreach (var file in asset.assetPath.EnumerateFiles("*", SearchOption.AllDirectories))
                    {
                        if (file.FullName.Contains("en_us", StringComparison.OrdinalIgnoreCase))
                        {
                            Log.Information("跳过了英文原文：{0}", file.FullName[(asset.prefixLength + 1)..]);
                            continue;
                        }
                        var destinationPath = $"assets\\{file.FullName[(asset.prefixLength + 1)..]}"
                            .Replace("zh_CN", "zh_cn") // 修复大小写
                            .Replace('\\', '/'); // 修复 Java 平台读取 CentralDirectory 部分时正反斜杠的问题
                        archive.CreateEntryFromFile(file.FullName, destinationPath);
                        Log.Information("添加了 {0}", destinationPath);
                    }
                    Log.Information("向 asset-domain 映射表中加入：{0} -> {1}", domain, name);
                    existingDomains.Add(domain, name);
                }
            }
            Log.Information("打包结束");
        }

        static Config RetrieveConfig()
        {
            var reader = File.ReadAllBytes(".\\config\\packer.json");
            return JsonSerializer.Deserialize<Config>(reader);
        }
    }
}
