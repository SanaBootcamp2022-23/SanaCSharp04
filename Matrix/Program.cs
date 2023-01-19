int N, M;

while (true)
{
    Console.Write("Введіть кількість рядків: ");
    if (int.TryParse(Console.ReadLine(), out N) && N > 0) break;
    Console.WriteLine("Помилка! Введіть позитивне ціле число.");
}

while (true)
{
    Console.Write("Введіть кількість стовпців: ");
    if (int.TryParse(Console.ReadLine(), out M) && M > 0) break;
    Console.WriteLine("Помилка! Введіть позитивне ціле число.");
}

int[,] matrix = new int[N, M];

Console.WriteLine("\t\t\tВведіть елемети матриці");
for (int i = 0; i < N; i++) 
{
    for (int j = 0; j < M; j++) 
    {
        while (true)
        {
            Console.Write("Введіть число [" + (i+1) + "] [" + (j+1) + "]: ");
            if (int.TryParse(Console.ReadLine(), out matrix[i, j])) break;
            Console.WriteLine("Помилка! Введіть ціле число.");
        }
    }
}
PrintMatrix(matrix);
Console.WriteLine("Кількість додатних елементів: " + CountPositiveElements(matrix));
Console.WriteLine("Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: " + FindMaxFrequentNumber(matrix));
Console.WriteLine("Кількість рядків, які не містять жодного нульового елемента: " + CountRowsWithoutZeroes(matrix));
Console.WriteLine("Кількість стовпців, які містять хоча б один нульовий елемент: " + CountColumnsWithZeroes(matrix));
Console.Write("Номер рядка, в якому знаходиться найдовша серія однакових елементів: ");
foreach (var longestSeriesRow in FindLongestSeriesRows(matrix))
{
    Console.Write(longestSeriesRow.ToString() + " ");
}
Console.WriteLine("\nДобуток елементів в тих рядках, які не містять від’ємних елементів: " + ProductOfElementsInRowsWithoutNegatives(matrix));
Console.WriteLine("Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: " + MaxSumOfElementsInDiagonals(matrix));
Console.WriteLine("Суму елементів в тих стовпцях, які не містять від’ємних елементів: " + SumOfElementsInColumnsWithoutNegatives(matrix));
Console.WriteLine("Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: " + MinSumOfAbsoluteValuesInDiagonals(matrix));
Console.WriteLine("Суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: " + SumOfElementsInColumnsWithNegatives(matrix));
Console.WriteLine("\t\t\tТранспонована матриця");
PrintMatrix(TransposeMatrix(matrix));

