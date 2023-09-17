using Packer.Models;
using Packer.Models.Providers;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Packer.Extensions
{
    using EvaluatorReturnType = IEnumerable<(IResourceFileProvider provider, bool overrides)>;
    using ParameterType = Dictionary<string, JsonElement>;


    /// <summary>
    /// 用于处理\[namespace]层级的不同加载策略的拓展方法，以及一些辅助方法
    /// </summary>
    public static partial class DirectoryExtension
    {
        [GeneratedRegex(@"^assets/[a-z0-9_.-]+/lang/[a-zA-Z0-9_-]+\.(?:json|lang)$", RegexOptions.Singleline)]
        private static partial Regex LanguageFileRegex();


        /// <summary>
        /// 加载策略所使用的标准方法代理
        /// </summary>
        /// <param name="namespaceDirectory">加载的基准位置</param>
        /// <param name="config">采用的全局配置</param>
        /// <param name="parameters">局部打包配置的附加参数</param>
        /// <returns>一个<see cref="Tuple"/>，第一参数为提供器的目标</returns>
        public delegate EvaluatorReturnType
            ProviderEvaluator(DirectoryInfo namespaceDirectory,
                              Config config,
                              Dictionary<string, JsonElement> parameters);

        public static Dictionary<PackerStrategyType, ProviderEvaluator> functionTable = new()
        {
            { PackerStrategyType.NoAction, FromCurrentDirectory },
            { PackerStrategyType.CloneMissing, FromSpecifiedDirectory } // ,
            // ...
        };

        public static IEnumerable<IResourceFileProvider> EnumerateProviders
            (this DirectoryInfo namespaceDirectory, Config config)
            => from enumeratedPair in namespaceDirectory.EnumerateRawProviders(config)
                              group enumeratedPair by enumeratedPair.provider.Destination into providerGroup
                              select providerGroup.Aggregate(
                                  seed: null as IResourceFileProvider,
                                  (accumlate, next)
                                      => next.provider.ApplyTo(accumlate, next.overrides)) /* into provider
                   select provider.ReplaceDestination(@"(?<=^assets/)[^/]*(?=/)",
                                                      namespaceDirectory.Name) */ ;// WARNING：路径替换要做到具体方法里面！

        static EvaluatorReturnType EnumerateRawProviders(this DirectoryInfo namespaceDirectory, Config config)
        {
            var policyFile = namespaceDirectory.GetFiles("packer-policy.json").FirstOrDefault();
            var policyList = Utils.RetrieveStrategy(policyFile);

            return from policy in policyList
                   from enumeratedPair in functionTable[policy.Type](namespaceDirectory, config, policy.Parameters)
                   select enumeratedPair;
        }

        ///// <summary>
        ///// 从[namespace]生成所需的Asset对象，采用本目录下放置的配置文件
        ///// </summary>
        ///// <param name="assetPath">目标路径</param>
        ///// <param name="config">采用的配置</param>
        ///// <param name="bypassed">未经处理的文件</param>
        ///// <returns></returns>
        //public static IEnumerable<IResourceFileProvider> AggregateAssetFiles(this DirectoryInfo assetPath,
        //                                                              Config config,
        //                                                              ref Dictionary<string, string> bypassed)
        //{
        //    // 读取局域配置文件；若为空，配置为“无操作”（直接处理文件）
        //    var policy = Utils.RetrieveStrategy(assetPath.GetFiles("packer-policy.json").FirstOrDefault());

        //    if (policy.Type != PackerStrategyType.NoAction)
        //        Log.Information("对asset-domain {2} 采用非标准检索策略：{0} w/ {1}",
        //                        policy.Type,
        //                        policy.Parameters,
        //                        assetPath.Name);

        //    // Delegate是个好东西 要不然这参数不知道要多长
        //    // 不过，什么时候能支持集合字面量......这样子就甚至不用写类型了
        //    // 目前支持的打包策略
        //    Dictionary<PackerStrategyType, ProviderEvaluator> functionTable = new()
        //    {
        //        { PackerStrategyType.NoAction, FromImmediateDirectory },
        //        { PackerStrategyType.PlainClone, FromIndirectDirectory },
        //        { PackerStrategyType.CloneMissing, FromMixedDirectory },
        //        { PackerStrategyType.BackPort, FromBackPort },
        //        { PackerStrategyType.Patch, FromPatches }
        //    };
        //    return functionTable[policy.Type](assetPath, config, ref bypassed, policy.Parameters);
        //}



        static IResourceFileProvider CreateProviderFromFile(FileInfo file, string destination, Config config)
        {
            var extension = file.Extension;
            if (file.Directory!.Name == "lang")
            {
                switch (extension)
                {
                    case ".json": return JsonLanguageFile.Create(file, destination);
                    case ".lang": return LangLanguageFile.Create(file, destination);
                };
            }
            return extension switch
            {
                // 已知的文本文件类型
                ".txt" or ".json" or ".md" => TextFile.Create(file, destination),
                _ => new RawFile(file, destination)
            };
        }






        static EvaluatorReturnType FromCurrentDirectory(DirectoryInfo namespaceDirectory,
                                                        Config config,
                                                        ParameterType parameters)
            => from candidate in namespaceDirectory.EnumerateFiles("*", SearchOption.AllDirectories)
               let relativePath = Path.GetRelativePath(namespaceDirectory.FullName,
                                                       candidate.FullName)
                                      .NormalizePath()
               let destination = Path.Combine(namespaceDirectory.Name,
                                              relativePath)
                                     .NormalizePath()
               let domain = relativePath.Split('/')[0]
               where relativePath != "packer-policy.json" // TODO：其他文件             // 策略文件本身不包含
               where destination.IsInTargetLanguage(config)                             // 含有正确的语言标记
                   || relativePath.IsForceIncluded(config)                              // 强制包含
               let provider = CreateProviderFromFile(candidate, destination, config)
               select (provider, DoesOverride(parameters));

        static EvaluatorReturnType FromSpecifiedDirectory(DirectoryInfo namespaceDirectory,
                                                          Config config,
                                                          ParameterType parameters)
        {
            var redirect = parameters["source"].GetString();
            var namespaceName = namespaceDirectory.Name;
            namespaceName.ValidateNamespace();
            var redirectDirectory = new DirectoryInfo(redirect!);
            return from candidate in redirectDirectory.EnumerateRawProviders(config)
                   let provider = candidate.provider
                                           .ReplaceDestination(@"^(?<=^assets/)[^/]*(?=/)",
                                                               namespaceName)
                   select (provider, DoesOverride(parameters));
        }




        static bool DoesOverride(ParameterType parameters)
        {
            var hasKey = parameters.TryGetValue("overrides", out var element);
            return hasKey ? element.GetBoolean() : false;
        }






        //static IEnumerable<TranslatedFile> FromMixedDirectory(DirectoryInfo assetDirectory,
        //                                                      Config config,
        //                                                      ref Dictionary<string, string> unprocessed,
        //                                                      Dictionary<string, JsonElement> parameters)
        //    => Utils.MergeFiles(FromImmediateDirectory(assetDirectory, config, ref unprocessed, parameters),
        //                         FromIndirectDirectory(assetDirectory, config, ref unprocessed, parameters));

        //static IEnumerable<TranslatedFile> FromBackPort(DirectoryInfo assetDirectory,
        //                                                      Config config,
        //                                                      ref Dictionary<string, string> unprocessed,
        //                                                      Dictionary<string, JsonElement> parameters)
        //    => Utils.PortFiles(FromImmediateDirectory(assetDirectory, config, ref unprocessed, parameters),
        //                        FromIndirectDirectory(assetDirectory, config, ref unprocessed, parameters));

        //static IEnumerable<TranslatedFile> FromIndirectDirectory(DirectoryInfo assetDirectory,
        //                                                         Config config,
        //                                                         ref Dictionary<string, string> unprocessed,
        //                                                         Dictionary<string, JsonElement> parameters)
        //    => AggregateAssetFiles(new DirectoryInfo(parameters["source"].GetString()), config, ref unprocessed);

        //static IEnumerable<TranslatedFile> FromPatches(DirectoryInfo assetDirectory,
        //                                               Config config,
        //                                               ref Dictionary<string, string> unprocessed,
        //                                               Dictionary<string, JsonElement> parameters)
        //{
        //    var reference = FromIndirectDirectory(assetDirectory, config, ref unprocessed, parameters)
        //                   .ToDictionary(_ => _.RelativePath);
        //    var patchList = JsonSerializer.Deserialize<Dictionary<string, string>>(parameters["patches"]);
        //    foreach (var patch in patchList)
        //    {
        //        Log.Information("对文件 {0} 应用 {1} 处的 patch。", patch.Key, patch.Value);
        //        reference.Remove(patch.Key, out var target);
        //        var patchText = string.Join('\n', File.ReadAllLines(patch.Value)); // 不要问我为什么D-M-P默认换行是LF
        //        reference.Add(patch.Key, target.ApplyPatch(patchText));
        //    }
        //    return reference.Values;
        //}

        //// 目前所有策略的终点方法
        //static IEnumerable<TranslatedFile> FromImmediateDirectory(DirectoryInfo assetDirectory,
        //                                                          Config config,
        //                                                          ref Dictionary<string, string> unprocessed,
        //                                                          Dictionary<string, JsonElement> parameters)
        //{
        //    var bypassed = unprocessed;
        //    var result = assetDirectory.EnumerateFiles("*", SearchOption.AllDirectories) // <asset-domain>/ 的下级文件
        //                               .Select(file =>
        //        {   // 这里开始真正的检索。被跳过的文本用 null 代替
        //            var prefixLength = assetDirectory.FullName.Length;
        //            var relativePath = file.FullName[(prefixLength + 1)..]
        //                               .Replace('\\', '/'); // 在asset-domain下的位置，规范为用正斜杠分割

        //            // 处理被跳过的文本。处理顺序：policy -> [bypass](font, textures) -> !zh_cn
        //            // 顺序乱了会导致字体文件被丢弃，因为没有带zh_cn

        //            // 跳过检索策略文件
        //            if (relativePath == "packer-policy.json")
        //            {
        //                return null;
        //            }

        //            // 选出不经过处理路径的文件
        //            if (relativePath.IsForceIncluded(config))
        //            {
        //                var target = Path.Combine("assets",
        //                                          assetDirectory.Name,
        //                                          relativePath);
        //                Log.Information("跳过了标记为直接加入的命名空间：{0} -> {1}",
        //                                relativePath.Split('/')[0],
        //                                target);

        //                if (bypassed.ContainsValue(target))
        //                {
        //                    Log.Warning("在未处理文件中检测到重复项。丢弃将要加入的新项");
        //                    return null;
        //                }
        //                bypassed.Add(file.FullName, target);
        //                return null;
        //            }

        //            // 跳过非中文文件
        //            if (!relativePath.IsInTargetLanguage(config))
        //            {
        //                return null;
        //            }

        //            // 跳过非中文文件
        //            if (!relativePath.IsInTargetLanguage(config))
        //            {
        //                return null;
        //            }

        //            // 处理正常的语言文件
        //            // TODO：Json5支持
        //            var parsingCategory = file.Extension switch
        //            {
        //                ".json" => FileCategory.JsonAlike,
        //                _ => FileCategory.LangAlike
        //            };
        //            if (relativePath.StartsWith("lang/"))
        //            {
        //                return new LangFile(file.OpenRead(),
        //                                    parsingCategory | FileCategory.LanguageFile,
        //                                    config)
        //                {
        //                    RelativePath = relativePath
        //                };
        //            }
        //            else
        //            {
        //                return new TranslatedFile(file.OpenRead(),
        //                                          parsingCategory | FileCategory.OtherFiles,
        //                                          config)
        //                {
        //                    RelativePath = relativePath
        //                };
        //            }
        //        }).Where(_ => _ is not null); // 排除掉跳过的文件
        //    return result;
        //}
    }
}
