using System.Text;

Console.OutputEncoding = Encoding.UTF8;


Console.Write("Введіть кількість рядків матриці (N): ");
uint colCount = uint.Parse(Console.ReadLine());
Console.Write("Введіть кількість стовбців матриці (M): ");
uint rowCount = uint.Parse(Console.ReadLine());
Console.Write("Введіть нижній діапазон чисел для заповнення матриці: ");
int minRange = int.Parse(Console.ReadLine());
Console.Write("Введіть верхній діапазон чисел для заповнення матриці: ");
int maxRange = int.Parse(Console.ReadLine());

int[,] matrix = new int[colCount, rowCount];

Console.WriteLine();

/* заповнення + відображення матриці */
Random random = new Random();
uint positiveNumCount = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(minRange, maxRange);
        if (matrix[i, j] < 0)
            Console.Write($"{matrix[i, j]}\t");
        else
            Console.Write($" {matrix[i, j]}\t");

        if (matrix[i, j] > 0)
            positiveNumCount++;
    }
    Console.WriteLine("\n");
}

/* кількість рядків, які не містять жодного нульового елемента */
/* добуток елементів в тих рядках, які не містять від’ємних елементів */
int rowsWithoutZeroEl = 0;
int positiveRowsMultiply = 1;
int positiveRowCount = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    int tmp = 1;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
        {
            rowsWithoutZeroEl--;
            break;
        }
    }
    for (int j = 0; j < matrix.GetLength(1);j++)
    {
        tmp *= matrix[i, j];
        positiveRowCount++;
        if (matrix[i, j] < 0)
        {
            positiveRowCount--;
            tmp = 1;
            break;
        }
    }
    positiveRowsMultiply *= tmp;
    rowsWithoutZeroEl++;
}


/* кількість стовпців, які містять хоча б один нульовий елемент */
int colsWithZeroEl = 0;

for (int i = 0; i < matrix.GetLength(1); i++)
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (matrix[j, i] == 0)
        {
            colsWithZeroEl++;
            break;
        }     
    }

/* сума елементів в тих стовпцях, які не містять від’ємних елементів + сума елементів в тих стовпцях, які мають від'ємний елемент */
int positiveColsSum = 0, negativeColsSum = 0;

for (int i = 0; i < matrix.GetLength(1); i++)
{
    bool isPositiveCol = true;

    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (matrix[j, i] < 0)
        {
            isPositiveCol = false;
            break;
        }
    }
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (isPositiveCol)
            positiveColsSum += matrix[j, i];
        else
            negativeColsSum += matrix[j, i];

    }

}


/* максимальне із чисел, що зустрічається в заданій матриці більше одного разу */
int rowIdx = 0, colIdx = 0;
int maxDuplicateValue = minRange - 1;

for (int k = 1; k < colCount * rowCount; k++)
{
    bool isFound = false;
    for (int i = colIdx; i < matrix.GetLength(0); i++)
    {
        for (int j = (i > colIdx) ? 0 : rowIdx + 1; j < matrix.GetLength(1); j++)
        {
            if (matrix[colIdx, rowIdx] == matrix[i, j])
            {
                if (matrix[colIdx, rowIdx] > maxDuplicateValue)
                    maxDuplicateValue = matrix[colIdx, rowIdx];
                isFound = true;
                break;
            }
        }
        if (isFound)
            break;

    }

    rowIdx++;
    if (k % rowCount == 0)
    {
        rowIdx = 0;
        colIdx++;
    }
}

/* Номер(індекс) рядка, в якому знаходиться найдовша серія однакових елементів */
int longestStreak = 0, currentStreak = 0, streakIdx = -1;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetUpperBound(1); j++)
    {
        if (matrix[i, j] == matrix[i, j + 1])
            currentStreak++;

    }

    if (currentStreak > longestStreak)
    {
        longestStreak = currentStreak;
        streakIdx = i;
    }

    currentStreak = 0;
}

/* дзеркальна матриця для підрахунку сум модулів побічних діагоналей */
int[,] mirrorMatrix = new int[colCount, rowCount];

for (int i = 0; i < mirrorMatrix.GetLength(0); i++)
{
    int idx = matrix.GetUpperBound(1);
    for (int j = 0; j < mirrorMatrix.GetLength(1); j++)
        mirrorMatrix[i, j] = matrix[i, idx--];
}

/* максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці */
/* мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці */
int diagonalMaxValue = int.MinValue;
int sideDiagonalMinModulo = int.MaxValue;
for (int j = 1 - matrix.GetLength(0); j < matrix.GetLength(1); j++)
{
    int sum = 0;
    int moduloSum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int idx = i + j;
        if (i == 0 && j == 0)
            break;

        if (idx < matrix.GetLength(1) && idx >= 0)
        {
            sum += matrix[i, idx];
            moduloSum += Math.Abs(mirrorMatrix[i, idx]);
        }
    }

    sideDiagonalMinModulo = (moduloSum < sideDiagonalMinModulo && moduloSum > 0) ? moduloSum : sideDiagonalMinModulo;
    diagonalMaxValue = (sum > diagonalMaxValue) ? sum : diagonalMaxValue;
}



Console.WriteLine($"Кількість додатних елементів: {positiveNumCount}");

if (maxDuplicateValue == minRange - 1)
    Console.WriteLine("Жоден елемент матриці не повторюється.");
else
    Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {maxDuplicateValue}");

Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента: {rowsWithoutZeroEl}");
Console.WriteLine($"Кількість стовпців, які  містять хоча б один нульовий елемент: {colsWithZeroEl}");

if (longestStreak == 0)
    Console.WriteLine($"Серія однакових елементів матриці відсутня.");
else
    Console.WriteLine($"Номер(індекс) рядка, в якому знаходиться найдовша серія однакових елементів: {streakIdx}");

if (positiveRowCount < 1)
    Console.WriteLine($"Рядки без від'ємних чисел відсутні.");
else
    Console.WriteLine($"Добуток елементів в тих рядках, які не містять від’ємних елементів: {positiveRowsMultiply}");

Console.WriteLine($"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {diagonalMaxValue}");
Console.WriteLine($"Сума елементів в стопцях, які не містять від'ємних елементів: {positiveColsSum}");
Console.WriteLine($"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриц: {sideDiagonalMinModulo}");
Console.WriteLine($"Сума елементів в стопцях, які містять хоча б один від'ємний елемент: {negativeColsSum}");

/* транспонована матриця */
Console.WriteLine("Транспонована матриця:\n");
int[,] transposedMatrix = new int[rowCount, colCount];

for (int i = 0; i < transposedMatrix.GetLength(0); i++)
{
    for (int j = 0; j < transposedMatrix.GetLength(1); j++)
    {
        transposedMatrix[i, j] = matrix[j, i];
        if (transposedMatrix[i, j] >= 0)
            Console.Write(" " + transposedMatrix[i, j] + "\t");
        else
            Console.Write(transposedMatrix[i, j] + "\t");
    }
    Console.WriteLine("\n");
}




