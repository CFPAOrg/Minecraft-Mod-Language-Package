using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Serilog;
using Packer.Models;

namespace Packer.Extensions
{
    
    public static class ContentExtension
    {
        public static string Preprocess(this string content, FileCategory category, Config config)
        {
            // 特殊符号（元素名称等）替换
            foreach (var mapping in config.CharatcerReplacement)
            {
                if (content.Contains(mapping.Key))
                {
                    Log.Information("正在进行特殊符号替换：{0} -> {1}", mapping.Key, mapping.Value);
                }
                if((category & FileCategory.JsonAlike) == FileCategory.JsonAlike)
                { // 替换为 unicode 转义码
                    content = content.Replace(mapping.Key, mapping.Value);
                }
                else
                { // 替换为 unicode 字符
                    content = content.Replace(mapping.Key, Regex.Unescape(mapping.Value));
                }

            }
            return content;
        }

        public static bool NeedBypass(this string location, Config config)
        {
            foreach (var @namespace in config.BypassedNamespace)
            {
                Log.Information("{0}|{1}", location, @namespace);
                if (location.Contains(@namespace + "/")) return true;
            }
            return false;
        }
    }
}
