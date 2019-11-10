using System.Collections.Generic;

public class AddRemoveCollection : IAddRemoveProvider
{
    private LinkedList<string> elements;

    public AddRemoveCollection()
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
        string last = this.elements.Last.Value;

        this.elements.RemoveLast();

        return last;
    }
}