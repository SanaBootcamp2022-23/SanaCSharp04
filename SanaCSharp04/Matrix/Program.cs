using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

double GetRandomDoubleNumber(Random rand, double Min, double Max) => (int)(rand.NextDouble() * (Max - Min) + Min);


double[,] GenerateMatrix(int N, int M, double Min, double Max)
{
    double[,] Matrix = new double[N, M];
    Random rand = new Random();

    for (int i = 0; i < Matrix.GetLength(0); i++)
        for (int j = 0; j < Matrix.GetLength(1); j++)
            Matrix[i, j] = GetRandomDoubleNumber(rand, Min, Max);

    return Matrix;
}

void OutputMatrix(double[,] Matrix)
{
    for (int i = 0; i < Matrix.GetLength(0); i++)
    {
        for (int j = 0; j < Matrix.GetLength(1); j++)
            Console.Write($"{Math.Round(Matrix[i, j], 2)}\t");
        Console.WriteLine();
    }
}


Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

int N = 4, M = 4, Min = -10, Max = 10;
double[,] Matrix = GenerateMatrix(N, M, Min, Max);
Console.WriteLine("Згенерована матриця: ");
OutputMatrix(Matrix);


int PositiveNumbersCount = 0;
for (int i = 0; i < Matrix.GetLength(0); i++)
    for (int j = 0; j < Matrix.GetLength(1); j++)
        if (Matrix[i, j] > 0)
            PositiveNumbersCount++;
Console.WriteLine($"\n1) Кількість додатних елементів в матриці {N}x{M}: {PositiveNumbersCount}");


Dictionary<double, int> RepeatedItems = new Dictionary<double, int>();
for (int i = 0; i < Matrix.GetLength(0); i++)
{
    for (int j = 0; j < Matrix.GetLength(1); j++)
    {
        if (RepeatedItems.ContainsKey(Matrix[i, j]))
            RepeatedItems[Matrix[i, j]]++;
        else
            RepeatedItems[Matrix[i, j]] = 1;
    }
}

List<double> ValuesRepeatedMoreThan2Times = new List<double>();
foreach (double Key in RepeatedItems.Keys)
{
    if (RepeatedItems[Key] > 1)
        ValuesRepeatedMoreThan2Times.Add(RepeatedItems[Key]);
}
if (ValuesRepeatedMoreThan2Times.Count > 0)
    Console.WriteLine($"\n2) Максимальне число яке повторюється більше 1 разу в матриці {N}x{M}: {ValuesRepeatedMoreThan2Times.Max()}");
else
    Console.WriteLine($"\n2) Максимального числа яке повторюється більше 1 разу в матриці {N}x{M} немає.");


int RowsNoZeroCount = 0;
for (int i = 0; i < Matrix.GetLength(0); i++)
{
    RowsNoZeroCount++;
    for (int j = 0; j < Matrix.GetLength(1); j++)
    {
        if (Matrix[i, j] == 0)
        {
            RowsNoZeroCount--;
            break;
        }
    }
}
Console.WriteLine($"\n3) Кількість рядків матриці {N}x{M}, які не містять жодного нульового елемента: {RowsNoZeroCount}");


int RowsZeroCount = 0;
for (int j = 0; j < Matrix.GetLength(1); j++)
{
    for (int i = 0; i < Matrix.GetLength(0); i++)
    {
        if (Matrix[i, j] == 0)
        {
            RowsZeroCount++;
            break;
        }
    }
}
Console.WriteLine($"\n4) Кількість стовпців матриці {N}x{M}, які містять хоча б один нульовий елемент: {RowsZeroCount}");


int MaxRowRepeatedNumbers = 0;
for (int i = 0; i < Matrix.GetLength(0); i++)
{
    Dictionary<double, double> Dict = new Dictionary<double, double>();

    for (int j = 0; j < Matrix.GetLength(1); j++)
    {
        if (Dict.ContainsKey(Matrix[i, j]))
            Dict[Matrix[i, j]]++;
        else
            Dict[Matrix[i, j]] = 1;
    }

    for (int k = 0; k < Dict.Count; k++)
    {
        if (Dict[Matrix[i, k]] != 1)
            MaxRowRepeatedNumbers = i;
    }
}
if (MaxRowRepeatedNumbers == 0)
    Console.WriteLine($"\n5) Номера рядка, в якому знаходиться найдовша серія однакових елементів немає.");
else
    Console.WriteLine($"\n5) Номер рядка, в якому знаходиться найдовша серія однакових елементів: {MaxRowRepeatedNumbers}");


Console.Write("\n6) ");
double[] MulRowsWithNoNegativeNumbers = new double[Matrix.GetLength(0)];
for (int i = 0; i < MulRowsWithNoNegativeNumbers.Length; i++)
    MulRowsWithNoNegativeNumbers[i] = 1;
