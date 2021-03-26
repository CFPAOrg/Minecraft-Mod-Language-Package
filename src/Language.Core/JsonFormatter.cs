using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Language.Core {
    public sealed class JsonFormatter {
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private readonly string _modName;

        public JsonFormatter(StreamReader reader, StreamWriter writer,string modName) {
            _reader = reader;
            _writer = writer;
            _modName = modName;
        }

        public void Format() {
            var builder = new StringBuilder();
            while (!_reader.EndOfStream) {
                builder.AppendLine(_reader.ReadLine());
            }

            try {
                var jsonObject = JsonSerializer.Deserialize<Dictionary<string, string>>(builder.ToString(), new JsonSerializerOptions() { AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip });
                var str = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions() { WriteIndented = true });
                _writer.Write(str);
                _writer.Close();
                _writer.Dispose();
            }
            catch {
                if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/broken")) {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/broken");
                }
                File.WriteAllText($"{Directory.GetCurrentDirectory()}/broken/{_modName}{DateTime.UtcNow.Millisecond}.json",builder.ToString());
            }
        }
    }
}