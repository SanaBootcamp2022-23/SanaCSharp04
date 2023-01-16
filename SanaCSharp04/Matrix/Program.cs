Console.OutputEncoding = System.Text.Encoding.UTF8;
int N, M;
do
    Console.WriteLine("Введіть розмір масиву(N>0) - ");
while (!(int.TryParse(Console.ReadLine(), out N) && N > 0));
do
    Console.WriteLine("Введіть розмір масиву(M>0) - ");
while (!(int.TryParse(Console.ReadLine(), out M) && M > 0));
int[,] mas = new int[N, M];
Random rnd = new Random();
for (int i = 0; i < mas.GetLength(0); i++)
{
    for (int j = 0; j < mas.GetLength(1); j++)
    {
        mas[i, j] = rnd.Next(-5,5);
        Console.Write($"{mas[i, j]}\t");
    }
    Console.WriteLine();
}
int numberPostiveElements = 0, maxElementMoreThanOnce = int.MinValue, numberLineContainsZero = 0, numberColumnContainsZero = 0,
    numberTheSame = 0, maxTheSame = 0, indexLongestStreak = 0,productNumbers=1,sumColumnNonNegative=0, sumColumnHasNegative=0;
bool moreThenOnce = false, containsZero = true,containsNegative=false;
for (int i = 0; i < mas.GetLength(0); i++)
{
    for (int j = 0; j < mas.GetLength(1); j++)
    {
        if (mas[i, j] >= 0)//кількість додатних елементів;
            numberPostiveElements++;
        if (mas[i, j] >= maxElementMoreThanOnce)//максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
        {
            if (maxElementMoreThanOnce == mas[i, j])
                moreThenOnce = true;
            maxElementMoreThanOnce = mas[i, j];
        }
        if (mas[i, j] == 0)//кількість рядків, які не містять жодного нульового елемента;
        {
            containsZero = false;
        }
        if (j != 0)//номер рядка, в якому знаходиться найдовша серія однакових елементів;
            if (mas[i, j - 1] == mas[i, j])
            {
                numberTheSame++;
            }
        if (mas[i,j]<0)//добуток елементів в тих рядках, які не містять від’ємних елементів;
            containsNegative = true;
    }
    if(!containsNegative)//добуток елементів в тих рядках, які не містять від’ємних елементів;
    {
        for (int j = 0; j < mas.GetLength(1); j++)
        {
            if (mas[i,j]!=0)
            productNumbers *= mas[i, j];
        }
    }
    if (numberTheSame >= maxTheSame)//номер рядка, в якому знаходиться найдовша серія однакових елементів;
    {
        maxTheSame = numberTheSame;
        indexLongestStreak = i;
        numberTheSame = 0;
    }
    if (containsZero)//кількість рядків, які не містять жодного нульового елемента;
    {
        numberLineContainsZero++;
    }
    containsNegative = false;
    containsZero = true;
}
for (int j = 0; j < mas.GetLength(1); j++)
{
    for (int i = 0; i < mas.GetLength(0); i++)
    {
        if (mas[i, j] == 0)//кількість стовпців, які містять хоча б один нульовий елемент
        {
            containsZero = false;
        }
        if (mas[i, j] < 0) //суму елементів в тих стовпцях, які не містять від’ємних елементів;
        containsNegative = true;
    }
    if (containsNegative)//суму елементів в тих стовпцях, які не містять від’ємних елементів;
    {
        for (int i = 0; i < mas.GetLength(0); i++)
        {
            if (mas[i, j] != 0)
                sumColumnHasNegative += mas[i, j];
        }
    }

    if (!containsNegative)//суму елементів в тих стовпцях, які не містять від’ємних елементів;
    {
        for (int i = 0; i < mas.GetLength(0);i++)
        {
            if (mas[i, j] != 0)
                sumColumnNonNegative += mas[i, j];
        }
    }
    if (!containsZero)//кількість стовпців, які містять хоча б один нульовий елемент
    {
        numberColumnContainsZero++;
    }
    containsNegative = false;
    containsZero = true;
}

