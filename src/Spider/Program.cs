using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spider
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

            var gameVersion = Configuration.Current.EnabledGameVersions[0];
            await Configuration.InitializeConfigurationAsync("./config/spider.json");
            var existingMods = new HashSet<Mod>();
            var mods = new HashSet<Mod>();
            var skipped = new HashSet<Mod>();
            try
            {
                var tempMods = JsonSerializer.Deserialize<List<Mod>>(await File.ReadAllBytesAsync(Configuration.Current.ModInfoPath));
                existingMods.UnionWith(tempMods ?? new List<Mod>());

            }
            catch (Exception e)
            {

                Log.Error(e, "");
            }
            var addons = await ModManager.GetModInfoAsync(Configuration.Current.ModCount + existingMods!.Count, gameVersion);


            foreach (var addon in addons)
            {
                var modFile = addon.GameVersionLatestFiles.First(_ => _.GameVersion == gameVersion);
                var downloadUrl = ModHelper.JoinDownloadUrl(modFile.ProjectFileId.ToString(), modFile.ProjectFileName);
                var mod = new Mod
                {
                    Name = addon.Name,
                    ProjectId = addon.Id,
                    ProjectUrl = addon.WebsiteUrl,
                    DownloadUrl = downloadUrl,
                    LastCheckUpdateTime = DateTimeOffset.Now,
                    LastUpdateTime = addon.DateModified
                };
                var old = existingMods.SingleOrDefault(_ => _.ProjectId == mod.ProjectId);
                if (!(old is null))
                {
                    if (old!.LastCheckUpdateTime >= mod.LastUpdateTime)
                    {
                        Log.Information($"跳过了已存在的mod: {mod.Name}");
                        skipped.Add(old);
                        continue;
                    }
                }
                mods.Add(mod);
            }
            Log.Information($"从api获取了{mods.Count}个mod的信息.");
            mods = (await ModManager.DownloadModAsync(mods)).ToHashSet();
            mods = mods.Select(_ =>
            {
                _.LangAssetsPaths = ModHelper.GetAssetPaths(_);
                _.AssetDomain = ModHelper.GetAssetDomain(_);
                return _;
            }).ToHashSet();
            mods = (await ModManager.GetModIdAsync(mods)).ToHashSet();
            Log.Information($"共有{mods.Count(_ => !string.IsNullOrEmpty(_.ModId))}个mod有modid.");
            mods.UnionWith(skipped);
            await ModHelper.SaveModInfoAsync(Configuration.Current.ModInfoPath, mods);
            Log.Information($"存储了所有 {mods.Count} 个mod信息到 {Path.GetFullPath(Configuration.Current.ModInfoPath)} ");
            Log.Information("Exiting application...");
        }

        
    }
}
