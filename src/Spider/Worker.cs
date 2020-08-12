using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace Spider
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ModManager _modManager;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime hostApplicationLifetime, ModManager modManager)
        {
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
            _modManager = modManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(100);
            var gameVersion = Configuration.Current.EnabledGameVersions[0];
            await Configuration.InitializeConfigurationAsync("./config/spider.json");
            var addons = await _modManager.GetModInfoAsync(Configuration.Current.ModCount, gameVersion);
            var mods = new List<Mod>();
            foreach (var addon in addons)
            {
                var modFile = addon.GameVersionLatestFiles.First(_ => _.GameVersion == gameVersion);
                var downloadUrl = Utils.JoinDownloadUrl(modFile.ProjectFileId.ToString(), modFile.ProjectFileName);
                var mod = new Mod
                {
                    Name = addon.Name,
                    ProjectId = addon.Id,
                    ProjectUrl = addon.WebsiteUrl,
                    DownloadUrl = downloadUrl,
                    LastCheckUpdateTime = DateTimeOffset.Now,
                    LastUpdateTime = addon.DateModified
                };
                mods.Add(mod);
            }
            _logger.LogInformation($"从api获取了{mods.Count}个mod的信息.");
            mods = await _modManager.DownloadModAsync(mods);
            mods = await _modManager.GetModIdAsync(mods);
            _logger.LogInformation($"共有{mods.Count(_ => !string.IsNullOrEmpty(_.ModId))}个mod有modid.");
            await _modManager.SaveModInfoAsync(Configuration.Current.ModInfoPath, mods);
            _logger.LogInformation($"存储了所有 {mods.Count} 个mod信息到 {Path.GetFullPath(Configuration.Current.ModInfoPath)} ");
            _logger.LogInformation("Exiting application...");
            _hostApplicationLifetime.StopApplication();
        }
    }
}
