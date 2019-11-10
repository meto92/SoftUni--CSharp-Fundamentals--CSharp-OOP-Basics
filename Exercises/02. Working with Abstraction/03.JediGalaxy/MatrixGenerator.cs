class MatrixGenerator
{
    public int[,] GenerateIntegersMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];

        int value = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = value++;
            }
        }

        return matrix;
    }
}