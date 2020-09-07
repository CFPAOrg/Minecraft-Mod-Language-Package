using Serilog;

namespace Spider {
    static class Program {
        static void Main(string[] args) {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }
    }
}