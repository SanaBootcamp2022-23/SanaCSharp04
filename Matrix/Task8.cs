using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task8
{
    public static void NoNegativeColumbs(int[,] matrix)
    {
        int sum, counter =0;
        bool ok;
        Console.WriteLine("Task 8:");
        for (int m=0; m<matrix.GetLength(1); m++)
        {
            sum = 0;
            ok = false;
            for(int n=0; n<matrix.GetLength(0); n++)
            {
                if (matrix[n, m] >= 0)
                {
                    sum += matrix[n, m];
                }
                else
                {
                    ok= true;
                    break;
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
        if (counter>= matrix.GetLength(1))
        {
            Console.WriteLine("There are no columbs which have no negative elements!");
        }
       
    }
}

