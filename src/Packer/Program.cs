using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

using Packer.Extensions;
using Serilog;

namespace Packer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .MinimumLevel.Information() // 以便 debug 时修改这一等级
                .CreateLogger();
            var configs = await Utils.RetrieveConfig(configPath:  "./config/packer.json",
                                                     mappingPath: "./config/fontmap.txt");
            foreach (var config in configs)
            {
                Log.Information("开始对版本 {0} 的打包。", config.Version);
                using var stream = File.Create($".\\Minecraft-Mod-Language-package-{config.Version}.zip");
                using var archive = new ZipArchive(stream, ZipArchiveMode.Update);
                archive.Initialize(config);
                await archive.WriteContent(Lib.RetrieveContent(config, out var bypassed));
                Log.Information("开始添加未经处理的文件。");
                archive.WriteBypassed(bypassed); // 将跳过的文件一并加入
                await Utils.WriteMd5(stream, config);
                Log.Information("对版本 {0} 的打包结束。", config.Version);
            }
            Log.Information("所有打包均已结束。");
        }
    }
}
