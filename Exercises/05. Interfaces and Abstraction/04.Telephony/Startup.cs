using System;

public class Startup
{
    public static void Main()
    {
        Smartphone smartphone = new Smartphone();

        string[] phoneNumbers = Console.ReadLine().Split();
        string[] sites = Console.ReadLine().Split();

        foreach (string number in phoneNumbers)
        {
            smartphone.Call(number);
        }

        foreach (string url in sites)
        {
            smartphone.BrowseWWW(url);
        }
    }
}