using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Packer.Extensions
{
    /// <summary>
    /// 对字符串的一些拓展方法
    /// </summary>
    public static partial class ContentExtension
    {
        /// <summary>
        /// 将文件的目标路径正规化，以免各种加载出错
        /// </summary>
        /// <param name="path">目标路径</param>
        /// <returns>正规化后的文件路径</returns>
        public static string NormalizePath(this string path)
            => path.Replace('\\', '/'); // 修正正反斜杠导致的压缩文件读取问题


        [GeneratedRegex(@"^[a-z0-9_.-]+$", RegexOptions.Singleline)]
        internal static partial Regex ValidNamespaceRegex();

        /// <summary>
        /// 检查命名空间名称是否合法
        /// </summary>
        /// <remarks>
        /// 合法的命名空间名称只包括小写字母、数字、_、.、-
        /// </remarks>
        /// <param name="namespaceName">待校验的命名空间名称</param>
        /// <returns>若合法，返回<see langword="true" /></returns>
        /// <exception cref="ArgumentOutOfRangeException">校验的命名空间不合法</exception>
        public static bool ValidateNamespace(this string namespaceName)
        {
            // 强行丢异常...行吧
            if (!ValidNamespaceRegex().IsMatch(namespaceName))
                throw new ArgumentOutOfRangeException(nameof(namespaceName), namespaceName, "Invalid namespace name.");
            return true;
        }


        /// <summary>
        /// 判断domain是否强制包含
        /// </summary>
        /// <param name="location">文件所在的位置</param>
        /// <param name="config">所使用的配置</param>
        public static bool IsDomainForceIncluded(this string location, Config config)
            => config.Floating.InclusionDomains.Any(_ => location.StartsWith(_ + '/'));

        /// <summary>
        /// 判断domain是否强制排除
        /// </summary>
        /// <param name="location">文件所在的位置</param>
        /// <param name="config">所使用的配置</param>
        public static bool IsDomainForceExcluded(this string location, Config config)
            => config.Floating.ExclusionDomains.Any(_ => location.StartsWith(_ + '/'));

        /// <summary>
        /// 判断文件是否属于目标语言
        /// </summary>
        /// <param name="location">文件所在的位置</param>
        /// <param name="config">所使用的配置</param>
        public static bool IsInTargetLanguage(this string location, Config config)
            => config.Base.TargetLanguages.Any(_ => location.Contains(_, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// 判断文件路径是否强制排除
        /// </summary>
        /// <param name="location">文件所在的位置</param>
        /// <param name="config">所使用的配置</param>
        public static bool IsPathForceExcluded(this string location, Config config)
            => config.Floating.ExclusionPaths.Contains(location);

        /// <summary>
        /// 判断文件路径是否强制包含
        /// </summary>
        /// <param name="location">文件所在的位置</param>
        /// <param name="config">所使用的配置</param>
        public static bool IsPathForceIncluded(this string location, Config config)
            => config.Floating.InclusionPaths.Contains(location);

        /// <summary>
        /// 将字符串输出到调试日志，然后返回该字符串
        /// </summary>
        public static string LogToDebug(this string message, string template)
        {
            Log.Debug(template, message);
            return message;
        }
        /// <summary>
        /// 将字符串输出到调试日志，然后返回该字符串
        /// </summary>
        public static string LogToDebug(this string message)
        {
            Log.Debug(message);
            return message;
        }

        // 临时方法
        /// <summary>
        /// 计算给定流中全体内容的MD5值
        /// </summary>
        /// <param name="stream">被计算的流</param>
        /// <returns></returns>
        public static string ComputeMD5(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin); // 确保文件流的位置被重置
            return Convert.ToHexString(MD5.Create().ComputeHash(stream));
        }
    }
}
