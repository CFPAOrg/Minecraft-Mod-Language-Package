using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Spider
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ModManager _modManager;

        public Worker(ILogger<Worker> logger,ModManager modManager)
        {
            _logger = logger;
            _modManager = modManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var modInfo = await _modManager.GetModInfoAsync(10, "1.12.2");

            await StopAsync(CancellationToken.None);
        }

        
    }
}
