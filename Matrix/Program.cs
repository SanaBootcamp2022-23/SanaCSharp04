using System.Text;

Console.OutputEncoding = UTF8Encoding.UTF8;

int NumPositive = 0,
    NumColumnsNull = 0,
    NumRowsNotNull = 0,
    MaxSeriesIdenticalElements = 0,
    Multiplication,
    SeriesIdenticalElements,
    NumMaxElement;
bool FlagColumnsNull, FlagRowsNull, FlagMultiplication;
string PosMaxSeries = "",
    MultiplicationRows= "";

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
        Console.Write(arr[i, j] + " ");
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
for (int i = 0; i < rows; i++)
{
    SeriesIdenticalElements = 0;
    for (int j = 0; j < columns - 1; j++)
    {
        for (int k = j + 1; k < columns; k++)
        {
            if (arr[i, j] == arr[i, k])
                SeriesIdenticalElements++;
        }
        if (SeriesIdenticalElements > MaxSeriesIdenticalElements)
        {
            MaxSeriesIdenticalElements = SeriesIdenticalElements;
            PosMaxSeries += "\nRow "+i.ToString();
        }
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
        if (arr[i,j]<0)
        {
            FlagMultiplication= false;
            break;
        }
        Multiplication *= arr[i, j];
    }
    if(FlagMultiplication)
    {
        MultiplicationRows += $"\nRow {i}: Multiplication = {Multiplication}";
    }
}
#endregion
#region виведення результатів

Console.WriteLine($"Кількість додатних елементів: {NumPositive}\n" +
$"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {MaxElement}\n" +
$"Кількість рядків, які не містять жодного нульового елемента: {NumRowsNotNull}\n" +
$"Кількість стовпців, які містять хоча б один нульовий елемент: {NumColumnsNull}\n" +
$"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {PosMaxSeries}\n" +
$"Добуток елементів в тих рядках, які не містять від’ємних елементів: {MultiplicationRows}\n" +
$"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {111}\n" +
$"Сума елементів в тих стовпцях, які не містять від’ємних елементів: {111}\n" +
$"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {11111}\n" +
$"Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: {11111}\n" +
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