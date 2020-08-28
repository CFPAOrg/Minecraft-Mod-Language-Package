using System;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using Serilog;
using System.Collections.Generic;


namespace Packer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            var config = RetrieveConfig();
            Log.Information("开始打包。版本：{0}", config.Version);
            using var stream = File.Create(".\\cache.zip"); // 生成空 zip 文档
            using var archive = new ZipArchive(stream, ZipArchiveMode.Update);
            InitializeArchive(archive, config);
            var existingModids = new Dictionary<string, string>();
            var assetsToBePacked = new DirectoryInfo($".\\projects\\{config.Version}\\assets")
                .EnumerateDirectories()
                .SelectMany(_ => _.GetDirectories()
                    .Select(descend => new
                    {
                        modid = descend.Name,
                        name = _.Name,
                        assetPath = descend,
                        prefixLength = _.FullName.Length
                    }
                ));
            foreach (var asset in assetsToBePacked)
            {
                if(asset is null)
                {
                    continue;
                }
                var id = asset.modid;
                var name = asset.name;
                Log.Information("正在打包 {0}（asset-domain：{1}）", name, id);
                if (existingModids.ContainsKey(id))
                {
                    Log.Warning("检测到 asset-domain 与 {0} 重合", existingModids[id]);
                    foreach(var file in asset.assetPath.EnumerateFiles("*", SearchOption.AllDirectories))
                    {
                        if (file.FullName.Contains("en_us", StringComparison.OrdinalIgnoreCase))
                        {
                            Log.Information("跳过了英文原文：{0}", file.FullName[(asset.prefixLength + 1)..]);
                            continue;
                        }
                        var destinationPath = $"assets\\{file.FullName[(asset.prefixLength + 1)..]}"
                            .Replace("zh_CN", "zh_cn"); // 修复大小写
                        var existingFile = archive.GetEntry(destinationPath);
                        if(existingFile is null) // null 代表没有找到文件，也就是该文件没有重合
                        {
                            archive.CreateEntryFromFile(file.FullName, destinationPath);
                            Log.Information("添加了暂未重合的 {0}", destinationPath);
                        }
                        else
                        {
                            Log.Warning("检测到重合文件：{0}", destinationPath);
                            using var reader = File.OpenRead(file.FullName);
                            using var writer = existingFile.Open();
                            writer.Seek(0, SeekOrigin.End); // 置于末尾
                            reader.CopyTo(writer); // 默认是有缓冲区的，不用担心爆内存
                            Log.Information("完成合并");
                        }
                    }
                }
                else
                {
                    foreach (var file in asset.assetPath.EnumerateFiles("*", SearchOption.AllDirectories))
                    {
                        if (file.FullName.Contains("en_us", StringComparison.OrdinalIgnoreCase))
                        {
                            Log.Information("跳过了英文原文：{0}", file.FullName[(asset.prefixLength + 1)..]);
                            continue;
                        }
                        var destinationPath = $"assets\\{file.FullName[(asset.prefixLength + 1)..]}"
                            .Replace("zh_CN", "zh_cn"); // 修复大小写
                        archive.CreateEntryFromFile(file.FullName, destinationPath);
                        Log.Information("添加了 {0}", destinationPath);
                    }
                    Log.Information("向 asset-domain 映射表中加入：{0} -> {1}", id, name);
                    existingModids.Add(id, name);
                }
            }
            Log.Information("打包结束");
            Log.Logger.Information("一次压缩完成");
            archive.ExtractToDirectory("cache");
            archive.Dispose();
            ZipFile.CreateFromDirectory("./cache", "Minecraft-Mod-Language-Package.zip");
            Log.Logger.Information("二次压缩完成");
        }

        static void InitializeArchive(ZipArchive archive, Config config)
        {
            Log.Information("开始初始化压缩包");
            string common = $".\\projects\\{config.Version}";
            new List<string>() { "LICENSE", "pack.mcmeta", "pack.png", "README.md" }.ForEach(_ =>
              {
                  Log.Information("初始化压缩包：添加 {0}", _);
                  archive.CreateEntryFromFile($"{common}\\{_}", _, CompressionLevel.Fastest);
              });
            Log.Information("初始化完成");
        }

        static Config RetrieveConfig()
        {
            var reader = File.ReadAllBytes(".\\config\\packer.json");
            return JsonSerializer.Deserialize<Config>(reader);
        }
    }
}
