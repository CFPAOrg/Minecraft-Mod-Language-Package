using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Channels;
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
        public List<Mod> Mods { get; set; }
        private readonly Timer _timer;

        public event EventHandler<LogEventArgs> Log;

        public Downloader(int modCount, string version, Timer timer) {
            ModCount = modCount;
            Version = version;
            _timer = timer;
            DownloadedCount = 0;
            _timer.Elapsed += (s, e) => Tick_Logger();
        }

        public class LogEventArgs : EventArgs {
            public int ModCount { get; set; }
            public int DownloadedCount { get; set; }
        }

        private void Tick_Logger() {
            var args = new LogEventArgs();
            args.DownloadedCount = DownloadedCount;
            args.ModCount = ModCount;
            OnLog(args);
        }

        protected virtual void OnLog(LogEventArgs e) {
            Log?.Invoke(this, e);
        }

        public async Task<List<Mod>> Start() {
            _timer.Start();
            List<ModInfo> addons;
            if (!File.Exists(@$"{Directory.GetCurrentDirectory()}\config\spider\{Version}\intro.json")) {
                UrlLib.GetAllModIntro(Version);
            }
            var root = new DirectoryInfo(@$"{Directory.GetCurrentDirectory()}\projects\{Version}\assets");
            var projects = root.GetDirectories();
            if (projects.Length <= ModCount) {
                Serilog.Log.Logger.Information("该版本mod数量不足，正在获取新mod");
                addons = (await UrlLib.GetModInfoAsync(ModCount, Version)).ToList();
            } else {
                ModCount = projects.Length;
                var mods = new List<long>();
                var dict = await FileLib.ReadIntro(Version);
                foreach (var info in projects) {
                    if (dict.ContainsKey(info.Name)) {
                        mods.Add(dict[info.Name]);
                    }
                }

                addons = new List<ModInfo>();
                var tmp1 = (await UrlLib.GetModInfoAsync(ModCount, Version)).ToList();
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
            }
            addons.ForEach(_ => Console.WriteLine(_.Name));
            var semaphore = new Semaphore(32, 40);
            var tasks = addons.Select(async Mod => {
                try {
                    semaphore.WaitOne();
                    var httpCli = new HttpClient();
                    var m = Mod.GameVersionLatestFiles.First(_ => _.GameVersion == Version);
                    var downloadUrl = UrlLib.GetDownloadUrl(m.ProjectFileId.ToString(), m.ProjectFileName);
                    var bytes = await httpCli.GetByteArrayAsync(downloadUrl);
                    var path = @$"{Path.GetTempFileName()}".Replace(".tmp", ".jar");
                    await File.WriteAllBytesAsync(path, bytes);
                    DownloadedCount++;
                    return new Mod() {
                        DownloadUrl = downloadUrl,
                        Name = Mod.Name,
                        ProjectId = Mod.Id,
                        ProjectName = UrlLib.GetProjectName(Mod.WebsiteUrl),
                        ProjectUrl = Mod.WebsiteUrl,
                        Version = Version
                    };
                } catch (Exception e) {
                    Serilog.Log.Logger.Error($"{Mod.Name}-{e}");
                    return null;
                } finally {
                    semaphore.Release();
                }
            });

            Mods = (await Task.WhenAll(tasks)).ToList();
            return Mods;
        }
    }
}