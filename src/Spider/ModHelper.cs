using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spider
{
    public static class ModHelper
    {
        public static bool ShouldPassMod(Mod mod, IEnumerable<Mod> mods)
        {

            var list = mods.ToList();
            if (list.Contains(mod))
            {
                var old = list.Find(_ => _.Equals(mod));
                if (old!.LastCheckUpdateTime < mod.LastUpdateTime)//检查是否有更新
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public static Uri JoinDownloadUrl(string fileId, string fileName)
        {
            return new Uri($"https://edge.forgecdn.net/files/{fileId[..4]}/{fileId[4..]}/{fileName}");
        }
    }
}
