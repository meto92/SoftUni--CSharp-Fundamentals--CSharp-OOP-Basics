using System;

public class Startup
{
    public static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());

        string[] pairs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        Bag bag = new Bag(bagCapacity);

        for (int i = 0; i < pairs.Length; i += 2)
        {
            string item = pairs[i];
            long amount = long.Parse(pairs[i + 1]);

            bag.TryAddItem(item, amount);
        }

        bag.PrintContent();
    }
}