using Packer.Helpers;
using Packer.Models;
using Packer.Models.Providers;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Packer.Extensions
{
    using EvaluatorReturnType = IEnumerable<(IResourceFileProvider provider, ApplyOptions options)>;
    using ParameterType = Dictionary<string, JsonElement>;


    /// <summary>
    /// 用于处理\[namespace]层级的不同加载策略的拓展方法，以及一些辅助方法
    /// </summary>
    public static partial class DirectoryExtension
    {
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
                              ParameterType? parameters);

        /// <summary>
        /// 从<see cref="PackerPolicyType"/>到加载方法<see cref="ProviderEvaluator"/>的查询表
        /// </summary>
        internal static Dictionary<PackerPolicyType, ProviderEvaluator> evaluatorPolicyMap = new()
        {
            { PackerPolicyType.Direct, FromCurrentDirectory },      // 现场生成
            { PackerPolicyType.Indirect, FromSpecifiedDirectory },  // 给定目录
            { PackerPolicyType.Composition, FromComposition },      // 组合生成
            { PackerPolicyType.Singleton, FromSingleton },          // 单项文件
        };

        /// <summary>
        /// 从给定的命名空间，基于当地的<c>packer-policy.json</c>
        /// 与<c>packer-config-fixup.json</c>，遍历<see cref="IResourceFileProvider"/>
        /// </summary>
        /// <param name="namespaceDirectory">命名空间所在目录</param>
        /// <param name="config">所使用的<i>全局</i>配置</param>
        /// <returns></returns>
        public static IEnumerable<IResourceFileProvider> EnumerateProviders
            (this DirectoryInfo namespaceDirectory, Config config)
            => from enumeratedPair in namespaceDirectory.EnumerateRawProviders(config)
               group enumeratedPair by enumeratedPair.provider.Destination into providerGroup
               select providerGroup.Aggregate(
                   seed: null as IResourceFileProvider,
                   (accumulate, next)
                       => next.provider.ApplyTo(accumulate, next.options));

        /// <summary>
        /// 遍历未经合并的文件，用于递归调用
        /// </summary>
        internal static EvaluatorReturnType EnumerateRawProviders(this DirectoryInfo namespaceDirectory, Config config)
            => from policy in ConfigHelpers.RetrievePolicy(namespaceDirectory)
               from enumeratedPair in evaluatorPolicyMap[policy.Type].Invoke(
                   namespaceDirectory, config, policy.Parameters)
               select enumeratedPair;


        internal static EvaluatorReturnType FromCurrentDirectory(DirectoryInfo namespaceDirectory,
                                                                 Config config,
                                                                 ParameterType? parameters)
        {
            var floatingConfig = ConfigHelpers.RetrieveLocalConfig(namespaceDirectory);
            var localConfig = config.Modify(floatingConfig);

            return from candidate in namespaceDirectory.EnumerateFiles("*", SearchOption.AllDirectories)
                   let relativePath = Path.GetRelativePath(namespaceDirectory.FullName,
                                                           candidate.FullName)
                                          .NormalizePath()
                   let fullPath = Path.GetRelativePath(".", candidate.FullName)
                   let destination = Path.Combine("assets", namespaceDirectory.Name, relativePath)
                                         .NormalizePath()
                   where !relativePath.IsPathForceExcluded(localConfig)             // [1] 排除路径   -- packer-policy等
                   where (relativePath.IsPathForceIncluded(localConfig)             // [2] 包含路径   [单列]
                       || relativePath.IsDomainForceIncluded(localConfig)           // [3] 包含domain -- font/ textures/
                       || (destination.IsInTargetLanguage(localConfig)              // [4] 语言标记   -- 含zh_cn的
                           && !relativePath.IsDomainForceExcluded(localConfig)))    // [5] 排除domain [暂无]
                   let provider = CreateProviderFromFile(candidate, destination, localConfig)
                   select (provider, GetOptions(parameters));
        }

        internal static EvaluatorReturnType FromSpecifiedDirectory(DirectoryInfo namespaceDirectory,
                                                                   Config config,
                                                                   ParameterType? parameters)
        {
            var redirect = parameters!["source"].GetString();
            var namespaceName = namespaceDirectory.Name;
            var redirectDirectory = new DirectoryInfo(redirect!);

            Log.Debug("[Policy:Indirect]目标：{0}，源：{1}", namespaceName, redirect);

            return from candidate in redirectDirectory.EnumerateRawProviders(config)
                   let provider = candidate.provider
                                           .ReplaceDestination(@"(?<=^assets/)[^/]*(?=/)",
                                                               namespaceName)
                   select (provider, GetOptions(parameters));
        }

        internal static EvaluatorReturnType FromComposition(DirectoryInfo namespaceDirectory,
                                                            Config config,
                                                            ParameterType? parameters)
        {
            var compositionPath = parameters!["source"].GetString();
            var type = parameters["destType"].GetString();
            var compositionFile = new FileInfo(compositionPath!);

            Log.Debug("[Policy:Composition]目标：{0}，源：{1}", namespaceDirectory.Name, compositionPath);

            IResourceFileProvider provider = type switch // 类型推断不出要用接口
            {
                "lang" => LangMappingHelper.CreateFromComposition(compositionFile),
                "json" => JsonMappingHelper.CreateFromComposition(compositionFile),
                _ => throw new InvalidOperationException($"Unexpected Type parameter at {namespaceDirectory.FullName}.")
            };
            yield return (provider, GetOptions(parameters));
        }

        internal static EvaluatorReturnType FromSingleton(DirectoryInfo namespaceDirectory,
                                                          Config config,
                                                          ParameterType? parameters)
        {
            var singletonPath = parameters!["source"].GetString()!;
            var relativePath = parameters!["relativePath"].GetString()!;
            var destination = Path.Combine("assets", namespaceDirectory.Name, relativePath)
                                  .NormalizePath();

            Log.Debug("[Policy:Singleton]目标：{0}，源：{1}", destination, singletonPath);

            var file = new FileInfo(singletonPath!);
            var provider = CreateProviderFromFile(file, destination, config);

            yield return (provider, GetOptions(parameters));
        }


        internal static IResourceFileProvider CreateProviderFromFile(FileInfo file, string destination, Config config)
        {
            var extension = file.Extension;
            if (file.Directory!.Name == "lang")
            {
                switch (extension)
                {
                    case ".json": return JsonMappingHelper.CreateFromFile(file, destination);
                    case ".lang": return LangMappingHelper.CreateFromFile(file, destination);
                };
            }
            return extension switch
            {
                // 已知的文本文件类型
                ".txt" or ".json" or ".md" => TextFile.Create(file, destination),
                _ => new RawFile(file, destination)
            };
        }

        internal static ApplyOptions GetOptions(ParameterType? parameters)
        {
            if (parameters is null) return default;
            return new(GetBoolOrDefalut("modifyOnly"), GetBoolOrDefalut("append"));

            bool GetBoolOrDefalut(string key)
            {
                if (!parameters.ContainsKey(key)) return false;
                return parameters[key].GetBoolean();
            }
        }
    }
}