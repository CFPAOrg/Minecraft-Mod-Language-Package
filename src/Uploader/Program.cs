using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

            using var scpClient = new ScpClient(host, port: 20002, name, password);
            scpClient.Connect(); // 与下载服务器建立连接
            
            // 确认连接状态
            if (scpClient.IsConnected)
            {
                Log.Information("SCP服务器连接成功");
            }
            else
            {
                Log.Error("SCP服务器连接失败");
                return -1;
            }

            // 获取可用的资源包，准备上传
            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var packList = currentDirectory
                           .EnumerateFiles("Minecraft-Mod-Language-Package-*.zip");

            packList.ToList()
                    .ForEach(_ =>
                    {
                        using var stream = _.OpenRead();
                        var md5 = stream.ComputeMD5();

                        // 文件名格式：Minecraft-Mod-Language-ModPack-[version]-[md5-hash].zip
                        // hash的对象是文件内容，不包括文件名（当然）
                        // hash应该是全大写
                        var fileName = _.Name;
                        var tweakedName = fileName.Insert(fileName.LastIndexOf('.'), "-" + md5)
                                                  .Replace("Package", "ModPack"); // 历史遗留问题
                        scpClient.Upload(_.OpenRead(), $"/var/www/html/files/{tweakedName}");
                        Log.Information("向远程服务器写入文件：{0}", tweakedName);
                    });

            return 0;
        }

        /// <summary>
        /// 计算给定流中全体内容的MD5值。
        /// </summary>
        /// <param name="stream">被计算的流</param>
        /// <returns></returns>
        public static string ComputeMD5(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin); // 确保文件流的位置被重置
            return Convert.ToHexString(MD5.Create().ComputeHash(stream));
        }
    }
}
