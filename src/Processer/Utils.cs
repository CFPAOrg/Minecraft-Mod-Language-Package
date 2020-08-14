using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Processer
{
    public class Utils
    {
        //public static List<string> SearchAllFiles(string path, string version)
        //{
        //    var allFiles = new List<string>();
        //    var files1 = Directory.GetFiles(path + "projects/" + version, "*.lang", SearchOption.AllDirectories);
        //    //var files2 = Directory.GetFiles(path + "projects/" + version, "*.json", SearchOption.AllDirectories);
        //    foreach (var s in files1)
        //        allFiles.Add(s);
        //    //foreach (var s in files2)
        //    //    allFiles.Add(s);
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

        static Dictionary<string, string> GetIdDictionary()
        {
            var idDirectory = new Dictionary<string, string>();
            var infos = GetModInfo();
            infos.ForEach(_ =>
            {
                if (!idDirectory.ContainsKey(_["projectId"]?.ToString() ?? string.Empty))
                {
                    if (_["projectId"]?.ToString() != "")
                    {
                        var nameL = _["projectUrl"]?.ToString().LastIndexOf("/mc-mods/") ?? 0;
                        var name = _["projectUrl"]?.ToString().Substring(nameL + 9);
                        if (_["assetDomain"]?.ToString() != "")
                        {
                            idDirectory.Add(_["projectId"]?.ToString() ?? string.Empty, name);
                        }
                    }
                }
            });
            foreach (var keyValuePair in idDirectory)
            {
                //Log.Logger.Information("{0},{1}",keyValuePair.Key,keyValuePair.Value);
            }

            return idDirectory;
        }


        public static void Do()
        {
            var folder = Program.ReaderFolder();
            var idD = GetIdDictionary();
            var root = new DirectoryInfo(folder.Projects + "/1.12.2/assets");
            foreach (var info in root.GetDirectories())
            {

                //var str = info.Name;
                //if (str.Contains("."))
                //{
                //    var strs = str.Split(".",2);
                //    var id = strs[1];
                //    string name;
                //    idD.TryGetValue(id, out name);
                //    Console.WriteLine(name);
                //    Directory.Move(info.ToString(), folder.Projects + "/1.12.2/assets" + "/" + name);
                //}


                //if (idD.ContainsValue(info.Name))
                //{
                //    var modid = idD.FirstOrDefault(_ => _.Value == info.Name).Key;
                //    modid = modid.Replace("|", "_");
                //    var pid = pidD.GetValueOrDefault(modid);
                //    if (!Directory.Exists(folder.Projects + "/1.12.2/assets/" + modid + "." + pid))
                //    {
                //        Directory.CreateDirectory(folder.Projects + "/1.12.2/assets/" + modid + "." + pid);
                //    }
                //    info.MoveTo(folder.Projects + "/1.12.2/assets/" + modid + "." + pid + "/" + info.Name);
                //}
            }
        }
    }
    public abstract partial class LangFile
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