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
       int multiply = 1, counter = 0;
            bool ok = true;
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                for (int m = 0; m < matrix.GetLength(1); m++)
                {
                    if (matrix[n, m] > 0)
                    {
                        multiply *= matrix[n, m];
                        ok = false;
                    }
                    else if (matrix[n, m] == 0)
                    {
                        multiply = 1;
                        ok = false;
                    }
                    else 
                    { ok = true;
                        break;
                    }
                }
                if (!ok)
                {
                    Console.WriteLine("Sum of elements {0} row: {1}", n + 1, multiply);
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("There are no rows which do not contain negative element!");
            }
       

    }
}
