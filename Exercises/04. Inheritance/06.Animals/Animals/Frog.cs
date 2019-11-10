using System;

public class Frog : Animal
{
    public Frog(string name, string ageStr, string gender) 
        : base(name, ageStr, gender)
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("Ribbit");
    }
}