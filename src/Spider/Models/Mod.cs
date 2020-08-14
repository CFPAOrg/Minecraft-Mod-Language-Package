using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;

namespace Spider.Models
{
    internal class Mod : IDisposable
    {
        private string _modId;

        public Mod(long id)
        {
            Id = id;

        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ShortUrl => Url[(Url.LastIndexOf('/') + 1)..];
        public string DownloadUrl { get; set; }

        public string ModId
        {
            get
            {
                _modId ??= FindModId();
                return _modId;
            }
        }

        public List<Language> Languages { get; set; } = new List<Language>();

        public bool IsInBlackList { get; set; }

        public Stream Stream { get; set; }

        public void Dispose()
        {
            Stream?.Dispose();
            if (!IsInBlackList && Languages.Count != 0)
            {
                Languages.ForEach(_ => _.Stream?.Dispose());
            }
        }

        private string FindModId()
        {
            var zipArchive = new ZipArchive(Stream,mode:ZipArchiveMode.Read,leaveOpen:true);
            var modId = "";
            foreach (var zipArchiveEntry in zipArchive.Entries.Where(_=>_.FullName.EndsWith(".class")))
            {
                var stream = zipArchiveEntry.Open();
                using var sr = new StreamReader(stream,leaveOpen:true);
                var str = sr.ReadToEnd();
                var regex1 = new Regex("\\W");
                var regex2 = new Regex("(?<=modid).*?(?=name)");
                str=regex1.Replace(str, "");
                if (regex2.IsMatch(str))
                {
                    modId = regex2.Match(str).Value;
                }
            }
            zipArchive.Dispose();
            return string.IsNullOrEmpty(modId) ? null : modId;
        }
    }
}