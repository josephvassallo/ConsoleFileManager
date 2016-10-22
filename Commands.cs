using System.Collections.Generic;
using System.IO;
public class Commands
{
    public void Ls(List<string> parameters)
    {
        if (parameters.Count == 0)
        {
            List<string> files = Utilities.GetListFiles();
            List<string> directories = Utilities.GetListDirectories();
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
            parameters.Remove(parameter);

            if (parameter.Contains("-"))
            {
                switch (parameter)
                {
                    case "-f":
                        List<string> files = Utilities.GetListFiles();
                        foreach (string file in files)
                        {
                            Print.PrintMessage(file);
                        }
                        break;

                    case "-d":
                        List<string> directories = Utilities.GetListDirectories();
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
                    List<string> files = Utilities.GetListFiles(parameter);
                    List<string> directories = Utilities.GetListDirectories(parameter);
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
        if (parameters.Count > 1)
        {
            string option = parameters[0];
            parameters.Remove(option);
            string path = parameters[0];
            parameters.Remove(path);
            bool pathExist = Directory.Exists(path);
            if (pathExist)
            {
                switch (option)
                {
                    case "-f":
                        List<string> files = Utilities.GetListFiles();
                        foreach (string file in files)
                        {
                            Print.PrintMessage(file);
                        }
                        break;

                    case "-d":
                        List<string> directories = Utilities.GetListDirectories();
                        foreach (string directory in directories)
                        {
                            Print.PrintMessage(directory);
                        }
                        break;

                    default:
                        Print.PrintWarningMessage("Parameter not found");
                        break;
                }
            }
            else
            {
                Print.PrintWarningMessage("Path not found");
            }
        }
    }
}