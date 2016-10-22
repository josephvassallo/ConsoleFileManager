using System.Collections.Generic;
using System.IO;
public static partial class Utilities
{
    public static List<string> GetListDirectories(string path = null)
    {
        List<string> directories = new List<string>();

        if (string.IsNullOrEmpty(path))
        {
            directories = (List<string>) Directory.EnumerateDirectories(Directory.GetCurrentDirectory());
        }
        else
        {
            directories = (List<string>) Directory.EnumerateDirectories(path);
        }

        return directories;
    }
}