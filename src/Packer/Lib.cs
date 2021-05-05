using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Packer.Models;
using Packer.Extensions;
using Serilog;

namespace Packer
{
    static class Lib
    {
        public static IEnumerable<Asset> RetrieveContent(Config config, out Dictionary<string, string> unprocessed)
        {
            // 注：仓库的文件结构如下：（仅考虑主要翻译文件）
            // projects/<version>/assets/<mod-name>/<asset-domain>/<namespace>/path/to/the/file
            // 其中，<version> 与 config.Version 一致
            // <mod-name> 是唯一的，但 <asset-domain> 和 <namespace> 都不是唯一的
            // 目标文件层级：
            // assets/<asset-domain>/<namespace>/path/to/the/file
            var bypassed = new Dictionary<string, string>(); // full path -> destination
            var result = new Dictionary<string, Asset>();
            var existingDomains = new Dictionary<string, string>();
            var mods = new DirectoryInfo($"./projects/{config.Version}/assets")
                .EnumerateDirectories() // assets/ 的下级文件夹
                .Select(modDirectory =>
                {
                    return new Mod()
                    {
                        modName = modDirectory.Name,
                        assets = modDirectory
                            .EnumerateDirectories() // <mod-name>/ 的下级文件夹
                            .Select(assetDirectory =>
                            {
                                return new Asset()
                                {
                                    domainName = assetDirectory.Name,
                                    contents = assetDirectory
                                        .EnumerateFiles("*", SearchOption.AllDirectories)
                                        .Select(file =>
                                        { // <asset-domain>/ 的下级文件夹
                                            var prefixLength = assetDirectory.FullName.Length;
                                            var relativePath = file.FullName[(prefixLength + 1)..];
                                            if (relativePath.NeedBypass(config))
                                            {
                                                Log.Information("跳过了标记为直接加入的命名空间：{0}", assetDirectory.Name);
                                                bypassed.Add(file.FullName, Path.Combine("assets",
                                                                  assetDirectory.Name,
                                                                  relativePath).Replace('\\', '/'));
                                                return null;
                                            }
                                            if (relativePath.Contains("en_us", StringComparison.OrdinalIgnoreCase))
                                            {
                                                return null;
                                            }
                                            var parsingCategory = file.Extension switch
                                            {
                                                ".json" => FileCategory.JsonAlike,
                                                _ => FileCategory.LangAlike
                                            };
                                            if (relativePath.StartsWith("lang\\"))
                                            {
                                                return new LangFile(file.OpenRead(),
                                                                    parsingCategory | FileCategory.LanguageFile,
                                                                    config)
                                                {
                                                    relativePath = relativePath
                                                };
                                            }
                                            else
                                            {
                                                parsingCategory |= FileCategory.OtherFiles;
                                                return new TranslatedFile(file.OpenRead(),
                                                                    parsingCategory | FileCategory.OtherFiles,
                                                                    config)
                                                {
                                                    relativePath = relativePath
                                                };
                                            }
                                        }).Where(_ => _ is not null) // 排除掉跳过的文件
                                };
                            })
                    };
                });
            foreach (var mod in mods)
            {
                var name = mod.modName;
                if (!mod.assets.Any()) continue; // 没有 asset 的情况
                foreach (var asset in mod.assets)
                {
                    var domain = asset.domainName;
                    if (config.ModBlackList.Contains(name))
                    {
                        Log.Information("跳过了黑名单中的 mod：{0}（asset-domain：{1}）", name, domain);
                        continue;
                    }
                    if (config.DomainBlackList.Contains(domain))
                    {
                        Log.Information("跳过了黑名单中的 asset-domain：{0}（对应 mod：{1}）", domain, name);
                        continue;
                    }
                    Log.Information("正在处理 {0}（asset-domain：{1}）", name, domain);

                    if (!existingDomains.ContainsKey(domain))
                    {
                        Log.Information("未检测到重合。直接加入");
                        result.Add(domain, asset);
                        Log.Information("向 asset-domain 映射表中加入：{0} -> {1}", domain, name);
                        existingDomains.Add(domain, name);
                    }
                    else
                    {
                        Log.Warning("检测到 asset-domain 与 {0} 重合", existingDomains[domain]);
                        result.Remove(domain, out var existing);
                        result.Add(domain, existing.Combine(asset));
                    }
                }
            }
            unprocessed = bypassed;
            return result.Select(_ => _.Value);
        }
    }
}
