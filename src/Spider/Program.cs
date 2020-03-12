using Serilog;
using Spider.Types;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spider
{
    internal static class Program
    {
        private static async Task Main()
        {
            Directory.CreateDirectory(Configuration.OutputPath);
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var mods = (await ApiManager.GetModsAsync()).ToList();
            await ModDownloadManager.DownloadModsAsync(mods);
            LangManager.ProcessLangFiles(mods);
            var languages = mods.SelectMany(_ => _.Languages).Where(_ => !_.IsInBlackList).ToList();
            Log.Information($"共收集到了{languages.Count}个语言文件.");
            foreach (var language in languages)
            {
                string path;
                try
                {
                    _ = languages.Single(_ => _.AssetDomain == language.AssetDomain);
                    path = $"assets/{language.AssetDomain}/lang/";
                }
                catch
                {
                    path = $"assets/{language.AssetDomain}-{language.BaseMod.ShortUrl}/lang/";
                }

                var directoryInfo = Directory.CreateDirectory(Path.Combine(Configuration.OutputPath, path));
                if (!directoryInfo.EnumerateFiles().Any(_=>_.Name.EndsWith("zh_cn.lang")))
                {
                    File.Create(Path.Combine(Configuration.OutputPath, path, "zh_cn.lang")).Dispose();
                }
                var fullPath = Path.Combine(Configuration.OutputPath, path, "en_us.lang");
                File.WriteAllText(fullPath, language.OutPutText);
                Log.Information($"写入了一个语言文件到: {fullPath}");
            }

            foreach (var mod in mods)
            {
                mod.Dispose();
            }
            RepositoryManager.PushToGithub();
            Log.CloseAndFlush();
        }
    }
}