using System;

public class Rectangle : Shape
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width
    {
        get => width;
        set => width = value;
    }

    public int Height
    {
        get => height;
        set => height = value;
    }

    public override void Draw()
    {
        string topAndBottom = $"|{new string('-', this.Width)}|";
        string middle = $"|{new string(' ', this.Width)}|";

        Console.WriteLine(topAndBottom);

        for (int i = 0; i < this.Height - 2; i++)
        {
            Console.WriteLine(middle);
        }

        Console.WriteLine(topAndBottom);
    }
}