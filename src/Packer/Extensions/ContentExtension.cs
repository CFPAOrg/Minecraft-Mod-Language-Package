using Packer.Models;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text.Encodings.Web;

namespace Packer.Extensions
{
    /// <summary>
    /// 对字符串的一些拓展方法
    /// </summary>
    public static partial class ContentExtension
    {
        [GeneratedRegex(@"^[a-z0-9_.-]+$", RegexOptions.Singleline)]
        private static partial Regex ValidNamespaceRegex();

        public static bool ValidateNamespace(this string namespaceName)
        {
            // 强行丢异常...行吧
            if (!ValidNamespaceRegex().IsMatch(namespaceName))
                throw new ArgumentOutOfRangeException(nameof(namespaceName), namespaceName, "Invalid namespace name.");
            return true;
        }



        /// <summary>
        /// 将文件的目标路径正规化，以免各种加载出错
        /// </summary>
        /// <param name="path">目标路径</param>
        /// <returns></returns>
        public static string NormalizePath(this string path)
            => path.Replace('\\', '/') // 修正正反斜杠导致的压缩文件读取问题
                   ;

        /// <summary>
        /// 移除模组名一级，在基础文件处理处用到
        /// </summary>
        /// <param name="path">目标文件在库中<c>assets\1\2\...</c>>式位置</param>
        /// <returns></returns>
        public static string StripModName(this string path)
        {
            var _ = path.Split('/').ToList();

            if (_.Count >= 2) _.RemoveAt(1); // 认为模组名在第一处 / 的后面
            return Path.Join(_.ToArray());
        }

        ///// <summary>
        ///// 文本预处理<br></br>
        ///// 目前仅有特殊符号更换，但还是预留了空间
        ///// </summary>
        ///// <param name="content">待处理的文本</param>
        ///// <param name="category">文本种类，用于判断是否转义</param>
        ///// <param name="config">所使用的配置</param>
        ///// <returns></returns>
        //public static string Preprocess(this string content, FileCategory category, Config config)
        //{
        //    // 特殊符号替换
        //    foreach (var mapping in config.CharatcerReplacement)
        //    {
        //        var escaped = JavaScriptEncoder.Default.Encode(mapping.Value);
        //        if (content.Contains(mapping.Key))
        //        {
        //            Log.Information("正在进行特殊符号替换：{0} -> {1}", mapping.Key, escaped);
        //        }
                
        //        if ((category & FileCategory.JsonAlike) == FileCategory.JsonAlike)
        //        { // 替换为 unicode 转义码
        //            content = content.Replace(mapping.Key, escaped);
        //        }
        //        else
        //        { // 替换为 unicode 字符
        //            content = content.Replace(mapping.Key, mapping.Value);
        //        }

        //    }
        //    return content;
        //}

        /// <summary>
        /// 判断文件是否需要跳过预处理<br></br>
        /// 一般而言，图片类文件需要跳过；这一点可以在<c>config\packer.json</c>里控制
        /// </summary>
        /// <param name="location">文件所在的位置</param>
        /// <param name="config">所使用的配置</param>
        /// <returns></returns>
        public static bool IsForceIncluded(this string location, Config config)
            => config.ForceInclusionDomain.Any(_ => location.StartsWith(_ + '/'));

        /// <summary>
        /// 判断文件是否属于应跳过的语言
        /// </summary>
        /// <param name="location">文件所在的位置</param>
        /// <param name="config">所使用的配置</param>
        /// <returns></returns>
        public static bool IsInTargetLanguage(this string location, Config config)
            => config.TargetLanguages.Any(_ => location.Contains(_, StringComparison.OrdinalIgnoreCase));

        // 临时方法
        /// <summary>
        /// 计算给定流中全体内容的MD5值。
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
