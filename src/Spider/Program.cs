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
                var modTask = UrlLib.GetModInfoAsync(cfg.Count, cfg.Configuration.Version);
                var root = Directory.CreateDirectory(
                    $"{Directory.GetCurrentDirectory()}\\projects\\{cfg.Version}\\assets");

                var names = root.GetDirectories().Select(_ => _.Name).ToList();

                foreach (var configuration in cfg.CustomConfigurations) {
                    if (!names.Contains(configuration.ProjectName)) {
                        names.Add(configuration.ProjectName);
                    }
                }

                var allM = await modTask;
                var allN = allM.ToList().Select(_ => _.ShortWebsiteUrl).ToList();
                var pending = new List<string>();
                foreach (var info in names) {
                    if (!allN.Contains(info)) {
                        pending.Add(info);
                    }
                }

                Log.Logger.Information($"该版本[assets]文件夹下含有 {names.Count} 个mod，{pending.Count} 个mod需要单独处理");

                var dict = await JsonReader.ReadIntroAsync(cfg.Configuration.Version,cfg.Version);

                if (names.Count > cfg.Count) {
                    var bin = allM.Where(_ => !names.Contains(_.ShortWebsiteUrl));
                    var l = allM.ToList();
                    foreach (var info in bin) {
                        l.Remove(info);
                    }

                    allM = l.ToArray();
                }
                parser.Infos = allM.ToList();
                var l1 = parser.SerializeAll().ToList();

                //var parallelOption = new ParallelOptions {
                //    MaxDegreeOfParallelism = 16
                //};

                var semaphore = new SemaphoreSlim(16,16);
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
            }
        }
    }
}
