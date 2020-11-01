using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LangPack.Core;

namespace Spider
{
    public class Program
    {
        public static async Task Main()
        {
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

            var gameVersion = Configuration.Default.EnabledGameVersions[0];
            var existingMods = new HashSet<Mod>();
            var mods = new HashSet<Mod>();
            var skipped = new HashSet<Mod>();
            //try
            //{
            //    var tempMods = JsonSerializer.Deserialize<List<Mod>>(await File.ReadAllBytesAsync(Configuration.Default.ModInfoPath));
            //    existingMods.UnionWith(tempMods ?? new List<Mod>());
            //}
            //catch (Exception e)
            //{
            //    Log.Error(e, "");
            //    throw;
            //}
            var addons = await ModHelper.GetModInfoAsync(Configuration.Default.ModCount + existingMods!.Count, gameVersion);


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
                    ShortProjectUrl = ModHelper.GetShortUrl(addon.WebsiteUrl),
                    LastCheckUpdateTime = DateTimeOffset.Now,
                    LastUpdateTime = addon.DateModified
                };
                //var old = existingMods.SingleOrDefault(_ => _.ProjectId == mod.ProjectId);
                //if (!(old is null))
                //{
                //    if (old!.LastCheckUpdateTime >= mod.LastUpdateTime)
                //    {
                //        Log.Information($"跳过了已存在的mod: {mod.Name}");
                //        skipped.Add(old);
                //        continue;
                //    }
                //}
                mods.Add(mod);
            }
            Log.Information($"从api获取了{mods.Count}个mod的信息.");
            mods = (await ModHelper.DownloadModAsync(mods)).ToHashSet();
            mods = mods.Select(_ =>
            {
                _.LangAssetsPaths = ModHelper.GetAssetPaths(_);
                _.AssetDomains = ModHelper.GetAssetDomains(_);
                return _;
            }).ToHashSet();
            Log.Information($"共有{mods.Count(_ => !string.IsNullOrEmpty(_.ModId))}个mod有modid.");
            //mods.UnionWith(skipped);
            await ModHelper.SaveModInfoAsync(Configuration.Default.ModInfoPath, mods);
            Log.Information($"存储了所有 {mods.Count} 个mod信息到 {Path.GetFullPath(Configuration.Default.ModInfoPath)} ");
            Log.Information("Exiting application...");
        }


    }
}
