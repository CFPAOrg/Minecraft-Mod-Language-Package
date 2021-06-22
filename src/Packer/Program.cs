using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

using Packer.Extensions;
using Serilog;

namespace Packer
{
    class Program
    {
        public static async Task Main(string version = null)
        {
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .MinimumLevel.Information() // 以便 debug 时修改这一等级
             .CreateLogger();
            if (version is null)
            {
                throw new ArgumentNullException(nameof(version));
            }
            var config = await Utils.RetrieveConfig(configPath:  "./config/packer.json",
                                                    mappingPath: "./config/fontmap.txt",
                                                    version:     version);
            if (config is null)
            {
                throw new ArgumentException("无效的版本参数", nameof(version));
            }
            Log.Information("开始对版本 {0} 的打包", config.Version);
            Utils.CreateTimeStamp(config.Version);
            await using var stream = File.Create($".\\Minecraft-Mod-Language-package-{config.Version}.zip");
            var archive = new ZipArchive(stream, ZipArchiveMode.Update);
            archive.Initialize(config);
            await archive.WriteContent(Lib.RetrieveContent(config, out var bypassed));
            archive.WriteBypassed(bypassed); // 将跳过的文件一并加入
            archive.Dispose();
            //stream.Dispose();
            await Utils.WriteMd5(await File.ReadAllBytesAsync($".\\Minecraft-Mod-Language-package-{config.Version}.zip"), config);
            Log.Information("对版本 {0} 的打包结束", config.Version);
        }
    }
}
