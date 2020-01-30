using System.IO;

namespace Spider
{
    internal static class Utils
    {
        public static string GetTargetParentDirectory(string path, string targetDirectory)
        {
            while (true)
            {
                if (Directory.Exists(Path.Combine(path, targetDirectory))) return path;
                if (Path.GetPathRoot(path) == path)
                    throw new DirectoryNotFoundException(
                        $"The {nameof(targetDirectory)} doesn't contain in any parent of {nameof(path)}");
                path = Directory.GetParent(path).FullName;
            }
        }
    }
}