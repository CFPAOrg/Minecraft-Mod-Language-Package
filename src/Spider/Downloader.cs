using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Spider.Lib;
using Spider.Lib.FileLib;
using Spider.Lib.JsonLib;

using Timer = System.Timers.Timer;

namespace Spider {
    public class Downloader {
        private int ModCount { get; set; }
        private int DownloadedCount { get; set; }
        private string Version { get; set; }
        private Config[] Config { get; set; }

        private List<Mod> Mods { get; set; }

        private readonly Timer _timer;

        public event EventHandler<LogEventArgs> Log;

        public Downloader(int modCount, string version,Config[] config, Timer timer) {
            ModCount = modCount;
            Version = version;
            _timer = timer;
            Config = config;
            DownloadedCount = 0;
            _timer.Elapsed += (_, _) => Tick_Logger();
        }

        public class LogEventArgs : EventArgs {
            public int ModCount { get; set; }
            public int DownloadedCount { get; set; }
        }

        private void Tick_Logger() {
            var args = new LogEventArgs {DownloadedCount = DownloadedCount, ModCount = ModCount};
            OnLog(args);
        }

        protected virtual void OnLog(LogEventArgs e) {
            Log?.Invoke(this, e);
        }

        public async Task<List<Mod>> Start() {
            _timer.Start();
            List<ModInfo> addons;
            if (!File.Exists(@$"{Directory.GetCurrentDirectory()}\config\spider\{Version}\intro.json")) {
                UrlLib.GetAllModIntroAsync(Version);
            }
            var root = new DirectoryInfo(@$"{Directory.GetCurrentDirectory()}\projects\{Version}\assets");
            var projects = root.GetDirectories();
            var boo = projects.Length <= ModCount;
            boo = true;
            if (boo) {
                Serilog.Log.Logger.Information("该版本mod数量不足，正在获取新mod");
                addons = (await UrlLib.GetModInfoAsync(ModCount, Version)).ToList();
                var mods = new List<long>();
                var dict = await ReadLib.ReadIntroAsync(Version);
                var white = Config.ToList().First(_ => _.Version == Version).List.WhiteList;

                foreach (var name in white) {
                    if (dict.ContainsKey(name)) {
                        mods.Add(dict[name]);
                    }
                }

                foreach (var name in white) {
                    if (addons.ToList().Where(_ => (UrlLib.GetProjectName(_.WebsiteUrl) == name)).ToArray().Length >0) {
                        var list = Config.ToList().First(_ => _.Version == Version).List.WhiteList.ToList();
                        list.Remove(name);
                        Config.ToList().First(_ => _.Version == Version).List.WhiteList = list.ToArray();
                    }
                }

                foreach (var mod in mods) {
                    ModInfo a;
                    try {
                        a = await UrlLib.GetModInfoAsync(mod);
                    } catch (Exception e) {
                        Console.WriteLine(e);
                        a = null;
                    }

                    if (a is not null) {
                        addons.Add(a);
                    }
                    Thread.Sleep(500);
                }

                ModCount += white.Length;
            } else {
                var mods = new List<long>();
                var dict = await ReadLib.ReadIntroAsync(Version);
                var white = Config.ToList().First(_ => _.Version == Version).List.WhiteList;
                foreach (var info in projects) {
                    if (dict.ContainsKey(info.Name)) {
                        mods.Add(dict[info.Name]);
                    }
                }
                ModCount = projects.Length + white.Length;
                foreach (var name in white) {
                    if (dict.ContainsKey(name)) {
                        if (!mods.Contains(dict[name])) {
                            mods.Add(dict[name]);
                        }
                    }
                }

                addons = new List<ModInfo>();
                var tmp1 = (await UrlLib.GetModInfoAsync(ModCount + 500, Version)).ToList();
                foreach (var modInfo in tmp1) {
                    if (mods.Contains(modInfo.Id)) {
                        addons.Add(modInfo);
                        mods.Remove(modInfo.Id);
                    }
                }

                foreach (var mod in mods) {
                    ModInfo a;
                    try {
                        a = await UrlLib.GetModInfoAsync(mod);
                    } catch (Exception e) {
                        Console.WriteLine(e);
                        a = null;
                    }

                    if (a is not null) {
                        addons.Add(a);
                    }
                    Thread.Sleep(500);
                }

                foreach (var name in white) {
                    if (addons.ToList().Where(_ => (UrlLib.GetProjectName(_.WebsiteUrl) == name)).ToArray().Length > 0) {
                        var list = Config.ToList().First(_ => _.Version == Version).List.WhiteList.ToList();
                        list.Remove(name);
                        Config.ToList().First(_ => _.Version == Version).List.WhiteList = list.ToArray();
                    }
                }
            }
            //addons.ForEach(_ => Console.WriteLine(_.Name));
            var semaphore = new Semaphore(32, 40);
            var tasks = addons.Select(async mod => {
                try {
                    semaphore.WaitOne();
                    var httpCli = new HttpClient();
                    var m = mod.GameVersionLatestFiles.First(_ => _.GameVersion == Version);
                    var downloadUrl = UrlLib.GetDownloadUrl(m.ProjectFileId.ToString(), m.ProjectFileName);
                    var bytes = await httpCli.GetByteArrayAsync(downloadUrl);
                    var path = @$"{Path.GetTempFileName()}".Replace(".tmp", ".jar");
                    await File.WriteAllBytesAsync(path, bytes);
                    DownloadedCount++;
                    return new Mod() {
                        DownloadUrl = downloadUrl,
                        Name = mod.Name,
                        ProjectId = mod.Id,
                        ProjectName = UrlLib.GetProjectName(mod.WebsiteUrl),
                        ProjectUrl = mod.WebsiteUrl,
                        Version = Version,
                        TempPath = path
                    };
                } catch (Exception e) {
                    Serilog.Log.Logger.Error($"{mod.Name}-{e}");
                    return null;
                } finally {
                    semaphore.Release();
                }
            });

            Mods = (await Task.WhenAll(tasks)).ToList();
            _timer.Stop();
            Tick_Logger();
            return Mods;
        }
    }
}