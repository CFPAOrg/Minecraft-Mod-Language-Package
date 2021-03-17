using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public class InfoParser {
        private readonly List<ModInfo> _infos;
        private readonly Configuration _defaultConfiguration;
        private readonly Configuration[] _customConfigurations;

        public InfoParser(List<ModInfo> infos, Configuration defaultConfiguration, Configuration[] customConfigurations) {
            _infos = infos;
            _defaultConfiguration = defaultConfiguration;
            _customConfigurations = customConfigurations;
        }

        public (ModInfo,Configuration)[] SerializeAll() {
            var tmp = new List<(ModInfo, Configuration)>();
            foreach (var c in _customConfigurations) {
                var mod = _infos.FirstOrDefault(_ => _.ShortWebsiteUrl == c.ProjectName);
                _infos.Remove(mod);
                tmp.Add((mod, c));
            }

            foreach (var info in _infos) {
                tmp.Add((info, _defaultConfiguration));
            }

            return tmp.ToArray();
        }
    }
}