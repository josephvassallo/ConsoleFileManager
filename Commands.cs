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
                Utilities.PrintFileName(file);
            }
            foreach (string directory in directories)
            {
                Utilities.PrintDirectoryName(directory);
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
                            Utilities.PrintFileName(file);
                        }
                        break;

                    case "-d":
                        List<string> directories = Utilities.GetListDirectories();
                        foreach (string directory in directories)
                        {
                            Utilities.PrintDirectoryName(directory);
                        }
                        break;

                    default:
                        Utilities.PrintWarningMessage("Parameter not found");
                        break;
                }
                return;
            }
            if (parameter.Contains("/"))
            {
                if (Directory.Exists(parameter))
                {
                    List<string> files = Utilities.GetListFiles(parameter);
                    List<string> directories = Utilities.GetListDirectories(parameter);
                    foreach (string file in files)
                    {
                        Utilities.PrintFileName(file);
                    }
                    foreach (string directory in directories)
                    {
                        Utilities.PrintDirectoryName(directory);
                    }
                }
                return;
            }
        }
        if (parameters.Count > 1)
        {
            string option = parameters[0];
            parameters.Remove(option);
            option = option.ToLower();
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
                            Utilities.PrintFileName(file);
                        }
                        break;

                    case "-d":
                        List<string> directories = Utilities.GetListDirectories();
                        foreach (string directory in directories)
                        {
                            Utilities.PrintDirectoryName(directory);
                        }
                        break;

                    default:
                        Utilities.PrintWarningMessage("Parameter not found");
                        break;
                }
            }
            else
            {
                Utilities.PrintWarningMessage("Path not found");
            }
        }
    }
    public void MakeFile(List<string> parameters)
    {
        if (parameters.Count == 0)
        {
            bool exist = false;
            int contatore = 0;
            string fileName = string.Empty;
            do
            {
                if (contatore == 0)
                {
                    fileName = "newFile";
                }
                else
                {
                    fileName = string.Format("newFile({0})", contatore);
                }
                exist = File.Exists(fileName);
                contatore++;
            } while (exist);

            File.Create(fileName);
            return;
        }
        if (parameters.Count == 1)
        {
            string path = parameters[0];
            parameters.Remove(path);
            
                

            File.Create(path);
        }
    }

    public string Cd(List<string> parameters, string currentDirectory)
    {
        if (parameters.Count == 0)
        {
            return currentDirectory;
        }
        if (parameters.Count == 1)
        {
            string directory = parameters[0];
            parameters.Remove(directory);

            // navigate to parent directory
            if (directory.Equals(".."))
            {
                DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);
                if (parentDirectory == null)
                {
                    Utilities.PrintWarningMessage("No parent for the current directory");
                    return currentDirectory;
                }
                return parentDirectory.FullName;
            }
            // navigate to absolute path
            if (directory.StartsWith("/"))
            {
                if (directory.EndsWith("/"))
                {
                    directory = directory.Remove(directory.LastIndexOf('/'));
                }
                if (Directory.Exists(directory))
                {
                    return directory;
                }
                else
                {
                    Utilities.PrintErrorMessage("Path not found");
                    return currentDirectory;
                }
            }
            // navigate to relative path
            string path = string.Format("{0}/{1}", currentDirectory, directory);
            if (Directory.Exists(path))
            {
                return path;
            } 
            Utilities.PrintErrorMessage("Path not found");
            return currentDirectory;
        }
        else
        {
            Utilities.PrintErrorMessage("Path not found");
            return currentDirectory;
        }
    }

    public void Rm(List<string> parameters)
    {
        if (parameters.Count == 0)
        {
            return; 
        }
        else
        {
            foreach (string item in parameters)
            {
                if (File.Exists(item))
                {
                    File.Delete(item);
                }
            }
        }
    }
}