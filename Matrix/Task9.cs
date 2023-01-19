using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task9
{
    public static void SumMin(int[,] matrix)
    {
        Console.WriteLine("Task 9:");
        if (matrix.GetLength(0) == matrix.GetLength(1))
        {
            int cordRow, cordCol, summa = 0, totalSum = int.MaxValue;
            for (int m=matrix.GetLength(1) - 1, n = 0; m >=0; m--,n++)
            {
                cordRow = 0;
                cordCol = m;
                summa = 0;
                for (int k = 0; k < matrix.GetLength(0) - n; k++)
                {
                    summa += Math.Abs(matrix[cordRow, cordCol]);
                    cordRow++;
                    cordCol--;
                }
                if (summa < totalSum) totalSum = summa;
            }
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                cordRow = n;
                cordCol = matrix.GetLength(1) - 1;
                summa = 0;
                for (int k = 0; k < matrix.GetLength(0) - n; k++)
                {
                    summa += Math.Abs(matrix[cordRow, cordCol]);
                    cordRow++;
                    cordCol--;
                }
                if (summa < totalSum) totalSum = summa;
            }
            Console.WriteLine("The minimum among the sums of diagonal elements parallel to the side diagonal of the matrix: {0}", totalSum);

        }
        else
        {
            Console.WriteLine("This matrix isn`t cubic!");
        }
    }
}
