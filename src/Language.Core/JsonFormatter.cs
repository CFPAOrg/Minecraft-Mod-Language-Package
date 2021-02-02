using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Language.Core {
    public class JsonFormatter {
        private readonly string _path;

        public JsonFormatter(string path) {
            _path = path;
        }

        public void Format() {
            var file = File.ReadAllText(_path);
            var jsonObject = JObject.Parse(file);
            foreach (var (key, value) in jsonObject) {
                Console.WriteLine($"\"{key}\":\"{value.ToString()}\"");
            }
        }
    }
}