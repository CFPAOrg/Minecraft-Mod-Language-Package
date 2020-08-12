using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Serilog;

namespace Processer
{
    public class Utils
    {
        public static List<string> SearchAllFiles(string path ,string version)
        {
            var allFiles = new List<string>();
            var files1 = Directory.GetFiles(path + "projects/langresource/" + version, "*.lang", SearchOption.AllDirectories);
            //var files2 = Directory.GetFiles(path + "projects/langresource/" + version, "*.json", SearchOption.AllDirectories);
            foreach (var s in files1)
                allFiles.Add(s);
            //foreach (var s in files2)
            //        allFiles.Add(s);
            return allFiles;
        }
    }
    public partial class LangFile
    {
        public void ProcessLangFile(LangFile _)
        {
            if (_.Format == Format.Lang)
            {
                if (_.IsNeeded == IsNeeded.Requested)
                {
                    if (_.Language == Language.Chinese)
                    {
                        var commentReg = new Regex("^#");
                        var keyReg = new Regex(".+(?==)");
                        var nameReg = new Regex("(?<==).+");
                        var findEqual = new Regex("=+");
                        var langs = new List<string>();
                        foreach (string str in File.ReadAllLines(_.LangPath, Encoding.UTF8))
                        {
                            //if (str == "")
                            //{
                            //    langs.Add(str);
                            //    Log.Debug("添加空行");
                            //}
                            //if (commentReg.IsMatch(str))
                            //{
                            //    langs.Add(str);
                            //    Log.Debug("添加规范注释");
                            //}
                            if (findEqual.IsMatch(str))
                            {
                                if (keyReg.IsMatch(str))
                                {
                                    if (nameReg.IsMatch(str))
                                    {
                                        if (!langs.Contains(str))
                                        {
                                            langs.Add(str);
                                            Log.Information("添加条目:{0}", str);
                                        }
                                    }
                                }
                            }
                        }
                        File.WriteAllLines(_.LangPath, langs);
                        Log.Information("{0}检查完成", _.LangPath);
                    }
                }
            }
        }
    }
}