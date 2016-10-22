using System;
public static partial class Utilities
{
    #region constants
    private static ConsoleColor _defaultColor = Console.ForegroundColor;
    private static ConsoleColor _successColor = ConsoleColor.Green;
    private static ConsoleColor _warningColor = ConsoleColor.Yellow;
    private static ConsoleColor _errorColor = ConsoleColor.Red;
    private static ConsoleColor _fileNameColor = ConsoleColor.Blue;
    private static ConsoleColor _directoryNameColor = ConsoleColor.Magenta;

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

    public static void PrintFileName(string fileName)
    {
        Console.ForegroundColor = _fileNameColor;
        Console.WriteLine(fileName);
        Console.ForegroundColor = _defaultColor;
    }

    public static void PrintDirectoryName(string directoryName)
    {
        Console.ForegroundColor = _directoryNameColor;
        Console.WriteLine(directoryName);
        Console.ForegroundColor = _defaultColor;
    }
}