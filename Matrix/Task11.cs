using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task11
{
    public static void TransportMatrix(int[,] matrix)
    {
        Console.WriteLine("Task 11:\nTransported matrix:");
        for (int n = 0; n < matrix.GetLength(0); n++)
        {
            for (int m = 0; m < matrix.GetLength(1); m++)
            {
                Console.Write($"{matrix[m, n]}\t");
            }
            Console.WriteLine();

        }
    }
}