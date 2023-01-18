using Matrix;
using System.Runtime.Serialization.Formatters;

int[,] matrix;
int rows, columns,
posCount = 0;
do
{
    Console.WriteLine("Please enter rows and columns for square matrix: ");
    Console.Write("Enter rows: ");
    rows = int.Parse(Console.ReadLine());
    Console.Write("Enter columns: ");
    columns = int.Parse(Console.ReadLine());
} while (rows != columns || columns <= 0 || rows <= 0);

matrix = MatrixMethods.FillMatrix(rows, columns);
MatrixMethods.PrintMatrix(matrix);

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > 0)
        {
            posCount++;
        }
    }
}
Console.WriteLine($"1. Count of positive elems in matrix: {posCount}");


int maxElem = int.MinValue;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > maxElem)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                if (j == k) continue;
                if (matrix[i, j] == matrix[i, k])
                {
                    maxElem = matrix[i, j];
                    break;
                }
            }
        }
    }
}
Console.WriteLine($"2. Max element that encounters more than once: {maxElem}");


int rowsCount = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
        {
            rowsCount++;
            break;

        }
    }
}
int rowsWithoutZero = rows;
Console.WriteLine($"3. Count of rows without zero is: {rowsWithoutZero - rowsCount}");


int columnsCount = 0;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] == 0)
        {
            columnsCount++;
            break;
        }
    }
}
Console.WriteLine($"4. Count of columns with at least 1 zero is: {columnsCount}");


int maxseriya = 0, rowWithMaxSeriya = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    int seriya = 0;
    for (int j = 1; j < matrix.GetLength(1); j++)
        if (matrix[i, j] == matrix[i, j - 1])
            seriya++;
        else
        {
            if (seriya > maxseriya)
            {
                maxseriya = seriya;
                rowWithMaxSeriya = i;
            }
            seriya = 0;
        }
    if (seriya > maxseriya)
    {
        maxseriya = seriya;
        rowWithMaxSeriya = i;
    }
}
Console.WriteLine($"5. Row with max series of same numbers: {rowWithMaxSeriya + 1}");


int tmpMultiple = 1;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            break;
        }
        else
        {
            tmpMultiple *= matrix[i, j];
            if (j == matrix.GetLength(1) - 1)
            {
                Console.WriteLine($"6. Positive row's number {i + 1} product is: {tmpMultiple}");
            }
        }
    }
    tmpMultiple = 1;
}


int coordRow, coordCol, maxUpperDiag = int.MinValue, maxLowerDiag = int.MinValue;
for (int j = 1; j < matrix.GetLength(1); j++)
{
    coordRow = 0;
    coordCol = j;
    int summary = 0;
    for (int i = 0; i < matrix.GetLength(0) - j; i++)
    {
        summary += matrix[coordRow, coordCol];
        coordRow++;
        coordCol++;
    }

    if (summary > maxUpperDiag)
    {
        maxUpperDiag = summary;
    }
}
for (int i = 1; i < matrix.GetLength(0); i++)
{
    coordRow = i;
    coordCol = 0;
    int summary = 0;
    for (int j = 0; j < matrix.GetLength(1) - i; j++)
    {
        summary += matrix[coordRow, coordCol];
        coordRow++;
        coordCol++;
    }
    if (summary > maxLowerDiag)
    {
        maxLowerDiag = summary;
    }
}
if (maxUpperDiag > maxLowerDiag)
{
    Console.WriteLine($"7. Max besides elements sums of diagonals, parallel to main matrix diagonal: {maxUpperDiag}");
}
else
{
    Console.WriteLine($"7. Max besides elements sums of diagonals, parallel to main matrix diagonal: {maxLowerDiag}");
}

int tmpSum = 0;
for (int j = 0; j < matrix.GetLength(0); j++)
{
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        if (matrix[i, j] < 0)
        {
            break;
        }
        else
        {
            tmpSum += matrix[i, j];
            if (i == matrix.GetLength(0) - 1)
            {
                Console.WriteLine($"8. Positive column's number {j + 1} sum is: {tmpSum}");
            }
        }
    }
    tmpSum = 0;
}

int coordRow1, coordCol1, maxUpperDiag1 = int.MaxValue, maxLowerDiag1 = int.MaxValue;
for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
{
    coordRow1 = 0;
    coordCol1 = j;
    int summary = 0;
    for (int i = 0; i < matrix.GetLength(0) - j; i++)
    {
        summary += Math.Abs(matrix[coordRow1, coordCol1]);
        coordRow1++;
        coordCol1++;
    }

    if (summary < (maxUpperDiag1))
    {
        maxUpperDiag1 = summary;
    }
}
for (int i = 1; i < matrix.GetLength(0); i++)
{
    coordRow1 = 1;
    coordCol1 = 4;
    int summary = 0;
    for (int j = matrix.GetLength(1) - 1; j > 0; j--)
    {
        summary += Math.Abs(matrix[coordRow1, coordCol1]);
        coordRow1++;
        coordCol1--;
    }
    if (summary < maxLowerDiag1)
    {
        maxLowerDiag1 = summary;
    }
}
if (maxUpperDiag1 < maxLowerDiag1)
{
    Console.WriteLine($"9. Minimal besides elements sums of diagonals modules, parallel to sub matrix diagonal: {maxUpperDiag1}");
}
else
{
    Console.WriteLine($"9. Minimal besides elements sums of diagonals modules, parallel to sub matrix diagonal: {maxLowerDiag1}");
}

int sumOfElemWithNegNum, n;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            sumOfElemWithNegNum = 0;
            for (n = 0; n < matrix.GetLength(1); n++)
            {
                sumOfElemWithNegNum += matrix[n, j];
            }
            Console.WriteLine($"10. Sum of elements in {j + 1} column, that contains at least 1 negative element: {sumOfElemWithNegNum} ");
            break;
        }
    }
}

int tmp;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < i; j++)
    {
        tmp = matrix[i, j];
        matrix[i, j] = matrix[j, i];
        matrix[j, i] = tmp;
    }
}
Console.WriteLine("11. There is transposed matrix: ");
MatrixMethods.PrintMatrix(matrix);