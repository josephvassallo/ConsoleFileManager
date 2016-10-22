using System.Collections.Generic;
using System.IO;
public static partial class Utilities
{
    public static List<string> GetListFiles(string path = null)
    {
        List<string> files = new List<string>();

        if (string.IsNullOrEmpty(path))
        {
            files.AddRange(Directory.EnumerateFiles(Directory.GetCurrentDirectory()));
        }
        else
        {
            files.AddRange(Directory.EnumerateFiles(path));
        }

        return files;
    }
}