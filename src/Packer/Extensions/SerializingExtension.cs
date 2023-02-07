using Packer.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Packer.Extensions
{
    static class SerializingExtension
    {
        public static string SerializeAsset(this Dictionary<string, string> assetMap, FileCategory category)
            => category switch
            {
                // Json 文件，直接写出
                FileCategory.JsonTranslationFormat => JsonSerializer.Serialize(assetMap,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }),
                // Lang文件
                FileCategory.LangTranslationFormat => SerializeFromLang(assetMap),
                _ => null // 其实不应该执行到这个地方
            };

        static string SerializeFromLang(Dictionary<string, string> assetMap)
        {
            // lang格式化还好说
            var sb = new StringBuilder();
            foreach (var pair in assetMap)
            {
                sb.AppendJoin('=', pair.Key, pair.Value);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public static Dictionary<string, string> DeserializeAsset(this string content, FileCategory category)
            => category switch
            {
                FileCategory.JsonTranslationFormat
                    => JsonSerializer.Deserialize<Dictionary<string, string>>(content,
                    new JsonSerializerOptions
                    {
                        ReadCommentHandling = JsonCommentHandling.Skip // 打包过程应当兼容注释，但不需要写入注释
                    }), // 直接有的算法
                FileCategory.LangTranslationFormat => DeserializeFromLang(content),
                _ => null // 其实不应该执行到这个地方
            };

        static Dictionary<string, string> DeserializeFromLang(string content)
        {
            // 甚至不是自动机...所以不敢多用，否则会炸

            // 下面的 Verbose 仅供调试，不会在 log 里出现
            // .lang的格式真的乱...
            Log.Verbose("开始反序列化 .lang 文件");
            // #PARSE_ESCAPE就算了吧
            var result = new Dictionary<string, string>();
            var isInComment = false; // 处理多行注释
            new List<string>(content.Split(Environment.NewLine,
                                           StringSplitOptions.RemoveEmptyEntries))
                .ForEach(line =>
                {
                    var isSingleLineComment = false;
                    new List<string> { "//", "#" }
                        .ForEach(_ => { isSingleLineComment |= line.StartsWith(_); });
                    if (isSingleLineComment)
                    {
                        Log.Verbose("跳过了单行注释：{0}", line);
                    }
                    else if (isInComment) // 多行注释内
                    {
                        Log.Verbose("{0}", line);
                        if (line.Trim()
                                .EndsWith("*/"))
                        {
                            isInComment = false;  // 跳出注释
                        }
                    }
                    else if (line.StartsWith("/*")) // 开始多行注释
                    {
                        Log.Verbose("跳过了多行注释：{0}", line);
                    }
                    else // 真正的条目
                    {
                        Log.Verbose("添加对应映射：{0}", line);
                        var spiltPosition = line.IndexOf('=');
                        try
                        {
                            result.Add(line[..spiltPosition], line[(spiltPosition + 1)..]);
                        }
                        catch (Exception e)
                        {
                            Log.Warning(e.ToString());
                        }
                    }
                }
            );
            Log.Verbose("反序列化完成");
            return result;
        }
    }
}
