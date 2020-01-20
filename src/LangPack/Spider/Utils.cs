using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Spider
{
    class Utils
    {
        public static  CancellationTokenSource CancellationTokenSource { get; set; }=new CancellationTokenSource();
        public static string GetParentContainsSpecificDirectory(string path, string containDir)
        {
            if (Directory.Exists(Path.Combine(path, containDir)))
            {
                return path;
            }
            else
            {
                if (Path.GetPathRoot(path) == path)
                {
                    throw new DirectoryNotFoundException(
                        $@"The {nameof(containDir)}:""{containDir}"" doesn't contain in any parent of {nameof(path)}");
                };
            }
            return GetParentContainsSpecificDirectory(Directory.GetParent(path).FullName, containDir);
        }
    }
}