int CountPositiveElements(int[,] matrix)
{
    int positiveCount = 0;

    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            if (matrix[i, j] > 0) 
            {
                positiveCount++;
            }
        }
    }
    return positiveCount;
}
int FindMaxFrequentNumber(int[,] matrix) 
{
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            if (dict.ContainsKey(matrix[i, j])) 
            {
                dict[matrix[i, j]]++;
            } else 
            {
                dict[matrix[i, j]] = 1;
            }
        }
    }

    int maxNum = 0;
    int maxCount = 0;
    foreach (var num in dict) 
    {
        if (num.Value > 1 && num.Key > maxNum) 
        {
            maxNum = num.Key;
            maxCount = num.Value;
        }
    }
    return maxNum;
}
int CountRowsWithoutZeroes(int[,] matrix) {
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        bool hasZero = false;
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            if (matrix[i, j] == 0) 
            {
                hasZero = true;
                break;
            }
        }
        if (!hasZero) 
        {
            count++;
        }
    }
    return count;
}
int CountColumnsWithZeroes(int[,] matrix) {
    int count = 0;
    for (int j = 0; j < matrix.GetLength(1); j++) 
    {
        bool hasZero = false;
        for (int i = 0; i < matrix.GetLength(0); i++) 
        {
            if (matrix[i, j] == 0) 
            {
                hasZero = true;
                break;
            }
        }
        if (hasZero) 
        {
            count++;
        }
    }
    return count;
}
List<int> FindLongestSeriesRows(int[,] matrix) 
{
    List<int> longestRows = new List<int>();
    int longestSeries = 0;
    int currentSeries = 1;
    int currentElement = matrix[0, 0];
    int currentRow = 0;

    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        currentElement = matrix[i, 0];
        currentSeries = 1;
        currentRow = i;
        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == currentElement) 
            {
                currentSeries++;
            } else {
                if (currentSeries > longestSeries) 
                {
                    longestSeries = currentSeries;
                    longestRows.Clear();
                    longestRows.Add(currentRow+1);
                } else if (currentSeries == longestSeries) 
                {
                    longestRows.Add(currentRow+1);
                }
                currentSeries = 1;
                currentElement = matrix[i, j];
            }
        }
        if (currentSeries > longestSeries) 
        {
            longestSeries = currentSeries;
            longestRows.Clear();
            longestRows.Add(currentRow+1);
        } else if (currentSeries == longestSeries) 
        {
            longestRows.Add(currentRow+1);
        }
    }
    return longestRows;
}
int ProductOfElementsInRowsWithoutNegatives(int[,] matrix) 
{
    int product = 1;
    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        bool hasNegative = false;
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            if (matrix[i, j] < 0) {
                hasNegative = true;
                break;
            }
        }
        if (!hasNegative) 
        {
            for (int j = 0; j < matrix.GetLength(1); j++) 
            {
                product *= matrix[i, j];
            }
        }
    }
    return product;
}
int MaxSumOfElementsInDiagonals(int[,] matrix) {
    int maxSum = int.MinValue;
    for (int i = 0; i < matrix.GetLength(0); i++) {
        int sum = 0;
        for (int j = i, k = 0; j < matrix.GetLength(0) && k < matrix.GetLength(1); j++, k++) {
            sum += matrix[j, k];
        }
        maxSum = Math.Max(maxSum, sum);
    }

    for (int i = 1; i < matrix.GetLength(1); i++) {
        int sum = 0;
        for (int j = 0, k = i; k < matrix.GetLength(1); j++, k++) {
            sum += matrix[j, k];
        }
        maxSum = Math.Max(maxSum, sum);
    }
    return maxSum;
}
int SumOfElementsInColumnsWithoutNegatives(int[,] matrix) 
{
    int sum = 0;
    for (int j = 0; j < matrix.GetLength(1); j++) 
    {
        bool hasNegative = false;
        for (int i = 0; i < matrix.GetLength(0); i++) 
        {
            if (matrix[i, j] < 0) 
            {
                hasNegative = true;
                break;
            }
        }
        if (!hasNegative) 
        {
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                sum += matrix[i, j];
            }
        }
    }
    return sum;
}
int MinSumOfAbsoluteValuesInDiagonals(int[,] matrix) 
{
    int minSum = int.MaxValue;
    for (int i = 0; i < matrix.GetLength(1); i++) 
    {
        int sum = 0;
        for (int j = 0, k = i;
             j < matrix.GetLength(0) && k >= 0
             ; j++, k--) 
        {
            sum += Math.Abs(matrix[j, k]);
        }
        minSum = Math.Min(minSum, sum);
    }
    for (int i = 1; i < matrix.GetLength(0); i++) 
    {
        int sum = 0;
        for (int j = i, k = matrix.GetLength(1) - 1; 
             j < matrix.GetLength(0); 
             j++, k--) 
        {
            sum += Math.Abs(matrix[j, k]);
        }
        minSum = Math.Min(minSum, sum);
    }
    return minSum;
}
int SumOfElementsInColumnsWithNegatives(int[,] matrix) 
{
    int sum = 0;
    for (int j = 0; j < matrix.GetLength(1); j++) 
    {
        bool hasNegative = false;
        for (int i = 0; i < matrix.GetLength(0); i++) 
        {
            if (matrix[i, j] < 0) 
            {
                hasNegative = true;
                break;
            }
        }
        if (hasNegative) 
        {
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                sum += matrix[i, j];}
        }
    }
    return sum;
}
int[,] TransposeMatrix(int[,] matrix) 
{
    int[,] transposedMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            transposedMatrix[j, i] = matrix[i, j];
        }
    }
    return transposedMatrix;
}
void PrintMatrix(int[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0); i++) 
    {
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}
