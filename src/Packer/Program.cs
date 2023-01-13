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
        // 由于某些魔法，这里可以直接加参数
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

            var config = await Utils.RetrieveConfig(configPath: "./config/packer.json",
                                                    mappingPath: "./config/fontmap.txt",
                                                    version: version);

            if (config is null)
            {
                throw new ArgumentException("无效的版本参数", nameof(version));
            }

            // Packer输出的文件名，可以随时更改
            string packName = $".\\Minecraft-Mod-Language-Package-{config.Version}.zip";

            Log.Information("开始对版本 {0} 的打包", config.Version);

            Utils.CreateTimeStamp(config.Version);
            await using var stream = File.Create(packName);
            var archive = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true);
            archive.Initialize(config);

            await archive.WriteContent(Lib.RetrieveContent(config, out var bypassed));
            archive.WriteBypassed(bypassed); // 将跳过的文件一并加入

            archive.Dispose(); // 确保ZipArchive的工作已经终止；底层流不会终止

            Log.Information("开始生成 MD5 值");
            var md5 = stream.ComputeMD5();
            await File.WriteAllTextAsync($"./{config.Version}.md5", md5);
            Log.Information("生成结束。MD5: {0}", md5);

            Log.Information("对版本 {0} 的打包结束", config.Version);
        }
    }
}
