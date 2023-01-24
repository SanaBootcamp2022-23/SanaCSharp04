//This program performs various operations with matrix elements
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Xml.Linq;

uint rowCount, colCount;

Console.Write("Enter the number of matrix rows: ");
rowCount = uint.Parse(Console.ReadLine());
Console.Write("Enter the number of matrix columns: ");
colCount = uint.Parse(Console.ReadLine());

int[,] matrix = new int[rowCount, colCount];

//This cycle fills the cells of the matrix with pseudo-random integers
uint positiveCount = 0;
Random random = new Random();
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-9, 10);
        if (matrix[i, j] > 0)
            positiveCount++;
    }

//Displaying the contents of matrix cells on the screen
for (int i = 0; i < matrix.GetLength(0); i++)
{
    if (i % 2 == 1)
        Console.ForegroundColor = ConsoleColor.Green;
    else
        Console.ForegroundColor = ConsoleColor.Blue;

    for (int j = 0; j < matrix.GetLength(1); j++)
        Console.Write($"{matrix[i, j],5}");
    Console.WriteLine();
}

//Displaying the number of positive matrix elements on the screen
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"The number of positive matrix elements = {positiveCount}.");

//This block finds the maximum number among the numbers that occur in the matrix more than once
bool noDoubleElements = true;
int maxDoubleElement = int.MinValue;
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
        for (int ii = 0; ii < matrix.GetLength(0); ii++)
            for (int jj = 0; jj < matrix.GetLength(1); jj++)
                if ((i != ii || j != jj) && (matrix[i, j] == matrix[ii, jj]))
                {
                      noDoubleElements = false;
                      if (maxDoubleElement < matrix[i, j])
                          maxDoubleElement = matrix[i, j];
                }
if (noDoubleElements)
    Console.WriteLine("The matrix does not contain the same elements.");
else
    Console.WriteLine($"The maximum element of the matrix elements that are repeated = {maxDoubleElement}.");

//This cycle counts the number of rows that do not contain a single null element
uint rowWithoutZero = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    bool rowZero = false;
    for (int j = 0; j < matrix.GetLength(1); j++)
        if (matrix[i, j] == 0)
        {
            rowZero = true;
            break;
        }
    if (rowZero == false)
        rowWithoutZero++;
}
Console.WriteLine($"The number of rows that do not contain any null elements = {rowWithoutZero}.");

//This cycle counts the number of columns that contain at least one null element
uint colWithZero = 0;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    bool colZero = false;
    for (int i = 0; i < matrix.GetLength(0); i++)
        if (matrix[i, j] == 0)
        {
            colZero = true;
            break;
        }
    if (colZero == true)
        colWithZero++;
}
Console.WriteLine($"The number of columns that contain at least one null element = {colWithZero}.");

//This block defines the row with the longest row of identical elements
uint[] array = new uint[matrix.GetLength(0)];
for (int i = 0; i < matrix.GetLength(0); i++)
{
    uint maxRepElemInRow = 0;
    uint numberRepeatElem = 0;
    for (int j = 0; j < matrix.GetUpperBound(1); j++)
    {
        if (matrix[i, j] == matrix[i, j+1])
            numberRepeatElem++;
        else
            numberRepeatElem = 0;

        if (maxRepElemInRow < numberRepeatElem)
            maxRepElemInRow = numberRepeatElem;     
    }
    array[i] = maxRepElemInRow;
}
uint maxElement = 0;
for (int k = 0; k < matrix.GetLength(0); k++)
    if (maxElement < array[k])
        maxElement = array[k];

if (maxElement == 0)
    Console.WriteLine("This matrix has no series of elements.");
else
    for (int n = 0; n < matrix.GetLength(0); n++)
        if (maxElement == array[n])
            Console.WriteLine($"Row number with the longest row of identical elements = {n}.");

