


using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Console.Write("Number of rows: ");
        int row = Int32.Parse(Console.ReadLine());
        Console.Write("Number of columns: ");
        int column = Int32.Parse(Console.ReadLine());

        int [,] testArray = new int[row, column];

        for (int y = 0; y < row; y++) 
        {
            for (int x = 0; x < column; x++)
            {
                testArray[y, x] = random.Next(-100, 100);
            }
        }
        Console.WriteLine();
        arrayPrint(testArray);
        Console.WriteLine();

        Console.WriteLine("Num of possitive elements: " + countPositiveElements(testArray) + "\n");
        Console.WriteLine("duplicate: null\n");
        Console.WriteLine("Row(s) without 0: " + rowWithoutZero(testArray) + "\n");
        Console.WriteLine("Column(s) contain 0: " + columnContainZero(testArray) + "\n");
        Console.WriteLine("series of identical elements: null\n");

        Console.WriteLine("===========================");
        Console.WriteLine("Result of multiplication rows without zero:");
        multElementsRowWithoutZero(testArray);
        Console.WriteLine("===========================");
        Console.WriteLine();
        Console.WriteLine("===========================");
        Console.WriteLine("Result of sum columns without below zero:");
        sumElementsColumnWithoutBelowZero(testArray);
        Console.WriteLine("===========================");
        Console.WriteLine();
        Console.WriteLine("Result of sum columns with below zero:");
        sumElementsColumnContainBelowZero(testArray);
        Console.WriteLine("===========================");

    }

    public static void arrayPrint(int [,] arr)
    {
        for (int y = 0; y < arr.GetLength(0); y++)
        {
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                Console.Write(arr[y, x] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static int countPositiveElements (int[,] arr)
    {
        int counter = 0;
        for (int y = 0; y < arr.GetLength(0); y++)
        {
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                if (arr[y, x] > 0)
                {
                    counter++;
                }
            }
        }
        return counter;
    }

    public static int rowWithoutZero(int[,] arr)
    {
        int counter = 0;
        for (int y = 0; y < arr.GetLength(0); y++)
        {
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                if (arr[y,x] == 0)
                {
                    break;
                }
                else if(x == arr.GetLength(1) - 1)
                {
                    counter++;
                }
            }
        }
        return counter;
    }

    public static int columnContainZero(int[,] arr)
    {
        int counter = 0;
        for (int x = 0; x < arr.GetLength(1); x++)
        {
            for (int y = 0; y < arr.GetLength(0); y++)
            {
                if (arr[y,x] != 0)
                {
                    continue;
                }
                else if (arr[y,x] == 0)
                {
                    counter++;
                    break;
                }
            }
        }
        return counter;
    }

    public static void multElementsRowWithoutZero(int[,] arr)
    {
        for (int y = 0; y < arr.GetLength(0); y++)
        {
            int result = 1;
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                if (arr[y, x] != 0)
                {
                    result *= arr[y, x];
                }
                else
                    break;

                if(x == arr.GetLength(1) - 1)
                {
                    Console.Write($"Row {y+1} result: ");
                    Console.WriteLine(result);
                }
            }
        }

    }

    public static void sumElementsColumnWithoutBelowZero(int[,] arr)
    {
        for (int x = 0; x < arr.GetLength(1); x++)
        {
            int sum = 0;
            for (int y = 0; y < arr.GetLength(0); y++)
            {
                if (arr[y, x] >= 0)
                    sum += arr[y, x];
                else
                {
                    sum = 0;
                    break;
                }


                if (y == arr.GetLength(0) - 1)
                {
                    Console.WriteLine($"Column {x+1} sum of elements {sum}");
                }
            }
        }
    }

    public static void sumElementsColumnContainBelowZero(int[,] arr)
    {
        for (int x = 0; x < arr.GetLength(1); x++)
        {
            int tempCount = 0;
            int sum = 0;
            for (int y = 0; y < arr.GetLength(0); y++)
            {
                if (arr[y,x] < 0)
                {
                    tempCount++;
                    sum += arr[y,x];
                }
                else
                    sum+= arr[y,x];

                if (tempCount != 0 && y == arr.GetLength(0) - 1)
                {
                    Console.WriteLine($"Column {x + 1} sum of elements {sum}");
                }


            }
        }
    }

}