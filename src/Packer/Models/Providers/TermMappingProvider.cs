using Packer.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.Encodings.Web;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using System.Linq;

namespace Packer.Models.Providers
{
    using LangMappingProvider = TermMappingProvider<string>;
    using JsonMappingProvider = TermMappingProvider<JsonNode>;

    #region termDictionary
    /// <summary>
    /// 可以作为语言文件使用的键值对包装
    /// </summary>
    /// <typeparam name="TValue">内部使用的值类型</typeparam>
    public interface ITermDictionary<TValue> : IDictionary<string, TValue>
    {
        /// <summary>
        /// 从内部的键值对表示生成正确的语言文件文本
        /// </summary>
        /// <returns>生成文本</returns>
        public string ProvideStringContent();
        /// <summary>
        /// 在内部键值对的值中，对于文本部分，执行给定的替换。
        /// </summary>
        /// <param name="searchPattern">替换的匹配模式，使用<see cref="Regex"/></param>
        /// <param name="replacement">替换文本</param>
        /// <returns>替换得到的新<see cref="ITermDictionary{TValue}"/></returns>
        public ITermDictionary<TValue> ReplaceContent(string searchPattern, string replacement);
    }

    internal class LangDictionaryWrapper : Dictionary<string, string>, ITermDictionary<string>
    {
        public LangDictionaryWrapper(IDictionary<string, string> dictionary) : base(dictionary) { }

        public string ProvideStringContent()
        {
            var builder = new StringBuilder();
            foreach (var (key, value) in this)
            {
                builder.AppendJoin('=', key, value);
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        public ITermDictionary<string> ReplaceContent(string searchPattern, string replacement)
        {
            var result = new Dictionary<string, string>();
            foreach (var (key, value) in this)
            {
                var replaced = Regex.Replace(value,
                                             searchPattern,
                                             replacement,
                                             RegexOptions.Singleline);
                result.Add(key, replaced);
            }
            return new LangDictionaryWrapper(result);
        }
    }

    internal class JsonDictionaryWrapper : Dictionary<string, JsonNode>, ITermDictionary<JsonNode>
    {
        public JsonDictionaryWrapper(IDictionary<string, JsonNode> dictionary) : base(dictionary) { }

        public string ProvideStringContent()
            => JsonSerializer.Serialize(this, new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

        public ITermDictionary<JsonNode> ReplaceContent(string searchPattern, string replacement)
        {
            var result = new Dictionary<string, JsonNode>();
            foreach (var (key, value) in this)
            {
                if (value.GetType() == typeof(JsonValue)
                    && value.AsValue().TryGetValue<string>(out var stringValue))
                {
                    var replaced = Regex.Replace(stringValue,
                                                 searchPattern,
                                                 replacement,
                                                 RegexOptions.Singleline);
                    result.Add(key, JsonValue.Create(replaced)!); // 我猜不会null罢
                    continue;
                }
                result.Add(key, value);
            }
            return new JsonDictionaryWrapper(result);
        }

        public static ITermDictionary<JsonNode> Create(IDictionary<string, string> nominalMapping)
        {
            var query = from pair in nominalMapping
                        let key = pair.Key
                        let value = pair.Value
                        let node = JsonValue.Create(value)!
                        select (key, node);
            var transformed = query.ToDictionary(_ => _.key, _ => _.node as JsonNode);
            return new JsonDictionaryWrapper(transformed);
        }
    }

    #endregion

    #region Provider
    /// <summary>
    /// 语言文件的提供器。支持内容替换、文件合并
    /// </summary>
    /// <remarks>
    /// 对于在<c>lang/</c>下的文件，使用该类型
    /// </remarks>
    /// <typeparam name="TValue">内部使用的值类型</typeparam>
    public class TermMappingProvider<TValue> : IResourceFileProvider
    {
        /// <summary>
        /// 语言文件所表示的映射表
        /// </summary>
        public ITermDictionary<TValue> Map { get; }
        
        /// <inheritdoc/>
        public string Destination { get; }

        /// <summary>
        /// 从给定的映射表构造提供器
        /// </summary>
        /// <param name="map">映射表</param>
        /// <param name="destination">目标地址</param>
        public TermMappingProvider(ITermDictionary<TValue> map, string destination)
        {
            Map = map;
            Destination = destination;
        }

        /// <inheritdoc/>
        public IResourceFileProvider ApplyTo(IResourceFileProvider? incoming, bool overrideExisting = false)
        {
            if (incoming is not TermMappingProvider<TValue>)
                throw new ArgumentException($"Argument not an instance of {typeof(TermMappingProvider<TValue>)}.",
                                            nameof(incoming));
            var inProvider = incoming as TermMappingProvider<TValue>;

            if (inProvider is null) throw new ArgumentNullException(nameof(incoming));

            var (baseMap, inMap) = !overrideExisting
                ? (Map, inProvider.Map)
                : (inProvider.Map, Map); // 交换顺序

            foreach (var pair in inMap)
            {
                baseMap.TryAdd(pair.Key, pair.Value);
            }

            return new TermMappingProvider<TValue>(baseMap, Destination);
        }

        /// <inheritdoc/>
        public IResourceFileProvider ReplaceContent(string searchPattern, string replacement)
            => new TermMappingProvider<TValue>(
                Map.ReplaceContent(searchPattern, replacement),
                Destination);

        /// <inheritdoc/>
        public IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
            => new TermMappingProvider<TValue>(
                Map,
                Regex.Replace(Destination,
                              searchPattern,
                              replacement,
                              RegexOptions.Singleline));

        /// <inheritdoc/>
        public async Task WriteToArchive(ZipArchive archive)
        {
            var destination = Destination.NormalizePath();
            Log.Information("正在添加 {0}", destination);

            archive.ValidateEntryDistinctness(destination);

            using var writer = new StreamWriter(
                archive.CreateEntry(destination)
                       .Open(),
                Encoding.UTF8);
            await writer.WriteAsync(Map.ProvideStringContent());
        }
    }
    #endregion

    #region Helper
    /// <summary>
    /// 用于生成<see cref="LangMappingProvider"/>的辅助类
    /// </summary>
    public static partial class LangMappingHelper
    {
        /// <summary>
        /// 从给定的语言文件创建<see cref="LangMappingProvider"/>
        /// </summary>
        /// <param name="file">读取源</param>
        /// <param name="destination">目标地址</param>
        public static LangMappingProvider CreateFromFile(FileInfo file, string destination)
        {
            using var stream = file.OpenRead();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            var content = reader.ReadToEnd();
            return new (new LangDictionaryWrapper(DeserializeFromLang(content)), destination);
        }

        // RAW
        // TODO：仔细检查一遍
        // TODO：PARSE-ESCAPE
        internal static Dictionary<string, string> DeserializeFromLang(string content)
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

    /// <summary>
    /// 用于生成<see cref="JsonMappingProvider"/>的辅助类
    /// </summary>
    public static partial class JsonMappingHelper
    {
        /// <summary>
        /// 从给定的语言文件创建<see cref="JsonMappingProvider"/>
        /// </summary>
        /// <param name="file">读取源</param>
        /// <param name="destination">目标地址</param>
        public static JsonMappingProvider CreateFromFile(FileInfo file, string destination)
        {
            using var stream = file.OpenRead();
            return new(new JsonDictionaryWrapper(JsonNode.Parse(stream)!.AsObject()!), destination);
        }
    }
    #endregion
}
