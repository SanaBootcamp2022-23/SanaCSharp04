using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Task3
{
    public  static void NoZeroRow(int [,] matrix)
    {
        Console.WriteLine("Task 3:");
        int counter = matrix.GetLength(0);
        for(int n = 0; n < matrix.GetLength(0); n++)
        {
            for(int m=0;m < matrix.GetLength(1); m++)
            {
                if (matrix[n, m] == 0)
                {
                    counter--;
                    break;
                }
            }
        }
        Console.WriteLine("Number of rows which don`t contain zero: {0}", counter);
    }
}
