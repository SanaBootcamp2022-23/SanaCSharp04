using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixAct
    {
        public static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine("\n");
            }


        }
        public static int[,] GenerateMatrix(int rowCount, int columnCount)
        {
            int min = 0, max = 0;
            Console.Write("Мiнiмальне значення: ");
            min = int.Parse(Console.ReadLine());

            Console.Write("Максимальне значення: ");
            max = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowCount, columnCount];

            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(min, max);
                }
            }
            return matrix;
        }
    }
}
