using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Spider.Data;
using Spider.Models;
using Spider.Types;

namespace Spider
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var task1 = ModInfoManager.DownloadModInfosAsync();
            task1.Wait();
            var task2 = ModDownloadManager.DownloadMods();
            task2.Wait();
            var task3 = Task.Run(RepositoryManager.PushToGitHub);
            task3.Wait();
            DataStore.Database.Dispose();// 关闭数据库
            sw.Stop();
            Console.WriteLine($"所有任务在{sw.ElapsedMilliseconds}内完成");
        }
    }
}