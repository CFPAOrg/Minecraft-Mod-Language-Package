using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public class InfoParser {
        public List<ModInfo> Infos { get; set; }
        private readonly Configuration _defaultConfiguration;
        private readonly Configuration[] _customConfigurations;

        public InfoParser(Configuration defaultConfiguration, Configuration[] customConfigurations) {
            _defaultConfiguration = defaultConfiguration;
            _customConfigurations = customConfigurations;
        }

        ~InfoParser() {
            Log.Logger.Debug("解析器已回收");
        }

        public (ModInfo,Configuration)[] SerializeAll() {
            if (Infos is null) {
                throw new NullReferenceException("Empty infos!");
            }

            var tmp = new List<(ModInfo, Configuration)>();
            foreach (var c in _customConfigurations) {
                var mod = Infos.FirstOrDefault(_ => _.ShortWebsiteUrl == c.ProjectName);
                Infos.Remove(mod);
                if (mod is not null) {
                    tmp.Add((mod, c));
                }
            }

            foreach (var info in Infos) {
                tmp.Add((info, _defaultConfiguration));
            }

            return tmp.ToArray();
        }

        public (ModInfo, Configuration) Serialize(ModInfo info) {
            foreach (var cfg in _customConfigurations) {
                if (cfg.ProjectName == info.ShortWebsiteUrl) {
                    return (info, cfg);
                }
            }
            return (info, _defaultConfiguration);
        }
    }
}