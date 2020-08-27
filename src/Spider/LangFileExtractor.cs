using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Spider
{
    class LangFileExtractor
    {
        private readonly string _gameVersion;
        private readonly string _projectsPath;

        public LangFileExtractor(string gameVersion, string projectsPath)
        {
            _gameVersion = gameVersion;
            _projectsPath = projectsPath;
        }
    }
}
