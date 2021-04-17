using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                var mapping = new Dictionary<string, TranslatedFile>();
                Log.Information("1");
                foreach (var file in contents)
                {
                    Log.Information("2");
                    if (file is null) continue;
                    if (file.relativePath is null) continue;
                    mapping.Add(file.relativePath, file);
                }
                foreach (var file in other.contents)
                {
                    if (file is null) continue;
                    if (file.relativePath is null) continue;
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
            catch(Exception ex)
            {
                Log.Error(ex, "合并失败。");
                return this;
            }
        }
    }
}
