using System.Collections.Generic;
using System.IO;
public class Commands
{
    public void Ls(List<string> parameters = null)
    {
        if (parameters == null)
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(Directory.GetCurrentDirectory()));
            List<string> directories = new List<string>(Directory.EnumerateDirectories(Directory.GetCurrentDirectory()));
            foreach (string file in files)
            {
                Print.PrintMessage(file);
            }
            foreach (string directory in directories)
            {
                Print.PrintMessage(directory);
            }
        }
    }
}