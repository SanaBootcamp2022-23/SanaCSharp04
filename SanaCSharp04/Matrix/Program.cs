using System.Diagnostics.CodeAnalysis;

uint rowCount, colCount;
uint positiveCount = 0, negativeCount = 0;
double maxValue = double.MinValue;
Console.WriteLine("Row Count: ");
rowCount = uint.Parse(Console.ReadLine());
Console.WriteLine("Columns Count: ");
colCount = uint.Parse(Console.ReadLine());
double [,] matrix = new double[rowCount, colCount];
Random random = new Random();
double rowNum = 0, colNum = 0;
int find = 0, maxF = 0;
double summa = 0, max = 0, curr = 0, dobutok = 0;
double tmp = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = Math.Round(random.Next(-9, 9) + random.NextDouble(),3);
        if(matrix[i, j] > 0)
            positiveCount++;
        if(matrix[i, j] < 0)
            negativeCount++;
    }
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if(matrix[i, j] > maxValue)
            maxValue = matrix[i, j];
    }
        for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]}\t");
    }
    Console.WriteLine();
}
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
            break;
        if (matrix[i, j] > 0)
            rowNum = matrix.GetLength(0);
    }
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
            colNum = matrix.GetLength(1);

        if (matrix[i, j] > 0)
            break;
          
    }
for(int i = 0; i < matrix.GetLength(0); i++)
    for(int j = 0; j < matrix.GetLength(1); j++)
    {
        for(int k = j+1; k < 5; k++)
        {
            if (matrix[i, j] == matrix[i, k])
                find++;
        }
        if (find > maxF)
        {
            rowCount = (uint)i;
            maxF = find;
            find = 0;
        }
    }

for(int i=0; i < matrix.GetLength(0); i++)
    for(int j=0 ; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > 0)
            summa += matrix[i, j]; 
    }
double r = 0, p = 0;
for (int i = 0; p < r - 1; p++)
{
    curr = 0;
    
    for (i = 0; i < r - p - 1; i++)
    {
        curr += matrix[i, (int)(i + 1 + p)];
    }
    if (p == 0)
        max = curr;
    else if
        (max < curr)
        max = curr;
    

}

for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > 0)
            dobutok *= matrix[i, j];
    }

for(int i = 0; i < rowCount; i++)
    for (int j = 0; j < colCount; j++)
    {
        tmp = matrix[i, j];
        matrix[i, j] = matrix[j, i];
        matrix[j, i] = tmp;
    }



Console.WriteLine($"Positive count = {positiveCount}");
Console.WriteLine($"Max Value = {maxValue}");
Console.WriteLine($"Rows without 0 - {rowNum}");
Console.WriteLine($"Rows with 0 - {colNum}");
Console.WriteLine($"Row number: {maxF}");
Console.WriteLine($"Summa: {summa}");
Console.WriteLine($"Max= {max}");
Console.WriteLine($"Dobutok = {dobutok}");
Console.WriteLine($"Trans = {tmp}");
