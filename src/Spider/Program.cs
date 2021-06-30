using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

using Serilog;

using Spider.Lib;
using Spider.Lib.FileLib;
using Spider.Lib.JsonLib;

namespace Spider {
    static class Program {
        static async Task Main(string[] args) {
            //Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException());

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var c = await JsonReader.ReadConfigAsync();

            foreach (var cfg in c) {
                var parser = new InfoParser(cfg.Configuration, cfg.CustomConfigurations);
                var num = (int)Math.Ceiling((decimal)cfg.Count / 50);
                var dict = await JsonReader.ReadIntroAsync(cfg.Configuration.Version, cfg.Version);
                var all = new List<string>();
                var pending = new List<string>();
                var names = new List<string>();
                for (int index = 0; index < num; index++) {
                    var modTask = UrlLib.GetModInfoAsync(50, cfg.Configuration.Version,index);
                    var root = Directory.CreateDirectory(
                        $"{Directory.GetCurrentDirectory()}\\projects\\{cfg.Version}\\assets");

                    names = root.GetDirectories().Select(_ => _.Name).ToList();

                    foreach (var configuration in cfg.CustomConfigurations) {
                        if (!names.Contains(configuration.ProjectName)) {
                            names.Add(configuration.ProjectName);
                        }
                    }

                    var allM = await modTask;
                    var allN = allM.ToList().Select(_ => _.ShortWebsiteUrl).ToList();
                    all.AddRange(allN);

                    Log.Logger.Information($"该版本[assets]文件夹下含有 {names.Count} 个mod");


                    if (names.Count > cfg.Count) {
                        var bin = allM.Where(_ => !names.Contains(_.ShortWebsiteUrl));
                        var l = allM.ToList();
                        foreach (var info in bin) {
                            l.Remove(info);
                        }

                        allM = l.ToArray();
                    }
                    var l1 = parser.SerializeAll(allM).ToList();

                    //var parallelOption = new ParallelOptions {
                    //    MaxDegreeOfParallelism = 16
                    //};

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

                    var tasks = l1.Select(async _ => {
                        try {
                            await semaphore.WaitAsync();
                            await Utils.ParseModsAsync(_, cfg);
                        }
                        catch (Exception e) {
                            Log.Logger.Error(e.Message);
                        }
                        finally {
                            semaphore.Release();
                        }
                    });

                    await Task.WhenAll(tasks);

                }

                foreach (var str in names) {
                    if (!all.Contains(str)) {
                        pending.Add(str);
                    }
                }

                foreach (var name in pending) {
                    if (dict.ContainsKey(name)) {
                        var m = await UrlLib.GetModInfoAsync(dict[name]);
                        var i = parser.Serialize(m);
                        try {
                            var task = new Task(async () => {
                                try {
                                    await Utils.ParseModsAsync(i, cfg);
                                }
                                catch (Exception e) {
                                    Log.Logger.Error(e.Message);
                                }
                            });
                            task.Start();
                            //await Utils.ParseModsAsync(i,cfg);
                        }
                        catch (Exception e) {
                            Log.Logger.Error(e.Message);
                        }
                        Thread.Sleep(5000);
                    }
                }

                //var semaphore = new Semaphore(32, 40);
                //foreach (var l in l1) {
                //    try {
                //        semaphore.WaitOne();
                //        await Utils.ParseModsAsync(l,cfg);
                //    }
                //    catch (Exception e) {
                //        Log.Logger.Error(e.Message);
                //    }
                //    finally {
                //        semaphore.Release();
                //    }
                //}

            }
        }
    }
}
