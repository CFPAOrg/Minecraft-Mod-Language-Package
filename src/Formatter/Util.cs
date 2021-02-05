using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Serilog;

namespace Formatter {
    public static class Util {
        public static List<string> SearchLangFiles(string version) {
            var allFiles = new List<string>();
            var files1 = Directory.GetFiles($"./projects/{version}/assets", "*.lang", SearchOption.AllDirectories);
            foreach (var s in files1)
                allFiles.Add(s);
            return allFiles;
        }

        public static async Task<List<string>> ReadBlackKey() {
            var res = new List<string>();
            foreach (string str in await File.ReadAllLinesAsync("./config/blackkey.txt", Encoding.UTF8)) {
                res.Add(str);
            }

            return res;
        }

        public static async Task<Hashtable> ReadReplaceFontMap() {
            var ht = new Hashtable();
            foreach (string str in await File.ReadAllLinesAsync("./config/fontmap.txt", Encoding.UTF8)) {
                var kv = str.Split('>', 2);
                var key = kv[0];
                var value = kv[1];
                ht.Add(key, value);
            }

            return ht;
        }

        public static async Task FormatLangFile(List<string> lp, List<string> bl) {
            foreach (var l in lp) {
                var keyReg = new Regex(".+(?==)");
                var nameReg = new Regex("(?<==).+");
                var findEqual = new Regex("=+");
                var commentReg = new Regex("#+");
                var ls = new List<string>();
                foreach (string str in await File.ReadAllLinesAsync(l, Encoding.UTF8)) {
                    if (str == "") {
                        ls.Add(str);
                        Log.Debug("添加空行");
                    }

                    
                    if (str.StartsWith("#")) {
                        ls.Add(str);
                        Log.Debug("添加规范注释");
                    }
                        
                    

                    if (findEqual.IsMatch(str)) {
                        if (keyReg.IsMatch(str)) {
                            if (bl.Contains(keyReg.Match(str).ToString())) continue;
                            if (nameReg.IsMatch(str)) {
                                if (!ls.Contains(str)) {
                                    ls.Add(str);
                                    Log.Debug("添加条目:{0}", str);
                                }
                            }
                        }
                    }
                }

                await File.WriteAllLinesAsync(l, ls);
                Log.Information("{0}检查完成", l);
            }
        }

