using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Language.Core;

using Serilog;
using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public class Utils {
        /// <summary>
        /// 解析mod
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public static async Task ParseModsAsync((ModInfo, Configuration) tuple, Config conf) {

            if (tuple.Item2.NonUpdate) {
                Log.Logger.Warning($"{tuple.Item1.ShortWebsiteUrl}已在黑名单中，跳过");
                return;
            }

            var cfg = tuple.Item2;
            var mod = tuple.Item1;
            var version = cfg.Version;
            Uri downloadUrl;
            var httpCli = new HttpClient();

            var path = $"{Path.GetTempFileName()}".Replace(".tmp", ".jar");
            {
                var file = mod.GameVersionLatestFiles.First(_ => _.GameVersion == version);
                downloadUrl = UrlLib.GetDownloadUrl(file.ProjectFileId.ToString(), file.ProjectFileName);
            }
            if (downloadUrl is not null) {

                try {
                    var bytes = await httpCli.GetByteArrayAsync(downloadUrl);
                    await File.WriteAllBytesAsync(path, bytes);
                }
                catch (Exception e) {
                    Log.Logger.Error($"写入文件时：{e.Message}");
                }

                var res = new Mod() {
                    Version = version,
                    DownloadUrl = downloadUrl,
                    Name = mod.Name,
                    ProjectId = mod.Id,
                    ProjectName = mod.ShortWebsiteUrl,
                    ProjectUrl = mod.WebsiteUrl,
                    TempPath = path,
                };

                ParseFiles(res, cfg, $"{Directory.GetCurrentDirectory()}\\projects\\{conf.Version}");
            }
        }

        /// <summary>
        /// 导出mod的文件
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="cfg"></param>
        /// <param name="rootPath"></param>
        private static void ParseFiles(Mod mod, Configuration cfg, string rootPath) {
            var zipArchive = new ZipArchive(File.OpenRead(mod.TempPath));
            var tmpDirectories = $"{Path.GetTempPath()}extracted\\{Path.GetFileName(mod.TempPath)}";
            Log.Logger.Debug(tmpDirectories);
            var include = cfg.IncludedPath.ToList();
            var extract = cfg.ExtractPath.ToList();
            var entries = zipArchive.Entries.ToList();

            IEnumerable<(ZipArchiveEntry, string)> Selector() {
                foreach (var zipArchiveEntry in entries) {
                    var split = zipArchiveEntry.FullName.Split('/');
                    if (split.Length<3) continue;
                    if (split.Last() == "") continue;
                    var baseDomain = split[0];
                    var modDomain = split[1];
                    var preDomain = split[2];
                    if (modDomain == "minecraft") {
                        continue;
                    }
                    if (include.Contains(baseDomain) && extract.Contains(preDomain)) {
                        yield return (zipArchiveEntry, modDomain);
                    }
                }
            }

            foreach (var (entry, modDomain) in Selector()) {
                var originPath = entry.FullName;
                var flag = true;
                var cflag = true;
                if (originPath.Contains($"assets/{modDomain}/lang")) {
                    flag = !(entry.Name.Equals("en_us.lang", StringComparison.OrdinalIgnoreCase) ||
                             entry.Name.Equals("en_us.json", StringComparison.OrdinalIgnoreCase));

                    
                    if (cfg.UpdateChinese) {
                        cflag = (entry.Name.Equals("zh_cn.lang",StringComparison.OrdinalIgnoreCase) ||
                                entry.Name.Equals("zn_cn.json",StringComparison.OrdinalIgnoreCase));
                    }

                    if (cflag) {
                        if (flag) {
                            continue;
                        }
                    }
                }

                var truePath = GeneratePath(originPath, mod.ProjectName, cfg.IncludedPath);
                var localPath = Path.GetDirectoryName(Path.Combine(rootPath, truePath).Replace("\\", "/"))!.Replace("\\", "/");
                if (!Directory.Exists(localPath)) {
                    Directory.CreateDirectory(localPath);
                }

                var p = localPath + "/" + entry.Name.ToLower();
                if (!flag) {
                    if (Path.GetExtension(entry.Name) == ".json" && CheckVersion(cfg.Version)) {
                        entry.ExtractToFile(p+".tmp", true);
                        var jf = new JsonFormatter(new StreamReader(File.OpenRead(p + ".tmp")), new StreamWriter(File.Create(p)),
                            mod.ProjectName);
                        jf.Format();
                        CreateEmptyJson(p);
                        File.Delete(p + ".tmp");
                    }
                    if (Path.GetExtension(entry.Name) == ".lang" && !CheckVersion(cfg.Version)) {
                        entry.ExtractToFile(p + ".tmp", true);
                        var lf = new LangFormatter(new StreamReader(File.OpenRead(p + ".tmp")), new StreamWriter(File.Create(p)));
                        lf.Format();
                        CreateEmptyLang(p);
                        File.Delete(p + ".tmp");
                    }
                }
                else {
                    entry.ExtractToFile(p, true);
                }
            }

        }

        /// <summary>
        /// 白嫖的目录复制
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs) {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new (sourceDirName);

            if (!dir.Exists) {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files) {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs) {
                foreach (DirectoryInfo subdir in dirs) {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        /// <summary>
        /// 往路径中插入项目名称
        /// </summary>
        /// <param name="path"></param>
        /// <param name="projectName"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private static string GeneratePath(string path, string projectName, string[] root) {
            var sb = new StringBuilder();
            var p = path.Split("/").ToList();
            p.ForEach(_ => {
                if (root.ToList().Contains(_)) {
                    sb.Append(_ + "/");
                    sb.Append(projectName + "/");
                }
                else if (_.EndsWith(".lang") || _.EndsWith(".json")) {
                    sb.Append(_.ToLower());
                }
                else {
                    sb.Append(_ + "/");
                }

            });

            return sb.ToString();
        }

        private static void CreateEmptyLang(string path) {
            var isParse = false;
            var d = Path.GetDirectoryName(path);
            foreach (string str in File.ReadAllLines(path)) {
                if (str == "#PARSE_ESCAPES") {
                    isParse = true;
                    break;
                }
            }

            if (File.Exists(Path.Combine(d!, "zh_cn.lang"))) {
                return;
            }
            if (isParse) {
                File.WriteAllText(
                    Path.Combine(d!, "zh_cn.lang"),
                    "#PARSE_ESCAPES\n\n");
            }
            else {
                File.WriteAllTextAsync(
                    Path.Combine(d!, "zh_cn.lang"), "\n");
            }
        }

        private static void CreateEmptyJson(string path) {
            var d = Path.GetDirectoryName(path);
            if (File.Exists(Path.Combine(d!, "zh_cn.json"))) {
                return;
            }
            File.WriteAllTextAsync(Path.Combine(d!, "zh_cn.json"),
                "{}");
        }

        /// <summary>
        /// true为高版本
        /// </summary>
        /// <param name="ver"></param>
        /// <returns></returns>
        private static bool CheckVersion(string ver) {
            var result = ver switch {
                "1.0" => false,
                "1.1" => false,
                "1.2.1" => false,
                "1.2.2" => false,
                "1.2.3" => false,
                "1.2.4" => false,
                "1.2.5" => false,
                "1.3.1" => false,
                "1.3.2" => false,
                "1.4.2" => false,
                "1.4.4" => false,
                "1.4.5" => false,
                "1.4.6" => false,
                "1.4.7" => false,
                "1.5.1" => false,
                "1.5.2" => false,
                "1.6.1" => false,
                "1.6.2" => false,
                "1.6.4" => false,
                "1.7.2" => false,
                "1.7.3" => false,
                "1.7.4" => false,
                "1.7.5" => false,
                "1.7.6" => false,
                "1.7.7" => false,
                "1.7.8" => false,
                "1.7.9" => false,
                "1.7.10" => false,
                "1.8" => false,
                "1.8.1" => false,
                "1.8.2" => false,
                "1.8.3" => false,
                "1.8.4" => false,
                "1.8.5" => false,
                "1.8.6" => false,
                "1.8.7" => false,
                "1.8.8" => false,
                "1.8.9" => false,
                "1.9" => false,
                "1.9.1" => false,
                "1.9.2" => false,
                "1.9.3" => false,
                "1.9.4" => false,
                "1.10" => false,
                "1.10.1" => false,
                "1.10.2" => false,
                "1.11" => false,
                "1.11.1" => false,
                "1.11.2" => false,
                "1.12" => false,
                "1.12.1" => false,
                "1.12.2" => false,
                "1.13" => true,
                "1.13.1" => true,
                "1.13.2" => true,
                "1.14" => true,
                "1.14.1" => true,
                "1.14.2" => true,
                "1.14.3" => true,
                "1.14.4" => true,
                "1.15" => true,
                "1.15.1" => true,
                "1.15.2" => true,
                "1.16" => true,
                "1.16.1" => true,
                "1.16.2" => true,
                "1.16.3" => true,
                "1.16.4" => true,
                "1.16.5" => true,
                _ => true
            };

            return result;
        }
    }

    public static class JsonElementExtension {
        public static string[] GetStringArray(this JsonElement elem) {
            var tmp = new List<string>();
            var enumerator = elem.EnumerateArray();
            while (enumerator.MoveNext()) {
                tmp.Add(enumerator.Current.GetString());
            }

            return tmp.ToArray();
        }

        public static List<string> GetStringList(this JsonElement elem) {
            var tmp = new List<string>();
            var enumerator = elem.EnumerateArray();
            while (enumerator.MoveNext()) {
                tmp.Add(enumerator.Current.GetString());
            }

            return tmp;
        }
    }
}