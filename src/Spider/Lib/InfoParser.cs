using System;
using System.Collections.Generic;
using System.Linq;

using Serilog;

using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public class InfoParser {
        private readonly Configuration _defaultConfiguration;
        private readonly IncompleteConfiguration[] _customConfigurations;

        public InfoParser(Configuration defaultConfiguration, IncompleteConfiguration[] customConfigurations) {
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
                var cfg = _customConfigurations.ToList().FirstOrDefault(_ => _.ProjectName == info.ShortWebsiteUrl);
                if (cfg is null) {
                    tmp.Add((info, _defaultConfiguration));
                }
                else {
                    var completedCfg = new Configuration() {
                        ExtractPath = cfg.ExtensionData.TryGetValue("extract_path", out var value1)
                            ? value1.GetStringArray()
                            : _defaultConfiguration.ExtractPath,
                        Version = cfg.Version,
                        IncludedPath = cfg.ExtensionData.TryGetValue("included_path", out var value2)
                            ? value2.GetStringArray()
                            : _defaultConfiguration.IncludedPath,
                        NonUpdate = cfg.ExtensionData.TryGetValue("non_update", out var value3)
                            ? value3.GetBoolean()
                            : _defaultConfiguration.NonUpdate,
                        ProjectName = cfg.ProjectName,
                        UpdateChinese = cfg.ExtensionData.TryGetValue("update_chinese", out var value4)
                            ? value3.GetBoolean()
                            : _defaultConfiguration.UpdateChinese
                    };

                    tmp.Add((info, completedCfg));
                }
            }

            return tmp.ToArray();
        }

        public (ModInfo, Configuration) Serialize(ModInfo info) {
            var cfg = _customConfigurations.ToList().FirstOrDefault(_ => _.ProjectName == info.ShortWebsiteUrl);
            if (cfg is null) {
                return (info, _defaultConfiguration);
            }

            var completedCfg = new Configuration() {
                ExtractPath = cfg.ExtensionData.TryGetValue("extract_path", out var value1)
                    ? value1.GetStringArray()
                    : _defaultConfiguration.ExtractPath,
                Version = cfg.Version,
                IncludedPath = cfg.ExtensionData.TryGetValue("included_path", out var value2)
                    ? value2.GetStringArray()
                    : _defaultConfiguration.IncludedPath,
                NonUpdate = cfg.ExtensionData.TryGetValue("non_update", out var value3)
                    ? value3.GetBoolean()
                    : _defaultConfiguration.NonUpdate,
                ProjectName = cfg.ProjectName,
                UpdateChinese = cfg.ExtensionData.TryGetValue("update_chinese", out var value4)
                    ? value4.GetBoolean()
                    : _defaultConfiguration.UpdateChinese
            };

            return (info, completedCfg);
        }
    }
}