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
        static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            var command = new RootCommand() {
                new Option<string>(
                    "--version",
                    getDefaultValue: (() => "1.12.2"),
                    description: "Set upload version."),
                new Option<string>(
                    "--host",
                    getDefaultValue:(() => ""),
                    description:"Set the host."),
                new Option<string>(
                    "--name",
                    description:"Set user name."),
                new Option<string>(
                    "--password",
                    description:"Set password.")
            };

            command.Description = "Config of uploader";

            command.Handler = CommandHandler.Create<string, string, string, string>((version, host, name, password) =>
            {
                using var scpClient = new ScpClient(host, 20002, name, password);
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

                var md5s = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.md5");
                md5s.ToList().ForEach(_ => { scpClient.Upload(File.OpenRead(_), $"/var/www/html/files/{Path.GetFileName(_)}"); });
                var fs = File.OpenRead($"./Minecraft-Mod-Language-Package-{version}.zip");
                switch (version)
                {
                    case "1.12.2":
                        scpClient.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack.zip.1");
                        break;
                    case "1.16":
                        scpClient.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack-1-16.zip.1");
                        break;
                    case "1.16-fabric":
                        scpClient.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack-1-16-Fabric.zip.1");
                        break;
                    case "1.18":
                        scpClient.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack-1-18.zip.1");
                        break;
                    case "1.18-fabric":
                        scpClient.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack-1-18-Fabric.zip.1");
                        break;
                    default:
                        break;//不应该
                }
                Log.Logger.Information("上传成功");
                scpClient.Dispose();
                using var sshClient = new SshClient(host, 20002, name, password);
                sshClient.Connect();
                if (sshClient.IsConnected)
                {
                    Log.Logger.Information("SSH服务器连接成功");
                }
                else
                {
                    Log.Logger.Error("SSH服务器连接失败");
                    return;
                }
                switch (version)
                {
                    case "1.12.2":
                        var cmd1 = sshClient.CreateCommand("mv /var/www/html/files/Minecraft-Mod-Language-Modpack.zip.1 /var/www/html/files/Minecraft-Mod-Language-Modpack.zip");
                        cmd1.Execute();
                        var err1 = cmd1.Error;
                        Log.Logger.Error(err1);
                        break;
                    case "1.16":
                        var cmd2 = sshClient.CreateCommand("mv /var/www/html/files/Minecraft-Mod-Language-Modpack-1-16.zip.1 /var/www/html/files/Minecraft-Mod-Language-Modpack-1-16.zip");
                        cmd2.Execute();
                        var err2 = cmd2.Error;
                        Log.Logger.Error(err2);
                        break;
                    case "1.16-fabric":
                        var cmd2 = sshClient.CreateCommand("mv /var/www/html/files/Minecraft-Mod-Language-Modpack-1-16-Fabric.zip.1 /var/www/html/files/Minecraft-Mod-Language-Modpack-1-16-Fabric.zip");
                        cmd2.Execute();
                        var err2 = cmd2.Error;
                        Log.Logger.Error(err2);
                        break;
                    case "1.18":
                        var cmd3 = sshClient.CreateCommand("mv /var/www/html/files/Minecraft-Mod-Language-Modpack-1-18.zip.1 /var/www/html/files/Minecraft-Mod-Language-Modpack-1-18.zip");
                        cmd3.Execute();
                        var err3 = cmd3.Error;
                        Log.Logger.Error(err3);
                        break;
                    case "1.18-fabric":
                        var cmd3 = sshClient.CreateCommand("mv /var/www/html/files/Minecraft-Mod-Language-Modpack-1-18-Fabric.zip.1 /var/www/html/files/Minecraft-Mod-Language-Modpack-1-18-Fabric.zip");
                        cmd3.Execute();
                        var err3 = cmd3.Error;
                        Log.Logger.Error(err3);
                        break;
                    default:
                        break;//不应该
                }
                sshClient.Dispose();
            });

            return command.Invoke(args);
        }
    }
}
