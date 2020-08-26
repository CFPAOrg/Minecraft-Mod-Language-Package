using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Serilog;

namespace Processor
{
    public static class Format
    {
        public static async Task FormatLangFile(List<string> lp)
        {
            foreach (var l in lp)
            {
                var keyReg = new Regex(".+(?==)");
                var nameReg = new Regex("(?<==).+");
                var findEqual = new Regex("=+");
                var commentReg = new Regex("#+");
                var ls = new List<string>();
                foreach (string str in await File.ReadAllLinesAsync(l, Encoding.UTF8))
                {
                    if (str == "")
                    {
                        ls.Add(str);
                        Log.Debug("添加空行");
                    }
                    if (commentReg.IsMatch(str))
                    {
                        ls.Add(str);
                        Log.Debug("添加规范注释");
                    }
                    if (findEqual.IsMatch(str))
                    {
                        if (keyReg.IsMatch(str))
                        {
                            if (nameReg.IsMatch(str))
                            {
                                if (!ls.Contains(str))
                                {
                                    ls.Add(str);
                                    Log.Debug("添加条目:{0}", str);
                                }
                            }
                        }
                    }
                }
                await File.WriteAllLinesAsync(l, ls);
                Log.Information("{0}检查完成", l);
            }
        }

        public static async Task CrateEmptyLangFile(Configuration configuration)
        {
            var root = new DirectoryInfo(Path.Combine(configuration.CustomSittings.ProjectsFolder, configuration.VersionList[0], "assets"));
            var dt1 = root.GetDirectories();//顶层project name
            foreach (var info in dt1)
            {
                var dt2 = info.GetDirectories();//domain
                foreach (var directoryInfo in dt2)
                {
                    try
                    {
                        var lf = Directory.EnumerateFiles(Path.Combine(directoryInfo.FullName, "lang"));
                        if (lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_us.lang")) || lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_US.lang")))
                        {
                            if (!(lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.lang")) || lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_CN.lang"))))
                            {
                                var pa = lf.FirstOrDefault(_ => _.ToLower().Contains("en_us.lang"));
                                var isParse = false;
                                foreach (string str in await File.ReadAllLinesAsync(pa, Encoding.UTF8))
                                {
                                    if (str == "#PARSE_ESCAPES")
                                    {
                                        isParse = true;
                                        break;
                                    }
                                }

                                if (isParse)
                                {
                                    await File.WriteAllTextAsync(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.lang"), "#PARSE_ESCAPES\n\n");
                                    Log.Logger.Information($"为{directoryInfo.Name}新建带#PARSE_ESCAPES的文件");
                                }
                                else
                                {
                                    await File.WriteAllTextAsync(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.lang"), "\n");
                                    Log.Logger.Information($"为{directoryInfo.Name}新建空文件");
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Logger.Error(e.Message);
                    }
                }
            }
        }

        public static async Task CrateEmptyJsonFile(Configuration configuration)
        {
            var root = new DirectoryInfo(Path.Combine(configuration.CustomSittings.ProjectsFolder, configuration.VersionList[0], "assets"));
            var dt1 = root.GetDirectories();//顶层project name
            foreach (var info in dt1)
            {
                var dt2 = info.GetDirectories();//domain
                foreach (var directoryInfo in dt2)
                {
                    try
                    {
                        var lf = Directory.EnumerateFiles(Path.Combine(directoryInfo.FullName, "lang"));
                        if (lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_us.json")) || lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "en_US.json")))
                        {
                            if (!(lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.json")) || lf.Contains(Path.Combine(directoryInfo.FullName, "lang", "zh_CN.json"))))
                            {
                                await File.WriteAllTextAsync(Path.Combine(directoryInfo.FullName, "lang", "zh_cn.json"), "{}");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Logger.Error(e.Message);
                    }
                }
            }
        }
    }
}