using System.Collections.Generic;
using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Commands commands = new Commands();
            List<string> parameters = new List<string>();
            bool next = true;
            string enter = string.Empty;    
            
            while (next)
            {
                Utilities.PrintInlineMessage(string.Format("{0} > " ,currentDirectory));

                enter = Console.ReadLine();
                // enter = "";

                if (string.IsNullOrEmpty(enter))
                { 
                    continue;
                }

                parameters.AddRange(enter.Split(' '));

                parameters.RemoveAll(WhiteParameters);

                enter = parameters[0];

                parameters.Remove(enter);

                enter = enter.ToLower();

                switch (enter)
                {
                    case "ls":
                        commands.Ls(parameters);
                        break;

                    case "makefile":
                        commands.MakeFile(parameters);    
                        break;
                        
                    case "cd":
                        currentDirectory = commands.Cd(parameters, currentDirectory);
                        break;

                    case "rm":
                        commands.Rm(parameters, currentDirectory);
                        break;

                    case "rmdir":
                        commands.RmDir(parameters, currentDirectory);
                        break;

                    case "exit":
                        next = false;
                        break;

                    default:
                        Utilities.PrintMessage("Command not found");
                        break;

                } // end switch

                enter = string.Empty;
                parameters.Clear();

            } // end while

        } // end function Main

        private static bool WhiteParameters(string parameter)
        {
            return string.IsNullOrEmpty(parameter);
        }
    }
}
