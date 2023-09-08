using Packer.Extensions;
using Packer.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Packer
{
    static class Lib
    {
        /// <summary>
        /// 从主库中选出所需文本
        /// </summary>
        /// <param name="config">所使用的配置</param>
        /// <param name="targetModIdentifiers">
        /// 需要包含的模组列表，按<c>模组唯一标识符</c><br />
        /// 若为<see langword="null"/>，表示包含所有模组
        /// </param>
        /// <returns></returns>
        public static IEnumerable<IResourceFileProvider> RetrieveContent(
            Config config,
            IEnumerable<string>? targetModIdentifiers)

            // 成功实现了没分号的C#语句...这就是查询表达式吗（
            => from modDirectory in new DirectoryInfo($"./projects/{config.Version}/assets")
                                                   .EnumerateDirectories()
               let modIdentifier = modDirectory.Name
               // 模组筛选，按模组标识符
               where targetModIdentifiers is null // 未提供列表，全部打包 
                   || targetModIdentifiers.Contains(modIdentifier) // 有列表，仅打包列表中的项
               from namespaceDirectory in modDirectory.EnumerateDirectories()
               let namespaceName = namespaceDirectory.Name
               // 检查命名空间格式，拒绝错误格式
               // 但是写成表达式以后，没法现场丢异常了...
               where !Regex.IsMatch(namespaceName, 
                                    @"^[a-z0-9_\-.]+$",
                                    RegexOptions.Singleline)
               from provider in namespaceDirectory.EnumerateProviders(config)
               // 合并文件；我猜没写错
               group provider by namespaceName into namespaceGroup
               select namespaceGroup
                   .Aggregate(seed: null as IResourceFileProvider, // 好家伙 类型推断系统推断不出TAggregate
                              (accumlate, next) // 为什么这个参数叫func不叫accumlator或者aggregator...
                                  => next.Append(accumlate, overrideExisting: false));
    }
}
