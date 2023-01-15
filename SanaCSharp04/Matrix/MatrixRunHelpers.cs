using System;

namespace Matrix
{
    internal static class MatrixRunHelpers
    {
        public static int[,] GenerateMatrix(int rowCount, int columnCount)
        {
            int[,] matrix = new int[rowCount, columnCount];

            Random random = new Random();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
            return matrix;
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}