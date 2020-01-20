using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace Spider.Models
{
    class ModPack
    {
        [BsonId]
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Modified { get; set; }
        public List<Mod> Mods { get; set; }

        protected bool Equals(ModPack other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ModPack) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        private sealed class IdEqualityComparer : IEqualityComparer<ModPack>
        {
            public bool Equals(ModPack x, ModPack y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id;
            }

            public int GetHashCode(ModPack obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public static IEqualityComparer<ModPack> IdComparer { get; } = new IdEqualityComparer();
    }
}
