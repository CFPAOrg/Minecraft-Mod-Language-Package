using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Fucker
{
    public class Utils
    {
        public static void DelFiles(string path, string version)
        {
            var files = Directory.GetFiles(path + "project/" + version, "*.lang", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var name = Path.GetFileName(file);
                switch (name)
                {
                    case "zh_cn.lang":
                        break;
                    case "zh_CN.lang":
                        break;
                    case "en_us.lang":
                        break;
                    case "en_US.lang":
                        break;
                    default:
                        var random = new Random();
                        var newPath = path + "/rubbish/" + random.Next() + ".lang";
                        File.Move(file, newPath);
                        Console.WriteLine("将{0}移动到{1}", path, newPath);
                        break;
                }
            }
        }

        public static void SortFiles(string path, string version)
        {
            var files = Directory.GetFiles(path + "project/" + version, "*.lang", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var name = Path.GetFileName(file);
                if (name == "zh_cn.lang" || name == "zh_CN.lang")
                {
                    var directory = Path.GetDirectoryName(file);
                    if (File.Exists(directory + "/lang/en_us.lang"))
                    {

                    }
                    else if (File.Exists(directory + "/lang/en_US.lang"))
                    {
                        
                    }
                }
            }
        }
    }
}