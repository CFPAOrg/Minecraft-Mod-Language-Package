using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Processer
{
    public class Utils
    {
    }
    public partial class LangFile
    {
        public void ProcessLangFile()
        {
            if (Format == Format.Lang)
            {
                if (IsNeeded == IsNeeded.Requested)
                {
                    if (Language == Language.Chinese)
                    {
                        var keyReg = new Regex(".+(?==)");
                        var nameReg = new Regex("(?<==).+");
                        var findEqual = new Regex("=+");
                        var langs = new List<string>();
                        foreach (string str in File.ReadAllLines(LangPath, Encoding.UTF8))
                        {
                            if (findEqual.IsMatch(str))
                            {
                                if (keyReg.IsMatch(str))
                                {
                                    if (nameReg.IsMatch(str))
                                    {
                                        if (!langs.Contains(str))
                                        {
                                            langs.Add(str);
                                            //Log.Information("添加条目:{0}", str);
                                        }
                                    }
                                }
                            }
                        }
                        File.WriteAllLines(LangPath, langs);
                        Log.Information("{0}检查完成", LangPath);
                    }
                }
            }
        }

        public void ExportJson()
        {
            var jObject = new JObject();
            var langObject = new JObject();
            var keyReg = new Regex(".+(?==)");
            var nameReg = new Regex("(?<==).+");
            foreach (string str in File.ReadAllLines(LangPath, Encoding.UTF8))
            {
                langObject.Add(keyReg.Match(str).ToString(), nameReg.Match(str).ToString());
            }
        }
    }
}