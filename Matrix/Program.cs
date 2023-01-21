using System.Text;

Console.OutputEncoding = UTF8Encoding.UTF8;

int NumPositive = 0,
    NumColumnsNull = 0,
    NumRowsNotNull = 0,
    MaxSumDiagonals,
    Multiplication,
    SeriesIdenticalElements,
    NumMaxElement,
    SumColumns,
    MinSumDiagonals;
bool FlagColumnsNull, FlagRowsNull, FlagMultiplication, FlagNegativeColumns;
string OutMaxSeries = "",
    MultiplicationRows = "",
    OutMaxSumDiagonals = "",
    OutSumColumns = "",
    OutMinSumDiagonals = "",
    OutSumNegativeColumns = "";

#region зчитування масиву
Console.Write("Введіть параметри матриці\nРядків: ");
int rows = int.Parse(Console.ReadLine());
Console.Write("Стовпців: ");
int columns = int.Parse(Console.ReadLine());

int[,] arr = new int[rows, columns];
for (int i = 0; i < rows; i++)
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"Arr[{i}][{j}]=");
        arr[i, j] = int.Parse(Console.ReadLine());
    }
Console.Clear();
Console.WriteLine("Матриця: \n" +
    "---");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
        Console.Write($"{arr[i, j],3} ");
    Console.WriteLine();
}
Console.WriteLine("---");
#endregion
#region кількість додатних елементів
for (int i = 0; i < rows; i++)
    for (int j = 0; j < columns; j++)
        if (arr[i, j] > 0) NumPositive++;
#endregion
#region максимальне із чисел, що зустрічається в заданій матриці більше одного разу
int MaxElement = arr[0, 0];
foreach (int i in arr)
{
    if (i >= MaxElement)
    {
        NumMaxElement = 0;
        foreach (int j in arr)
        {
            if (j == i)
            {
                NumMaxElement++;
                if (NumMaxElement >= 2)
                {
                    MaxElement = i;
                    break;
                }
            }
        }
    }
}
#endregion
#region кількість рядків, які не містять жодного нульового елемента
for (int i = 0; i < rows; i++)
{
    FlagRowsNull = false;
    for (int j = 0; j < columns; j++)
    {
        if (arr[i, j] == 0)
        {
            FlagRowsNull = true;
            break;
        }
    }
    if (!FlagRowsNull) NumRowsNotNull++;
}
#endregion
#region кількість стовпців, які містять хоча б один нульовий елемент
for (int j = 0; j < columns; j++)
{
    FlagColumnsNull = false;
    for (int i = 0; i < rows; i++)
    {
        if (arr[i, j] == 0)
        {
            FlagColumnsNull = true;
            break;
        }
    }
    if (FlagColumnsNull) NumColumnsNull++;
}
#endregion
#region номер рядка, в якому знаходиться найдовша серія однакових елементів
int MaxSeriesIdenticalElements = 0;
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns - 1; j++)
    {
        SeriesIdenticalElements = 0;
        for (int k = j + 1; k < columns; k++)
        {
            if (arr[i, j] == arr[i, k]) SeriesIdenticalElements++;
        }
        if (SeriesIdenticalElements > MaxSeriesIdenticalElements)
        {
            MaxSeriesIdenticalElements = SeriesIdenticalElements;
            OutMaxSeries = "";
        }
        if (SeriesIdenticalElements == MaxSeriesIdenticalElements) OutMaxSeries += $"\nRow: {i} Series: {MaxSeriesIdenticalElements + 1}";
    }
}
#endregion
#region Добуток елементів в тих рядках, які не містять від’ємних елементів
for (int i = 0; i < rows; i++)
{
    Multiplication = 1;
    FlagMultiplication = true;
    for (int j = 0; j < columns; j++)
    {
        if (arr[i, j] < 0)
        {
            FlagMultiplication = false;
            break;
        }
        Multiplication *= arr[i, j];
    }
    if (FlagMultiplication)
    {
        MultiplicationRows += $"\nRow {i}: Multiplication = {Multiplication}";
    }
}
#endregion
#region Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці
int NumDiagonals = rows + columns;
int[] SumDiagonals = new int[NumDiagonals];
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        SumDiagonals[columns - (j - i)] += arr[i, j];
    }
}
MaxSumDiagonals = SumDiagonals[NumDiagonals - 1];
for (int i = 1; i < NumDiagonals; i++)
    if (SumDiagonals[i] >= MaxSumDiagonals && i != columns)
    {
        if (SumDiagonals[i] > MaxSumDiagonals)
        {
            MaxSumDiagonals = SumDiagonals[i];
            OutMaxSumDiagonals = "";
        }
        OutMaxSumDiagonals += $"\n {i}-діагональ {MaxSumDiagonals}";
    }
#endregion
#region Сума елементів в тих стовпцях, які не містять від’ємних елементів
for (int j = 0; j < columns; j++)
{
    FlagNegativeColumns = false;
    SumColumns = 0;
    for (int i = 0; i < rows; i++)
    {
        if (arr[i, j] < 0)
        {
            FlagNegativeColumns = true;
            break;
        }
        else
        {
            SumColumns += arr[i, j];
        }
    }
    if (!FlagNegativeColumns) OutSumColumns += $"\nColumn {j}, Sum={SumColumns}";
}
#endregion
#region Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці
int[] SumSecondDiagonals = new int[NumDiagonals];
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        SumSecondDiagonals[i + j + 1] += Math.Abs(arr[i, j]);
    }
}
MinSumDiagonals = SumSecondDiagonals[NumDiagonals - 1];
for (int i = 1; i < NumDiagonals; i++)
    if (SumSecondDiagonals[i] <= MinSumDiagonals && i != columns)
    {
        if (SumSecondDiagonals[i] < MinSumDiagonals)
        {
            MinSumDiagonals = SumSecondDiagonals[i];
            OutMinSumDiagonals = "";
        }
        OutMinSumDiagonals += $"\n {i}-діагональ {MinSumDiagonals}";
    }
#endregion
#region Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент
for (int j = 0; j < columns; j++)
{
    FlagNegativeColumns = false;
    SumColumns = 0;
    for (int i = 0; i < rows; i++)
    {
        SumColumns += arr[i, j];
        if (arr[i, j] < 0)
        {
            FlagNegativeColumns = true;
        }
    }
    if (FlagNegativeColumns) OutSumNegativeColumns += $"\nColumn {j}, Sum={SumColumns}";
}
#endregion
#region виведення результатів
Console.WriteLine($"Кількість додатних елементів: {NumPositive}\n" +
$"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {MaxElement}\n" +
$"Кількість рядків, які не містять жодного нульового елемента: {NumRowsNotNull}\n" +
$"Кількість стовпців, які містять хоча б один нульовий елемент: {NumColumnsNull}\n" +
$"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {OutMaxSeries}\n" +
$"Добуток елементів в тих рядках, які не містять від’ємних елементів: {MultiplicationRows}\n" +
$"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {OutMaxSumDiagonals}\n" +
$"Сума елементів в тих стовпцях, які не містять від’ємних елементів: {OutSumColumns}\n" +
$"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {OutMinSumDiagonals}\n" +
$"Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: {OutSumNegativeColumns}\n" +
$"Транспонована матриця:\n" +
"---");

for (int j = 0; j < columns; j++)
{
    for (int i = 0; i < rows; i++)
    {
        Console.Write($"{arr[i, j],3} ");
    }
    Console.WriteLine();
}
Console.WriteLine("---");
#endregion