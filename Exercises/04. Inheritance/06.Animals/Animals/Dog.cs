using System;

public class Dog : Animal
{
    public Dog(string name, string ageStr, string gender) 
        : base(name, ageStr, gender)
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}