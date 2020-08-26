using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Serilog;

namespace Processor
{
    public class Format
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
    }
}