        public static async Task CrateEmptyLangFile(string version) {
            var root = new DirectoryInfo($"./projects/{version}/assets");
            var dt1 = root.GetDirectories(); //顶层project name
            foreach (var info in dt1) {
                var dt2 = info.GetDirectories(); //domain
                foreach (var directoryInfo in dt2) {
                    try {
                        var lf = Directory.EnumerateFiles(Path.Combine(directoryInfo.FullName, "lang"));
                        if (lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_us.lang")) ||
                            lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_US.lang"))) {
                            if (!(lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.lang")) ||
                                  lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_CN.lang")))) {
                                var pa = lf.FirstOrDefault(_ => _.ToLower().Contains("en_us.lang"));
                                var isParse = false;
                                foreach (string str in await File.ReadAllLinesAsync(pa, Encoding.UTF8)) {
                                    if (str == "#PARSE_ESCAPES") {
                                        isParse = true;
                                        break;
                                    }
                                }

                                if (isParse) {
                                    await File.WriteAllTextAsync(
                                        Path.Combine(directoryInfo.FullName, "lang", "zh_cn.lang"),
                                        "#PARSE_ESCAPES\n\n");
                                    Log.Logger.Information($"为{directoryInfo.Name}新建带#PARSE_ESCAPES的文件");
                                }
                                else {
                                    await File.WriteAllTextAsync(
                                        Path.Combine(directoryInfo.FullName, "lang", "zh_cn.lang"), "\n");
                                    Log.Logger.Information($"为{directoryInfo.Name}新建空文件");
                                }
                            }
                        }
                    }
                    catch (Exception e) {
                        Log.Logger.Error(e.Message);
                    }
                }
            }
        }

        public static async Task CrateEmptyJsonFile(string version) {
            var root = new DirectoryInfo($"./projects/{version}/assets");
            var dt1 = root.GetDirectories(); //顶层project name
            foreach (var info in dt1) {
                var dt2 = info.GetDirectories(); //domain
                foreach (var directoryInfo in dt2) {
                    try {
                        var lf = Directory.EnumerateFiles(Path.Combine(directoryInfo.FullName, "lang"));
                        if (lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_us.json")) ||
                            lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_US.json"))) {
                            if (!(lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.json")) ||
                                  lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_CN.json")))) {
                                await File.WriteAllTextAsync(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.json"),
                                    "{}");
                            }
                        }
                    }
                    catch (Exception e) {
                        Log.Logger.Error(e.Message);
                    }
                }
            }
        }

        public static async Task ReplaceFontInLang(string version, Hashtable map) {
            var root = new DirectoryInfo($"./projects/{version}/assets");
            var dt1 = root.GetDirectories(); //顶层project name
            foreach (var info in dt1) {
                var dt2 = info.GetDirectories(); //domain
                foreach (var directoryInfo in dt2) {
                    try {
                        var lf = Directory.EnumerateFiles(Path.Combine(directoryInfo.FullName, "lang"));
                        if (lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.lang")) ||
                            lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_CN.lang"))) {
                            var pa = lf.FirstOrDefault(_ => _.ToLower().Contains("zh_cn.lang"));
                            var isParse = true;

                            if (isParse) {
                                var replaced = new List<string>();
                                foreach (string str in await File.ReadAllLinesAsync(pa, Encoding.UTF8)) {
                                    var needReplace = false;
                                    foreach (var mapKey in map.Keys) {
                                        var mapKeys = mapKey as string;
                                        if (str.Contains(mapKeys)) {
                                            needReplace = true;
                                            break;
                                        }
                                    }

                                    if (needReplace) {
                                        var line = str;
                                        foreach (var key in map.Keys) {
                                            var skey = key as string;
                                            line = line.Replace(skey, Regex.Unescape(map[skey] as string));
                                        }

                                        replaced.Add(line);
                                    }
                                    else {
                                        replaced.Add(str);
                                    }
                                }

                                await File.WriteAllLinesAsync(pa, replaced);
                            }
                        }
                    }
                    catch (Exception e) {
                        Log.Logger.Error(e.Message);
                    }
                }
            }
        }

        public static async Task ReplaceFontInJson(string version, Hashtable map) {
            var root = new DirectoryInfo($"./projects/{version}/assets");
            var dt1 = root.GetDirectories(); //顶层project name
            foreach (var info in dt1) {
                var dt2 = info.GetDirectories(); //domain
                foreach (var directoryInfo in dt2) {
                    try {
                        var lf = Directory.EnumerateFiles(Path.Combine(directoryInfo.FullName, "lang"));
                        if (lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.json")) ||
                            lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_CN.json"))) {
                            var pa = lf.FirstOrDefault(_ => _.ToLower().Contains("zh_cn.json"));

                            var replaced = new List<string>();
                            foreach (string str in await File.ReadAllLinesAsync(pa, Encoding.UTF8)) {
                                var needReplace = false;
                                foreach (var mapKey in map.Keys) {
                                    var mapKeys = mapKey as string;
                                    if (str.Contains(mapKeys)) {
                                        needReplace = true;
                                        break;
                                    }
                                }

                                if (needReplace) {
                                    var line = str;
                                    foreach (var key in map.Keys) {
                                        var skey = key as string;
                                        line = line.Replace(skey, map[skey] as string);
                                    }

                                    replaced.Add(line);
                                }
                                else {
                                    replaced.Add(str);
                                }


                                await File.WriteAllLinesAsync(pa, replaced);
                            }
                        }
                    }
                    catch (Exception e) {
                        Log.Logger.Error(e.Message);
                    }
                }
            }
        }
    }
}
        
