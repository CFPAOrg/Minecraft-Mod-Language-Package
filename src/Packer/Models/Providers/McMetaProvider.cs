using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packer.Models.Providers
{
    internal class McMetaProvider : IResourceFileProvider
    {
        public string Destination => "pack.mcmeta";

        public IResourceFileProvider ReplaceDestination(string searchPattern, string replacement)
            => this;

        public Task WriteToArchive(ZipArchive archive)
        {
            throw new NotImplementedException();
        }
    }
}
