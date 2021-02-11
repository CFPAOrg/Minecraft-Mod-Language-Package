using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Spider.Lib;
using Spider.Lib.FileLib;
using Spider.Lib.JsonLib;

using Timer = System.Timers.Timer;

namespace Spider {
    public sealed class Downloader {
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

        private void OnLog(LogEventArgs e) {
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
            var add = projects.Length <= ModCount;
            add = true;
            if (add) {
                Serilog.Log.Logger.Information("该版本mod数量不足，正在获取新mod");
                addons = (await UrlLib.GetModInfoAsync(ModCount, Version)).ToList();
                var mods = new List<long>();
                var dict = await ReadLib.ReadIntroAsync(Version);

            } else {
                var mods = new List<long>();
                var dict = await ReadLib.ReadIntroAsync(Version);
                foreach (var info in projects) {
                    if (dict.ContainsKey(info.Name)) {
                        mods.Add(dict[info.Name]);
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
            }
            //addons.ForEach(_ => Console.WriteLine(_.Name));
            var semaphore = new Semaphore(32, 40);
            var tasks = addons.Select(async mod => {
                semaphore.WaitOne();
                var res = await UrlLib.DownloadAsync(mod, Version);
                semaphore.Release();
                if (res.Item2) {
                    return res.Item1;
                }

                return null;
            });

            Mods = (await Task.WhenAll(tasks)).ToList();
            _timer.Stop();
            Tick_Logger();
            return Mods;
        }
    }
}