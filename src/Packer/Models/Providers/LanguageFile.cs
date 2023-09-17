using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;

namespace Packer.Models.Providers
{

    using LangMappingProvider = TermMappingProvider<string>;
    using JsonMappingProvider = TermMappingProvider<JsonNode>;

    public class LangLanguageFile : LangMappingProvider
    {
        public LangLanguageFile(ITermDictionary<string> map, string destination) : base(map, destination) { }
        public static LangLanguageFile Create(FileInfo file, string destination)
        {
            using var stream = file.OpenRead();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            var content = reader.ReadToEnd();
            return new(new LangDictionaryWrapper(DeserializeFromLang(content)), destination);
        }

        // RAW CONTENT
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


    public class JsonLanguageFile : JsonMappingProvider
    {
        public JsonLanguageFile(ITermDictionary<JsonNode> map, string destination) : base(map, destination) { }
        public static JsonLanguageFile Create(FileInfo file, string destination)
        {
            using var stream = file.OpenRead();
            return new(new JsonDictionaryWrapper(JsonNode.Parse(stream).AsObject()), destination);
        }
    }

}
