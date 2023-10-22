using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Packer.Models.Providers
{
    using JsonMappingProvider = TermMappingProvider<JsonNode>;
    using LangMappingProvider = TermMappingProvider<string>;

    public static partial class LangMappingHelper
    {
        /// <summary>
        /// 从组合文件创建<see cref="LangMappingProvider"/>
        /// </summary>
        /// <param name="file">组合文件</param>
        public static LangMappingProvider CreateFromComposition(FileInfo file)
        {
            using var reader = file.OpenText();
            var data = JsonSerializer.Deserialize<CompositionData>(
                reader.ReadToEnd(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return new LangMappingProvider(
                new LangDictionaryWrapper(CompositionHelper.CreateRawDictionary(data)),
                data.Target);
        }
    }

    public static partial class JsonMappingHelper
    {
        /// <summary>
        /// 从组合文件创建<see cref="JsonMappingProvider"/>
        /// </summary>
        /// <param name="file">组合文件</param>
        public static JsonMappingProvider CreateFromComposition(FileInfo file)
        {
            using var reader = file.OpenText();
            var data = JsonSerializer.Deserialize<CompositionData>(
                reader.ReadToEnd(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return new JsonMappingProvider(
                JsonDictionaryWrapper.Create(CompositionHelper.CreateRawDictionary(data)),
                data.Target);
        }
    }

    internal static class CompositionHelper
    {
        internal static Dictionary<string, string> CreateRawDictionary(CompositionData data)
        {
            var query = from entry in data.Entries
                        let templates = entry.Templates
                        let parameters = entry.Parameters.CrossMap()
                        from parameter in parameters
                        from template in templates
                        let formattedKey = string.Format(template.Key, parameter.Key.ToArray())
                        let formattedValue = string.Format(template.Value, parameter.Value.ToArray())
                        select (formattedKey, formattedValue);
            return query.ToDictionary(_ => _.formattedKey, _ => _.formattedValue);
        }

        internal static IEnumerable<KeyValuePair<IEnumerable<TOuter>, IEnumerable<TInner>>>
            CrossMap<TOuter, TInner>(this IEnumerable<IEnumerable<KeyValuePair<TOuter, TInner>>> origin)
            => origin.Aggregate(
                seed: new[] { KeyValuePair.Create(Enumerable.Empty<TOuter>(), Enumerable.Empty<TInner>()) }
                    as IEnumerable<KeyValuePair<IEnumerable<TOuter>, IEnumerable<TInner>>>, // 这都需要手写...
                (accumulate, next) => from incomingPair in next
                                      join existingGroup in accumulate on true equals true
                                      select KeyValuePair.Create(
                                          existingGroup.Key.Append(incomingPair.Key),
                                          existingGroup.Value.Append(incomingPair.Value)));
    }


    // composition format:
    // - root
    // * object
    //   - string target => 本文件产生组合的目标地址。
    //   * list
    //     * object
    //       * object templates => 组合所用的模板。所有内容采用C#格式化模式填写。
    //         - <key template> => <value template>
    //       * list params => 参数表。参数按照列举顺序排列。不支持嵌套，必须字面量。
    //         * object
    //           - <key param> => <value param>

    internal struct CompositionData
    {
        public string Target { get; set; }
        public List<CompositionEntry> Entries { get; set; }
    }

    internal struct CompositionEntry
    {
        public Dictionary<string, string> Templates { get; set; }
        public List<Dictionary<string, string>> Parameters { get; set; }
    }
}
