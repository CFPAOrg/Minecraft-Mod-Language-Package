using Packer.Models;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Packer.Extensions
{
    /// <summary>
    /// 用于处理\[namespace]层级的不同加载策略的拓展方法，以及一些辅助方法
    /// </summary>
    public static class DirectoryExtension
    {


        /// <summary>
        /// 从[namespace]生成所需的Asset对象，采用本目录下放置的配置文件
        /// </summary>
        /// <param name="assetPath">目标路径</param>
        /// <param name="config">采用的配置</param>
        /// <param name="bypassed">未经处理的文件</param>
        /// <returns></returns>
        public static IEnumerable<TranslatedFile> AggregateAssetFiles(this DirectoryInfo assetPath,
                                                                      Config config,
                                                                      ref Dictionary<string, string> bypassed)
        {
            // 读取局域配置文件；若为空，配置为“无操作”（直接处理文件）
            var policy = Utils.RetrieveStrategy(assetPath.GetFiles("packer-policy.json").FirstOrDefault());

            if (policy.Type != PackerStrategyType.NoAction)
                Log.Information("对asset-domain {2} 采用非标准检索策略：{0} w/ {1}",
                                policy.Type,
                                policy.Parameters,
                                assetPath.Name);

            // Delegate是个好东西 要不然这参数不知道要多长
            // 不过，什么时候能支持集合字面量......这样子就甚至不用写类型了
            // 目前支持的打包策略
            Dictionary<PackerStrategyType, Del> functionTable = new()
            {
                { PackerStrategyType.NoAction, FromImmediateDirectory },
                { PackerStrategyType.PlainClone, FromIndirectDirectory },
                { PackerStrategyType.CloneMissing, FromMixedDirectory },
                { PackerStrategyType.Patch, FromPatches}
            };
            return functionTable[policy.Type](assetPath, config, ref bypassed, policy.Parameters);
        }

        /// <summary>
        /// 加载策略所使用的标准方法代理
        /// </summary>
        /// <param name="assetDirectory">目标路径</param>
        /// <param name="config">采用的全局配置</param>
        /// <param name="unprocessed">不经处理的文件</param>
        /// <param name="parameters">局部打包配置的附加参数</param>
        /// <returns></returns>
        public delegate IEnumerable<TranslatedFile> Del(DirectoryInfo assetDirectory,
                                                        Config config,
                                                        ref Dictionary<string, string> unprocessed,
                                                        Dictionary<string, JsonElement> parameters);

        static IEnumerable<TranslatedFile> FromMixedDirectory(DirectoryInfo assetDirectory,
                                                              Config config,
                                                              ref Dictionary<string, string> unprocessed,
                                                              Dictionary<string, JsonElement> parameters)
            => Utils.MergeFiles(FromImmediateDirectory(assetDirectory, config, ref unprocessed, parameters),
                                FromIndirectDirectory(assetDirectory, config, ref unprocessed, parameters));

        static IEnumerable<TranslatedFile> FromIndirectDirectory(DirectoryInfo assetDirectory,
                                                                 Config config,
                                                                 ref Dictionary<string, string> unprocessed,
                                                                 Dictionary<string, JsonElement> parameters)
            => FromImmediateDirectory(new DirectoryInfo(parameters["source"].GetString()), config, ref unprocessed, parameters);

        static IEnumerable<TranslatedFile> FromPatches(DirectoryInfo assetDirectory,
                                                       Config config,
                                                       ref Dictionary<string, string> unprocessed,
                                                       Dictionary<string, JsonElement> parameters)
        {
            var reference = FromIndirectDirectory(assetDirectory, config, ref unprocessed, parameters)
                           .ToDictionary(_ => _.RelativePath);
            var patchList = JsonSerializer.Deserialize<Dictionary<string, string>>(parameters["patches"]);
            foreach (var patch in patchList)
            {
                Log.Information("{0}", reference.Keys);
                Log.Information("对文件 {0} 应用 {1} 处的 patch。", patch.Key, patch.Value);
                var target = reference[patch.Key];
                var patchText = string.Join('\n', File.ReadAllLines(patch.Value)); // 不要问我为什么D-M-P默认换行是LF
                target.ApplyPatch(patchText);
            }
            return reference.Values;
        }

        // 目前所有策略的终点方法
        static IEnumerable<TranslatedFile> FromImmediateDirectory(DirectoryInfo assetDirectory,
                                                                  Config config,
                                                                  ref Dictionary<string, string> unprocessed,
                                                                  Dictionary<string, JsonElement> parameters)
        {
            var bypassed = unprocessed;
            var result = assetDirectory.EnumerateFiles("*", SearchOption.AllDirectories) // <asset-domain>/ 的下级文件
                                       .Select(file =>
                {   // 这里开始真正的检索。被跳过的文本用 null 代替
                    var prefixLength = assetDirectory.FullName.Length;
                    var relativePath = file.FullName[(prefixLength + 1)..]; // 在asset-domain下的位置

                    // 跳过英文文件
                    if (relativePath.IsSkippedLang(config))
                    {
                        return null;
                    }

                    // 跳过检索策略文件
                    if (relativePath == "packer-policy.json")
                    {
                        return null;
                    }

                    // 选出不经过处理路径的文件
                    if (relativePath.NeedBypass(config))
                    {
                        Log.Information("跳过了标记为直接加入的命名空间：{0}", relativePath.Split('\\')[0]);
                        bypassed.Add(file.FullName,
                                     Path.Combine("assets",
                                                  assetDirectory.Name,
                                                  relativePath));
                        return null;
                    }

                    // 处理正常的语言文件
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
                            RelativePath = relativePath
                        };
                    }
                    else
                    {
                        return new TranslatedFile(file.OpenRead(),
                                                  parsingCategory | FileCategory.OtherFiles,
                                                  config)
                        {
                            RelativePath = relativePath
                        };
                    }
                }).Where(_ => _ is not null); // 排除掉跳过的文件
            return result;
        }
    }
}
