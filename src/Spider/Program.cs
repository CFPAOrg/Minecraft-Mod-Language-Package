using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using Formatter;
using Language.Core;
using Serilog;
using Spider.Lib.FileLib;
using Spider.Lib.JsonLib;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var config = await FileLib.ReadConfigAsync();
            Console.ReadLine();
        }
    }
}