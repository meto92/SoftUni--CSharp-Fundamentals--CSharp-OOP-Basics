using System;

public class Startup
{
    public static void Main()
    {
        string firstDateStr = Console.ReadLine();
        string secondDateStr = Console.ReadLine();

        DateModifier dateModifier = new DateModifier(firstDateStr, secondDateStr);

        Console.WriteLine(dateModifier.DifferenceInDays);
    }
}