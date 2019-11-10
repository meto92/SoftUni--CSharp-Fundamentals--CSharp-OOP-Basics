using System;

public class Cat : Animal
{
    public Cat(string name, string ageStr, string gender) 
        : base(name, ageStr, gender)
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("Meow meow");
    }
}