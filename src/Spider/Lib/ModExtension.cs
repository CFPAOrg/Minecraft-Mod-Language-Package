using System;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog.Core;
using Spider.Lib.JsonLib;

namespace Spider.Lib {
    public class FullMod {
        private Mod _mod;

        public Mod Mod {
            get {
                if (_mod is null) {
                    throw new NullReferenceException("获取的mod信息为空！");
                }
                return _mod;
            }
            set => _mod = value;
        }

        private Configuration _config;

        public Configuration Config {
            get {
                if (_config is null) {
                    throw new NullReferenceException("当前配置未初始化！");
                }

                return _config;
            }
            set => _config = value;
        }

        public FullMod(Mod mod, Configuration config) {
            this._mod = mod;
            this._config = config;
        }
    }
    public static class ModExtension {
        //public static FullMod AnalyzeMod(this Mod mod, Config[] config) {
        //    var version = mod.Version;
        //    var customConfig = config.ToList().First(_ => _.Version == version).CustomConfigurations
        //        .Where(_ => _.ProjectName == mod.ProjectName).ToArray()[0] ?? config.ToList().First(_ => _.Version == version).Configuration;

        //    var fullMod = new FullMod(mod, customConfig);
        //    return fullMod;
        //}
    }
}