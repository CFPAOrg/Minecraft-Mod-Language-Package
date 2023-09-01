using System.Text.Json.Serialization;

namespace Spider.Lib.JsonLib
{
    public class ModIntro
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }
}