//This block calculates the product of elements in rows that do not contain negative elements
int countRowWithNegElem = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    int productRowElem = 1;
    bool rowWithoutNegElem = true;
    for (int j = 0; j < matrix.GetLength(1); j++)
        if (matrix[i, j] < 0)
        {
            countRowWithNegElem++;
            rowWithoutNegElem = false;
            break;
        }
    if (rowWithoutNegElem)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            productRowElem *= matrix[i, j];
        Console.WriteLine($"The PRODUCT of the elements of the ROW {i}, which does not contain" +
                          $" negative elements = {productRowElem}.");
    }
}
if (matrix.GetLength(0) == countRowWithNegElem)
    Console.WriteLine("This matrix has no ROWS without negative elements.");

//This block finds the maximum sum of diagonal elements that are parallel to the main diagonal of the matrix
int coordRow, coordCol;
int numbIdentDiag = Math.Abs(matrix.GetLength(0) - matrix.GetLength(1));
int rows, cols;
int numberIterations = 0;
bool matrixNotSquare = false;

switch (matrix.GetLength(0) - matrix.GetLength(1))
{   
    case 0:
            cols = 1;
            rows = 1;
            break;
    case > 0:
            cols = 1;
            rows = 1 + numbIdentDiag;
            matrixNotSquare = true;
            numberIterations = matrix.GetLength(0) - numbIdentDiag;
            break;
    case < 0:
            cols = 1 + numbIdentDiag;
            rows = 1;
            matrixNotSquare = true;
            numberIterations = matrix.GetLength(1) - numbIdentDiag;
            break;
}

int maxSumDiagElem = 0;
for (int j = cols; j < matrix.GetLength(1); j++)
{
    coordRow = 0;
    coordCol = j;
    int sumDiagonalElem = 0;
    for (int m = 0; m < matrix.GetLength(1) - j; m++)
    {
        sumDiagonalElem += matrix[coordRow, coordCol];
        coordRow++;
        coordCol++;
    }
    if (maxSumDiagElem < sumDiagonalElem)
        maxSumDiagElem = sumDiagonalElem;
}

if (matrixNotSquare)
{
    for (int rc = 1; rc <= numbIdentDiag; rc++)
    {
        if (matrix.GetLength(0) - matrix.GetLength(1) > 0)
        {
            coordRow = rc;
            coordCol = 0;
        }
        else
        {
            coordRow = 0;
            coordCol = rc;
        }
        int sumDiagonalElem = 0;
        for (int m = 0; m < numberIterations; m++)
        {
            sumDiagonalElem += matrix[coordRow, coordCol];
            coordRow++;
            coordCol++;
        }
        if (maxSumDiagElem < sumDiagonalElem)
            maxSumDiagElem = sumDiagonalElem;
    }
}

for (int i = rows; i < matrix.GetLength(0); i++)
{
    coordRow = i;
    coordCol = 0;
    int sumDiagonalElem = 0;
    for (int m = 0; m < matrix.GetLength(0) - i; m++)
    {
        sumDiagonalElem += matrix[coordRow, coordCol];
        coordRow++;
        coordCol++;
    }
    if (maxSumDiagElem < sumDiagonalElem)
        maxSumDiagElem = sumDiagonalElem;
}
Console.WriteLine($"The MAXIMUM among the sums of diagonal elements that are parallel" +
                  $" to the main diagonal of the matrix = {maxSumDiagElem}");

//This block calculates the sum of columns elements that do not contain negative elements
int countColWithNegElem = 0;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    int sumColElem = 0;
    bool colWithoutNegElem = true;
    for (int i = 0; i < matrix.GetLength(0); i++)
        if (matrix[i, j] < 0)
        {
            countColWithNegElem++;
            colWithoutNegElem = false;
            break;
        }
    if (colWithoutNegElem)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
            sumColElem += matrix[i, j];
        Console.WriteLine($"The SUM of the elements of the COLUMN {j}, which does not contain" +
                          $" negative elements = {sumColElem}.");
    }
}
if (matrix.GetLength(1) == countColWithNegElem)
    Console.WriteLine("This matrix has no COLUMNS without negative elements.");

//This block finds the minimum sum among the sums of the modules of the elements of the diagonals
//that are parallel to the side diagonal of the matrix
matrixNotSquare = false;

