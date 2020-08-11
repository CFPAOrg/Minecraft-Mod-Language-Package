using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Spider.Properties;

namespace Spider
{
    public class Utils
    {
        public static Uri JoinDownloadUrl(string fileId, string fileName)
        {
            return new Uri($"https://edge.forgecdn.net/files/{fileId[..4]}/{fileId[4..]}/{fileName}");
        }
    }
}
