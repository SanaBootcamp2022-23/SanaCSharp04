using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task7
{
    public static void SumMax(int[,] matrix)
    {
        Console.WriteLine("Task 7:");
        if (matrix.GetLength(0) == matrix.GetLength(1))
        {
            int cordRow, cordCol, summa = 0, totalSum= int.MinValue;
            for (int m = 1; m < matrix.GetLength(1); m++)
            {
                cordRow = 0;
                cordCol = m;
                summa = 0;
                for (int k = 0; k < matrix.GetLength(0) - m; k++)
                {
                    summa += matrix[cordRow, cordCol];
                    cordRow++;
                    cordCol++;
                    
                }
                if (summa > totalSum) totalSum = summa;
            }
            for (int n = 1; n < matrix.GetLength(0); n++)
            {
                cordRow = n;
                cordCol = 0;
                summa = 0;
                for (int k = 0; k < matrix.GetLength(0) - n; k++)
                {
                    summa += matrix[cordRow, cordCol];
                    cordRow++;
                    cordCol++;
                }
                if (summa > totalSum) totalSum = summa;
            }
                Console.WriteLine("The maximum among the sums of diagonal elements parallel to the main diagonal of the matrix: {0}", totalSum);
        }
        else
        {
            Console.WriteLine("This matrix isn`t cubic!");
        }
    }
}