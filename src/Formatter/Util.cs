using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Language.Core;

using Serilog;

namespace Formatter {
    public static class Util {
        public static List<string> SearchLangFiles() {
            var allFiles = new List<string>();
            var files1 = Directory.GetFiles($"./projects", "*.lang", SearchOption.AllDirectories);
            foreach (var s in files1) {
                if (s.Contains(".placeholder")) {
                    continue;
                }
                allFiles.Add(s);
            }
            return allFiles;
        }

        public static List<string> SearchJsonFiles() {
            var allFiles = new List<string>();
            var files1 = Directory.GetFiles($"./projects", "*.json", SearchOption.AllDirectories);
            foreach (var s in files1) {
                if (s.Contains(".placeholder")) {
                    continue;
                }
                allFiles.Add(s);
            }
            return allFiles;
        }

        public static async Task<List<string>> ReadBlackKey() {
            var res = new List<string>();
            foreach (string str in await File.ReadAllLinesAsync("./config/blackkey.txt", Encoding.UTF8)) {
                res.Add(str);
            }

            return res;
        }

        public static async Task FormatLangFile(List<string> lp, List<string> bl) {
            var keyReg = new Regex(".+(?==)");
            foreach (var l in lp) {
                var list = new List<string>();
                var lines = await File.ReadAllLinesAsync(l);
                foreach (var line in lines) {
                    if (keyReg.IsMatch(line)) {
                        if (bl.Contains(keyReg.Match(line).Value)) {
                            continue;
                        }
                    }
                    list.Add(line);
                }

                await File.WriteAllLinesAsync(l, list);
            }
        }

        public static async Task FormatJsonFile(List<string> lp, List<string> bl) {
            foreach (var path in lp) {
                var fileStream = await File.ReadAllTextAsync(path);
                if (string.IsNullOrWhiteSpace(fileStream)) {
                    await File.WriteAllTextAsync(path, "{}");
                }
                try {
                    var obj = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(new MemoryStream(Encoding.UTF8.GetBytes(fileStream ?? "")));
                    foreach (var key in bl) {
                        if (obj!.ContainsKey(key)) {
                            obj.Remove(key);
                        }
                    }
                    var str = JsonSerializer.Serialize(obj, new JsonSerializerOptions() {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    });
                    await File.WriteAllTextAsync(path, str);
                }
                catch (Exception) {
                    Log.Logger.Verbose($"发生错误，已跳过{path}");
                }
            }
        }
    }
}

