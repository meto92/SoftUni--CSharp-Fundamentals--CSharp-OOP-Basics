using System;

public class Square : Shape
{
    private int side;

    public Square(int side)
    {
        this.Side = side;
    }

    public int Side
    {
        get => side;
        set => side = value;
    }

    public override void Draw()
    {
        string topAndBottom = $"|{new string('-', this.Side)}|";
        string middle = $"|{new string(' ', this.Side)}|";

        Console.WriteLine(topAndBottom);

        for (int i = 0; i < this.Side - 2; i++)
        {
            Console.WriteLine(middle);
        }

        Console.WriteLine(topAndBottom);
    }
}