for (int j = 0; j < Matrix.GetLength(0); j++)
{
    bool Flag = true;

    for (int i = 0; i < Matrix.GetLength(1); i++)
    {
        if (Matrix[j, i] < 0)
        {
            Flag = false;
            break;
        }
    }

    if (Flag)
    {
        for (int k = 0; k < Matrix.GetLength(1); k++)
            MulRowsWithNoNegativeNumbers[j] *= Matrix[j, k];

        Console.WriteLine($"Добуток елементів {j + 1} рядка, який не містить від'ємних елементів: {MulRowsWithNoNegativeNumbers[j]}");
    }
    else
    {
        Console.WriteLine($"{j + 1} рядок має від'ємні елементи!");
    }
}


double BottomDiagonalSum = 0;
double TopDiagonalSum = 0;
for (int i = 0; i < Matrix.GetLength(0); i++)
{
    for (int j = 0; j < Matrix.GetLength(1); j++)
    {
        if (i - 1 == j)
        {
            BottomDiagonalSum += Matrix[i, j];
        }

        if (i + 1 == j)
        {
            TopDiagonalSum += Matrix[i, j];
        }
    }
}

if (BottomDiagonalSum > TopDiagonalSum)
{
    Console.WriteLine($"\n7) Сума нижньої діагоналі більша за суму верхньої і = {BottomDiagonalSum}");
}
else
{
    if (BottomDiagonalSum < TopDiagonalSum)
    {
        Console.WriteLine($"\n7) Сума верхньої діагоналі більша за суму нижньої і = {TopDiagonalSum}");
    }
    else
    {
        Console.WriteLine($"\n7) Сума верхньої діагоналі = сумі нижньої діагоналі!");
    }
}


Console.Write("\n8)  ");
double[] SumRowsWithNoNegativeNumbers = new double[Matrix.GetLength(0)];
for (int i = 0; i < SumRowsWithNoNegativeNumbers.Length; i++)
    SumRowsWithNoNegativeNumbers[i] = 0;
for (int j = 0; j < Matrix.GetLength(1); j++)
{
    bool Flag = true;

    for (int i = 0; i < Matrix.GetLength(0); i++)
    {
        if (Matrix[i, j] < 0)
        {
            Flag = false;
            break;
        }
    }

    if (Flag)
    {
        for (int k = 0; k < Matrix.GetLength(0); k++)
            SumRowsWithNoNegativeNumbers[j] += Matrix[k, j];

        Console.WriteLine($"Сума елементів {j + 1} стовпця, який не містить від'ємних елементів: {SumRowsWithNoNegativeNumbers[j]}");
    }
    else
    {
        Console.WriteLine($"{j + 1} стовпець має від'ємні елементи");
    }
}


double BottomDiagonalModuleSum = 0;
double TopDiagonalModuleSum = 0;
for (int i = 0; i < Matrix.GetLength(0); i++)
{
    for (int j = 0; j < Matrix.GetLength(1); j++)
    {
        if (i - 1 == j)
        {
            BottomDiagonalModuleSum += Math.Abs(Matrix[i, j]);
        }

        if (i + 1 == j)
        {
            TopDiagonalModuleSum += Math.Abs(Matrix[i, j]);
        }
    }
}

if (BottomDiagonalModuleSum > TopDiagonalModuleSum)
{
    Console.WriteLine($"\n9) Сума модулів нижньої діагоналі більша за суму модулів верхньої і = {BottomDiagonalModuleSum}");
}
else
{
    if (BottomDiagonalModuleSum < TopDiagonalModuleSum)
    {
        Console.WriteLine($"\n9) Сума модулів верхньої діагоналі більша за суму модулів нижньої і = {TopDiagonalModuleSum}");
    }
    else
    {
        Console.WriteLine($"\n9) Сума модулів верхньої діагоналі = сумі модулів нижньої діагоналі");
    }
}


Console.Write("\n10)");
double[] SumRowsAlLeast1NegativeNumber = new double[Matrix.GetLength(0)];
for (int i = 0; i < SumRowsAlLeast1NegativeNumber.Length; i++)
    SumRowsAlLeast1NegativeNumber[i] = 0;
for (int i = 0; i < Matrix.GetLength(0); i++)
{
    for (int j = 0; j < Matrix.GetLength(1); j++)
    {
        if (Matrix[i, j] < 0)
        {
            for (int k = 0; k < Matrix.GetLength(1); k++)
                SumRowsAlLeast1NegativeNumber[i] += Matrix[i, k];

            Console.WriteLine($"Сума елементів {i + 1} рядка, де є хоча б 1 від'ємний елемент: {SumRowsAlLeast1NegativeNumber[i]}");
            break;
        }
    }
}

double[,] TransposedMatrix = new double[N, M];
for (int i = 0; i < Matrix.GetLength(0); i++)
{
    for (int j = 0; j < Matrix.GetLength(1); j++)
    {
        TransposedMatrix[j, i] = Matrix[i, j];
    }
}
Console.WriteLine("\n11) Транспонована матриця: ");
OutputMatrix(TransposedMatrix);
