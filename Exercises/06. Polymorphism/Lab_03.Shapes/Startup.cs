using System;

public class Startup
{
    public static void Main()
    {
        Shape circle = new Circle(15);
        Shape rectangle = new Rectangle(4, 5);

        Console.WriteLine(circle.Draw());
        Console.WriteLine(rectangle.Draw());
    }
}