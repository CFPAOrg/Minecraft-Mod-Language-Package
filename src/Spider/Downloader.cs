using System;
using System.Collections.Generic;
using System.Timers;
using Spider.Lib;
using Spider.Lib.JsonLib;

namespace Spider {
    public class Downloader {
        private int ModCount { get; set; }
        private int DownloadedCount { get; set; }
        private string Version { get; set; }
        public List<Mod> Mods { get; set; }
        private readonly Timer _timer;

        public event EventHandler<LogEventArgs> Log;

        public Downloader(int modCount,string version, Timer timer) {
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
            args.DownloadedCount = this.DownloadedCount;
            args.ModCount = this.ModCount;
            OnLog(args);
        }

        protected virtual void OnLog(LogEventArgs e) {
            Log?.Invoke(this, e);
        }

        public async void Start() {
            _timer.Start();
            var addons =await UrlLib.GetModInfoAsync(ModCount, Version);
        }

        public void CheckCount() {

        }
    }
}