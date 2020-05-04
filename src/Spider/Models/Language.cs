using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Serilog;

namespace Spider.Models
{
    internal class Language
    {
        private string _outputText;
        private Stream _stream;

        public Language(Mod baseMod, Stream stream, string assetPath)
        {
            BaseMod = baseMod;
            Stream = stream;
            AssetPath = assetPath;
            UpdateAssetDomain();
            BuildLangEntries();
        }
        [JsonIgnore]
        public string Id { get; set; }
        [JsonIgnore]
        public Mod BaseMod { get; }
        public string ModId => BaseMod.ModId;
        [JsonIgnore]
        public Stream Stream
        {
            get => _stream;
            private set
            {
                using var sr = new StreamReader(value);
                PlainText = sr.ReadToEnd();
                _stream = value;
            }
        }
        public string AssetPath { get; }
        [JsonIgnore]
        public string PlainText { get; private set; }

        public string OutPutText
        {
            get
            {
                if (string.IsNullOrEmpty(_outputText)) BuildOutputText();
                return _outputText;
            }
        }
        public string AssetDomain { get; set; }
        [JsonIgnore]
        public bool IsInBlackList { get; set; }
        [JsonIgnore]
        public List<LanguageEntry> LangEntries { get; set; } = new List<LanguageEntry>();

        private void UpdateAssetDomain()
        {
            try
            {
                AssetDomain = AssetPath[7..AssetPath.IndexOf("/lang/", StringComparison.Ordinal)];
            }
            catch (Exception)
            {
                Log.Information($"跳过了无法识别的asset路径:{AssetPath}.");
                IsInBlackList = true;
                AssetDomain = null;
            }
        }

        private void BuildOutputText()
        {
            var sb = new StringBuilder();
            foreach (var languageEntry in LangEntries.Where(languageEntry => !languageEntry.IsInBlackLIst))
            {
                if (languageEntry.IsComment)
                {
                    sb.AppendLine(languageEntry.Key);
                    continue;
                }

                sb.AppendLine($"{languageEntry.Key}={languageEntry.Value}");
            }

            _outputText = sb.ToString();
        }

        private void BuildLangEntries()
        {
            using var sr = new StringReader(PlainText);
            var lines = new List<string>();
            while (sr.Peek() != -1) lines.Add(sr.ReadLine());
            var langEntryBlackList = Configuration.LangEntryBlackList;
            if (lines.First().StartsWith("#PARSE_ESCAPES"))
            {
                IsInBlackList = true;
                Log.Information($"跳过了{BaseMod.Name}的一个Properties语言文件:{AssetPath}");
                return;
            }

            lines.ForEach(_ =>
            {
                if (string.IsNullOrWhiteSpace(_))
                {
                    LangEntries.Add(LanguageEntry.EmptyLanguageEntry);
                    return;
                }

                if (!_.StartsWith('#') && !_.Contains('='))
                {
                    LangEntries.Add(new LanguageEntry("# " + _, true));
                    Log.Information($"修复不规范注释:{_}");
                    return;
                }

                if (_.StartsWith('#'))
                {
                    LangEntries.Add(new LanguageEntry(_, true));
                    return;
                }

                var index = _.IndexOf('=');
                LangEntries.Add(new LanguageEntry(_[..index], _[(index + 1)..], false));
            });
            LangEntries.Where(_ => !_.IsComment).ToList().ForEach(_ =>
            {
                if (langEntryBlackList.Contains(_.Key)) _.IsInBlackLIst = true;
            });
        }
    }
}