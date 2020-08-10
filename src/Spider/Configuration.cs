using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Spider
{
    public class Configuration
    {
        public Configuration()
        {
            
        }
        public static Configuration Default { get; }

        public List<string> EnabledGameVersions { get; set; }
        public string ModCount { get; set; }
        public string VersionsPath { get; set; }
    }
}
