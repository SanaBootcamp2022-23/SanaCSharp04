using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task4
{
    public static void ZeroColumbs(int [,] matrix)
    {
        Console.WriteLine("Task 4:");
        int counter = 0;
        for(int m = 0; m < matrix.GetLength(1); m++)
        {
            for(int n=0; n < matrix.GetLength(0); n++)
            {
                if(matrix[m,n] == 0)
                {
                    counter++;
                    break;
                }
            }
        }
        Console.WriteLine("Number of columbs which contain zero: {0}", counter);
    }
}
