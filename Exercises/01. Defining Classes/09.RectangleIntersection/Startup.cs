using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    private static Dictionary<string, Rectangle> GetRectanglesById(int rectanglesCount)
    {
        Dictionary<string, Rectangle> rectanglesById
            = new Dictionary<string, Rectangle>(rectanglesCount);

        for (int i = 0; i < rectanglesCount; i++)
        {
            string[] rectangleParams = Console.ReadLine().Split();

            string id = rectangleParams[0];
            double width = double.Parse(rectangleParams[1]);
            double height = double.Parse(rectangleParams[2]);
            double xCoord = double.Parse(rectangleParams[3]);
            double yCoord = double.Parse(rectangleParams[4]);

            Rectangle rectangle = new Rectangle(id, width, height, xCoord, yCoord);

            rectanglesById[id] = rectangle;
        }

        return rectanglesById;
    }

    private static void CheckIntersections(Dictionary<string, Rectangle> rectanglesById, int intersectionChecks)
    {
        for (int i = 0; i < intersectionChecks; i++)
        {
            string[] rectanglesIds = Console.ReadLine().Split();

            string firstId = rectanglesIds[0];
            string secondId = rectanglesIds[1];

            Rectangle firstRectangle = rectanglesById[firstId];
            Rectangle secondRectangle = rectanglesById[secondId];

            Console.WriteLine(firstRectangle.Intersects(secondRectangle).ToString().ToLower());
        }
    }

    public static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int rectanglesCount = nums[0],
            intersectionChecks = nums[1];

        Dictionary<string, Rectangle> rectanglesById = GetRectanglesById(rectanglesCount);

        CheckIntersections(rectanglesById, intersectionChecks);
    }    
}