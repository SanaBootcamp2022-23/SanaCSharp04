
using System.Globalization;

int IntInput(string text)
{
    bool check = false;
    int val = 0;
    while (!check || val < 1)
    {
        Console.Write(text);
        check = int.TryParse(Console.ReadLine(), out val);
        if (!check || val < 1)
        {
            Console.WriteLine("Incorect input, you must input an integer above 0.");
        }
    }
    return val;
}

//input variables
int n = IntInput("n = ");
int m = IntInput("m = ");
int[][] arr = new int[n][];

//calcualtion variables
int positiveElem = 0;

var dictDuplicate = new Dictionary<int, int>();

int biggestDuplicate = -100;
int biggestDuplicateVal = -100;

int rowsWithZero = 0;
int rowsWithoutZero;

int biggestSeria = 0;
int biggestSeriaRow = 0;

int?[] positiveArrSum = new int?[n];

int maxMainDiagonalSum = int.MinValue;

int?[] positiveColumnSum = new int?[m];

int minSecondDiagonalSum = int.MaxValue;

int?[] negativeColumnSum = new int?[m];

int[,] transposeArr;

Random random = new Random();
Console.WriteLine("\nGenerated array is: ");
for (int i = 0; i < n; i++)
{
    arr[i] = new int[m];

    int tmpSeria = 1;

    positiveArrSum[i] = 0;
    bool positiveArrSumLock = false;
    for (int j = 0; j < m; j++)
    {
        arr[i][j] = random.Next(-5, 25);
        Console.Write($"{arr[i][j]}   ");

        if (arr[i][j] > 0)
        {
            positiveElem++;
        }

        dictDuplicate.TryGetValue(arr[i][j], out int count);
        dictDuplicate[arr[i][j]] = count + 1;

        if (j != 0 && arr[i][j] == arr[i][j - 1])
        {
            tmpSeria++;
            if (tmpSeria > biggestSeria)
            {
                biggestSeria = tmpSeria;
                biggestSeriaRow = i + 1;
            }
        }
        else
        {
            tmpSeria = 1;
        }

        if (arr[i][j] < 0)
        {
            positiveArrSumLock = true;
        }
        else
        {
            positiveArrSum[i] += arr[i][j];
        }
    }
    if (arr[i].Contains(0))
    {
        rowsWithZero++;
    }

    if (positiveArrSumLock)
    {
        positiveArrSum[i] = null;
    }

    Console.WriteLine();
}
rowsWithoutZero = arr.Length - rowsWithZero;

Console.WriteLine();
foreach (var pair in dictDuplicate)
{
    if (pair.Value < 2)
    {
        dictDuplicate.Remove(pair.Key);
    }
    else
    {
        if (pair.Value > biggestDuplicateVal || (pair.Value == biggestDuplicateVal && pair.Key > biggestDuplicate))
        {
            biggestDuplicate = pair.Key;
            biggestDuplicateVal = pair.Value;
        }
        Console.WriteLine($"Value {pair.Key} occurred {pair.Value} times.");
    }
}

for (int step = 1; step < m; step++)
{
    int diagonalSum = 0;
    for (int i = 0; i < n; i++)
    {
        int j = i + step;
        if (j < 0 || j + 1 > m)
        {
            continue;
        }
        diagonalSum += arr[i][j];
    }
    if (diagonalSum > maxMainDiagonalSum)
    {
        maxMainDiagonalSum = diagonalSum;
    }
}
for (int step = 1; step < n; step++)
{
    int diagonalSum = 0;
    for (int i = 0; i < n; i++)
    {
        int j = i - step;
        if (j < 0 || j + 1 > m)
        {
            continue;
        }
        diagonalSum += arr[i][j];
    }
    if (diagonalSum > maxMainDiagonalSum)
    {
        maxMainDiagonalSum = diagonalSum;
    }
}

for (int j = 0; j < m; j++)
{
    positiveColumnSum[j] = 0;
    bool hasNegative = false;
    for (int i = 0; i < n; i++)
    {
        if (arr[i][j] < 0)
        {
            hasNegative = true;
        }
        positiveColumnSum[j] += arr[i][j];
    }
    if (hasNegative)
    {
        negativeColumnSum[j] = positiveColumnSum[j];
        positiveColumnSum[j] = null;
    }
}

for (int step = 1; step < n; step++)
{
    int diagonalSum = 0;
    for (int i = 0; i < n; i++)
    {
        int j = (m - 1) - step - i;
        if (j < 0 || j + 1 > m)
        {
            continue;
        }
        diagonalSum += arr[i][j];
    }
    diagonalSum = Math.Abs(diagonalSum);
    if (diagonalSum < minSecondDiagonalSum)
    {
        minSecondDiagonalSum = diagonalSum;
    }
}
for (int step = 1; step < n; step++)
{
    int diagonalSum = 0;
    for (int i = 1; i < n; i++)
    {
        int j = (m - 1) + step - i;
        if (j < 0 || j + 1 > m)
        {
            continue;
        }
        diagonalSum += arr[i][j];
    }
    diagonalSum = Math.Abs(diagonalSum);
    if (diagonalSum < minSecondDiagonalSum)
    {
        minSecondDiagonalSum = diagonalSum;
    }
}

transposeArr = new int[m, n];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        transposeArr[j, i] = arr[i][j];
    }
}

//results
Console.WriteLine("\nResults:");
Console.WriteLine($"Positive elements amount: {positiveElem}");
Console.WriteLine($"Biggest duplicate: {biggestDuplicate} ({biggestDuplicateVal} times)");
Console.WriteLine($"Rows without zero: {rowsWithoutZero}");
Console.WriteLine($"Rows with zero: {rowsWithZero}");
Console.WriteLine($"Biggest seria row: {biggestSeriaRow} ({biggestSeria} times)");
Console.WriteLine("Sum of elements in rows without negative elements:");
for (int i = 0; i < positiveArrSum.Length; i++)
{
    Console.WriteLine($"{i + 1} row: {positiveArrSum[i]}");
}
Console.WriteLine($"Biggest parallel to main diagonal sum: {maxMainDiagonalSum}");
Console.WriteLine("Sum of columns without negative elements:");
for (int j = 0; j < positiveColumnSum.Length; j++)
{
    Console.WriteLine($"{j + 1} column: {positiveColumnSum[j]}");
}
Console.WriteLine($"Smallest parallel to secondary diagonal sum: {minSecondDiagonalSum}");
Console.WriteLine("Sum of columns with negative elements:");
for (int j = 0; j < negativeColumnSum.Length; j++)
{
    Console.WriteLine($"{j + 1} column: {negativeColumnSum[j]}");
}
Console.WriteLine("\nTransponsed array is: ");
for (int i = 0; i < transposeArr.GetLength(0); i++)
{
    Console.WriteLine();
    for (int j = 0; j < transposeArr.GetLength(1); j++)
    {
        Console.Write($"{transposeArr[i, j]}   ");
    }
}