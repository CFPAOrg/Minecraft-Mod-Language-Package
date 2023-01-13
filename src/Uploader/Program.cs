using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

using Renci.SshNet;

using Serilog;

namespace Uploader
{
    static class Program
    {
        static int Main(string host, string name, string password)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            using var scpClient = new ScpClient(host, 20002, name, password);
            scpClient.Connect(); // 与下载服务器建立连接

            if (scpClient.IsConnected)
            {
                Log.Information("SCP服务器连接成功");
            }
            else
            {
                Log.Error("SCP服务器连接失败");
                return -1;
            }

            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var md5List = currentDirectory
                          .EnumerateFiles("*.md5",
                                          SearchOption.TopDirectoryOnly);
            var packList = currentDirectory
                           .EnumerateFiles("Mincreaft-Mod-Language-Package-*.zip",
                                           SearchOption.TopDirectoryOnly);

            var timestamp = DateTime.Now.Ticks;

            md5List.ToList()
                   .ForEach(_ =>
                   {
                       var fileName = _.Name;
                       var tweakedName = fileName.Insert(fileName.LastIndexOf('.') - 1, timestamp.ToString());
                       scpClient.Upload(_.OpenRead(),$"/var/www/html/files/{tweakedName}");
                   });

            packList.ToList()
                   .ForEach(_ =>
                   {
                       var fileName = _.Name;
                       var tweakedName = fileName.Insert(fileName.LastIndexOf('.') - 1, timestamp.ToString())
                                                 .Replace("Package", "ModPack"); // 历史遗留问题
                       scpClient.Upload(_.OpenRead(), $"/var/www/html/files/{tweakedName}");
                   });

            return 0;
        }
    }
}
