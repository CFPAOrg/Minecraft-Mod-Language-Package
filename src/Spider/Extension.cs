using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Spider.Properties;

namespace Spider {
    public static class Extension {
        public static List<ModBase> GenerateBases(this List<Addon> addons, string version) {
            var bases = new List<ModBase>();
            foreach (var addon in addons) {
                var name = addon.Name;
                var projectName = UrlLib.GetProjectName(addon.WebsiteUrl);
                var projectId = addon.Id;
                var projectUrl = addon.WebsiteUrl;
                var mod = addon.GameVersionLatestFiles.First(_ => _.GameVersion == version);
                var downloadUrl = UrlLib.GetDownloadUrl(mod.ProjectFileId.ToString(), mod.ProjectFileName);
                var modBase = new ModBase() {
                    DownloadUrl = downloadUrl, Name = name, ProjectId = projectId, ProjectName = projectName,
                    ProjectUrl = projectUrl
                };
                bases.Add(modBase);
            }

            return bases;
        }

        public static async Task<List<DownloadMod>> DownloadModAsync(this List<ModBase> modBases) {
            var semaphore = new Semaphore(32, 40);
            var tasks = modBases.Select(async _ => {
                try {
                    semaphore.WaitOne();
                    var httpCli = new HttpClient();
                    Log.Logger.Information($"下载mod：{_.Name}");
                    var bytes = await httpCli.GetByteArrayAsync(_.DownloadUrl);
                    var path = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
                    path = path.Replace(".tmp", ".jar");
                    await File.WriteAllBytesAsync(path, bytes);
                    var downloadMod = new DownloadMod() {
                        DownloadUrl = _.DownloadUrl,
                        ModPath = path,
                        Name = _.Name,
                        ProjectId = _.ProjectId,
                        ProjectName = _.ProjectName,
                        ProjectUrl = _.ProjectUrl
                    };
                    return downloadMod;
                }
                catch (Exception e) {
                    Log.Logger.Error(e.Message);
                    return null;
                }
                finally {
                    semaphore.Release();
                }
            });

            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public static async Task<List<Info>> ParseModAsync(this List<DownloadMod> download) {
            var cfrPath = Path.Combine(Directory.GetCurrentDirectory(), "cfr.jar");
            Log.Logger.Information("释放反编译工具");
            await File.WriteAllBytesAsync(cfrPath, Resources.cfr_0_150);
            Log.Logger.Information("释放完成");
            var tasks = new List<Task<Info>>();
            var regex = new Regex("(?<=modid=\").*?(?=\")");
            var semaphore = new Semaphore(10, 20);
            foreach (var downloadMod in download) {
                var task = Task.Run(async () => {
                    try {
                        semaphore.WaitOne();
                        Log.Logger.Information($"开始反编译{downloadMod.Name}");
                        var process = new Process() {
                            StartInfo = {
                                FileName = "java",
                                Arguments = $"-jar ./cfr.jar {downloadMod.ModPath}",
                                RedirectStandardOutput = true,
                                UseShellExecute = false
                            }
                        };
                        process.Start();
                        var modid = string.Empty;
                        while (!process.StandardOutput.EndOfStream) {
                            var line = await process.StandardOutput.ReadLineAsync();
                            if (!String.IsNullOrEmpty(line)) {
                                if (regex.IsMatch(line)) {
                                    if (line.StartsWith("@Mod(")) {
                                        modid = regex.Match(line).Value;
                                        break;
                                    }
                                }
                            }
                        }

                        process.Kill();
                        //Log.Logger.Information($"找到modid：{modid}");
                        var zipArchive = new ZipArchive(File.OpenRead(downloadMod.ModPath));
                        var languageEntries = zipArchive.Entries
                            .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
                            .Where(_ => _.FullName.Contains("/lang/"))
                            .Where(_ => _.FullName.EndsWith(".lang"))
                            .ToList();
                        var domainEntries = zipArchive.Entries
                            .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
                            .Where(_ => _.FullName.EndsWith("/lang/")).ToList();
                        var chineseEntries = zipArchive.Entries
                            .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
                            .Where(_ => _.FullName.Contains("/lang/"))
                            .Where(_ => _.FullName.EndsWith("zh_cn.lang", StringComparison.OrdinalIgnoreCase))
                            .ToList();
                        var domains = domainEntries.Select(_ => _.FullName.Split("/", 3)[1]).ToList();
                        var languages = languageEntries.Select(_ => _.FullName).ToList();
                        var info = new Info() {
                            Domain = domains,
                            DownloadUrl = downloadMod.DownloadUrl,
                            HasLang = languages.Count > 0,
                            LangList = languages,
                            LastUpdateTime = DateTimeOffset.UtcNow,
                            ModId = modid,
                            Name = downloadMod.Name,
                            ProjectId = downloadMod.ProjectId,
                            ProjectName = downloadMod.ProjectName,
                            ProjectUrl = downloadMod.ProjectUrl,
                            HasChinese = chineseEntries.Count > 0,
                            ModPath = downloadMod.ModPath
                        };
                        return info;
                    }
                    catch (Exception e) {
                        Log.Logger.Error(e.Message);
                        return null;
                    }
                    finally {
                        semaphore.Release();
                    }
                });
                tasks.Add(task);
            }

            var res = await Task.WhenAll(tasks);
            return res.ToList();
        }

        public static async Task<List<Info>> GetModInfoAsync(this List<DownloadMod> download) {
            return null;
        }

        public static List<Info> ExtractResource(this List<Info> infos, string version) {
            foreach (var info in infos) {
                var zipArchive = new ZipArchive(File.OpenRead(info.ModPath));
                if (info.HasLang) {
                    var enPath = info.LangList.Where(_ =>
                        _.EndsWith("en_us.lang", StringComparison.CurrentCultureIgnoreCase)).ToList();
                    var entires = new List<ZipArchiveEntry>{};
                    foreach (var i in enPath) {
                        entires.Add(zipArchive.GetEntry(i));
                    }

                    foreach (var zipArchiveEntry in entires) {
                        foreach (var domain in info.Domain) {
                            var fullName = zipArchiveEntry.FullName;
                            if (fullName.Contains($"assets/{domain}/lang/")) {
                                Directory.CreateDirectory($"./projects/assets/{version}/{info.ProjectName}/{domain}/lang");
                                File.Delete($"./projects/{version}/assets/{info.ProjectName}/{domain}/lang/{zipArchiveEntry.Name.ToLower()}");
                                zipArchiveEntry.ExtractToFile($"./projects/{version}/assets/{info.ProjectName}/{domain}/lang/{zipArchiveEntry.Name.ToLower()}");
                            }
                        }
                    }
                }
            }
            return infos;
        }

        public static async Task WriteToAsync(this List<Info> infos, string path) {
            var fullPath = Path.GetFullPath(path);
            await File.WriteAllBytesAsync(fullPath, JsonSerializer.SerializeToUtf8Bytes(infos, new JsonSerializerOptions() {
                WriteIndented = true
            }));
        }
    }
}