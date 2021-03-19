using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Serilog;
using Spider.Lib;
using Spider.Lib.JsonLib;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException());

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var m = new Mod();
            m.TempPath = @"C:\Users\Nullpinter\Desktop\spacesniffer_1_3_0_2\thermal_foundation-1.16.3-1.1.6.jar";
            m.ProjectName = "114514";
            var c = new Lib.JsonLib.Configuration();
            c.IncludedPath = new[] {"assets","data"};
            c.ExtractPath = new[] {"lang", "patchouli_books"};
            Utils.ParseFiles(m,c, @"D:\repos\Minecraft-Mod-Language-Package\projects\1.12.2");
            Console.ReadLine();
        }
    }
}