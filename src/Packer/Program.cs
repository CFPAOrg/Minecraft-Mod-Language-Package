using Packer.Extensions;
using Packer.Helpers;
using Packer.Models;
using Packer.Models.Providers;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Packer
{
    class Program
    {
        // System.CommandLine.DragonFruit支持
        public static async Task Main(string version, bool increment = false, bool grouped = false, bool flattened = false)
        {
            Log.Logger = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .MinimumLevel.Debug()
             .CreateLogger();

            var config = ConfigHelpers.RetrieveConfig(configTemplate: "./config/packer/{0}.json",
                                                      version: version);
            Log.Information("开始对版本 {0} 的打包", config.Base.Version);

            var targetModIdentifiers = increment ? GitHelpers.EnumerateChangedMods(config.Base.Version)
                : Enumerable.Empty<string>();

            var query = 
                EnumerationHelper.EnumerateUnmerged(targetModIdentifiers, config, config.Base.FallbackVersions.Prepend(config.Base.Version))
                .MergeDeep()
                .PostProcess(config)
                .ToArray(); // 好吧要打两种包导致的


            IEnumerable<IResourceFileProvider> initialFiles = [
                new RawFile(new FileInfo("./projects/templates/pack.png"), "pack.png"),
                TextFile.Create(new FileInfo("./projects/templates/LICENSE"), "LICENSE"),
                TextFile.CreateFromTemplate(new FileInfo(config.Base.ReadmeTemplate),
                    "README.txt",
                    config.Base.ReadmeParameters),
                TextFile.CreateFromTemplate(new FileInfo(config.Base.McMetaTemplate),
                    "pack.mcmeta",
                    [DateTime.UtcNow.AddHours(8), .. config.Base.McMetaParameters])
                ];

            if (flattened)
            {
                string packName = $"./Minecraft-Mod-Language-Modpack-{version}.zip";
                Log.Information("直出资源包：{0}", packName);
                await using var stream = File.Create(packName);

                using (var archive = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true))
                {
                    await archive.WriteDirect(initialFiles);
                    await archive.WriteDirect(query);
                }
                var md5 = stream.ComputeMD5();

                Log.Information("打包文件的 MD5 值：{0}", md5);
                File.WriteAllText($"./{version}.md5", md5);
            }

            if (grouped)
            {
                string packName = $"./Minecraft-Mod-Language-Modpack-{config.Base.Version}-namespaced.zip";
                Log.Information("命名空间组合包：{0}", packName);
                await using var stream = File.Create(packName);

                using (var archive = new ZipArchive(stream, ZipArchiveMode.Update, leaveOpen: true))
                {
                    await archive.WriteDirect(initialFiles);
                    await archive.WriteGrouped(query);
                }
                //var md5 = stream.ComputeMD5();

                //Log.Information("打包文件的 MD5 值：{0}", md5);
                //File.WriteAllText($"./{config.Base.Version}.md5", md5);
            }

            Log.Information("对版本 {0} 的打包结束。", version);
        }
    }
}
