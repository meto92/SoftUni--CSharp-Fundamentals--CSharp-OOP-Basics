public class MatrixOperator
{
    public void DeleteElementsFromBottomRightToUpperLeft(int[,] matrix, int bottomRightRow, int bottomRightCol)
    {
        int row = bottomRightRow,
            col = bottomRightCol,
            rows = matrix.GetLength(0),
            cols = matrix.GetLength(1);

        while (row >= 0 && col >= 0)
        {
            if (row < rows && col >= 0 && col < cols)
            {
                matrix[row, col] = 0;
            }

            row--;
            col--;
        }
    }

    public long SumElementsFromBottomLeftToUpperRight(int[,] matrix, int ivoRow, int ivoCol)
    {
        long sum = 0;
        int rows = matrix.GetLength(0),
            cols = matrix.GetLength(1);

        while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
        {
            if (ivoRow < rows && ivoCol >= 0 && ivoCol < cols)
            {
                sum += matrix[ivoRow, ivoCol];
            }

            ivoCol++;
            ivoRow--;
        }

        return sum;
    }
}