using System;

public class Startup
{
    public static void Main()
    {
        string[] args = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        ArrayParser parser = new ArrayParser();

        int[] dimensions = parser.IntegersParser(args);
        int rows = dimensions[0];
        int cols = dimensions[1];

        MatrixGenerator matrixGenerator = new MatrixGenerator();
        MatrixOperator matrixOperator = new MatrixOperator();

        int[,] matrix = matrixGenerator.GenerateIntegersMatrix(rows, cols);

        string command = null;
        long sum = 0;

        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            string[] ivoArgs = command.Split();
            int[] ivoCoordinates = parser.IntegersParser(ivoArgs);

            string[] evilArgs = Console.ReadLine().Split();
            int[] evilCoordinates = parser.IntegersParser(evilArgs);

            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            matrixOperator.DeleteElementsFromBottomRightToUpperLeft(matrix, evilRow, evilCol);

            int ivoRow = ivoCoordinates[0];
            int ivoCol = ivoCoordinates[1];

            sum += matrixOperator.SumElementsFromBottomLeftToUpperRight(matrix, ivoRow, ivoCol);
        }

        Console.WriteLine(sum);
    }
}