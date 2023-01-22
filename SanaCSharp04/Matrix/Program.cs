
using System.Runtime.ConstrainedExecution;
using System.Text;

Console.InputEncoding = Encoding.UTF8; Console.OutputEncoding = Encoding.UTF8;

// Задання користувачем розміру масиву
int[,] arr;
Console.Write(" Введіть к-ість рядків матриці: ");
int n = int.Parse(Console.ReadLine());
Console.Write(" Введіть к-ість стовпців матриці: ");
int m = int.Parse(Console.ReadLine());
Random random = new Random();
arr = new int[n, m];

// Ініціалізація даного 2D-масиву
for (int i = 0; i < arr.GetLength(0); i++)
{
    for(int j = 0; j < arr.GetLength(1); j++)
    {
        arr[i, j] = random.Next(-5, 11);
        Console.Write($"\t{arr[i, j]}");
    }
    Console.WriteLine();
}

// Підрахунок к-ості додатних елементів масиву та к-ості рядків без нуль-елементів:
int positiveCount = 0,
    zeroNoRowCount = 0,
    zeroColCount = 0,
    zeroCount = 0;
for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        if (arr[i, j] > 0) 
            positiveCount++; // Підрахунок к-ості додатних елементів
        if (arr[i, j] == 0)
            zeroCount++;      
    }
    if (zeroCount == 0)
        zeroNoRowCount++; // К-ість  рядків без нуль-елементів
    zeroCount = 0;
}

// Підрахунок стовпців, що містять хоча б один нуль-елемент
for (int j = 0; j < arr.GetLength(1); j++)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if (arr[i, j] == 0)
            zeroCount++;
    }
    if (zeroCount >= 1)
        zeroColCount++;
    zeroCount = 0;
}

// Максимальне число, що зустрічається в матриці більше одного разу
int[] Arr1D = new int[arr.GetLength(0) * arr.GetLength(1)];
for (int i = 0; i < arr.GetLength(0); i++) 
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        Arr1D[i * arr.GetLength(1) + j] = arr[i, j]; // "Копіювання" елементів 2D-масиву в одновимірний масив
    }
Array.Sort(Arr1D); // Сортування
int repeat = 0,
    num1 = 0,
    num2 = 0;
while (repeat <= 1)
{
    int i;
    for ( i = Arr1D.Length - 1; i > 0; i--)
    { 
        int j = Arr1D.Length - 1;
        num1 = Arr1D[i];  
       if (num1 == Arr1D[j--] && j != i)
        {
            repeat++; // Підрахунок к-ості найбільшого повторюваного числа масиву
            num2 = num1;
        }
    }
}

// Пошук рядка з найдовшою серією однакових елементів
int Series = 1, SeriesMax = 0, indexMaxSeries = 0;
for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1) - 1; j++)
    {
        if (arr[i, j] == arr[i, j + 1]) // Перевірка умови серії однакових елементів
            Series++; // підрахунок серії одного числа 
    }
    if (Series > SeriesMax) // Перевірка останньої серії з найбільшою 
    {
        SeriesMax = Series; // Заміна при умові, що остання серія більша за найбільшу попередніх рядків
        indexMaxSeries = i;
    }
    Series = 1;
}

// Пошук рядків без від'ємних елементів і обрахунок добутку кожного з них
int NegCount = 0,
    Prod;
for (int i = 0; i < arr.GetLength(0); i++)
{
    Prod = 1;
    for (int j = 0; j < arr.GetLength (1); j++)
    {
        if (arr[i, j] < 0)
            NegCount++; // К-ість від'ємних елементів даного рядка
    }
    if (NegCount == 0) // Умова відсутності від'ємних елементів у рядку
    {
        for (int k = 0; k < arr.GetLength(1); k++)
            Prod *= arr[i, k];  // циклічний добуток кожного елемента даного рядка
        Console.WriteLine($"\vРядок {i} не має негативних елементів, його добуток = {Prod}");
    }
}

// Пошук макс. суми елементів діагоналей, які знаходяться над головною та паралельні їй:
int rowDiag,
    colDiag,
    sum,
    sumMax = 0,
    sumMax2 = 0;
