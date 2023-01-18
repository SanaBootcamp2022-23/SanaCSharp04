// See https://aka.ms/new-console-template for more information
int rowCount, colCount;
int counter, maxRepeatRow = 0, coordRow, coordCol;
int positiveCount = 0, rowsWithoutZero = 0, colWithZero = 0, rowWithMaxRepetition = 0;
double maxRepeatingValue = 0, multiplicationResult = 0, summa = 0, maxDiagonalSum = int.MinValue, sumPositiveCols = 0, minDiagonalSum = int.MaxValue, sumNegativeCols = 0;

Console.WriteLine("Row Count:");
rowCount = int.Parse(Console.ReadLine());
Console.WriteLine("Columns Count:");
colCount = int.Parse(Console.ReadLine());

double[,] matrix = new double[rowCount, colCount];
Random random= new Random();
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-1000, 1001);
        Console.Write($"{matrix[i, j]} \t");
       
        
        if (matrix[i, j] > 0)       // кількість позитивних елементів
            positiveCount++;

        for (int i2 = i; i2 < matrix.GetLength(0); i2++)        //найбільше число що повторюється
        {
            for (int j2 = j + 1; j2 < matrix.GetLength(1); j2++)
            {
                if (matrix[i2, j2] == matrix[i, j] && matrix[i, j] > maxRepeatingValue)
                {
                    maxRepeatingValue = matrix[i, j];
                }
            }
        }
    }
    Console.WriteLine();
}

for (int i = 0; i < matrix.GetLength(0); i++)       // кількість рядків без нуля
{
    counter = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
            counter++;
    }
    if (counter == 0)
        rowsWithoutZero++;
}

for (int j = 0; j < matrix.GetLength(0); j++)       // кількість стовпців з нулем
{
    counter = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        if (matrix[i, j] == 0)
            counter++;
    }
    if (counter > 0)
        colWithZero++;
}

for (int i = 0; i < matrix.GetLength(0); i++)   // рядок, де більше всього повторень
{
    counter = 0;
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == matrix[i, j - 1])
        {
            counter++;
        }
    }
    if (counter  > maxRepeatRow)
    {
        maxRepeatRow = counter;
        rowWithMaxRepetition = i;
    }
}

for (int i = 0; i < matrix.GetLength(0); i++)   //добуток елементів рядків , які не містять від’ємних елементів
{
    counter = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            counter++;
        }
    }
    if (counter == 0)
    {
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            multiplicationResult  *= matrix[i, k];
        }
    }
}

for (int j = 1; j < matrix.GetLength(1); j++)   // максимальна сума елементів діагоналі, паралельній головній діагоналі матриці
{
    coordRow = 0;
    coordCol = j;
    summa = 0;
    while (coordRow < matrix.GetLength(0) && coordCol < matrix.GetLength(1))
    {
        summa += matrix[coordRow, coordCol];
        coordRow++;
        coordCol++;
    }
    if (summa > maxDiagonalSum)
    {
        maxDiagonalSum = summa;
    }
}

for (int i = 1; i < matrix.GetLength(0); i++)   // сума елементів у стовпцях, які не містять від’ємних елементів
{
    coordRow = i;
    coordCol = 0;
    summa = 0;
    while (coordRow < matrix.GetLength(0) && coordCol < matrix.GetLength(1))
    {
        summa += matrix[coordRow, coordCol];
        coordRow++;
        coordCol++;
    }
    if (summa > maxDiagonalSum)
    {
        maxDiagonalSum = summa;
    }
}

for (int j = 0; j < matrix.GetLength(1); j++)
{
    counter = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            counter++;
        }
    }
    if (counter == 0)
    {
        for (int a = 0; a < matrix.GetLength(0); a++)
        {
            sumPositiveCols += matrix[a , j];
        }
    }
}

for (int i = 1; i < matrix.GetLength(0); i++)   // мінімальна сума модулів елементів діагоналі паралельній побічній діагоналі матриці
{
    summa = 0;
    coordRow = i;
    coordCol = matrix.GetLength(1) - 1;
    while (coordRow < matrix.GetLength(0) && coordCol >= 0)
    {
        summa += Math.Abs(matrix[coordRow, coordCol]);
        coordRow++;
        coordCol--;
    }
    if (summa < minDiagonalSum)
    {
        minDiagonalSum = summa;
    }
}
for (int j = matrix.GetLength(1) - 2; j >= 0; j--)
{
    coordRow = 0;
    coordCol = j;
    summa = 0;
    while (coordRow < matrix.GetLength(0) && coordCol >= 0)
    {
        summa += Math.Abs(matrix[coordRow, coordCol]);
        coordRow++;
        coordCol--;
    }
    if (summa < minDiagonalSum)
    {
        minDiagonalSum = summa;
    }
}

for (int j = 0; j < matrix.GetLength(1); j++)       // сума елементів у стовпцях, які містять хоч один від’ємний елемент
{
    counter = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            counter++;
        }
    }
    if (counter > 0)
    {
        for (int a = 0; a < matrix.GetLength(0); a++)
        {
            sumNegativeCols += matrix[a, j];
        }
    }
}

Console.WriteLine("Transposed matrix:");        // транспонована матриця
for (int i = 0; i < matrix.GetLength(1); i++)
{
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        Console.Write($"{matrix[j, i],5}");
    }
    Console.WriteLine();
}

Console.WriteLine($"Positive Count = {positiveCount}");
Console.WriteLine($"The maximum number that occurs more than once = {maxRepeatingValue}");
Console.WriteLine($"Number of rows without zero = {rowsWithoutZero}");
Console.WriteLine($"Number of columns with zero = {colWithZero}");
Console.WriteLine($"Line number with the longest series of identical elements = {rowWithMaxRepetition}");
Console.WriteLine($"The maximum sum of the elements of the diagonal parallel to the main diagonal of the matrix  = {maxDiagonalSum}");
Console.WriteLine($"Sum items in columns without negative elements = {sumPositiveCols}");
Console.WriteLine($"The minimum sum of the modules of the elements of the diagonal parallel to the side diagonal = {minDiagonalSum}");
Console.WriteLine($"Sum items in columns with negative elements = {sumNegativeCols}");



