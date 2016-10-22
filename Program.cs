﻿using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Commands commands = new Commands();
            List<string> parameters = new List<string>();
            bool next = true;
            string enter = string.Empty;    

            while (next)
            {
                Print.PrintInlineMessage(">");

                #if (DEBUG)
                    enter = "ls -a";
                #else
                    enter = Console.ReadLine();
                #endif
                
                if (string.IsNullOrEmpty(enter))
                { 
                    continue;
                }

                enter = enter.ToLower();

                parameters.AddRange(enter.Split(' '));

                enter = parameters[0];

                parameters.Remove(enter);

                switch (enter)
                {
                    case "ls":
                        commands.Ls(parameters);
                        break;

                    case "exit":
                        next = false;
                        break;

                    default:
                        Print.PrintMessage("Command not found");
                        break;
                }

                enter = string.Empty;
            }
        }
    }
}
