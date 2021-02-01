using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Serilog;

namespace Language.Core {
    public class LanguageConvert {
        public static List<string> Deserialize(FileStream fileStream) {
            var lr = new LangReader(fileStream);
            //var keyReg = new Regex(".+(?==)");
            //var valueReg = new Regex("(?<==).+");
            //var equalReg = new Regex("=+");
            var list = new List<string>();
            var builder = new StringBuilder();
            while (!lr.StreamReader.EndOfStream) {
                var nextChar = (char)lr.Peek();
                switch (nextChar) {
                    case '#':
                        list.Add(lr.ReadLine() ?? "");
                        break;
                    case '/':
                        lr.Read();
                        var nextC = (char) lr.Read();
                        switch (nextC) {
                            case '/':
                                list.Add("#"+lr.ReadLine());
                                break;
                            case '*':
                                lr.SeekToPreviousLineEnd();
                                while (true) {
                                    var current = (char) lr.Read();
                                    var next = (char) lr.Peek();
                                    if ((char)lr.Read() == '*'&&(char)lr.Peek() == '/') {
                                        list.Add(builder.ToString()+"*/");
                                        builder.Clear();
                                        break;
                                    }
                                    builder.Append(lr.Read());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        builder.Append(lr.Read());
                        break;
                }
            }
            return null;
        }
    }
}
