using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public void Call(string number)
    {
        if (number.Any(c => !char.IsDigit(c)))
        {
            Console.WriteLine("Invalid number!");
        }
        else
        {
            Console.WriteLine($"Calling... {number}");
        }
    }

    public void BrowseWWW(string url)
    {
        if (url.Any(c => char.IsDigit(c)))
        {
            Console.WriteLine("Invalid URL!");
        }
        else
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}