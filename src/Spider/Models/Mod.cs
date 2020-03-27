using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Spider.Models
{
    internal class Mod : IDisposable
    {
        public Mod(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ShortUrl => Url[(Url.LastIndexOf('/') + 1)..];
        public string DownloadUrl { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();

        public bool IsInBlackList { get; set; }

        public Stream Stream { get; set; }

        public void Dispose()
        {
            Stream?.Dispose();
            if (!IsInBlackList&&Languages.Count!=0)
            {
                Languages.ForEach(_ => _.Stream?.Dispose());
            }
        }
    }
}