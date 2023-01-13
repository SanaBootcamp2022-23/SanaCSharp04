using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MyMatrix
    {
        public static int[,] GenerateRandomMatrix(uint rows, uint cols, int start, int finish)
        {
            int[,] matrix = new int[rows, cols];
            Random rand = new Random();
            for (uint i = 0; i < rows; i++)
                for (uint j = 0; j < cols; j++)
                    matrix[i, j] = rand.Next(start,finish+1);
            return matrix;
        }

        public static int[,] TransponsMatrix (int[,] matrix)
        {
            int[,] transposed = new int[matrix.GetLength(1),matrix.GetLength(0)];
            for (uint i = 0; i < matrix.GetLength(0); i++)
                for (uint j = 0; j < matrix.GetLength(1); j++)
                    transposed[j, i] = matrix[i, j];
            return transposed;
        }


        public static void DisplayTranposedMatrix(int[,] matrix)
        {
            int space = GetMaxLenght(matrix);
            for (uint j = 0; j < matrix.GetLength(1); j++, Console.Write("\n"))
                for (uint i = 0; i < matrix.GetLength(0); i++)
                    Console.Write(matrix[i, j].ToString().PadLeft(space) + " ");

        }
        public static void DisplayMatrix(int[,] matrix)
        {
            int space = GetMaxLenght(matrix);
            for (uint i = 0; i < matrix.GetLength(0); i++, Console.Write("\n"))
                for (uint j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j].ToString().PadLeft(space) + " ");
        }
        public static void DisplayMatrixDiagonalColor(int[,] matrix)
        {
            int space = GetMaxLenght(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++, Console.Write("\n"))
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    long curColor = Math.Abs(i - j);
                    while (curColor >= 16)
                        curColor -= 16;
                    if (curColor == 0)
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = (ConsoleColor)(curColor);
                    Console.Write(matrix[i, j].ToString().PadLeft(space) + " ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DisplayMatrixSideDiagonalColor(int[,] matrix)
        {
            int space = GetMaxLenght(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++, Console.Write("\n"))
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    long curColor = Math.Abs(i + j);
                    while (curColor >= 16)
                        curColor -= 16;
                    if (curColor == 0)
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = (ConsoleColor)(curColor);
                    Console.Write(matrix[i, j].ToString().PadLeft(space) + " ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static int GetMaxLenght(int[,] matrix)
        {
            int max = Math.Abs(matrix[0,0]);
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (uint j = 0; j < matrix.GetLength(1); j++)
                    if (Math.Abs(matrix[i, j]) > max)
                        max = Math.Abs(matrix[i, j]);
            int count = 0;
            while (max != 0) { 
                count++;
                max /= 10;
            }
            return count+1;
        }
    }
}
