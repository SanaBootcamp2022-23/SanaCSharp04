using System.Text;
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;
//Для матриці N на M цілого типу визначити:
//кількість додатних елементів;
//максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
//кількість рядків, які не містять жодного нульового елемента;
//кількість стовпців, які містять хоча б один нульовий елемент;
//номер рядка, в якому знаходиться найдовша серія однакових елементів;
//добуток елементів в тих рядках, які не містять від’ємних елементів;
//максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;
//суму елементів в тих стовпцях, які не містять від’ємних елементів;
//мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;
//суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент;
//транспоновану матрицю.

int N, M, positiveCount = 0, repeatedCount = int.MinValue, repeat, haventZeroRows = 0, haveZeroCols = 0;

Console.Write("Введіть кількість стовпців: "); N = int.Parse(Console.ReadLine());
Console.Write("Введіть кількість рядків: ");   M = int.Parse(Console.ReadLine());
Random rand = new Random();
int[,] matrix = new int [N, M];
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        matrix[i, j] = rand.Next(-10, 11);
        Console.Write($"{matrix[i,j],5}");
        if(matrix[i,j] > 0) positiveCount++;// кількість додатних елементів;
    }
    Console.WriteLine();
}
Console.WriteLine($"Кількість додатніх чисел = {positiveCount}");
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        int current = matrix[i, j];
        repeat = 0;
        for (int i1 = 0; i1 < N; i1++)
        {
            for (int j1 = 0; j1 < M; j1++)
            {
                if (matrix[i1, j1] == current) repeat++;
            }
            if (repeat > 1 && current > repeatedCount) repeatedCount = current;//максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
        }
    }
}
Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу = {repeatedCount}");
int dobutokCountHaventZeroRows = 1;
for (int i = 0; i < N; i++)
{
    int rowsPos = 0, rowsZero = 0;
    for (int j = 0; j < M; j++)
    {
        if (matrix[i, j] != 0) rowsZero++;
        if (matrix[i, j] >= 0) rowsPos++;
        if (matrix[i, j] == 0) haveZeroCols++;//Кількість стовпців, які містять хоча б один нульовий елемент
    }
    if (rowsPos == N)
    {
        for (int j1 = 0; j1 < N; j1++)
        {
            dobutokCountHaventZeroRows *= matrix[i, j1]; //добуток елементів в тих рядках, які не містять від’ємних елементів;
        }
    }
    if (rowsZero == N) haventZeroRows++;//кількість рядків, які не містять жодного нульового елемента;
}
Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента = {haventZeroRows}");
Console.WriteLine($"Кількість стовпців, які містять хоча б один нульовий елемент = { haveZeroCols}");
int serias = 0, count = 0, longestSeriasRow = 0, longestSerias = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 1; j < M; j++)
    {
        if (matrix[i, j] == matrix[i, j - 1])
        {
            count++;
            if (count > serias) serias = count;
        }
        else count = 0;
    }
    if (serias > longestSerias)
    {
        longestSerias = serias;
        longestSeriasRow = i; //номер рядка, в якому знаходиться найдовша серія однакових елементів
    }
}
Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серія однакових елементів = {longestSeriasRow}");
Console.WriteLine($"Добуток елементів в тих рядках, які не містять від’ємних елементів = {dobutokCountHaventZeroRows}");
int  maxSumParalelDiagonal= int.MinValue;
for (int k = 1 - N; k < M; k++)
{
    int sum = 0;
    for (int i = 0; i < N; i++)
    {
        int j = i + k;
        if (j >= 0 && j < M)
        {
            sum += matrix[i, j];
        }
    }
    if (sum > maxSumParalelDiagonal) maxSumParalelDiagonal = sum;//максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;
}
Console.WriteLine($"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці = {maxSumParalelDiagonal}");
int sumCountHaventZeroCols = 0;
for (int j = 0; j < N; j++)
{
    int cols = 0;
    for (int i = 0; i < M; i++)
    {
        if (matrix[i, j] >= 0) cols++;
    }
    if (cols == M)
    {
        for (int i1 = 0; i1 < M; i1++)
        {
            sumCountHaventZeroCols += matrix[i1, j]; //суму елементів в тих стовпцях, які не містять від’ємних елементів;
        }
    }
}
Console.WriteLine($"Суму елементів в тих стовпцях, які не містять від’ємних елементів = {sumCountHaventZeroCols}");
int minSumAbsParalelDiagonal = int.MaxValue;
for (int i = 0; i < N + M - 1; i++)
{
    int sum = 0;
    for (int j = 0; j < N; j++)
    {
        for (int k = 0; k < M; k++)
        {
            if (j + k == i) sum += Math.Abs(matrix[j, k]);
        }
    }
    if (minSumAbsParalelDiagonal > sum) minSumAbsParalelDiagonal = sum;
}
Console.WriteLine($"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці = {minSumAbsParalelDiagonal}");
int sumElNegCols = 0;
for (int j = 0; j < M; j++)
{
    int negEl = 0;
    for (int i = 0; i < N; i++)
    {
        if (matrix[i, j] < 0) negEl++;
    }
    for (int i1 = 0; i1 < N; i1++)
    {
        if (negEl > 0) sumElNegCols += matrix[i1, j]; //сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент
    }
}
Console.WriteLine($"Суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент = {sumElNegCols}");
int[,] transMatrix = new int[N, M];
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        transMatrix[j, i] = matrix[i, j];//транспонована матриця
    }
}
Console.WriteLine("Транспонована матриця: ");
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        Console.Write($"{transMatrix[i, j],5}");
    }
    Console.WriteLine();
}