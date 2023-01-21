using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task1
{
    public static void PositiveElements(int [,] matrix)
    {
        Console.WriteLine("Task 1:");
        int posElements = 0;
        for(int n = 0; n <matrix.GetLength(0); n++)
        {
            for(int m = 0; m<matrix.GetLength(1); m++)
            {
                if (matrix[n, m] > 0)
                {
                    posElements++;
                }
            }

        }
        Console.WriteLine("Number of positive elements: {0}", posElements);
    }
}
