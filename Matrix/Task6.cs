using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task6
{
    public static void NoNegativeRows(int[,] matrix)
    {
        Console.WriteLine("Task 6:");
        int multiply = 0, counter = 0;
        for (int n = 0; n < matrix.GetLength(0); n++)
        {
            for (int m = 0; m < matrix.GetLength(1); m++)
            {
                if (matrix[n, m] >= 0)
                {
                    multiply *= matrix[n, m];
                }
                else break;
            }
            if (multiply != 0)
            {
                Console.WriteLine("Sum of elements {0} columb: {1}", n + 1, multiply);
                counter++;
            }
        }
        if(counter==0)
        {
            Console.WriteLine("There are no rows which do not contain negative element!");
        }
       

    }
}
