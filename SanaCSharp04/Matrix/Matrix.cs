using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class Matrix
    {
        public static void RandomValuesInMatrix(int[,] matrix, int min, int max)
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
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{matrix[i, j],5}");
                        Console.ResetColor();
                        continue;
                    }
                    if (matrix[i, j] < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{matrix[i, j],5}");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }

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

        public static int[] GetMatrixRow(int[,] matrix, int rowNumber)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < array.Length; j++)
                array[j] = matrix[rowNumber, j];
            return array;
        }

        public static int[] GetMatrixCol(int[,] matrix, int colNumber)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < array.Length; i++)
                array[i] = matrix[i, colNumber];
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

    public static class ArrayMultiplication
    {
        public static int Multiply(this int[] arr)
        {
            int multiplication = 1;
            for (int i = 0; i < arr.Length; i++)
                multiplication *= arr[i];
            return multiplication;
        }
    }
}