switch (matrix.GetLength(0) - matrix.GetLength(1))
{
    case 0:
            rows = 1;
            cols = matrix.GetUpperBound(0) - 1;
            break;
    case > 0:
            matrixNotSquare = true;
            rows = 1 + numbIdentDiag;
            cols = matrix.GetUpperBound(1) - 1;
            numberIterations = matrix.GetLength(1);
            break;
    case < 0:
            matrixNotSquare = true;
            rows = 1;
            cols = matrix.GetUpperBound(1) - 1 - numbIdentDiag;
            numberIterations = matrix.GetLength(0);
            break;
}

int minSumElemSideDiag = int.MaxValue;
for (int j = cols; j >= 0; j--)
{
    coordRow = 0;
    coordCol = j;
    int sumElemSideDiag = 0;
    for (int r = matrix.GetUpperBound(0) - j; r < matrix.GetLength(0); r++)
    {
        sumElemSideDiag += Math.Abs(matrix[coordRow, coordCol]);
        coordRow++;
        coordCol--;
    }
    if (sumElemSideDiag < minSumElemSideDiag)
        minSumElemSideDiag = sumElemSideDiag;
}

if (matrixNotSquare)
{
    for (int rc = 1; rc <= numbIdentDiag; rc++)
    {
        if (matrix.GetLength(0) - matrix.GetLength(1) > 0)
        {
            coordRow = rc;
            coordCol = matrix.GetUpperBound(1);
        }
        else
        {
            coordRow = 0;
            coordCol = matrix.GetUpperBound(1) - rc;
        }
        int sumElemSideDiag = 0;
        for (int m = 0; m < numberIterations; m++)
        {
            sumElemSideDiag += Math.Abs(matrix[coordRow, coordCol]);
            coordRow++;
            coordCol--;
        }
        if (sumElemSideDiag < minSumElemSideDiag)
            minSumElemSideDiag = sumElemSideDiag;
    }
}

for (int i = rows; i < matrix.GetLength(0); i++)
{
    coordRow = i;
    coordCol = matrix.GetUpperBound(1);
    int sumElemSideDiag = 0;
    for (int r = 0; r < matrix.GetLength(0) - i; r++)
    {
        sumElemSideDiag += Math.Abs(matrix[coordRow, coordCol]);
        coordRow++;
        coordCol--;
    }
    if (sumElemSideDiag < minSumElemSideDiag)
        minSumElemSideDiag = sumElemSideDiag;
}
Console.WriteLine($"The MINIMUM among the sums of diagonal elements parallel" +
                  $" to the side diagonal of the matrix = {minSumElemSideDiag}");

//This block calculates the sum of columns elements that contain at least one negative element
int countColWithPosElem = 0;

for (int j = 0; j < matrix.GetLength(1); j++)
{
    int sumColElem = 0;
    bool colWithPosElem = true;
    for (int i = 0; i < matrix.GetLength(0); i++)
        if (matrix[i, j] < 0)
        {
            colWithPosElem = false;
            for (int l = 0; l < matrix.GetLength(0); l++)
                sumColElem += matrix[l, j];
            Console.WriteLine($"The sum of the elements of COLUMN {j}, which contains" +
                              $" at least one negative element = {sumColElem}.");
            break;
        }
    if (colWithPosElem)
        countColWithPosElem++;
}
if (matrix.GetLength(1) == countColWithPosElem)
    Console.WriteLine("This matrix has no COLUMNS with negative elements.");

//This block transposes the matrix and displays it on the screen
int[,] transpMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

for (int r = 0; r < matrix.GetLength(1); r++)
    for (int s = 0; s < matrix.GetLength(0); s++)
        transpMatrix[r, s] = matrix[s, r]; 

for (int r = 0; r < matrix.GetLength(1); r++)
{
    for (int s = 0; s < matrix.GetLength(0); s++)
    {
        if (s % 2 == 1)
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{transpMatrix[r, s],5}");
    }
    Console.WriteLine();
}

Console.ForegroundColor = ConsoleColor.White;