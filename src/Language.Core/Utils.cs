using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Language.Core
{
    public static class Utils
    {
        private static List<string> ReadBlackKey()
        {
            var res = new List<string>();
            foreach (string str in File.ReadAllLines($"{Directory.GetCurrentDirectory()}/config/blackkey.txt", Encoding.UTF8))
            {
                res.Add(str);
            }

            return res;
        }

        public static void DeleteBlackKeys(string path)
        {
            var bl = ReadBlackKey();
            var keyReg = new Regex(".+(?==)");
            var nameReg = new Regex("(?<==).+");
            var findEqual = new Regex("=+");
            var commentReg = new Regex("#+");
            var ls = new List<string>();
            foreach (string str in File.ReadAllLines(path))
            {
                if (findEqual.IsMatch(str))
                {
                    if (keyReg.IsMatch(str))
                    {
                        if (bl.Contains(keyReg.Match(str).ToString()))
                        {
                            continue;
                        }

                        ls.Add(str);
                    }
                    else
                    {
                        ls.Add(str);
                    }
                }
                else
                {
                    ls.Add(str);
                }
            }

            File.WriteAllLines(path, ls);
        }
    }
}