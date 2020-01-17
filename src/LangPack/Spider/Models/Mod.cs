using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace Spider.Models
{
    class Mod
    {
        [BsonId]
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string FileId { get; set; }
        public DateTime Modified { get; set; }
        public string DownloadUrl { get; set; }

        protected bool Equals(Mod other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Mod) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        private sealed class IdEqualityComparer : IEqualityComparer<Mod>
        {
            public bool Equals(Mod x, Mod y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id;
            }

            public int GetHashCode(Mod obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public static IEqualityComparer<Mod> IdComparer { get; } = new IdEqualityComparer();
    }
}
