using System;

namespace Spider {
    public class Filelib {
        public static string GetProjectName (Uri uri){
            var url = uri.ToString();
            var start = url.LastIndexOf('/') + 1;
            return url[start..];
        }
    }
}