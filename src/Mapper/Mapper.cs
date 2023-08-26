using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mapper
{
    public static class SlugToDomainMapper
    {
        public static List<(string gameVersionDirectory, Dictionary<string, string> dictionary)> Run()
        {
            var list = new List<(string gameVersionDirectory, Dictionary<string, string> dictionary)>();
            foreach (var gameVersionDir in Directory.GetDirectories("projects/").Select(Path.GetFullPath).Where(x => !x.Contains(".placeholder")))
            {
                var dic = new Dictionary<string, string>();
                foreach (var slugDir in Directory.GetDirectories(gameVersionDir + "/assets"))
                {
                    var max = Directory.GetDirectories(slugDir).MaxBy(x => DirSize(x));
                    dic.Add(Path.GetFileName(slugDir)!, Path.GetFileName(max)!);
                }

                long DirSize(string folder)
                {
                    long size = 0;
                    DirectoryInfo dir = new DirectoryInfo(folder);
                    foreach (FileInfo fi in dir.GetFiles("*.*", SearchOption.AllDirectories))
                    {
                        if (fi.Length > 10 && fi.Name == "zh_cn.json") size += 10000000;
                        
                        size += fi.Length;
                    }

                    return size;
                }
                list.Add((Path.GetFileName(gameVersionDir)!, dic));
            }

            return list;
        }

        public static void Main()
        {
            Environment.CurrentDirectory = "C:\\Users\\cyl18\\Documents\\GitHub\\Minecraft-Mod-Language-Package-CFPA";
            var s = new JsonSerializerOptions(){ WriteIndented = true, IncludeFields = true};
            File.WriteAllText("C:\\mapper.json", JsonSerializer.Serialize(Run(), s));
        }
    }
}
