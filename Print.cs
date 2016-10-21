using System;
public static class Print
{
    #region constants
    private static ConsoleColor _defaultColor = Console.ForegroundColor;
    private static ConsoleColor _successColor = ConsoleColor.Green;
    private static ConsoleColor _warningColor = ConsoleColor.Yellow;
    private static ConsoleColor _errorColor = ConsoleColor.Red;

    #endregion
    
    public static void PrintMessage(string message)
    {
        Console.ForegroundColor = _defaultColor;
        Console.WriteLine(message);
    }

    public static void PrintInlineMessage(string message)
    {
        Console.ForegroundColor = _defaultColor;
        Console.Write(message);
    }

    public static void PrintSuccessMessage(string message)
    {
        Console.ForegroundColor = _successColor;
        Console.WriteLine(message);
        Console.ForegroundColor = _defaultColor;
    }

    public static void PrintWarningMessage(string message)
    {
        Console.ForegroundColor = _warningColor;
        Console.WriteLine(message);
        Console.ForegroundColor = _defaultColor;
    }

    public static void PrintErrorMessage(string message)
    {
        Console.ForegroundColor = _errorColor;
        Console.WriteLine(message);
        Console.ForegroundColor = _defaultColor;
    }
}