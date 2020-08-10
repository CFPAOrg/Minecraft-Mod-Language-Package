using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Fucker
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ReaderConfig();
            //var status = false;
            //Utils.DelFiles("./",out status);
        }

        static Addon ReaderConfig()
        {
            var reader = File.ReadAllBytes("./config/fucker.json");
            return JsonSerializer.Deserialize<Addon>(reader);
        }
    }
}
