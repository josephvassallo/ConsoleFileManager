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
                Console.Write(">");

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
                        Console.WriteLine("Command not found");
                        break;
                }

                enter = string.Empty;
            }
        }
    }
}
