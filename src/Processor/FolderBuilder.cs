using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    static class FolderBuilder
    {
        public static bool CheckProjectFolder(Configuration configuration)
        {
            var projects = configuration.VersionList;
            var b1 = false;
            foreach (var t in projects)
            {
                b1 = Directory.Exists(Path.Combine(configuration.CustomSittings.ProjectsFolder, t));
                if (!b1)
                {
                    break;
                }
            }
            return b1;
        }
    }
}
