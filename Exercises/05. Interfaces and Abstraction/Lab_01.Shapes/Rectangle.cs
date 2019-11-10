using System;

public class Rectangle : IDrawable
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
        get => this.width;
        private set => this.width = value;
    }

    public int Height
    {
        get => this.height;
        private set => this.height = value;
    }

    private void DrawLine(char mid)
    {
        string middle = new string(mid, this.Width - 2);

        Console.WriteLine($"*{middle}*");
    }

    public void Draw()
    {
        this.DrawLine('*');

        for (int i = 0; i < this.Height - 2; i++)
        {
            this.DrawLine(' ');
        }

        this.DrawLine('*');
    }
}