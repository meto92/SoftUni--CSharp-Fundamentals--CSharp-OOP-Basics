using System;
using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }

    public void Push(string element)
    {
        this.data.Add(element);
    }

    private void Validate()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException("Stack empty.");
        }
    }

    public string Pop()
    {
        this.Validate();

        int lastIndex = this.data.Count - 1;
        string result = this.data[lastIndex];
        this.data.RemoveAt(lastIndex);

        return result;
    }

    public string Peek()
    {
        this.Validate();

        int lastIndex = this.data.Count - 1;
        string result = this.data[lastIndex];

        return result;
    }
}