using System;
using System.ComponentModel.DataAnnotations;
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
            using var scpClient = new ScpClient(host, 12356, name, pwd);
            scpClient.Connect();
            if (scpClient.IsConnected)
            {
                Log.Logger.Information("SCP服务器连接成功");
            }
            else
            {
                Log.Logger.Error("SCP服务器连接失败");
                return;
            }
            var fs = File.OpenRead("./Minecraft-Mod-Language-Package.zip");
            scpClient.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack.zip.1");
            Log.Logger.Information("上传成功");
            scpClient.Disconnect();
            using var sshClient = new SshClient(host, 12356, name, pwd);
            sshClient.Connect();
            if (scpClient.IsConnected)
            {
                Log.Logger.Information("SSH服务器连接成功");
            }
            else
            {
                Log.Logger.Error("SSH服务器连接失败");
                return;
            }
            using var cmd = sshClient.CreateCommand("mv /var/www/html/files/Minecraft-Mod-Language-Modpack.zip.1 /var/www/html/files/Minecraft-Mod-Language-Modpack.zip");
            var err = cmd.Error;
            var output = cmd.Result;
            Log.Logger.Information(output);
            Log.Logger.Error(err);
            sshClient.Disconnect();
        }
    }
}
