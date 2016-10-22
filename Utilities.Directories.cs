using System.Collections.Generic;
using System.IO;
public static partial class Utilities
{
    public static List<string> GetListDirectories(string path = null)
    {
        List<string> directories = new List<string>();

        if (string.IsNullOrEmpty(path))
        {
            directories.AddRange(Directory.EnumerateDirectories(Directory.GetCurrentDirectory()));
        }
        else
        {
            directories.AddRange(Directory.EnumerateDirectories(path));
        }

        return directories;
    }
}