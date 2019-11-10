using System;

class Kitten : Cat
{
    public Kitten(string name, string ageStr, string gender) 
        : base(name, ageStr, "Female")
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}