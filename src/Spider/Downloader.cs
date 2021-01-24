using System;
using System.Timers;

namespace Spider {
    public class Downloader {
        private int ModCount { get; set; }
        private int DownloadedCount { get; set; }
        private Timer Timer { get; set; }

        public event EventHandler<LogEventArgs> Log;

        public Downloader(int modCount, Timer timer) {
            ModCount = modCount;
            Timer = timer;
            DownloadedCount = 0;
            Timer.Elapsed += (s, e) => tick_Logger();
        }

        public async void Download() {
            Timer.Start();
        }

        public void CheckCount() {

        }

        public class LogEventArgs : EventArgs {
            public int ModCount { get; set; }
            public int DownloadedCount { get; set; }
        }

        void tick_Logger() {
            var args = new LogEventArgs();
            args.DownloadedCount = this.DownloadedCount;
            args.ModCount = this.ModCount;
            OnLog(args);
        }

        protected virtual void OnLog(LogEventArgs e) {
            Log?.Invoke(this, e);
        }
    }
}