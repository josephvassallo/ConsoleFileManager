using System.Collections.Generic;
using System.IO;
public class Commands
{
    // show the files and the directories of a specific directory
    public void Ls(List<string> parameters, string currentDirectory)
    {
        // show all files and directories
        if (parameters.Count == 0)
        {
            List<string> files = Utilities.GetListFiles(currentDirectory);
            List<string> directories = Utilities.GetListDirectories(currentDirectory);
            // print the list of files
            foreach (string file in files)
            {
                Utilities.PrintFileName(file);
            }
            // print the list of directories
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
                    // show only the files
                    case "-f":
                        List<string> files = Utilities.GetListFiles(currentDirectory);
                        foreach (string file in files)
                        {
                            Utilities.PrintFileName(file);
                        }
                        break;
                    // show only the directories
                    case "-d":
                        List<string> directories = Utilities.GetListDirectories(currentDirectory);
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
            // show all the content of a specific directory
            if (parameter.Contains("/"))
            {
                // check if the directory exist
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
        // show the files or the directory of a specific directory
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
                    // show only the files
                    case "-f":
                        List<string> files = Utilities.GetListFiles(path);
                        foreach (string file in files)
                        {
                            Utilities.PrintFileName(file);
                        }
                        break;
                    // show only the directory
                    case "-d":
                        List<string> directories = Utilities.GetListDirectories(path);
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
    // change the working directory
    public void Cd(List<string> parameters, ref string currentDirectory)
    {
        if (parameters.Count == 0)
        {
            Utilities.PrintErrorMessage("Missing path");
            return;
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
                }
                currentDirectory = parentDirectory.FullName;
                return;
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
                    currentDirectory = directory;
                }
                else
                {
                    Utilities.PrintErrorMessage("Path not found");
                    return;
                }
            }
            // navigate to relative path
            string path = string.Format("{0}/{1}", currentDirectory, directory);
            if (Directory.Exists(path))
            {
                currentDirectory = path;
            } 
            else
            {
                Utilities.PrintErrorMessage("Path not found");
                return;
            }
        }
    }
    // remove one or more files from a directory
    public void Rm(List<string> parameters, string currentDirectory)
    {
        // nothing to remove
        if (parameters.Count == 0)
        {
            return; 
        }
        else
        {
            // iterate the list of input files
            foreach (string item in parameters)
            {
                string filePath = string.Empty;

                if (!item.StartsWith("/"))
                {
                    filePath = string.Format("{0}/{1}", currentDirectory, item);
                }
                if (string.IsNullOrEmpty(filePath))
                {
                    filePath = item;
                }
                // check if the file exist
                if (File.Exists(filePath))
                {
                    // delete the file
                    File.Delete(filePath);
                }
            }
        }
    }
    // remove a directory
    public void RmDir(List<string> parameters, string currentDirectory)
    {
        // nothing to remove
        if (parameters.Count == 0)
        {
            Utilities.PrintWarningMessage("Missing directory name");
            return;
        }
        if (parameters.Count == 1)
        {
            string directory = parameters[0];
            parameters.Remove(directory);
            directory = Utilities.GetDirectoryFullPath(directory, currentDirectory);
            // check if the directory exist
            if (Directory.Exists(directory))
            {
                try
                {
                    // delete the directory only if its empty
                    Directory.Delete(directory);
                }
                // throwed if the directory is not empty
                catch(IOException)
                {
                    Utilities.PrintErrorMessage("The directory is not empty");
                    return;
                }
            }
        }
        if (parameters.Count > 1)
        {
            string option = parameters[0];
            parameters.Remove(option);
            string directory = parameters[0];
            parameters.Remove(directory);
            directory = Utilities.GetDirectoryFullPath(directory, currentDirectory);
            switch (option)
            {
                // delete the directory and all its content
                case "-r":
                    if (Directory.Exists(directory))
                    {
                        Directory.Delete(directory, true);
                    }
                    break;
                
                default:
                    string message = string.Format("Option '{0}' not found", option);
                    Utilities.PrintWarningMessage(message);
                    break;
            }
        }
    }

    public void MkDir(List<string> parameters, string currentDirectory)
    {
        string newDirectory = parameters[0];
        parameters.Remove(newDirectory);
        newDirectory = string.Format("{0}/{1}", currentDirectory, newDirectory);
        if (Directory.Exists(newDirectory))
        {
            Directory.CreateDirectory(newDirectory);
        }
        else
        {
            Utilities.PrintErrorMessage("Directory already exist");
        }
    }
}