using System.Numerics;
using System.Text;
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;
int positiveElementsCount = 0;
int maxValue = int.MinValue;
int maxValueCount = 0;
int rowsNullCount = 0, colsNullCount = 0, dobRowsNullCount = 1;
int rowNumberOFsimillarElements = 0, sumOFColsWithPositiveElements=0, sumOFColsWithNegativeElements = 0;
int productPositiveRows;
int k=0, l = 0;
int nulli=0, negativej=0;
int maxSummaMainDiagonal=int.MinValue;
int minSummaLateralDiagonal = int.MaxValue;
Console.Write("Введіть кількість рядків матриці: ");
int rowCount = int.Parse(Console.ReadLine());
Console.Write("Введіть кількість стовпців матриці: ");
int colCount = int.Parse(Console.ReadLine());
int[,] array = new int[rowCount, colCount];
int[,] trans = new int[colCount, rowCount];
Random random = new Random();
Console.WriteLine("Вхідна матриця:");
for (int i = 0; i < array.GetLength(0); i++) // Формування вхідної матриці
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        array[i, j] = random.Next(-5, 11);
        Console.Write($"{array[i, j],10}");
    }
    Console.WriteLine();
}
Console.WriteLine("\nДосліджуємо вхідну матрицю:\n");
for (int i = 0; i < array.GetLength(0); i++)
    for (int j = 1; j < array.GetLength(1); j++)
    {
        if (array[i, j] == array[i, j - 1]) k++;
        else k = 0;
        if (k > l)
        {
            rowNumberOFsimillarElements = i;
            l = k;
        }
        if (array[i, j - 1] * array[i, j] == 0) nulli = i;
    }
for (int i = 0; i < array.GetLength(0); i++)
    for (int j = 1; j < array.GetLength(1) + 1; j++)
    {
        if (i != nulli) dobRowsNullCount *= array[i, j - 1];
    }

for (int j = 0; j < array.GetLength(1); j++)
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (array[i, j] < 0) negativej = j;
        if (j != negativej) sumOFColsWithPositiveElements += array[i, j]; // Сумма елементів стовпців, що не містять від'ємних елементів
        if (j == negativej) sumOFColsWithNegativeElements += array[i, j]; // Сумма елементів стовпців, що містять від'ємні елементи
    }

for (int i = 0; i < array.GetLength(0); i++)         
    for (int j = 0; j < array.GetLength(1); j++)
    {
        if (array[i, j] > 0) positiveElementsCount++; // Додатні елементи
        if (maxValue < array[i, j]) // Максимальні елементи
        {
            maxValue = array[i, j];
            maxValueCount++; 
        }
        if (array[i, j] == 0) rowsNullCount++; // К-сть рядків з нульовими елементами
        if (array[i, j] == 0) colsNullCount++;// К-сть стовпців з нульовими елементами
    }
if (maxValueCount < 2) // Максимальні елементи, що зустрічаються більше ніж 2 рази
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            maxValue = int.MinValue;
            maxValueCount = 0;
            if (maxValue < array[i, j])
            {
                maxValue = array[i, j];
                maxValueCount++;
            }
        }
}
if (array.GetLength(0) == array.GetLength(1)) 
{
    for (int j = 0; j < array.GetLength(1); j++) // Максимальна сумма діагоналей, паралельних головній діагоналі
    {
        int coordRow = 0;
        int coordCol = j;
        int sumDiagonal = 0;
        for (int x = 0; x < array.GetLength(0) - j; x++)
        {
            sumDiagonal += array[coordRow, coordCol];
            coordCol++;
            coordRow++;
        }
        if (maxSummaMainDiagonal < sumDiagonal) maxSummaMainDiagonal = sumDiagonal;
    }
    for (int i = 1; i < array.GetLength(0); i++)
    {
        int coordRow = i;
        int coordCol = 0;
        int sumDiagonal = 0;
        for (int x = 0; x < array.GetLength(1) - i; x++)
        {
            sumDiagonal += array[coordRow, coordCol];
            coordCol++;
            coordRow++;
        }
        if (maxSummaMainDiagonal < sumDiagonal) maxSummaMainDiagonal = sumDiagonal;
    }
    Console.WriteLine($"Максимум серед сумм елементів діагоналей, паралельних головній діагоналі матриці: {maxSummaMainDiagonal}");
    for (int j = 1; j < array.GetLength(0); j++) // Мінімальна сумма модулів елементів діагоналей, паралельних побічній діагоналі 
    {
        int coordRow = j;
        int coordCol = array.GetLength(0) - 1;
        int sumLateralDiagonal = 0;
        while (coordRow < array.GetLength(0) && coordCol >= 0)
        {
            sumLateralDiagonal += Math.Abs(array[coordRow, coordCol]);
            coordCol--;
            coordRow++;
        }
        if (minSummaLateralDiagonal > sumLateralDiagonal) minSummaLateralDiagonal = sumLateralDiagonal;
    }
    for (int i = array.GetLength(1) - 2; i >= 0; i--)
    {
        int coordRow = 0;
        int coordCol = i;
        int sumLateralDiagonal = 0;
        while (coordRow < array.GetLength(0) && coordCol >= 0)
        {
            sumLateralDiagonal += Math.Abs(array[coordRow, coordCol]);
            coordCol--;
            coordRow++;
        }
        if (minSummaLateralDiagonal > sumLateralDiagonal) minSummaLateralDiagonal = sumLateralDiagonal;
    }
    Console.WriteLine($"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {minSummaLateralDiagonal}");
}
Console.WriteLine($"Кількість додатніх елемінтів: {positiveElementsCount}");
Console.WriteLine($"Максимальне значення, яке зустрічається більше одного разу: {maxValue}");
Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента: {rowCount-rowsNullCount}");
Console.WriteLine($"Кількість стовпців, які містять нульовий елемент: {colsNullCount}");
Console.WriteLine($"Номер рядка з найбільшою кількістю однакових елемнтів: {rowNumberOFsimillarElements}");
Console.WriteLine($"Добуток елементів рядків, що не містять нульових елементів: {dobRowsNullCount}");
Console.WriteLine($"Сумма елементів стовпців, що не містять від'ємних елементів: {sumOFColsWithPositiveElements}");
Console.WriteLine($"Сумма елементів стовпців, що містять хоча б один від'ємний елемент: {sumOFColsWithNegativeElements}");
Console.WriteLine("Транспонована матриця:");
for (int i = 0; i < array.GetLength(1); i++) // Транспонована матриця
{ 
    for (int j = 0; j < array.GetLength(0); j++)
    {
        trans[i, j] = array[j, i];
        Console.Write($"{trans[i, j],10}");
    }
    Console.WriteLine();
}