using System;

public class Startup
{
    public static void Main()
    {
        string figure = Console.ReadLine();

        Shape shape = null;

        if (figure == "Square")
        {
            int side = int.Parse(Console.ReadLine());

            shape = new Square(side);
        }
        else if (figure == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            shape = new Rectangle(width, height);
        }

        DrawingTool drawingTool = new DrawingTool(shape);

        drawingTool.Draw();
    }
}