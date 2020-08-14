using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Processer
{
    public class Utils
    {
        //public static List<string> SearchAllFiles(string path ,string version)
        //{
        //    var allFiles = new List<string>();
        //    var files1 = Directory.GetFiles(path + "projects/" + version, "*.lang", SearchOption.AllDirectories);
        //    var files2 = Directory.GetFiles(path + "projects/" + version, "*.json", SearchOption.AllDirectories);
        //    foreach (var s in files1)
        //        allFiles.Add(s);
        //    foreach (var s in files2)
        //        allFiles.Add(s);
        //    return allFiles;
        //}

        static List<JObject> GetModInfo()
        {
            var folder = Program.ReaderFolder();
            var jFIle = new JsonTextReader(File.OpenText(folder.Config + "/mod_info.json"));
            var list = JToken.ReadFrom(jFIle);
            var objects = new List<JObject>();
            foreach (var jToken in list)
            {
                objects.Add((JObject)jToken);
            }
            return objects;
        }

        public static Dictionary<string, string> GetIdDictionary()
        {
            var idDirectory = new Dictionary<string, string>();
            var infos = GetModInfo();
            infos.ForEach(_ =>
            {
                if (!idDirectory.ContainsKey(_["modId"]?.ToString() ?? string.Empty))
                {
                    if (_["modId"]?.ToString() != "")
                    {
                        if (_["assetDomain"]?.ToString() != "")
                        {
                            idDirectory.Add(_["modId"]?.ToString() ?? string.Empty, _["assetDomain"]?.ToString());
                        }
                    }
                }
            });
            foreach (var keyValuePair in idDirectory)
            {
                Log.Logger.Information("{0},{1}",keyValuePair.Key,keyValuePair.Value);
            }

            return idDirectory;
        }

        public static Dictionary<string, string> GetProjectIdDictionary()
        {
            var pidDirectory = new Dictionary<string, string>();
            var infos = GetModInfo();
            infos.ForEach(_ =>
            {
                if (!pidDirectory.ContainsKey(_["modId"]?.ToString() ?? string.Empty))
                {
                    if (_["modId"]?.ToString() != "")
                    {
                        if (_["projectId"]?.ToString() != "")
                        {
                            pidDirectory.Add(_["modId"]?.ToString() ?? string.Empty, _["projectId"]?.ToString());
                        }
                    }
                }
            });
            foreach (var keyValuePair in pidDirectory)
            {
                Log.Logger.Information("{0},{1}", keyValuePair.Key, keyValuePair.Value);
            }

            return pidDirectory;
        }
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
                        var commentReg = new Regex("#+");
                        var langs = new List<string>();
                        foreach (string str in File.ReadAllLines(LangPath, Encoding.UTF8))
                        {
                            if (str == "")
                            {
                                langs.Add(str);
                                Log.Debug("添加空行");
                            }
                            if (commentReg.IsMatch(str))
                            {
                                langs.Add(str);
                                Log.Debug("添加规范注释");
                            }
                            if (findEqual.IsMatch(str))
                            {
                                if (keyReg.IsMatch(str))
                                {
                                    if (nameReg.IsMatch(str))
                                    {
                                        if (!langs.Contains(str))
                                        {
                                            langs.Add(str);
                                            Log.Debug("添加条目:{0}", str);
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
    }
}