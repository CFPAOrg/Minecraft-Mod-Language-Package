using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Permissions;
using System.Text;

namespace Spider
{
    public static class PathUtils
    {
        internal const string KERNEL32 = "kernel32.dll";
        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        private static extern uint GetTempFileName(string tmpPath, string prefix, uint uniqueIdOrZero, [Out] StringBuilder tmpFileName);
        public static string GetTempFileName(string extension)
        {
            var path = Path.GetTempPath();
            var sb = new StringBuilder(260);
            var quickDemand = typeof(FileIOPermission).GetMethod("QuickDemand",BindingFlags.Static|BindingFlags.NonPublic);
            quickDemand?.Invoke(null, new object[] {FileIOPermissionAccess.Write, path});
            GetTempFileName(path, extension, 0, sb);
            return sb.ToString();
        }
    }
}
