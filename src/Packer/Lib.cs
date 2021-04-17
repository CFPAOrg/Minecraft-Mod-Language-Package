using Packer.Models;
using Packer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Serilog;

namespace Packer
{
    static class Lib
    {
        public static IEnumerable<Asset> RetrieveContent(Config config, out Dictionary<string,string> unprocessed)
        {
            // 注：仓库的文件结构如下：（仅考虑主要翻译文件）
            // projects/<version>/assets/<mod-name>/<asset-domain>/<sub-directory>/path/to/the/file
            // 其中，<version> 与 config.Version 一致
            // <mod-name> 是唯一的，但 <asset-domain> 和 <sub-directory> 都不是唯一的
            // 目标文件层级：
            // assets/<asset-domain>/<sub-directory>/path/to/the/file
            var bypassed = new Dictionary<string, string>(); // full path -> destination
            var result = new Dictionary<string, Asset>();
            var existingDomains = new Dictionary<string, string>();
            var mods = new DirectoryInfo($"./projects/{config.Version}/assets")
                .EnumerateDirectories() // assets/ 的下级文件夹
                .Select(modDirectory =>
                {
                    Log.Information("2");
                    return new Mod()
                    {
                        modName = modDirectory.Name,
                        assets = modDirectory
                            .EnumerateDirectories()
                            .Select(assetDirectory =>
                            { // <mod-name>/ 的下级文件夹
                                Log.Information("3");
                                return new Asset()
                                {
                                    domainName = assetDirectory.Name,
                                    contents = assetDirectory
                                        .EnumerateFiles("*", SearchOption.AllDirectories)
                                        .Select(file =>
                                        { // <asset-domain>/ 的下级文件夹
                                            Log.Information("4");
                                            Log.Information(assetDirectory.FullName);
                                            var prefixLength = assetDirectory.FullName.Length;
                                            var relativePath = file.FullName[(prefixLength + 1)..];
                                            Log.Information(relativePath);
                                            if (relativePath.NeedBypass(config))
                                            {
                                                Log.Information("跳过了标记为不被处理的命名空间：{0}", assetDirectory.Name);
                                                bypassed.Add(file.FullName, Path.Combine("assets",
                                                                  assetDirectory.Name,
                                                                  relativePath));
                                                return null;
                                            }
                                            if(relativePath.Contains("en_us", StringComparison.OrdinalIgnoreCase))
                                            {
                                                Log.Information("跳过了英文原文");
                                                return null;
                                            }
                                            var parsingCategory = file.Extension switch
                                            {
                                                ".json" => FileCategory.JsonAlike,
                                                _ => FileCategory.LangAlike
                                            };
                                            if (relativePath.Contains("lang"))
                                            {
                                                parsingCategory |= FileCategory.LanguageFile;
                                            }
                                            else
                                            {
                                                parsingCategory |= FileCategory.OtherFiles;
                                            }
                                            return new LangFile(file.OpenRead(),
                                                                       parsingCategory,
                                                                       config)
                                                          {
                                                              relativePath = relativePath
                                                          };
                                        }).Where(_ => _ is not null)
                                };
                            })
                    };
                });
            Log.Information("1");
            foreach(var mod in mods)
            {
                var name = mod.modName;
                if (!mod.assets.Any()) continue;
                foreach(var asset in mod.assets)
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
                    { // 没有冲突，直接加入
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
        //var mapping = await Utils.ReadReplaceFontMap();
        //var config = Utils.RetrieveConfig();
        //Log.Information("开始打包。版本：{0}", config.Version);
        //using var stream = File.Create(".\\Minecraft-Mod-Language-Package.zip"); // 生成空 zip 文档
        //using var archive = new ZipArchive(stream, ZipArchiveMode.Update);
        //archive.Initialize(config);
        //           - ------ - -- - - - -- - - -
        //Log.Information("打包结束");
        //var md5 = new MD5CryptoServiceProvider();
        //var hash = await md5.ComputeHashAsync(stream);
        //var md5Str = Convert.ToBase64String(hash);
        //await File.WriteAllTextAsync($"./{config.Version}.md5",md5Str);


     
    }
}
