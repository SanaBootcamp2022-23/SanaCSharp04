using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Task2
{
    public static void MaxElements(int[,] matrix)
    {
        Console.WriteLine("Task 2:");
        int maxEl = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[] sort = new int[n * m];
        sort = matrix.Cast<int>().ToArray();
        Array.Sort(sort);
        Array.Reverse(sort);
        for (int i = 0; i < sort.Length; i++)
        {
            
           if (sort[i] == sort[i+1])
           {
             maxEl = sort[i+1];
             break;
           }
        }
        Console.WriteLine($"The maximum number that occurs in the given matrix more than once: {maxEl}");
    }
}
