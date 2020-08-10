using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Fucker
{
    public class Utils
    {
        public static void DelFiles(string path, string version)
        {
            if (version == "1.12.2")
            {
                var files = Directory.GetFiles(path + "project/" + version, "*.lang", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var name = Path.GetFileName(file);
                    switch (name)
                    {
                        case "zh_cn.lang":
                            break;
                        case "zh_CN.lang":
                            break;
                        case "en_us.lang":
                            break;
                        case "en_US.lang":
                            break;
                        default:
                            var random = new Random();
                            var newPath = path + "/rubbish/" + random.Next() + ".lang";
                            File.Move(file, newPath);
                            Console.WriteLine("将{0}移动到{1}", path, newPath);
                            break;
                    }
                }
            }
            else
            {
                var files = Directory.GetFiles(path + "project/" + version, "*.json", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var name = Path.GetFileName(file);
                    switch (name)
                    {
                        case "zh_cn.json":
                            break;
                        case "zh_CN.json":
                            break;
                        case "en_us.json":
                            break;
                        case "en_US.json":
                            break;
                        default:
                            var random = new Random();
                            var newPath = path + "/rubbish/" + random.Next() + ".json";
                            File.Move(file, newPath);
                            Console.WriteLine("将{0}移动到{1}", path, newPath);
                            break;
                    }
                }
            }
        }

        public static void DelDeduplicationFiles(string path, string version)
        {
            if (version == "1.12.2")
            {
                var files = Directory.GetFiles(path + "project/" + version, "*.lang", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var name = Path.GetFileName(file);
                    if (file.Contains("0x_trans_fix"))
                        continue;
                    if (name == "zh_cn.lang")
                    {
                        var list = new List<string>();
                        foreach (string str in File.ReadAllLines(file, Encoding.UTF8))
                        {
                            var keyReg = new Regex(".+(?==)");
                            var nameReg = new Regex("(?<==).+");
                            var findEqual = new Regex("=+");
                            if (findEqual.IsMatch(str))
                            {
                                if (nameReg.IsMatch(str))
                                {
                                    if (keyReg.IsMatch(str))
                                    {
                                        if (!list.Contains(str))
                                        {
                                            list.Add(str);
                                        }
                                    }
                                }
                            }
                        }
                        File.WriteAllLines(file,list);
                    }
                    else if (name == "zn_CN.lang")
                    {
                        var list = new List<string>();
                        foreach (string str in File.ReadAllLines(file, Encoding.UTF8))
                        {
                            var keyReg = new Regex(".+(?==)");
                            var nameReg = new Regex("(?<==).+");
                            var findEqual = new Regex("=+");
                            if (findEqual.IsMatch(str))
                            {
                                if (nameReg.IsMatch(str))
                                {
                                    if (keyReg.IsMatch(str))
                                    {
                                        if (!list.Contains(str))
                                        {
                                            list.Add(str);
                                        }
                                    }
                                }
                            }
                        }
                        File.WriteAllLines(file, list);
                    }
                }
            }
            else
                Console.WriteLine("非1.12.2文件不可去重。");
        }
    }
}