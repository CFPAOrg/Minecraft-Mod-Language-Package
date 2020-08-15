using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        public static void UpdateInfo()
        {
            var folder = Program.ReaderFolder();
            var config = Program.ReaderConfig();
            var idD = GetIdDictionary();
            var jArray = (JArray)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(folder.Root, "info.json"),Encoding.UTF8));
            var jObjects = new List<JObject>();
            foreach (var jObject in jArray)
            {
                   jObjects.Add((JObject)jObject);
            }

            var targetJobject = jObjects.FirstOrDefault(_ => _["version"]?.ToString() == config.TargetVersion);
            jObjects.Remove(jObjects.FirstOrDefault(_ => _["version"]?.ToString() == config.TargetVersion));
            var targetJarr = new JArray(targetJobject["info"]);
            var root = new DirectoryInfo(Path.Combine(folder.Projects,config.TargetVersion,"assets"));
            foreach (var directory in root.GetDirectories())
            {
                if (directory.Name == "1old")
                {
                    continue;
                }
                var obj = new JObject();
                var pid = idD.FirstOrDefault(_ => _.Value == directory.Name).Key;
                obj.Add("project_name",directory.Name);
                obj.Add("project_id",pid);
                targetJarr.Add(obj);
            }

            targetJobject["info"] = targetJarr;
            //Console.WriteLine(targetJobject.ToString());
            jObjects.Add(targetJobject);
            jObjects.OrderBy(_ => _["local"]);
            string[] str = new string[jObjects.Count];
            var sw = new StreamWriter(Path.Combine(folder.Root, "info.json"));
            var jw = new JsonTextWriter(sw);
            jw.Formatting = Formatting.Indented;
            jw.WriteStartArray();
            jObjects.ForEach(_ => _.WriteTo(jw));
            jw.WriteEndArray();
            jw.Close();
            sw.Close();
            //File.WriteAllText(Path.Combine(folder.Root, "info.json"),JsonSerializer.Serialize(jObjects));
            //Console.WriteLine(jObjects);
            //File.WriteAllLines(Path.Combine(folder.Root, "info.json"),jObjects.ToArray());
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