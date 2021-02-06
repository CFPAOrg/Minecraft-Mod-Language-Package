using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Spider.Lib.JsonLib;

namespace Spider.Lib.FileLib {
    public class WriteLib {
        public static async Task WriteInformationAsync(ProjectInfo[] info,string version) {
            await File.WriteAllBytesAsync(@$"{Directory.GetCurrentDirectory()}\config\spider\{version}\mod_info.json",
                JsonSerializer.SerializeToUtf8Bytes(info, new JsonSerializerOptions() {WriteIndented = true}));
        }
    }
}