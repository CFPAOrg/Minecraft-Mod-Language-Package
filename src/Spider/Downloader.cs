using System;
using System.Timers;

namespace Spider {
    public class Downloader {
        private int ModCount { get; set; }
        private int DownloadedCount { get; set; }
        private readonly Timer _timer;

        public event EventHandler<LogEventArgs> Log;

        public Downloader(int modCount, Timer timer) {
            ModCount = modCount;
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

        public async void Download() {
            _timer.Start();
        }

        public void CheckCount() {

        }
    }
}