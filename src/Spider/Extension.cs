//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Net.Http;
//using System.Reflection.Metadata.Ecma335;
//using System.Text.Json;
//using System.Text.RegularExpressions;
//using System.Threading;
//using System.Threading.Tasks;
//using Serilog;
//using Spider.Lib;
//using Spider.Properties;

//namespace Spider {
//    public static class Extension {
//        public static ModBase[] GenerateBases(this Addon[] addons, string version) {
//            var bases = new List<ModBase>();
//            foreach (var addon in addons) {
//                var name = addon.Name;
//                var projectName = UrlLib.GetProjectName(addon.WebsiteUrl);
//                var projectId = addon.Id;
//                var projectUrl = addon.WebsiteUrl;
//                var mod = addon.GameVersionLatestFiles.First(_ => _.GameVersion == version);
//                var downloadUrl = UrlLib.GetDownloadUrl(mod.ProjectFileId.ToString(), mod.ProjectFileName);
//                var modBase = new ModBase() {
//                    DownloadUrl = downloadUrl, Name = name, ProjectName = projectId, ProjectName = projectName,
//                    ProjectUrl = projectUrl
//                };
//                bases.Add(modBase);
//            }

//            return bases.ToArray();
//        }

//        public static async Task<DownloadMod[]> DownloadModAsync(this ModBase[] modBases) {
//            var semaphore = new Semaphore(32, 40);
//            var tasks = modBases.Select(async _ => {
//                try {
//                    semaphore.WaitOne();
//                    var httpCli = new HttpClient();
//                    Log.Logger.Information($"下载mod：{_.Name}");
//                    var bytes = await httpCli.GetByteArrayAsync(_.DownloadUrl);
//                    var path = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
//                    path = path.Replace(".tmp", ".jar");
//                    await File.WriteAllBytesAsync(path, bytes);
//                    var downloadMod = new DownloadMod() {
//                        DownloadUrl = _.DownloadUrl,
//                        ModPath = path,
//                        Name = _.Name,
//                        ProjectName = _.ProjectName,
//                        ProjectName = _.ProjectName,
//                        ProjectUrl = _.ProjectUrl
//                    };
//                    return downloadMod;
//                }
//                catch (Exception e) {
//                    Log.Logger.Error(e.Message);
//                    return null;
//                }
//                finally {
//                    semaphore.Release();
//                }
//            });

//            var result = await Task.WhenAll(tasks);
//            return result;
//        }

//        public static async Task<Info[]> ParseModAsync(this DownloadMod[] download,string version,string[] bl) {
//            if (version == "1.12.2") {
//                var cfrPath = Path.Combine(Directory.GetCurrentDirectory(), "cfr.jar");
//                Log.Logger.Information("释放反编译工具");
//                await File.WriteAllBytesAsync(cfrPath, Resources.cfr_0_150);
//                Log.Logger.Information("释放完成");
//                var tasks = new List<Task<Info>>();
//                var regex = new Regex("(?<=modid=\").*?(?=\")");
//                var semaphore = new Semaphore(10, 20);
//                foreach (var downloadMod in download) {
//                    if (bl.ToList().Contains(downloadMod.ProjectName.ToString())) continue;
//                    var task = Task.Run(async () => {
//                        try {
//                            semaphore.WaitOne();
//                            Log.Logger.Information($"开始反编译{downloadMod.Name}");
//                            //var process = new Process() {
//                            //    StartInfo = {
//                            //    FileName = "java",
//                            //    Arguments = $"-jar ./cfr.jar {downloadMod.ModPath}",
//                            //    RedirectStandardOutput = true,
//                            //    UseShellExecute = false
//                            //}
//                            //};
//                            //process.Start();
//                            var modid = string.Empty;
//                            //while (!process.StandardOutput.EndOfStream) {
//                            //    var line = await process.StandardOutput.ReadLineAsync();
//                            //    if (!String.IsNullOrEmpty(line)) {
//                            //        if (regex.IsMatch(line)) {
//                            //            if (line.StartsWith("@Mod(")) {
//                            //                modid = regex.Match(line).Value;
//                            //                break;
//                            //            }
//                            //        }
//                            //    }
//                            //}

//                            //process.Kill();
//                            modid = "off";
//                            //Log.Logger.Information($"找到modid：{modid}");
//                            var zipArchive = new ZipArchive(File.OpenRead(downloadMod.ModPath));
//                            var languageEntries = zipArchive.Entries
//                                .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
//                                .Where(_ => _.FullName.Contains("/lang/"))
//                                .Where(_ => _.FullName.EndsWith(".lang"))
//                                .ToArray();
//                            var domainEntries = zipArchive.Entries
//                                .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
//                                .Where(_ => _.FullName.EndsWith("/lang/")).ToArray();
//                            var chineseEntries = zipArchive.Entries
//                                .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
//                                .Where(_ => _.FullName.Contains("/lang/"))
//                                .Where(_ => _.FullName.EndsWith("zh_cn.lang", StringComparison.OrdinalIgnoreCase))
//                                .ToArray();
//                            var domains = domainEntries.Select(_ => _.FullName.Split("/", 3)[1]).ToArray();
//                            var languages = languageEntries.Select(_ => _.FullName).ToArray();
//                            var info = new Info() {
//                                Domain = domains,
//                                DownloadUrl = downloadMod.DownloadUrl,
//                                HasLang = languages.Length > 0,
//                                LangList = languages,
//                                LastUpdateTime = DateTimeOffset.UtcNow,
//                                ModId = modid,
//                                Name = downloadMod.Name,
//                                ProjectName = downloadMod.ProjectName,
//                                ProjectName = downloadMod.ProjectName,
//                                ProjectUrl = downloadMod.ProjectUrl,
//                                HasChinese = chineseEntries.Length > 0,
//                                ModPath = downloadMod.ModPath
//                            };
//                            return info;
//                        } catch (Exception e) {
//                            Log.Logger.Error(e.Message);
//                            return null;
//                        } finally {
//                            semaphore.Release();
//                        }
//                    });
//                    tasks.Add(task);
//                }

