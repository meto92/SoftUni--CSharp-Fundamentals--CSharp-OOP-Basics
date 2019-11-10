using System;

public class Startup
{
    public static void Main()
    {
        string driver = Console.ReadLine();

        Console.WriteLine(new Ferrari(driver));
    }
}