using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Language.Core;
using Serilog;
using Spider.Lib.FileLib;
using Spider.Lib.JsonLib;

namespace Spider.Lib
{
    public class Utils
    {
        /// <summary>
        /// 解析mod
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public static async Task ParseMods((ModInfo, Configuration) tuple)
        {

            if (tuple.Item2.NonUpdate)
            {
                Log.Logger.Warning($"{tuple.Item1.ShortWebsiteUrl}已在黑名单中，跳过");
                return;
            }

            Log.Logger.Information($"{tuple.Item1.ShortWebsiteUrl}正在解析");
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
            if (downloadUrl is not null)
            {

                try
                {
                    var bytes = await httpCli.GetByteArrayAsync(downloadUrl);
                    await File.WriteAllBytesAsync(path, bytes);
                }
                catch (Exception e)
                {
                    Log.Logger.Error($"写入文件时：{e.Message}");
                }

                var res = new Mod()
                {
                    Version = version,
                    DownloadUrl = downloadUrl,
                    Name = mod.Name,
                    ProjectId = mod.Id,
                    ProjectName = mod.ShortWebsiteUrl,
                    ProjectUrl = mod.WebsiteUrl,
                    TempPath = path,
                };

                ParseFiles(res,cfg,$"{Directory.GetCurrentDirectory()}\\projects\\{(await JsonReader.ReadConfigAsync())[0].Version}");
            }
        }

        /// <summary>
        /// 导出mod的文件
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="cfg"></param>
        /// <param name="rootPath"></param>
        public static void ParseFiles(Mod mod, Configuration cfg, string rootPath)
        {
            var zipArchive = new ZipArchive(File.OpenRead(mod.TempPath));
            var tmpDirectories = $"{Path.GetTempPath()}extracted\\{Path.GetFileName(mod.TempPath)}";
            Log.Logger.Debug(tmpDirectories);
            zipArchive.ExtractToDirectory(tmpDirectories, true);
            var directories = cfg.IncludedPath.ToList()
                .Select(_ => new DirectoryInfo($"{tmpDirectories}\\{_}"));
            var include = cfg.ExtractPath.ToList();
            //遍历所有目录
            var root = directories.Select(dire =>
                dire.EnumerateDirectories().Where(domain => domain.Name != "minecraft")
                    .Select(domain => domain.EnumerateDirectories()
                        .Where(_ => include.Contains(_.Name))));
            //遍历遍历所有输出的目录
            foreach (var a in root)
            {
                foreach (var b in a)
                {
                    foreach (var c in b)
                    {
                        //Console.WriteLine(c.FullName);
                        var dire1 = c.GetDirectories();
                        if (dire1.Length > 0) {
                            foreach (var dire2 in dire1)
                            {
                                var dire3 = dire2.GetDirectories();
                                foreach (var info in dire3)
                                {
                                    if (info.Name == "en_us")
                                    {
                                        //Console.WriteLine(info.FullName);
                                        var p = $"{rootPath}{info.FullName[(info.FullName.LastIndexOf(Path.GetFileName(mod.TempPath)!, StringComparison.Ordinal) + Path.GetFileName(mod.TempPath)!.Length)..]}";
                                        var path = GeneratePath(p, mod.ProjectName, cfg.IncludedPath);
                                        //Console.WriteLine(path);
                                        DirectoryCopy(info.FullName, path, true);
                                        //info.MoveTo(sb.ToString());
                                    }
                                }
                            }
                        }

                        var fi = c.GetFiles().ToList();
                        var ei = fi.Where(_ => _.Name.StartsWith("en_us", StringComparison.OrdinalIgnoreCase)).ToList();
                        if (cfg.UpdateChinese) {
                            ei.AddRange(fi.Where(_ => _.Name.StartsWith("zh_cn", StringComparison.OrdinalIgnoreCase)).ToList());
                        }

                        foreach (var info in ei) {
                            if (info.Name.EndsWith(".lang")) {
                                var p = $"{rootPath}{info.FullName[(info.FullName.LastIndexOf(Path.GetFileName(mod.TempPath)!, StringComparison.Ordinal) + Path.GetFileName(mod.TempPath)!.Length)..]}";
                                var path = GeneratePath(p, mod.ProjectName, cfg.IncludedPath);
                                //Console.WriteLine(path);
                                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                                var lf = new LangFormatter(new StreamReader(File.OpenRead(info.FullName)),
                                    new StreamWriter(File.Create(path)));
                                lf.Format();
                                //Language.Core.Utils.DeleteBlackKeys(path);
                            }
                            else if (info.Name.EndsWith(".json")) {
                                var p = $"{rootPath}{info.FullName[(info.FullName.LastIndexOf(Path.GetFileName(mod.TempPath)!, StringComparison.Ordinal) + Path.GetFileName(mod.TempPath)!.Length)..]}";
                                var path = GeneratePath(p, mod.ProjectName, cfg.IncludedPath);
                                //Console.WriteLine(path);
                                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                                var jf = new JsonFormatter(new StreamReader(File.OpenRead(info.FullName)),
                                    new StreamWriter(File.Create(path)), mod.ProjectName);
                                jf.Format();
                            }
                        }
                    }
                }
            }
            //比较好看的
            //foreach (var info in directories) {
            //    foreach (var directory in info.GetDirectories()) {
            //        if (directory.Name == "minecraft") {
            //            continue;
            //        }

            //        var root = directory.EnumerateDirectories()
            //            .Where(_ => include.Contains(_.Name))
            //            .Select(_ => _.FullName);

            //        root.ToList().ForEach(Console.WriteLine);
            //    }
            //}
        }

        /// <summary>
        /// 白嫖的目录复制
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
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
        private static string GeneratePath(string path, string projectName,string[] root) {
            var sb = new StringBuilder();
            var p = path.Split("\\").ToList();
            p.ForEach(_ =>
            {
                if (root.ToList().Contains(_))
                {
                    sb.Append(_ + "\\");
                    sb.Append(projectName + "\\");
                }
                else if (_.EndsWith(".lang") || _.EndsWith(".json")) {
                    sb.Append(_);
                }
                else
                {
                    sb.Append(_ + "\\");
                }

            });

            return sb.ToString();
        }
    }
}