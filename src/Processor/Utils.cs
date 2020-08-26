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

namespace Processor
{
    public class Utils
    {
        public static List<string> SearchLangFiles(Configuration configuration)
        {
            var allFiles = new List<string>();
            var files1 = Directory.GetFiles(Path.Combine(configuration.CustomSittings.ProjectsFolder,configuration.VersionList[0],"assets"), "*.lang", SearchOption.AllDirectories);
            foreach (var s in files1)
                allFiles.Add(s);
            return allFiles;
        }


        //public static void UpdateInfo()
        //{
        //    var folder = Program.ReaderFolder();
        //    var config = Program.ReadConfig();
        //    var idD = GetIdDictionary();
        //    var exD = GetExtendDictionary();
        //    var jArray = (JArray)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(folder.Root, "info.json"),Encoding.UTF8));
        //    var jObjects = new List<JObject>();
        //    foreach (var jObject in jArray)
        //    {
        //           jObjects.Add((JObject)jObject);
        //    }

        //    var targetJobject = jObjects.FirstOrDefault(_ => _["version"]?.ToString() == config.TargetVersion);
        //    jObjects.Remove(jObjects.FirstOrDefault(_ => _["version"]?.ToString() == config.TargetVersion));
        //    var targetJarr = new JArray(targetJobject["info"]);
        //    targetJarr.RemoveAll();
        //    var root = new DirectoryInfo(Path.Combine(folder.Projects,config.TargetVersion,"assets"));
        //    foreach (var directory in root.GetDirectories())
        //    {
        //        if (directory.Name == "1UNKNOWN")
        //        {
        //            continue;
        //        }
        //        var obj = new JObject();
        //        var pid = idD.FirstOrDefault(_ => _.Value == directory.Name).Key;
        //        Tuple<string, string, JArray> tuple = new Tuple<string,string,JArray>(null,null,null);
        //        obj.TryAdd("project_name", directory.Name);
        //        obj.TryAdd("project_id", pid);
        //        if (pid != null)
        //        {
        //            exD.TryGetValue(pid, out tuple);
        //            obj.TryAdd("name", tuple.Item1);
        //            obj.TryAdd("modid", tuple.Item2);
        //            obj.TryAdd("domains", tuple.Item3);
        //        }
        //        //Console.WriteLine("{0},{1},{2}",tuple.Item1,tuple.Item2,tuple.Item3);
        //        targetJarr.Add(obj);
        //    }

        //    targetJobject["info"] = targetJarr;
        //    //Console.WriteLine(targetJobject.ToString());
        //    jObjects.Add(targetJobject);
        //    string[] str = new string[jObjects.Count];
        //    var sw = new StreamWriter(Path.Combine(folder.Root, "info.json"));
        //    var jw = new JsonTextWriter(sw);
        //    jw.Formatting = Formatting.Indented;
        //    jw.WriteStartArray();
        //    jObjects.ForEach(_ => _.WriteTo(jw));
        //    jw.WriteEndArray();
        //    jw.Close();
        //    sw.Close();
        //    Log.Logger.Information("info更新完成");
        //    //File.WriteAllText(Path.Combine(folder.Root, "info.json"),JsonSerializer.Serialize(jObjects));
        //    //Console.WriteLine(jObjects);
        //    //File.WriteAllLines(Path.Combine(folder.Root, "info.json"),jObjects.ToArray());
        //}
    }
}