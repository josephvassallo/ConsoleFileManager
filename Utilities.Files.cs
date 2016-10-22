using System.Collections.Generic;
using System.IO;
public static partial class Utilities
{
    public static List<string> GetListFiles(string path = null)
    {
        List<string> files = new List<string>();

        if (string.IsNullOrEmpty(path))
        {
            files = (List<string>) Directory.EnumerateFiles(Directory.GetCurrentDirectory());
        }
        else
        {
            files = (List<string>) Directory.EnumerateFiles(path);
        }

        return files;
    }
}