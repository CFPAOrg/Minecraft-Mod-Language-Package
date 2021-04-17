using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

using Renci.SshNet;

using Serilog;

namespace Uploader {
    static class Program {
        static int Main(string[] args) {
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

            command.Handler = CommandHandler.Create<string,string,string,string>((version, host, name, pwd) => {
                using var scpClient = new ScpClient(host, 20002, name, pwd);
                scpClient.Connect();
                if (scpClient.IsConnected) {
                    Log.Logger.Information("SCP服务器连接成功");
                }
                else {
                    Log.Logger.Error("SCP服务器连接失败");
                    return;
                }

                var md5s = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.md5");
                md5s.ToList().ForEach(_ => { scpClient.Upload(File.OpenRead(_), $"/var/www/html/files/{Path.GetFileName(_)}"); });
                var fs = File.OpenRead("./Minecraft-Mod-Language-Package.zip");
                scpClient.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack.zip.1");
                Log.Logger.Information("上传成功");
                scpClient.Dispose();
                using var sshClient = new SshClient(host, 20002, name, pwd);
                sshClient.Connect();
                if (sshClient.IsConnected) {
                    Log.Logger.Information("SSH服务器连接成功");
                }
                else {
                    Log.Logger.Error("SSH服务器连接失败");
                    return;
                }
                using var cmd = sshClient.CreateCommand("mv /var/www/html/files/Minecraft-Mod-Language-Modpack.zip.1 /var/www/html/files/Minecraft-Mod-Language-Modpack.zip");
                cmd.Execute();
                var err = cmd.Error;
                Log.Logger.Error(err);
                sshClient.Dispose();
            });

            return command.Invoke(args);
        }
    }
}
