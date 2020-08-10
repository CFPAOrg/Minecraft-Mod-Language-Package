using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Spider.Properties;

namespace Spider
{
    public class ModManager
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ModManager(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Addon>> GetModInfoAsync(int modCount, string gameVersion)
        {
            var httpClinet = _httpClientFactory.CreateClient();
            var uriBuilder = new UriBuilder("https://addons-ecs.forgesvc.net/api/v2/addon/search");
            uriBuilder.Query =
                $"categoryId=0&gameId=432&index=0&pageSize={modCount}&gameVersion={gameVersion}&sectionId=6&sort=1";
            var uri = uriBuilder.Uri;
            return await httpClinet.GetFromJsonAsync<List<Addon>>(uri);
        }

        public async Task<List<Mod>> DownloadModAsync(IEnumerable<Mod> mods)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var tasks = mods.Select(async _ =>
            {
                var bytes = await httpClient.GetByteArrayAsync(_.DownloadUrl);
                var oldPath = Path.GetTempFileName();
                var newPath = Path.ChangeExtension(oldPath, Path.GetExtension(_.DownloadUrl));
                File.Move(oldPath, newPath);
                await File.WriteAllBytesAsync(newPath, bytes);
                _.Path = newPath;
                _logger.LogInformation($"下载了 {_.DownloadUrl} 到{_.Path}!");
                return _;
            });
            var result = await Task.WhenAll(tasks);
            return result.ToList();
        }

        public async Task<List<Mod>> GetModIdAsync(IEnumerable<Mod> mods)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(0,10);
            File.WriteAllBytes("./cfr.jar", Resources.cfr_0_150);
            var regex = new Regex("(?<=modid=\").*?(?=\")");
            var result = mods.Select(_ =>
            {
                return Task.Run(async () =>
                {
                    await semaphore.WaitAsync();
                    _logger.LogInformation($"开始对 {_.Path} 进行反编译以获得modid.");
                    var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = "java",
                            Arguments = $"-jar ./cfr.jar {_.Path}",
                            RedirectStandardOutput = true,
                            UseShellExecute = false
                        }
                    };
                    process.Start();
                    var modid = string.Empty;
                    while (!process.StandardOutput.EndOfStream)
                    {
                        var line = process.StandardOutput.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (regex.IsMatch(line))
                            {
                                modid = regex.Match(line).Value;
                                break;
                            }
                        }
                    }

                    _logger.LogCritical($"找到了modid: {modid}");
                    _.ModId = modid;
                    semaphore.Release(1);
                    return _;
                });
            });

            return (await Task.WhenAll(result)).ToList();

        public void ProcessLangFile(IEnumerable<Mod> mods) // 暂时没找到把他 async 的办法
        {
            mods.ToList().ForEach(_ =>
            {
                using var file = File.Open(_.Path, FileMode.Open);
                var keys = new List<string>();
                var values = new List<string>();
                var builder = new StringBuilder();
                using (var reader = new StreamReader(file, Encoding.UTF8))
                {
                    var iskey = false;
                    var isOverlap = false;
                    while (!reader.EndOfStream)
                    {
                        // 暂时先不处理PARSE_ESCAPE
                        var currentChar = reader.Read();
                        switch (currentChar)
                        {
                            case '\n': // 新行
                                if(iskey)
                                { // 空行？
                                    var current = builder.ToString();
                                    if(!string.IsNullOrWhiteSpace(current)) // 如果确实是空行，什么都不用做，让reader接着往下读
                                    { // 不是空行，算作非法注释，删掉
                                        _logger.LogInformation("删除一条非法注释：{0}", current);
                                    }
                                }
                                else
                                {
                                    if (!isOverlap)
                                    {
                                        addAndValidateValue(builder.ToString(), ref values, ref keys, ref iskey) ;
                                        builder.Clear();
                                    }
                                }
                                break;
                            case '#':
                                reader.ReadLine(); // 直接读到本行的末尾，因为这种 comment 是单行的；丢弃读取结果
                                isOverlap = false;
                                break;
                            case '/':
                                // 需要注意是 //还是/*还是其他
                                var nextChar = reader.Read();
                                switch (nextChar)
                                {
                                    case '/':
                                        reader.ReadLine(); // //注释，单行，丢弃
                                        isOverlap = false;
                                        break;
                                    case '*':
                                        // 多行注释，需要一些处理，可能可读性不是很好
                                        while (true)
                                        {
                                            if (reader.Read() == '*') // 发现了 *，需要考虑是否是 */（结束注释）
                                            {
                                                if (reader.Read() == '/')
                                                {
                                                    break; // 结束注释，跳出循环
                                                }
                                            } // 仍然在注释里，接着循环
                                        }
                                        // 后面会剩一点空格/换行符，跳过一下
                                        reader.ReadLine();
                                        break;
                                    case '\n': // 是的，还要再来一次
                                        if(iskey)
                                        { // 空行？
                                            var current = builder.ToString();
                                            if(!string.IsNullOrWhiteSpace(current)) // 如果确实是空行，什么都不用做，让reader接着往下读
                                            { // 不是空行，算作非法注释，删掉
                                                _logger.LogInformation("删除一条非法注释：{0}", current);
                                            }
                                        }
                                        else
                                        {
                                            if (!isOverlap)
                                            {
                                                addAndValidateValue(builder.ToString(), ref values, ref keys, ref iskey) ;
                                                builder.Clear();
                                            }
                                        }
                                        break;
                                    default: // 不是 comment
                                        builder.Append(currentChar);
                                        builder.Append(nextChar);
                                        break;
                                }
                                break;
                            case '=': // 分隔key与value
                                if (iskey)
                                {
                                    var key = builder.ToString();
                                    if (keys.Contains(key))
                                    { // 重key，跳过value
                                        _logger.LogInformation("移除一处重key。key:{0}", key);
                                        reader.ReadLine(); // 终于可以直接跳过了
                                    }
                                    else
                                    {
                                        keys.Add(key);
                                    }
                                    iskey = false;
                                    builder.Clear();
                                }
                                else // 等号在 value 里，记得接着加
                                {
                                    builder.Append(currentChar);
                                }
                                break;
                            default:
                                builder.Append(currentChar);
                                break;
                        }
                    }
                    // 事后检查：是否还有什么没读完的？
                    if (!iskey) // 不是 key，也就是 value 读取未结束，有可能是文件末尾没有换行
                    {
                        addAndValidateValue(builder.ToString(), ref values, ref keys, ref iskey); // 事实上 iskey 可以不用了...
                    }
                }
                Debug.Assert(keys.Count == values.Count); // value 和 key 理应一一对应
                using var writer = new StreamWriter(file);
                for(int i = 0; i < keys.Count; ++i)
                {
                    writer.WriteLine($"{keys[i]}={values[i]}"); // 写入文件
                }
            });

            // 下方是提取出来的一个高度重复的代码片段
            void addAndValidateValue(string value, ref List<string> values, ref List<string> keys, ref bool iskey)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _logger.LogInformation("移除一处空词条。key:{0}", keys[^1]);
                    keys.RemoveAt(keys.Count() - 1); // 为什么 RemoveAt 没有输入 Index 的重载...
                }
                else
                {
                    values.Add(value);
                }
                iskey = true; // 读完value了，下一个就确实是 key
            }
        }
    }
}
