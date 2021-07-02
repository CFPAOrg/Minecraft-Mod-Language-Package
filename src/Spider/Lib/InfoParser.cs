using System;
using System.Collections.Generic;
using System.Linq;

using Serilog;

using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public class InfoParser {
        private readonly Configuration _defaultConfiguration;
        private readonly Configuration[] _customConfigurations;

        public InfoParser(Configuration defaultConfiguration, Configuration[] customConfigurations) {
            _defaultConfiguration = defaultConfiguration;
            _customConfigurations = customConfigurations;
        }

        ~InfoParser() {
            Log.Logger.Debug("解析器已回收");
        }

        public (ModInfo, Configuration)[] SerializeAll(IEnumerable<ModInfo> infos) {
            if (infos is null) {
                throw new NullReferenceException("Empty infos!");
            }

            var tmp = new List<(ModInfo, Configuration)>();

            foreach (var info in infos) {
                var cfg = _customConfigurations.ToList().FirstOrDefault(_ => _.ProjectName == info.Slug);
                if (cfg is null) {
                    tmp.Add((info, _defaultConfiguration));
                }
                else {
                    var completedCfg = new Configuration() {
                        ExtractPath = cfg.ExtractPath ?? _defaultConfiguration.ExtractPath,
                        Version = cfg.Version,
                        IncludedPath = cfg.IncludedPath ?? _defaultConfiguration.IncludedPath,
                        NonUpdate = cfg.NonUpdate ?? _defaultConfiguration.NonUpdate,
                        ProjectName = cfg.ProjectName,
                        UpdateChinese = cfg.UpdateChinese ?? _defaultConfiguration.UpdateChinese
                    };

                    tmp.Add((info, completedCfg));
                }
            }

            return tmp.ToArray();
        }

        public (ModInfo, Configuration) Serialize(ModInfo info) {
            var cfg = _customConfigurations.ToList().FirstOrDefault(_ => _.ProjectName == info.Slug);
            if (cfg is null) {
                return (info, _defaultConfiguration);
            }

            var completedCfg = new Configuration() {
                ExtractPath = cfg.ExtractPath ?? _defaultConfiguration.ExtractPath,
                Version = cfg.Version,
                IncludedPath = cfg.IncludedPath ?? _defaultConfiguration.IncludedPath,
                NonUpdate = cfg.NonUpdate ?? _defaultConfiguration.NonUpdate,
                ProjectName = cfg.ProjectName,
                UpdateChinese = cfg.UpdateChinese ?? _defaultConfiguration.UpdateChinese
            };

            return (info, completedCfg);
        }
    }
}