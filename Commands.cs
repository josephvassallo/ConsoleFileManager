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
            return;
        }
        if (parameters.Count == 1)
        {
            string parameter = parameters[0];
            if (parameter.Contains("-"))
            {
                switch (parameter)
                {
                    case "-f":
                        List<string> files = new List<string>(Directory.EnumerateFiles(Directory.GetCurrentDirectory()));
                        foreach (string file in files)
                        {
                            Print.PrintMessage(file);
                        }
                        break;

                    case "-d":
                        List<string> directories = new List<string>(Directory.EnumerateDirectories(Directory.GetCurrentDirectory()));
                        foreach (string directory in directories)
                        {
                            Print.PrintMessage(directory);
                        }
                        break;

                    default:
                        Print.PrintWarningMessage("Parameter not found");
                        break;
                }
                return;
            }
            if (parameter.Contains("\\"))
            {
                if (Directory.Exists(parameter))
                {
                    List<string> files = new List<string>(Directory.EnumerateFiles(parameter));
                    List<string> directories = new List<string>(Directory.EnumerateDirectories(parameter));
                    foreach (string file in files)
                    {
                        Print.PrintMessage(file);
                    }
                    foreach (string directory in directories)
                    {
                        Print.PrintMessage(directory);
                    }
                }
                return;
            }
        }
    }
}