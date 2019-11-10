using System.Collections.Generic;

public class AddCollection : IAddProvider
{
    private List<string> elements;

    public AddCollection()
    {
        this.elements = new List<string>();
    }

    public int Add(string element)
    {
        this.elements.Add(element);

        return this.elements.Count - 1;
    }
}