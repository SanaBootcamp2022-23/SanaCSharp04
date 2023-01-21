using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task10
{
    public static void NegativeElementsColumbs(int[,] matrix)
    {
        int sum, counter =0;
        bool ok;
        Console.WriteLine("Task 10:");
        for (int m = 0; m < matrix.GetLength(1); m++)
        {
            sum = 0;
            ok = true;
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                sum += matrix[n, m];
                if (matrix[n, m] < 0)
                {
                    ok = false;
                }
            }
            if (!ok)
            {
            Console.WriteLine("Sum of elements {0} columb: {1}", m + 1, sum);
            }
            else
            {
                counter++;
            }
        }
        if(counter>= matrix.GetLength(1))
        {
            Console.WriteLine("There are no columbs which have negative elements!");
        }
    }
}

