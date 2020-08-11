using System.Collections.Generic;
using System.IO;

namespace Processer
{
    public partial class LangFile
    {
        public string LangPath { get; set; }
        public Format Format { get; set; }
        public Language Language { get; set; }
        public IsNeeded IsNeeded { get; set; }

        public LangFile(string path, List<string> modBlackList, List<string> pathBlackList)
        {
            LangPath = path;
            if (Path.GetFileName(path).Contains(".lang"))
            {
                Format = Format.Lang;
                if (Path.GetFileName(path).Contains("zh_CN") || Path.GetFileName(path).Contains("zh_cn"))
                {
                    Language = Language.Chinese;
                }
                else if (Path.GetFileName(path).Contains("en_US") || Path.GetFileName(path).Contains("en_us"))
                {
                    Language = Language.English;
                }
            }else if (Path.GetFileName(path).Contains(".json"))
            {
                Format = Format.Json;
                if (Path.GetFileName(path).Contains("zh_CN") || Path.GetFileName(path).Contains("zh_cn"))
                {
                    Language = Language.Chinese;
                }
                else if (Path.GetFileName(path).Contains("en_US") || Path.GetFileName(path).Contains("en_us"))
                {
                    Language = Language.English;
                }
            }
            modBlackList.ForEach(_ => { if (path.Contains(_)) IsNeeded = IsNeeded.Unneeded; });
            pathBlackList.ForEach(_ => { if (path.Contains(_)) IsNeeded = IsNeeded.Unneeded; });
        }
    }
}