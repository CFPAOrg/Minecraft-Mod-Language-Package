using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Serilog;

using Spider.Lib;
using Spider.Lib.FileLib;
using Spider.Lib.JsonLib;

namespace Spider
{
    static class Program
    {
        static async Task Main()
        {
            //Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException());

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .CreateLogger();
            var c = await JsonReader.ReadConfigAsync();

            foreach (var cfg in c)
            {
                Log.Logger.Information("Loading version configration: {0}",cfg.Version);
                //初始化parser
                var parser = new InfoParser(cfg.Configuration, cfg.CustomConfigurations);

                if (cfg.Configuration is not null)
                {
                    var dict = await JsonReader.ReadIntroAsync(cfg.Configuration.Version, cfg.Version);
                    var root = Directory.CreateDirectory(
                        $"{Directory.GetCurrentDirectory()}\\projects\\{cfg.Version}\\assets");

                    var names = root.GetDirectories().Select(_ => _.Name).ToList();

                    if (cfg.CustomConfigurations is not null)
                        foreach (var configuration in cfg.CustomConfigurations)
                        {
                            if (!names.Contains(configuration.ProjectName))
                            {
                                names.Add(configuration.ProjectName);
                            }
                        }

                    if (cfg.Count is not null)
                    {
                        var allMods = await UrlLib.GetModInfoAsync(cfg.Count.Value, cfg.Configuration.Version);
                        foreach (var modInfo in allMods)
                        {
                            if (dict.ContainsKey(modInfo.Slug) || dict.ContainsValue(modInfo.Id))
                            {
                                continue;
                            }
                            dict.Add(modInfo.Slug, modInfo.Id);
                        }

                        if (names.Count > cfg.Count)
                        {
                            var bin = allMods.Where(_ => !names.Contains(_.Slug));
                            var l = allMods.ToList();
                            foreach (var info in bin)
                            {
                                l.Remove(info);
                            }

                            allMods = l.ToArray();
                        }
                        var allNames = allMods.ToList().Select(_ => _.Slug).Distinct().ToList();
                        var l1 = parser.SerializeAll(allMods).Distinct().ToList();

                        var pending = new List<string>();
                        foreach (var str in names)
                        {
                            if (!allNames.Contains(str))
                            {
                                pending.Add(str);
                            }
                        }

                        Log.Logger.Information($"该版本[assets]文件夹下含有 {names.Count} 个mod，有 {pending.Count} 要单独处理");
                        var semaphore = new SemaphoreSlim(16, 16);

                        var tasks = l1.Select(async mod =>
                        {
                            try
                            {
                                await semaphore.WaitAsync();
                                await Utils.ParseModsAsync(mod, cfg);
                            }
                            catch (Exception e)
                            {
                                Log.Logger.Error(e.Message);
                            }
                            finally
                            {
                                semaphore.Release();
                            }
                        });

                        await Task.WhenAll(tasks);
                        if (!Directory.Exists(@$"{Directory.GetCurrentDirectory()}\config\spider\{cfg.Configuration.Version}"))
                        {
                            Directory.CreateDirectory(
                                @$"{Directory.GetCurrentDirectory()}\config\spider\{cfg.Configuration.Version}");
                        }

                        var inf = new List<ModIntro>();
                        foreach (var (key, value) in dict) inf.Add(new ModIntro() { Name = key, Id = value });
                        await File.WriteAllTextAsync(@$"{Directory.GetCurrentDirectory()}\config\spider\{cfg.Version}\intro.json",
                            JsonSerializer.Serialize(inf, new JsonSerializerOptions() { WriteIndented = true }));

                        var ids = pending.Where(name => dict.ContainsKey(name)).Select(name => dict[name].ToString());

                        var infos = await UrlLib.GetModInfosAsync(ids);
                        var cfgs = parser.SerializeAll(infos);

                        var semaphore2 = new SemaphoreSlim(16, 16);
                        var postTask = cfgs.Select(async _ =>
                        {
                            try
                            {
                                await semaphore2.WaitAsync();
                                await Utils.ParseModsAsync(_, cfg);
                            }
                            catch (Exception e)
                            {
                                Log.Logger.Error(e.Message);
                            }
                            finally
                            {
                                semaphore2.Release();
                            }
                        });

                        await Task.WhenAll(postTask);
                    }
                }
            }
        }
    }
}
