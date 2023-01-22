using System;
namespace Matrix
{
    public class MatrixFunctions
    {
        public static int[] ConvertMatrixToArray(int[,] matrix)
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
    }
}
