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
            
            Log.Information("检测到的资源包数目：{0}", packList.Count());

            packList.ToList()
                    .ForEach(_ =>
                    {
                        using var stream = _.OpenRead();
                        var md5 = stream.ComputeMD5();

                        // 文件名格式：Minecraft-Mod-Language-Modpack-[dashed-version]-[md5-hash].zip
                        // 如：Minecraft-Mod-Language-Modpack-1-16-Fabric-0000000000000000.zip
                        // hash的对象是文件内容，不包括文件名（当然）
                        // hash应该是全大写

                        var fileExtensionName = _.Extension; // 带点名称，应当为 ".zip"
                        var fileName = _.Name[0..^fileExtensionName.Length]
                                        .RegulateFileName(); // 无后缀的文件名，应当已修正

                        // 选择性地加上该文件的md5值，以便生成patch
                        var tweakedName = fileName + "-" + md5;

                        var destinationName = $"/var/www/html/files/{fileName + fileExtensionName}";
                        var tweakedDestinationName = $"/var/www/html/files/{tweakedName + fileExtensionName}";

                        // 传递不带md5值的最新版本；会覆写已有文件
                        scpClient.Upload(_.OpenRead(), destinationName);
                        Log.Information("向远程服务器写入文件：{0}", destinationName);

                        //// 传递带md5值的历史版本，一般不会覆写已有文件
                        //scpClient.Upload(_.OpenRead(), tweakedDestinationName);
                        //Log.Information("向远程服务器写入文件：{0}", tweakedDestinationName);
                    });

            // 临时操作 在使用旧md5校验的程序弃用以后需要删除
            var md5List = currentDirectory
                          .EnumerateFiles("*.md5");
            md5List.ToList()
                   .ForEach(_ =>
            {
                scpClient.Upload(_.OpenRead(), $"/var/www/html/files/{_.Name}");
                Log.Information("向远程服务器写入文件：{0}", $"/var/www/html/files/{_.Name}");
            });

            Log.Information("资源包传递完毕");
            return 0;
        }

        public static string RegulateFileName(this string fileName)
        {
            // 历史遗留问题：全部单词都要大小写
            return CapitalizeGroup(fileName.Replace("Package", "Modpack") // 历史遗留问题：文件名
                                          .Replace('.', '-') // 历史遗留问题：版本号需要输杠
                                          .Replace("-1-12-2", "") // 历史遗留问题：1.12.2文件没有版本号
                                          .Split('-'));

            // 将一组字符串的各项大小写，用'-'连接
            string CapitalizeGroup(string[] texts) => string.Join('-', texts.Select(_ => Capitalize(_)));

            // 将一段文本的首字母大写，其余不动
            string Capitalize(string text) => string.Join("",
                                                          text[0..1].ToUpper(),
                                                          text[1..]);
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
