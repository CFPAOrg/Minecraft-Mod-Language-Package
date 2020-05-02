using System;

namespace Spider.Models
{
    internal class LanguageEntry
    {
        public static LanguageEntry EmptyLanguageEntry = new LanguageEntry(Environment.NewLine, true);

        private string _value;

        public LanguageEntry(string key, string value, bool isComment)
        {
            IsComment = isComment;
            Key = key;
            Value = value;
        }

        public LanguageEntry(string key, bool isComment)
        {
            IsComment = isComment;
            Key = key;
        }

        public string Id { get; set; }

        public string Key { get; set; }

        public string Value
        {
            get
            {
                if (IsComment) return Key;
                return _value;
            }
            private set
            {
                if (IsComment) Key = value;
                _value = value;
            }
        }

        public bool IsComment { get; }
        public bool IsInBlackLIst { get; set; }
    }
}