using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;

namespace Language.Core {
    public sealed class JsonFormatter {
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private readonly string _modName;

        public JsonFormatter(StreamReader reader, StreamWriter writer, string modName) {
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
                if (string.IsNullOrEmpty(builder.ToString())) {
                    throw new NullReferenceException();
                }

                if (string.IsNullOrWhiteSpace(builder.ToString())) {
                    throw new NullReferenceException();
                }
                //有憨憨作者在json里写除了string以外的内容全部抛出
                var jsonObject = JsonSerializer.Deserialize<Dictionary<string, string>>(builder.ToString(), new JsonSerializerOptions() {
                    AllowTrailingCommas = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
                var str = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions() {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
                _writer.Write(str);
                _writer.Close();
                _writer.Dispose();
            }
            catch {
                if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/broken")) {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/broken");
                }
                _writer.Write("{}");
                _writer.Close();
                _writer.Dispose();
                File.WriteAllText($"{Directory.GetCurrentDirectory()}/broken/{_modName}{DateTime.UtcNow.Millisecond}.json", builder.ToString());
            }
        }
    }
}
