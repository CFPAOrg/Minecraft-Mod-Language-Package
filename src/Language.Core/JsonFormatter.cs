using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Language.Core {
    public sealed class JsonFormatter {
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;

        public JsonFormatter(StreamReader reader,StreamWriter writer) {
            _reader = reader;
            _writer = writer;
        }

        public void Format() {
            var builder = new StringBuilder();
            while (!_reader.EndOfStream) {
                builder.AppendLine(_reader.ReadLine());
            }
            var jsonObject = JObject.Parse(builder.ToString());
            var writer = new JsonTextWriter(_writer);
            writer.WriteRaw(jsonObject.ToString());
            writer.Close();
        }
    }
}