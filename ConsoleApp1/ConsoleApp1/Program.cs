using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection;

uint rows, cols;
uint poscount = 0, rowsoutzero = 0, colzero = 0;
double maxDup = double.MinValue;

Console.WriteLine("Write count of raws");
rows = uint.Parse(Console.ReadLine());
Console.WriteLine("Write count of columns");
cols = uint.Parse(Console.ReadLine());
double[,] matrix = new double[rows, cols];
Console.WriteLine("Begining with matrix:");
Random random = new Random();
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-1, 4); ;
        if (matrix[i, j] > 0)
            poscount++; //1

    }
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]}\t");
    }
    Console.WriteLine();
}


//2
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > maxDup)
        {
            for (int a = 0; a < matrix.GetLength(1); a++)
            {
                if (j == a)
                {
                    continue;
                }
                if (matrix[i, j] == matrix[i, a])
                {
                    maxDup = matrix[i, j];
                    break;
                }
            }
        }
    }
}

//3
int counter = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
        {
            counter++;
        }
    }
    if (counter == 0)
        rowsoutzero++;
}

//4
int count = 0;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] == 0)
        {
            count++;
        }
    }
    if (count > 0)
        colzero++;
}

//5
int streakrow = 0;
int allrowstreak = 0;
int indexstreak = 0;
int tmpj = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == matrix[i, tmpj])
        {
            tmpj = j;
            streakrow++;
        }
        else
        {
            if (streakrow > allrowstreak)
            {
                streakrow = allrowstreak;
                indexstreak = i;
            }
            streakrow = 0;
        }
    }
    if (streakrow > allrowstreak)
    {
        streakrow = allrowstreak;
        indexstreak = i + 1;
    }
}
//6
for (int i = 0; i < matrix.GetLength(0); i++)
{
    double dobutok = 1;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            break;
        }
        else
        {
            dobutok *= matrix[i, j];
            if (j == matrix.GetLength(1) - 1)
            {
                Console.WriteLine($"Product of elements in rows without negative elements  {dobutok}");
            }
        }
    }
}
//8
for (int j = 0; j < matrix.GetLength(1); j++)
{
    double suma = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            break;
        }
        else
        {
            suma += matrix[i, j];
            if (i == matrix.GetLength(0) - 1)
            {
                Console.WriteLine($"Sum in columns without negative elements {suma}");
            }
        }
    }
}
//11
double temp;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < i; j++)
    {
        temp = matrix[i, j];
        matrix[i, j] = matrix[j, i];
        matrix[j, i] = temp;
    }
}
Console.WriteLine("Transponned matrix");
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]}\t");
    }
    Console.WriteLine();
}



//10
for (int i = 0; i < matrix.GetLength(0); i++)
{
    double tmp = 0;
    double sumcol = 0;
    for (int j = 0; j < i; j++)
    {
        if (matrix[i, j] < 0)
            tmp++;
        if (tmp > 0)
        {
            sumcol += matrix[i, j];
            if (j == matrix.GetLength(0) - 1)
            {
                Console.WriteLine($"Sum of elements in columns which have one or more negative numbers  {sumcol}");
            }
        }


    }
}


Console.WriteLine($"Max duplicate number   {maxDup}");
Console.WriteLine($"Count of positive numbers  {poscount}");
Console.WriteLine($"Count of rows without zero  {rowsoutzero}");
Console.WriteLine($"Count of columns with zero  {colzero}");
Console.WriteLine($"Row with max duplicating streak numbers {indexstreak}");