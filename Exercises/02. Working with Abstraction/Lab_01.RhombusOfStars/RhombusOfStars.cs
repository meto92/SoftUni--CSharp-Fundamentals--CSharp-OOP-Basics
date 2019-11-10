using System;

public class RhombusOfStars
{
    static void PrintRow(int n, int starsCount)
    {
        Console.Write($"{new string(' ', n - starsCount)}*");

        for (int i = 0; i < starsCount - 1; i++)
        {
            Console.Write(" *");
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int row = 1; row < 2 * n - 0; row++)
        {
            int starsCount = row <= n ? row : n - row % n;

            PrintRow(n, starsCount);
        }
    }
}