//                var res = await Task.WhenAll(tasks);
//                return res;
//            }
//            else {
//                var regex = new Regex("(?<=modId=\").*?(?=\")");
//                var il = new List<Info>();
//                foreach (var downloadMod in download) {
//                    if (bl.ToList().Contains(downloadMod.ProjectName.ToString())) continue;
//                    Log.Logger.Information($"解析：{downloadMod.Name}");
//                    var fs = File.Open(downloadMod.ModPath, FileMode.Open);
//                    var jarArchive = new ZipArchive(fs);
//                    try {
//                        var modIdEntry = jarArchive.GetEntry("META-INF/mods.toml");
//                        var tempName = Path.GetTempFileName().Replace(".tmp", ".entryTmp");
//                        modIdEntry.ExtractToFile(tempName);
//                        foreach (var line in await File.ReadAllLinesAsync(tempName)) {
//                            if (line.StartsWith("modId=\"")) {
//                                var modId = regex.Match(line).ToString();
//                                var languageEntries = jarArchive.Entries
//                                    .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
//                                    .Where(_ => _.FullName.Contains("/lang/"))
//                                    .Where(_ => _.FullName.EndsWith(".json"))
//                                    .ToArray();
//                                var domainEntries = jarArchive.Entries
//                                    .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
//                                    .Where(_ => _.FullName.EndsWith("/lang/")).ToArray();
//                                var chineseEntries = jarArchive.Entries
//                                    .Where(_ => _.FullName.StartsWith("assets", StringComparison.OrdinalIgnoreCase))
//                                    .Where(_ => _.FullName.Contains("/lang/"))
//                                    .Where(_ => _.FullName.EndsWith("zh_cn.json", StringComparison.OrdinalIgnoreCase))
//                                    .ToArray();
//                                var domains = domainEntries.Select(_ => _.FullName.Split("/", 3)[1]).ToArray();
//                                var languages = languageEntries.Select(_ => _.FullName).ToArray();
//                                fs.Close();
//                                il.Add(new Info() {
//                                    Domain = domains,
//                                    DownloadUrl = downloadMod.DownloadUrl,
//                                    HasLang = languages.Length > 0,
//                                    LangList = languages,
//                                    LastUpdateTime = DateTimeOffset.UtcNow,
//                                    ModId = modId,
//                                    Name = downloadMod.Name,
//                                    ProjectName = downloadMod.ProjectName,
//                                    ProjectName = downloadMod.ProjectName,
//                                    ProjectUrl = downloadMod.ProjectUrl,
//                                    HasChinese = chineseEntries.Length > 0,
//                                    ModPath = downloadMod.ModPath
//                                });
//                            }
//                        }

//                    } catch (Exception e) {
//                        Log.Logger.Error(e.Message);
//                        Log.Logger.Error($"找不到{downloadMod.Name}的modId");
//                    }
//                }
//                return il.ToArray();
//            }
//        }

//        public static Info[] ExtractResource(this Info[] infos, string version) {
//            var format = version == "1.12.2" ? "en_us.lang" : "en_us.json";
//            foreach (var info in infos) {
//                var zipArchive = new ZipArchive(File.OpenRead(info.ModPath));
//                if (info.HasLang) {
//                    var enPath = info.LangList.Where(_ =>
//                        _.EndsWith(format, StringComparison.CurrentCultureIgnoreCase)).ToList();
//                    var entires = new List<ZipArchiveEntry>{};
//                    foreach (var i in enPath) {
//                        entires.Add(zipArchive.GetEntry(i));
//                    }

//                    foreach (var zipArchiveEntry in entires) {
//                        foreach (var domain in info.Domain) {
//                            var fullName = zipArchiveEntry.FullName;
//                            if (fullName.Contains($"assets/{domain}/lang/")) {
//                                Directory.CreateDirectory($"./projects/{version}/assets/{info.ProjectName}/{domain}/lang/");
//                                if (File.Exists($"./projects/{version}/assets/{info.ProjectName}/{domain}/lang/{zipArchiveEntry.Name.ToLower()}")) {
//                                    File.Delete($"./projects/{version}/assets/{info.ProjectName}/{domain}/lang/{zipArchiveEntry.Name.ToLower()}");
//                                }
//                                Log.Logger.Information($"解压：{zipArchiveEntry.FullName}");
//                                zipArchiveEntry.ExtractToFile($"./projects/{version}/assets/{info.ProjectName}/{domain}/lang/{zipArchiveEntry.Name.ToLower()}");
//                            }
//                        }
//                    }
//                }
//            }
//            return infos;
//        }

//        public static async Task WriteToAsync(this Info[] infos, string version,string name) {
//            Directory.CreateDirectory($"./config/spider/{version}");
//            await File.WriteAllBytesAsync($"./config/spider/{version}/{name}", JsonSerializer.SerializeToUtf8Bytes(infos, new JsonSerializerOptions() {
//                WriteIndented = true
//            }));
//        }
//    }
//}