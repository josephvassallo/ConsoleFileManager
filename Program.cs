using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool next = true;
            string enter = string.Empty;    

            while (next)
            {
                Print.PrintInlineMessage(">");

                enter = Console.ReadLine();

                if (string.IsNullOrEmpty(enter))
                { 
                    continue;
                }

                enter = enter.ToLower();

                switch (enter)
                {
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
