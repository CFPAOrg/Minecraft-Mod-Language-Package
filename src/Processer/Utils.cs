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
            var jFIle = new JsonTextReader(File.OpenText(Path.Combine(folder.Config, "mod_info.json")));
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

        static Dictionary<string, Tuple<string, string, JArray>> GetExtendDictionary()
        {
            var extendDictionary = new Dictionary<string, Tuple<string, string, JArray>>();
            var infos = GetModInfo();
            infos.ForEach(_ =>
            {
                if (!extendDictionary.ContainsKey(_["projectId"]?.ToString() ?? string.Empty))
                {
                    if (_["projectId"]?.ToString() != "")
                    {
                        if (_["assetDomain"]?.ToString() != "")
                        {
                            extendDictionary.Add(_["projectId"]?.ToString() ?? string.Empty, new Tuple<string, string, JArray>(_["name"]?.ToString(), _["modId"]?.ToString(), _["assetDomains"]?.ToObject<JArray>()));
                        }
                    }
                }
            });
            foreach (var keyValuePair in extendDictionary)
            {
                //Log.Logger.Information("{0},{1}",keyValuePair.Key,keyValuePair.Value);
            }

            return extendDictionary;
        }

        static Dictionary<string, string> GetDomainDictionary()
        {
            var domainDictionary = new Dictionary<string, string>();
            var infos = GetModInfo();
            infos.ForEach(_ =>
            {
                if (!domainDictionary.ContainsKey(_["projectId"]?.ToString() ?? string.Empty))
                {
                    if (_["projectId"]?.ToString() != "")
                    {
                        if (_["assetDomain"]?.ToString() != "")
                        {
                            domainDictionary.Add(_["projectId"]?.ToString() ?? string.Empty, _["assetDomains"]?.ToString());
                        }
                    }
                }
            });
            foreach (var keyValuePair in domainDictionary)
            {
                //Log.Logger.Information("{0},{1}",keyValuePair.Key,keyValuePair.Value);
            }

            return domainDictionary;
        }

        public static void ProcessFiles()
        {
            var config = Program.ReaderConfig();
            var folder = Program.ReaderFolder();
            var idD = GetIdDictionary();
            var dD = GetDomainDictionary();
            var root = new DirectoryInfo(Path.Combine(folder.Projects,config.TargetVersion, "assets", "1UNKNOWN"));
            foreach (var info in root.GetDirectories())
            {
                var pid = dD.FirstOrDefault(_ => _.Value.Contains(info.Name)).Key;
                if (pid == null)
                {
                    continue;
                }
                string name;
                idD.TryGetValue(pid, out name);
                if (name == null)
                {
                    continue;
                }
                if (!Directory.Exists(Path.Combine(folder.Projects, config.TargetVersion, "assets", name)))
                {
                    Directory.CreateDirectory(Path.Combine(folder.Projects, config.TargetVersion, "assets", name));
                }

                var newPath = Path.Combine(folder.Projects, config.TargetVersion, "assets", name, info.Name);
                try
                {
                    Directory.Move(info.FullName, newPath);
                }
                catch
                {
                    var di = new DirectoryInfo(newPath);
                    di.Delete(true);
                    Directory.Move(info.FullName, newPath);
                }
                Log.Logger.Information("文件处理完成");
            }
        }

        public static void UpdateInfo()
        {
            var folder = Program.ReaderFolder();
            var config = Program.ReaderConfig();
            var idD = GetIdDictionary();
            var exD = GetExtendDictionary();
            var jArray = (JArray)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(folder.Root, "info.json"),Encoding.UTF8));
            var jObjects = new List<JObject>();
            foreach (var jObject in jArray)
            {
                   jObjects.Add((JObject)jObject);
            }

            var targetJobject = jObjects.FirstOrDefault(_ => _["version"]?.ToString() == config.TargetVersion);
            jObjects.Remove(jObjects.FirstOrDefault(_ => _["version"]?.ToString() == config.TargetVersion));
            var targetJarr = new JArray(targetJobject["info"]);
            targetJarr.RemoveAll();
            var root = new DirectoryInfo(Path.Combine(folder.Projects,config.TargetVersion,"assets"));
            foreach (var directory in root.GetDirectories())
            {
                if (directory.Name == "1UNKNOWN")
                {
                    continue;
                }
                var obj = new JObject();
                var pid = idD.FirstOrDefault(_ => _.Value == directory.Name).Key;
                Tuple<string, string, JArray> tuple = new Tuple<string,string,JArray>(null,null,null);
                obj.TryAdd("project_name", directory.Name);
                obj.TryAdd("project_id", pid);
                if (pid != null)
                {
                    exD.TryGetValue(pid, out tuple);
                    obj.TryAdd("name", tuple.Item1);
                    obj.TryAdd("modid", tuple.Item2);
                    obj.TryAdd("domains", tuple.Item3);
                }
                //Console.WriteLine("{0},{1},{2}",tuple.Item1,tuple.Item2,tuple.Item3);
                targetJarr.Add(obj);
            }

            targetJobject["info"] = targetJarr;
            //Console.WriteLine(targetJobject.ToString());
            jObjects.Add(targetJobject);
            string[] str = new string[jObjects.Count];
            var sw = new StreamWriter(Path.Combine(folder.Root, "info.json"));
            var jw = new JsonTextWriter(sw);
            jw.Formatting = Formatting.Indented;
            jw.WriteStartArray();
            jObjects.ForEach(_ => _.WriteTo(jw));
            jw.WriteEndArray();
            jw.Close();
            sw.Close();
            Log.Logger.Information("info更新完成");
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