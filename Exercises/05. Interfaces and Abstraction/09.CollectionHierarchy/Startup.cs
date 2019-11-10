using System;

public class Startup
{
    private static void AddElements(IAddProvider collection, string[] elements)
    {
        foreach (string element in elements)
        {
            int index = collection.Add(element);

            Console.Write($"{index} ");
        }

        Console.WriteLine();
    }

    private static void RemoveElements(IAddRemoveProvider collection, int removeOperationsCount)
    {
        for (int i = 0; i < removeOperationsCount; i++)
        {
            string removeElement = collection.Remove();

            Console.Write($"{removeElement} ");
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        string[] elements = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int removeOperationsCount = int.Parse(Console.ReadLine());

        IAddProvider addCollection = new AddCollection();
        IAddRemoveProvider addRemoveCollection = new AddRemoveCollection();
        IAddRemoveProvider myList = new MyList();

        AddElements(addCollection, elements);
        AddElements(addRemoveCollection, elements);
        AddElements(myList, elements);

        RemoveElements(addRemoveCollection, removeOperationsCount);
        RemoveElements(myList, removeOperationsCount);
    }
}