using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Task5
{
    public static void LongElements(int[,] matrix)
    {
        Console.WriteLine("Task 5:");
        int counter = 0,repeat = 0,maxIndex=0;
        for (int n = 0; n < matrix.GetLength(0); n++)
        {
            for (int m = 0; m < matrix.GetLength(1); m++)
            {
                if (matrix[n, m] == matrix[n, m + 1])
                {
                    counter++;
                }
                else break;
                if (counter > repeat)
                {
                    repeat = counter; 
                    maxIndex=n+1;
                }
            }

        }
        Console.WriteLine("Row number in which there is the longest series of identical elements{}", maxIndex);

    }
}