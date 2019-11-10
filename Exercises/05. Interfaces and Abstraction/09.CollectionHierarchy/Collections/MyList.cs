using System.Collections.Generic;

public class MyList : IMyList
{
    private LinkedList<string> elements;

    public MyList()
    {
        this.elements = new LinkedList<string>();
    }

    public int Add(string element)
    {
        this.elements.AddFirst(element);

        return 0;
    }

    public string Remove()
    {
        string first = this.elements.First.Value;

        this.elements.RemoveFirst();

        return first;
    }

    public int Used()
    {
        return this.elements.Count;
    }
}