using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Serilog;
using Spider.Models;

namespace Spider.Types
{
    internal static class LangManager
    {
        public static void ProcessLangFiles(IEnumerable<Mod> mods)
        {
            var sw1 = Stopwatch.StartNew();
            var collection1 = mods.Where(_ => !_.IsInBlackList).ToList();
            var collection2 = collection1.SelectMany(_ => _.Languages).ToList();
            var assetDomainBlackList = Configuration.AssetDomainBlackList;
            collection2.ForEach(_ =>
            {
                var assetDomain = _.AssetDomain;
                if (assetDomain == null) return;

                if (assetDomainBlackList.Contains(assetDomain))
                {
                    Log.Information($"跳过了黑名单中的assetdomain:{assetDomain}.");
                    _.IsInBlackList = true;
                }
            });
        }
    }
}