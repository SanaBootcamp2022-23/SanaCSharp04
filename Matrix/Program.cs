// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

Console.WriteLine("Please,enter number of rows and colums of matrix: ");
Random r = new Random();
int rows, cols;
rows = Convert.ToInt32(Console.ReadLine());
cols = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[rows,cols];

InitializeArray(rows,cols,ref array);
Console.WriteLine("Array Initialized with random numbers on range(-5 — 5)");
PrintArray(array);
Console.WriteLine($"1. Number of  positive elements  = {PositiveElements(array)}");
MaxElementMoreThanOnce(array);
Console.WriteLine($"3. Number of Rows that do not contain zero = {NotNullRows(array)}"); 
Console.WriteLine($"4. Number of Colums that  contain zero = {NullCols(array)}");
Console.WriteLine($"5. Row with longest series of  repeatble elements is {LongestSerieOfNumbers(array)}");
Console.WriteLine("6. Product of rows that do no contain negative numbers");MultiplyOfRowsWithNoNegativeNumbers(array);
Console.WriteLine($"7. Maximum sum of element that paralel to main diagonal = {maxSumDiagonales(array)}");
Console.WriteLine("8. Sum of cols that do no contain negative numbers"); SumOfColsWithNoNegativeNumbers(array);
Console.WriteLine($"9. Minimum average sum of modules of elements of diagonals parallel to side diagonals of matrices = {minSumModuleDiagonales(array)}");
Console.WriteLine($"10. Sum of cols that contain at least one negative element: ");SumOfColsWithNegativeNumbers(array);
Console.WriteLine("11.Transponierte matrix");
TransponateMatrix(array);
void InitializeArray(int n, int m, ref int[,] array)
{

    Random r = new Random();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            array[i, j] = r.Next(-2,7) ;
        }
    }
}
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int PositiveElements(int[,] array)
{
    int numberOfPositiveElements = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] > 0)
                numberOfPositiveElements++;
        }
    }
    
    return numberOfPositiveElements;
} // 1

void MaxElementMoreThanOnce(int[,] array)
{
    int maxElement = int.MinValue;
    bool notin = true;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int temp = array[i, j];
            for (int k = i; k < array.GetLength(0); k++)
            {
                if (!notin && temp <= maxElement)
                    break;
                int u;
                if (k == i)
                    u = j + 1;
                else u = 0;
                for (; u < array.GetLength(1); u++)
                {
                    if (temp == array[k, u]) if (notin || maxElement < temp) { maxElement = temp; notin = false; break; }
                }
            }
        }

    if (maxElement == int.MinValue)
    {
        Console.WriteLine("There is no repeatable elements");

    }
    else
        Console.WriteLine($"2. Maximum element that appears more than once = {maxElement}");
}//2
int NotNullRows(int[,] array)
{
    int rowsCount = array.GetLength(0);
    int nullRow = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == 0)
            { nullRow++; break; }
        }
    }
    return rowsCount - nullRow;
} //3

int NullCols(int[,] array)
{

    int nullColumns = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, j] == 0)
            { nullColumns++; break; }
        }

    }
    return nullColumns;
} //4

int LongestSerieOfNumbers(int[,]array)
{
    int counter, buffer, score = -1, rezult = -1;
    for (int y = 0; y < array.GetLength(0); ++y)
    {
        buffer = 0;
        counter = 0;
        for (int x = 1; x < array.GetLength(1); ++x)
        {
            if (array[y,x - 1] == array[y,x])
                ++counter;
            else
                counter = 0;
            if (counter > buffer)
                buffer = counter;
        }
        if (buffer > score)
        {
            score = buffer;
            rezult = y;
        }
    }
    return rezult;
}//5

void MultiplyOfRowsWithNoNegativeNumbers(int[,]array)
{
    int count = 0;
    for (int i = 0; i < array.GetLength(0); ++i)
    {
        bool rowContainsNegativeNumber = false;
        int rowProduct = 1;
        for (int j = 0; j < array.GetLength(1); ++j)
        {
            if (array[i, j] < 0)
            { rowContainsNegativeNumber = true;  }
            else
                rowProduct *= array[i, j];
               
        }
        if (!rowContainsNegativeNumber)
        {
            count++;
            Console.WriteLine($"Row {i} Product is = {rowProduct}");
        }
      
    }
    if (count == 0)
    {
        Console.WriteLine("There is no rows that do not contain negative numbers");
    }

}//6

int maxSumDiagonales(int[,] array)
{
    int maxSum = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int row = 0, col = i;

        // Diagonal sums
        int sum1 = 0, sum2 = 0;
        while (col < array.GetLength(0) && row < array.GetLength(0))
        {
            sum1 += array[row, col];
            sum2 += array[col, row];
            row++;
            col++;
        }

        // Update maxSum with
        // the maximum sum
        maxSum = Math.Max(maxSum, Math.Max(sum1, sum2));
    }
    return maxSum;
}//7

void SumOfColsWithNoNegativeNumbers(int[,]array)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        bool colContainsNegativeNumber = false;
        int colSum = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, j] < 0)
            {
                colContainsNegativeNumber = true;
              
                break;
            }

            else
                colSum += array[i, j];
          
        }

        if (!colContainsNegativeNumber)
        {
            Console.WriteLine($"Col {j} Sum is = {colSum}");
        }
    }
} //8

int minSumModuleDiagonales(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);
    int numberOfDiagonales;

    if (rows > cols)
        numberOfDiagonales = rows * 2 - 1;
    else
        numberOfDiagonales = cols * 2 - 1;

    int[] sum = new int[numberOfDiagonales];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum[i + j] += Math.Abs(array[i, j]);
        }
    }
    return sum.Min();
}//9

void SumOfColsWithNegativeNumbers(int[,]array)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        bool colContainsNegativeNumber = false;
        int colSum = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            colSum += array[i, j];
            if (array[i, j] < 0)
            {colContainsNegativeNumber = true;
            }


        }

        if (colContainsNegativeNumber)
        {
            Console.WriteLine($"Col {j} Sum is = {colSum}");
        }
    }
}//10

void TransponateMatrix(int[,]array)
{

    rows= array.GetLength(0);
    cols= array.GetLength(1);
    int[,] trans = new int[cols,rows];
    for (int row = 0; row!=cols; row++)
    {
        for (int col = 0; col!=rows; col++)
        {
            trans[row,col] = array[col,row];
        }
    }

   PrintArray(trans);
}//11


