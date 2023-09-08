using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Packer.Models.Providers
{



    public enum LanguageFileFormat
    {
        Lang = 0,
        Json = 1
    }


    internal class TermMappingProvider<TValue> : IResourceFileProvider
    {
        public Dictionary<string, TValue> Map { get; }

        public TermMappingProvider(Dictionary<string, TValue> map) 
        {
            Map = map;
        }

        public IResourceFileProvider Append(IResourceFileProvider? incoming, bool overrideExisting = false)
        {
            if (incoming is not TermMappingProvider<TValue>)
                throw new ArgumentException($"Argument not an instance of {typeof(TermMappingProvider<TValue>)}.",
                                            nameof(incoming));
            var inProvider = incoming as TermMappingProvider<TValue>;

            if (inProvider is null) throw new ArgumentNullException(nameof(incoming));

            var (baseMap, inMap) = overrideExisting
                ? (Map, inProvider.Map)
                : (inProvider.Map, Map); // 交换顺序

            foreach (var pair in inMap)
            {
                baseMap.TryAdd(pair.Key, pair.Value);
            }

            return new TermMappingProvider<TValue>(baseMap);
        }

        public IResourceFileProvider ReplaceContent(string searchPattern, string replacement)
        {
            throw new NotImplementedException();
        }

        public IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
        {
            throw new NotImplementedException();
        }

        public Task WriteToArchive(ZipArchive archive)
        {
            throw new NotImplementedException();
        }
    }
}
