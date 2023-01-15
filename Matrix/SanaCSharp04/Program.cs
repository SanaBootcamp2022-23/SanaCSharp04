double mul = 1;
uint colCount, rowCount, positivecount = 0;
int maxRepeatingElement = int.MinValue, noZeroElementRowCount = 0, zeroElementColCount = 0,
    rowWithLongestRepeatingSequece = 0, sumOfPositiveCols = 0, sumOfNegativeCols = 0,
    paraToMainDiagMax = int.MinValue, paraToSecondaryDiagMin = int.MaxValue, coordRow, coordCol, temp;
Console.Write("Rows: ");
rowCount = uint.Parse(Console.ReadLine());
Console.Write("Columns: ");
colCount = uint.Parse(Console.ReadLine());
int[,] matrix = new int[rowCount, colCount];
Random random = new Random();
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-5, 10);
    }
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j], 5}");
    }
    Console.WriteLine();
}
for(int i = 0; i<matrix.GetLength(0);i++)
{
    for(int j = 0; j<matrix.GetLength(1);j++)
    {
        if (matrix[i,j]>0)
        {
            positivecount++;
        }
    }
}
for(int i = 0;i<matrix.GetLength(0);i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int i2 = i; i2 < matrix.GetLength(0); i2++)
        {
            for(int j2 = j+1; j2<matrix.GetLength(1);j2++)
            {
                if (matrix[i2, j2] == matrix[i,j] && matrix[i,j]>maxRepeatingElement)
                {
                    maxRepeatingElement = matrix[i, j];
                }
            }
        }
    }
}
for(int i = 0; i<matrix.GetLength(0); i++)
{
     temp = 0;
    for(int j = 0; j<matrix.GetLength(1);j++)
    {
        if (matrix[i, j] == 0)
            temp++;
    }
    if (temp == 0)
        noZeroElementRowCount++;
}
for(int j = 0; j < matrix.GetLength(1);j++)
{
     temp = 0;
    for(int i = 0; i < matrix.GetLength(0);i++)
    {
        if (matrix[i, j] == 0)
            temp++;
    }
    if (temp > 0)
        zeroElementColCount++;
}
int tempmax = 0;
for(int i = 0;i<matrix.GetLength(0);i++)
{
     temp = 0;
    for(int j =1;j<matrix.GetLength(1);j++)
    {
        if (matrix[i, j] == matrix[i, j - 1])
        {
            temp++;
        }
    }
    if (temp > tempmax)
    {
        tempmax = temp;
        rowWithLongestRepeatingSequece = i;
    }
}
for (int i = 0; i < matrix.GetLength(0); i++)
{
     temp = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            temp++;      
        }
    }
    if (temp == 0)
    {
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            mul *= matrix[i, k];
        }
    }
}
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        coordRow = 0;
        coordCol = j;
        int sum = 0;
        while (coordRow < matrix.GetLength(0) && coordCol < matrix.GetLength(1))
        {
            sum+=matrix[coordRow, coordCol];
            coordRow++;
            coordCol++;
        }
        if (sum > paraToMainDiagMax)
        {
            paraToMainDiagMax = sum;
        }
    }
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        coordRow = i;
        coordCol = 0;
        int sum = 0;
        while (coordRow < matrix.GetLength(0) && coordCol < matrix.GetLength(1))
        {
            sum += matrix[coordRow, coordCol];
            coordRow++;
            coordCol++;
        }
        if (sum > paraToMainDiagMax)
        {
            paraToMainDiagMax = sum;
        }
    }   
for (int j = 0; j < matrix.GetLength(1);j++)
{
     temp = 0;
    for(int i = 0;i<matrix.GetLength(0);i++)
    {
        if (matrix[i,j]<0)
        {
            temp++;
        }
    }
    if(temp==0)
    {
        for(int k = 0;k<matrix.GetLength(0);k++)
        {
            sumOfPositiveCols += matrix[k, j];
        }
    }
}
for (int j = 0; j < matrix.GetLength(1); j++)
{
     temp = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            temp++;
        }
    }
    if (temp > 0)
    {
        for (int k = 0; k < matrix.GetLength(0); k++)
        {
            sumOfNegativeCols += matrix[k, j];
        }
    }
}
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        coordRow = i;
        coordCol = matrix.GetLength(1)-1;
        while (coordRow < matrix.GetLength(0)&&coordCol>=0)
        {
            sum += Math.Abs(matrix[coordRow, coordCol]);
            coordRow++;
            coordCol--;
        }
        if(sum<paraToSecondaryDiagMin)
        {
            paraToSecondaryDiagMin = sum;
        }
    }
    for(int j = matrix.GetLength(1)-2;j>=0;j--)
    {
        coordRow = 0;
        coordCol = j;
        int sum = 0;
        while (coordRow < matrix.GetLength(0) && coordCol >= 0)
        {
            sum += Math.Abs(matrix[coordRow, coordCol]);
            coordRow++;
            coordCol--;
        }
        if (sum < paraToSecondaryDiagMin)
        {
            paraToSecondaryDiagMin = sum;
        }
    }
Console.WriteLine($"Number of positive values in matrix: {positivecount}");
Console.WriteLine($"Max repeating value in matrix: {maxRepeatingElement}");
Console.WriteLine($"Number of rows without zero value element: {noZeroElementRowCount}");
Console.WriteLine($"Number of columns with at least one zero value element: {zeroElementColCount}");
Console.WriteLine($"Row with lonegst repeating sequence of elements: {rowWithLongestRepeatingSequece}");
Console.WriteLine($"Multiplication of elements in rows with no negative elements: {mul}");
Console.WriteLine($"Max sum of elements in diagonals parallel to the main diagonal: {paraToMainDiagMax}");
Console.WriteLine($"Sum of elements in columns without negative integers: {sumOfPositiveCols}");
Console.WriteLine($"Sum of elements in columns with negative integers: {sumOfNegativeCols}");
Console.WriteLine($"Min sum of absolute value of elements in diagonals parallel to secondary diagonal:{paraToSecondaryDiagMin}");
Console.WriteLine("Transposed matrix:");
    for(int i = 0; i<matrix.GetLength(1);i++)
    {
        for(int j = 0;j<matrix.GetLength(0);j++)
        {
            Console.Write($"{matrix[j, i],5}");
        }
        Console.WriteLine();
    }