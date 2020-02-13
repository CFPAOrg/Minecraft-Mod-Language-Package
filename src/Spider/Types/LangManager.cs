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
            var collection = mods.Where(_ => !_.IsInBlackList).SelectMany(_ => _.Languages).ToList();
            var assetDomainBlackList = Configuration.AssetDomainBlackList;
            collection.ForEach(_ =>
            {
                var assetDomain = _.AssetDomain;
                if (assetDomain == null) return;

                if (assetDomainBlackList.Contains(assetDomain))
                {
                    Log.Information($"跳过了黑名单中的assetdomain:{assetDomain}.");
                    _.IsInBlackList = true;
                }
            });
            Log.Information($"语言文件已全部处理完毕,共有{collection.Count}个语言文件被处理，其中有{collection.Count(_=>_.IsInBlackList)}文件在黑名单中");
        }
    }
}