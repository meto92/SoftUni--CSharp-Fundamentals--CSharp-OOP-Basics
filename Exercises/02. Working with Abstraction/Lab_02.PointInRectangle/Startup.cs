using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        double[] rectangleCoordinates = Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToArray();

        double topLeftX = rectangleCoordinates[0];
        double topLeftY = rectangleCoordinates[1];
        double bottomRightX = rectangleCoordinates[2];
        double bottomRightY = rectangleCoordinates[3];

        Point topLeft = new Point(topLeftX, topLeftY);
        Point bottomRight = new Point(bottomRightX, bottomRightY);

        Rectangle rectangle = new Rectangle(topLeft, bottomRight);

        int pointsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < pointsCount; i++)
        {
            double[] pointCoordinates = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double x = pointCoordinates[0];
            double y = pointCoordinates[1];

            Point point = new Point(x, y);

            Console.WriteLine(rectangle.Contains(point));
        }
    }
}