using System;

public class Tomcat : Cat
{
    public Tomcat(string name, string ageStr, string gender) 
        : base(name, ageStr, "Male")
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("MEOW");
    }
}