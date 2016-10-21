namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Commands commands = new Commands();
            bool next = true;
            string enter = string.Empty;    

            while (next)
            {
                Print.PrintInlineMessage(">");

                #if (DEBUG)
                    enter = "ls";
                #else
                    enter = Console.ReadLine();
                #endif
                
                if (string.IsNullOrEmpty(enter))
                { 
                    continue;
                }

                enter = enter.ToLower();

                switch (enter)
                {
                    case "ls":
                        commands.Ls();
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
