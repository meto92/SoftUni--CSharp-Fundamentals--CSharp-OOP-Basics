using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random rnd;

    public RandomList()
    {
        this.rnd = new Random();
    }

    public string RandomString()
    {
        int randomIndex = rnd.Next(this.Count);
        string result = this[randomIndex];
        this.RemoveAt(randomIndex);

        return result;
    }
}