using System.IO;
using LiteDB;
using Spider.Models;

namespace Spider.Data
{
    static class DataStore
    {
        public static LiteDatabase Database { get; set; }
        public static LiteCollection<Mod> Mods { get; set; }
        public static LiteCollection<ModPack> ModPacks { get; set; }
        static DataStore()
        {
            var mapper = BsonMapper.Global;
            mapper.Entity<ModPack>()
                .DbRef(x => x.Mods, "mods");
            var fs = File.Open(Path.Combine(Settings.WorkPath, "database/data.db"),FileMode.OpenOrCreate);
            Database= new LiteDatabase(fs);
            Mods = Database.GetCollection<Mod>("mods");
            ModPacks = Database.GetCollection<ModPack>("modpacks");
        }
    }
}
