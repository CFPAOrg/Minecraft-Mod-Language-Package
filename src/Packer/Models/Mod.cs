using System.Collections.Generic;
using System.Linq;

using Serilog;

namespace Packer.Models
{
    public class Mod
    {
        public string modName;
        public IEnumerable<Asset> assets;
    }

    public class Asset
    {
        public string domainName;
        public IEnumerable<TranslatedFile> contents;
        public Asset Combine(Asset other)
        {
            var mapping = new Dictionary<string, TranslatedFile>();
            if (!contents.Any()) return other;
            if (!other.contents.Any()) return this;
            foreach (var file in contents)
            {
                if (file.relativePath is null) continue; // 无效文件
                mapping.Add(file.relativePath, file);
            }
            foreach (var file in other.contents)
            {
                if (file.relativePath is null) continue; // 无效文件
                if (!mapping.TryAdd(file.relativePath, file))
                {
                    mapping.Remove(file.relativePath, out var existing);
                    mapping.Add(existing.relativePath, existing.Combine(file));
                }
            }
            return new Asset()
            {
                domainName = this.domainName,
                contents = mapping.Select(_ => _.Value)
            };
        }
    }
}
