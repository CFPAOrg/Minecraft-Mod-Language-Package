using System;
using Serilog;

namespace Spider {
    class Program {
        static void Main(string[] args) {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }
    }
}