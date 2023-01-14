using System;

namespace Matrix
{
    /// <summary>
    /// Class with ulils methods for more comfy work with matrix
    /// </summary>
    public static class Matrix
    {
        public static void FillMatrixByRandomValues(int[,] matrix, int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(min, max + 1);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j], 5}");
                Console.WriteLine();
            }
        }

        public static int[] ConvertToArray(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0) * matrix.GetLength(1)];
            uint arrayIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[arrayIndex] = matrix[i, j];
                    arrayIndex++;
                }
            return array;
        }

        public static int[] GetRow(int[,] matrix, int rowIndex)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < array.Length; j++)
                array[j] = matrix[rowIndex, j];
            return array;
        }

        public static int[] GetColumn(int[,] matrix, int columnIndex)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < array.Length; i++)
                array[i] = matrix[i, columnIndex];
            return array;
        }

        public static int[,] TransposeMatrix(int[,] matrix)
        {
            int[,] transposedMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    transposedMatrix[j, i] = matrix[i, j];
            return transposedMatrix;
        }
    }
}
