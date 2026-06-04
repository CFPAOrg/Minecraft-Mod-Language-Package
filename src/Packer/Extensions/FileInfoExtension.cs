using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Packer.Extensions;

internal static class FileInfoExtension
{
    public static string ReadAllText(this FileInfo file)
    {
        using var stream = file.OpenText();
        var text = stream.ReadToEnd();
        return text;
    }
}
