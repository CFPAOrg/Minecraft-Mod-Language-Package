using System;
using System.IO;
using Renci.SshNet;

namespace Uploader
{
    static class Program
    {
        static void Main(string[] args)
        {
            var host = args[0];
            var name = args[1];
            var pwd = args[2];
            using var client = new ScpClient(host, 12356, name, pwd);
            client.Connect();
            if (client.IsConnected)
            {
                Console.WriteLine("服务器连接成功！");
            }
            else
            {
                Console.WriteLine("服务器连接失败！");
                return;
            }
            var fs = File.OpenRead("./Minecraft-Mod-Language-Package.zip");
            client.Upload(fs, "/var/www/html/files/Minecraft-Mod-Language-Modpack.zip");
            Console.WriteLine("上传成功");
            client.Disconnect();
        }
    }
}