for (int j = 1; j < arr.GetLength(1); j++)
{
    rowDiag = 0;
    colDiag = j;
    sum = 0;
    for (int i = 0; i < arr.GetLength(0) - j; i++)
    {
        sum += arr[rowDiag, colDiag]; // підрахунок суми даної діагоналі, паралельної до головної
        rowDiag++;
        colDiag++;
    }
    if (sum > sumMax) // Порівняння суми поточної діагоналі з максимальною знайденою
        sumMax = sum; 
}
// Пошук макс. суми елементів діагоналей, які знаходяться під головною та паралельні їй:
for (int i = 1; i < arr.GetLength(1); i++)
{
    rowDiag = i;
    colDiag = 0;
    sum = 0;
    for (int j = 0; j < arr.GetLength(0) - i; j++)
    {
        sum += arr[rowDiag, colDiag]; // підрахунок суми даної діагоналі, паралельної до головної
        rowDiag++;
        colDiag++;
    }
    if (sum > sumMax2) // Порівняння суми поточної діагоналі з максимальною знайденою
        sumMax2 = sum;
}
if (sumMax < sumMax2) // Порівняння максимальної суми двох найбільших діагоналей, 
    sumMax = sumMax2; // які знаходяться над і під головною діагоналлю матриці

// Пошук стовпців без від'ємних елементів та обрахунок суми всіх їх елементів
int colNegCount,
    sumColnoNeg;
for (int j = 0; j < arr.GetLength(1); j++)
{
    sumColnoNeg = 0;
    colNegCount = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if (arr[i, j] < 0) 
            colNegCount++; // Пошук від'ємних елементів
    }
    if (colNegCount == 0) // Умова відсутності від'ємних елементів
    {
        for (int k = 0; k < arr.GetLength(0); k++)
            sumColnoNeg += arr[k, j]; // циклічна сума елементів даного стовпця
        Console.WriteLine($"\v Стовпець {j + 1} не містить від'ємних елементів, сума його елементів = {sumColnoNeg}");
    }
}

// Пошук мінімуму серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці
int sumMin = 0;
bool firstTime = true;
for (int j = arr.GetLength(1) - 2; j >= 0; j--)
{
    rowDiag = 0;
    colDiag = j;
    sum = 0;
    for (int k = 0; k <= j; k++)
    {
        sum += Math.Abs(arr[rowDiag, colDiag]); // Сума модулів елементів діагоналей, 
        rowDiag++;                              // що знаходяться над побічною діагоналлю
        colDiag--;
    }
    if (firstTime)
    {
        sumMin = sum;
        firstTime = false;
        continue;
    }
    if (sum < sumMin) // Порівняння поточної суми з найменшою серед попередніх
    {
        sumMin = sum;
    }
}
// Пошук мінімуму серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці
for (int i = 1; i < arr.GetLength(0); i++)
{
    rowDiag = i;
    colDiag = arr.GetLength(1) - 1;
    sum = 0;
    for (int k = 0; k < arr.GetLength(1) - i; k++)
    {
        sum += Math.Abs(arr[rowDiag, colDiag]); // Сума модулів елементів діагоналей
        rowDiag++;                             // що знаходяться під побічною діагоналлю
        colDiag--;
    }
    if (sum < sumMin) // Порівняння поточної суми з найменшою серед попередніх
    {
        sumMin = sum;
    }
}

// Пошук стовпців з принаймні одним мінус-елементом, і обрахунок суми їх елементів:
int sumColNeg;
for (int j = 0; j < arr.GetLength(1); j++)
{
    sumColNeg = 0;
    colNegCount = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if (arr[i, j] < 0)
            colNegCount++; // пошук мінус-елемента
    }
    if (colNegCount > 0) // Перевірка наявності від'ємногго елемента в стовпцю
    {
        for (int k = 0; k < arr.GetLength(0); k++)
            sumColNeg += arr[k, j]; // сума всіх елементів даного стовпця
        Console.WriteLine($"\v Сума елементів {j + 1} стовпця з принаймні одним від'ємним елементом = {sumColNeg}");
    }
}

Console.WriteLine($"\v Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці = {sumMin}");
Console.WriteLine($"\v Макс. сума елементів діагоналей, що паралельні головній діагоналі = {sumMax}");
Console.WriteLine($"\v Найдовша серія однакових елементів = {SeriesMax}, індекс рядка даної серії = {indexMaxSeries}");
Console.WriteLine($"\v Максимальне із чисел, що зустрічається в заданій матриці більше одного разу = {num2}");
Console.WriteLine($"\v К-ість додатних елементів = {positiveCount}");
Console.WriteLine($"\v К-ість  рядків, які не містять жодного нульового елемента = {zeroNoRowCount}");
Console.WriteLine($"\v К-ість  стовпців, які містять хоча б один нульовий елемент = {zeroColCount}");

// Транспонована матриця
Console.WriteLine();
Console.WriteLine("\tТранспонована матриця:");
for (int j = 0; j < arr.GetLength(1); j++)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        Console.Write($"\t{arr[i, j]}");
    }
    Console.WriteLine();    
}

