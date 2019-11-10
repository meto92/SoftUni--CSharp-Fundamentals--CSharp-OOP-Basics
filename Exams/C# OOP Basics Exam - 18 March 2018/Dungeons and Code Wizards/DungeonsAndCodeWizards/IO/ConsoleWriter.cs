using System;

public class ConsoleWriter : IOutputWriter
{
    public void Write(string message, params object[] parameters)
    {
        Console.Write(message, parameters);
    }

    public void WriteLine(string message, params object[] parameters)
    {
        Console.WriteLine(message, parameters);
    }
}