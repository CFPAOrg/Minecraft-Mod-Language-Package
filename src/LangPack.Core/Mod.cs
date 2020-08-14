using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LangPack.Core
{
    public class Mod : IEquatable<Mod>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("projectId")]
        public long ProjectId { get; set; }
        [JsonPropertyName("projectUrl")]
        public Uri ProjectUrl { get; set; }
        [JsonPropertyName("downloadUrl")]
        public Uri DownloadUrl { get; set; }
        [JsonPropertyName("shortProjectUrl")]
        public string ShortProjectUrl { get; set; }
        [JsonPropertyName("modId")]
        public string ModId { get; set; }
        [JsonPropertyName("assetDomains")]
        public List<string> AssetDomains { get; set; }
        [JsonPropertyName("lastUpdateTime")]
        public DateTimeOffset LastUpdateTime { get; set; }
        [JsonPropertyName("lastCheckUpdateTime")]
        public DateTimeOffset LastCheckUpdateTime { get; set; }
        [JsonPropertyName("langAssetsPaths")]
        public HashSet<string> LangAssetsPaths { get; set; }
        [JsonIgnore]
        public string Path { get; set; }

        public bool Equals(Mod other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return ProjectId == other.ProjectId;
        }

        private sealed class ProjectIdEqualityComparer : IEqualityComparer<Mod>
        {
            public bool Equals(Mod x, Mod y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.ProjectId == y.ProjectId;
            }

            public int GetHashCode(Mod obj)
            {
                return obj.ProjectId.GetHashCode();
            }
        }

        public static IEqualityComparer<Mod> ProjectIdComparer { get; } = new ProjectIdEqualityComparer();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Mod)obj);
        }

        public override int GetHashCode()
        {
            return ProjectId.GetHashCode();
        }
    }
}
