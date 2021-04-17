using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Packer.Models;
using Serilog;
//public static string CombineLangFiles(string destination, string added, string extension)
//{
//    if (!new List<string> { ".json", ".lang" }.Contains(extension))
//    {
//        Log.Warning("检测到暂不支持的拓展名（{0}），取消合并", extension);
//        return destination;
//    }
//    Log.Information("正在反序列化目标文件");
//    var destMap = AssetSerializer.Deserialize(destination, extension);
//    Log.Information("正在反序列化目标文件");
//    var addMap = AssetSerializer.Deserialize(added, extension);
//    foreach (var pair in addMap)
//    {
//        if (!destMap.TryAdd(pair.Key, pair.Value))
//        {
//            Log.Warning("检测到相同 key 的条目：{0} -> {1} | {2}，选取 {1}", pair.Key, destMap[pair.Key], pair.Value);
//        }
//    }
//    Log.Information("正在序列化合并后的文件");
//    return AssetSerializer.Serialize(destMap, extension);
//}

namespace Packer.Extensions
{
    static class SerializingExtension
    {
        public static string SerializeAsset(this Dictionary<string, string> assetMap, FileCategory category)
        {
            return category switch
            {
                FileCategory.JsonTranslationFormat => JsonSerializer.Serialize(assetMap, 
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }),
                FileCategory.LangTranslationFormat => SerializeFromLang(assetMap),
                _ => null // 其实不应该执行到这个地方
            };
        }

        static string SerializeFromLang(Dictionary<string, string> assetMap)
        {
            var sb = new StringBuilder();
            foreach (var pair in assetMap)
            {
                sb.AppendJoin('=', pair.Key, pair.Value);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public static Dictionary<string, string> DeserializeAsset(this string content, FileCategory category)
        {
            return category switch
            {
                FileCategory.JsonTranslationFormat => JsonSerializer.Deserialize<Dictionary<string, string>>(content), // 直接有的算法
                FileCategory.LangTranslationFormat => DeserializeFromLang(content),
                _ => null // 其实不应该执行到这个地方
            };
        }

        static Dictionary<string, string> DeserializeFromLang(string content)
        {
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
                    new List<string> { "//", "#" }.ForEach(_ => { isSingleLineComment = line.StartsWith(_); });
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
                        result.Add(line[..(spiltPosition)], line[(spiltPosition + 1)..]);
                    }
                }
            );
            Log.Verbose("反序列化完成");
            return result;
        }

    }

}
