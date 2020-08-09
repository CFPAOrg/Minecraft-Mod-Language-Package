using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    public class Utils
    {
        public static string JoinDownloadUrl(string fileId, string fileName)
        {
            return $"https://edge.forgecdn.net/files/{fileId[..4]}/{fileId[4..]}/{fileName}";
        }
    }
}
