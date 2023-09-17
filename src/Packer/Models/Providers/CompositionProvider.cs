using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;

namespace Packer.Models.Providers
{
    using LangMappingProvider = TermMappingProvider<string>;
    using JsonMappingProvider = TermMappingProvider<JsonNode>;


    // 考量：Helper？
    public class CompositionProvider<TValue> : TermMappingProvider<TValue>
    {
        public CompositionProvider(ITermDictionary<TValue> map, string destination) : base(map, destination) { }

        public CompositionProvider<TValue> Create(FileInfo file)
        {

        }
    }


    internal struct CompositonData
    {
        public string Target { get; set; }
        public List<CompositionEntry> Entries { get; set; }
    }

    internal struct CompositionEntry
    {
        public Dictionary<string, string> Templates { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
