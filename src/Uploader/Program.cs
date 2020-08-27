using System;
using System.IO;
using Renci.SshNet;
using Serilog;

namespace Uploader
{
    static class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var host = args[0];
            var name = args[1];
            var pwd = args[2];
            using var client = new ScpClient(host, 22, name, pwd);
            client.Connect();
            if (client.IsConnected)
            {
                Log.Logger.Information("服务器连接成功！");
            }
            else
            {
                Log.Logger.Error("服务器连接失败！");
            }
            var fs = File.OpenRead("./Minecraft-Mod-Language-Package.zip");
            client.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack.zip");
            client.Disconnect();
        }
    }
}
