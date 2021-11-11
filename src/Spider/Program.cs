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
                var parser = new InfoParser(cfg.Configuration, cfg.CustomConfigurations);

                if (cfg.Configuration is not null)
                {
                    var dict = await JsonReader.ReadIntroAsync(cfg.Configuration.Version, cfg.Version);
                    var pending = new List<string>();
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
                        var allM = await UrlLib.GetModInfoAsync(cfg.Count.Value, cfg.Configuration.Version);
                        foreach (var modInfo in allM)
                        {
                            dict.Add(modInfo.Slug, modInfo.Id);
                        }

                        if (names.Count > cfg.Count)
                        {
                            var bin = allM.Where(_ => !names.Contains(_.Slug));
                            var l = allM.ToList();
                            foreach (var info in bin)
                            {
                                l.Remove(info);
                            }

                            allM = l.ToArray();
                        }
                        var allN = allM.ToList().Select(_ => _.Slug).Distinct().ToList();
                        var l1 = parser.SerializeAll(allM).Distinct().ToList();

                        //var parallelOption = new ParallelOptions {
                        //    MaxDegreeOfParallelism = 16
                        //};

                        foreach (var str in names)
                        {
                            if (!allN.Contains(str))
                            {
                                pending.Add(str);
                            }
                        }

                        Log.Logger.Information($"该版本[assets]文件夹下含有 {names.Count} 个mod，有 {pending.Count} 要单独处理");
                        var semaphore = new SemaphoreSlim(16, 16);
                        //Parallel.ForEach(l1, parallelOption, (async tuple => {
                        //    try {
                        //        semaphore.WaitOne();
                        //        await Utils.ParseModsAsync(tuple, cfg);
                        //    }
                        //    catch (Exception e) {
                        //        Log.Logger.Error(e.Message);
                        //    }
                        //    finally {
                        //        semaphore.Release();
                        //    }
                        //}));

                        var tasks = l1.Select(async _ =>
                        {
                            try
                            {
                                await semaphore.WaitAsync();
                                await Utils.ParseModsAsync(_, cfg);
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
                        await File.WriteAllTextAsync(@$"{Directory.GetCurrentDirectory()}\config\spider\config.json",
                            JsonSerializer.Serialize(dict));
                    }

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
