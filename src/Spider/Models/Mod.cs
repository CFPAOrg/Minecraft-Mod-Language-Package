using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Spider.Models
{
    internal class Mod
    {
        private bool _isInBlackList;

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

        public bool IsInBlackList
        {
            get
            {
                if (Languages.Count == 0) return _isInBlackList;
                return Languages.All(_ => _.IsInBlackList) || _isInBlackList;
            }
            set => _isInBlackList = value;
        }

        public Stream Stream { get; set; }
    }
}