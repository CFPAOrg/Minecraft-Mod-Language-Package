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



    public interface ITermDictionary<TValue> : IDictionary<string, TValue>
    {
        // TODO：Parse
        public string ProvideStringContent();
        public ITermDictionary<TValue> ReplaceContent(string searchPattern, string replacement);
        public static ITermDictionary<TValue> Create(IDictionary<string, string> nominalMapping)
            => throw new NotImplementedException();
    }


    public class TermMappingProvider<TValue> : IResourceFileProvider
    {
        public ITermDictionary<TValue> Map { get; }
        public string Destination { get; }

        public TermMappingProvider(ITermDictionary<TValue> map, string destination)
        {
            Map = map;
            Destination = destination;
        }

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

        public IResourceFileProvider ReplaceContent(string searchPattern, string replacement)
            => new TermMappingProvider<TValue>(
                Map.ReplaceContent(searchPattern, replacement),
                Destination);

        public IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
            => new TermMappingProvider<TValue>(
                Map,
                Regex.Replace(Destination,
                              searchPattern,
                              replacement,
                              RegexOptions.Singleline));

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

        public static ITermDictionary<string> Create(IDictionary<string, string> nominalMapping)
            => new LangDictionaryWrapper(nominalMapping);
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
            foreach(var (key, value) in this)
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
}