Console.WriteLine();
Console.WriteLine($"кількість додатних елементів = {numberPostiveElements}");
if (moreThenOnce)
    Console.WriteLine($"максимальне із чисел, що зустрічається в заданій матриці більше одного разу ={maxElementMoreThanOnce}");
Console.WriteLine($"кількість рядків, які не містять жодного нульового елемента = {numberLineContainsZero}");
Console.WriteLine($"кількість стовпців, які містять хоча б один нульовий елемент; = {numberColumnContainsZero}");
Console.WriteLine($"номер рядка, в якому знаходиться найдовша серія однакових елементів = {indexLongestStreak + 1}");
Console.WriteLine($"добуток елементів в тих рядках, які не містять від’ємних елементів = {productNumbers}");
Console.WriteLine($"суму елементів в тих стовпцях, які не містять від’ємних елементів = {sumColumnNonNegative}");
Console.WriteLine($"суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент = {sumColumnHasNegative}");
if (mas.GetLength(0) == mas.GetLength(1))
{
    int sumDiagUpperThenMainDiag = 0, sumDiagLowerThenMainDiag = 0, maxSumElemParalDiagToMainDiag = int.MinValue;
    for (int i = 0; i < mas.GetLength(0) - 1; i++)
    {
        for (int j = i + 1; j < mas.GetLength(0); j++)
        {
            sumDiagUpperThenMainDiag += mas[j - i - 1, j];
            sumDiagLowerThenMainDiag += mas[j, j - i - 1];
        }
        if (sumDiagUpperThenMainDiag > maxSumElemParalDiagToMainDiag) maxSumElemParalDiagToMainDiag = sumDiagUpperThenMainDiag;
        if (sumDiagLowerThenMainDiag > maxSumElemParalDiagToMainDiag) maxSumElemParalDiagToMainDiag = sumDiagLowerThenMainDiag;
        sumDiagUpperThenMainDiag = 0; sumDiagLowerThenMainDiag = 0;
    }
    Console.WriteLine($"максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці = {maxSumElemParalDiagToMainDiag}");
    int minAbsSumElemParalDiagToMainDiag = int.MaxValue;
    for (int i = 0; i < mas.GetLength(0); i++)
    {
        if (i == 0) sumDiagUpperThenMainDiag += Math.Abs(mas[i, mas.GetLength(0) - i - 2]);
        else if (i == mas.GetLength(0) - 1) sumDiagLowerThenMainDiag += Math.Abs(mas[i, mas.GetLength(0) - i]);
        else
        {
            sumDiagUpperThenMainDiag += Math.Abs(mas[i, mas.GetLength(0) - i - 2]);
            sumDiagLowerThenMainDiag += Math.Abs(mas[i, mas.GetLength(0) - i]);
        }
    }
    if (sumDiagLowerThenMainDiag > sumDiagUpperThenMainDiag)
        minAbsSumElemParalDiagToMainDiag = sumDiagUpperThenMainDiag;
    else
        minAbsSumElemParalDiagToMainDiag = sumDiagLowerThenMainDiag;
    Console.WriteLine($"мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матрицi = {minAbsSumElemParalDiagToMainDiag}");
}
else
    Console.WriteLine("Не квадратна матриця");
int[,]transposedMas= new int[mas.GetLength(1), mas.GetLength(0)];
for (int i = 0; i < mas.GetLength(0); i++)
{
    for (int j = 0; j < mas.GetLength(1); j++)
    {
        transposedMas[j, i] = mas[i, j];
    }
}
Console.WriteLine("транспоновану матрицю");
for (int i = 0; i < transposedMas.GetLength(0); i++)
{
    for (int j = 0; j < transposedMas.GetLength(1); j++)
    {
        Console.Write($"{transposedMas[i, j]}\t");
    }
    Console.WriteLine();
}
