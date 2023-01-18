using System;
using System.Globalization;

int n, m;
Console.WriteLine("Введiть число рядкiв для матрицi: ");
while (!Int32.TryParse(Console.ReadLine(),out n))
{
    Console.WriteLine("Помилка! Спробуйте ще раз!");
}
Console.WriteLine("Введiть число стовпцiв для матрицi: ");
while (!Int32.TryParse(Console.ReadLine(), out m))
{
    Console.WriteLine("Помилка! Спробуйте ще раз!");
}
int[,] matrix = new int[n,m];
// Matrix's initialization


Console.WriteLine("\nМатриця: ");
Random r = new Random();
int lowVal = -10,
    highVal = 10;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++) 
    {
        matrix[i,j] = r.Next(lowVal,highVal);
        Console.Write($"{matrix[i, j],4}");
    }

    Console.WriteLine();
}
// Fill matrix with numbers

int PositiveCount = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (matrix[i,j] > 0)
            PositiveCount++;
    }
}
Console.WriteLine($"Кiлькiсть додатних елементiв в матрицi = {PositiveCount}");
// Find the number of positive elements


int count = 0, resultCount = 0;
int Max = Int32.MinValue;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        foreach (int number in matrix)
        {
            if (number == matrix[i, j])
                count++;
        }

        if (matrix[i, j] > Max && count > 1)
        {
            Max = matrix[i, j];
            resultCount = count;
        }
        count = 0;
    }
}
Console.WriteLine($"Елемент {Max} є максимальним та зустрiчається {resultCount}р.");
// Find the max value in matrix which occures more than 1 time


bool ZeroExists = false;
int countRows = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (matrix[i, j] == 0)
            ZeroExists = true;
    }
    if (!ZeroExists)
        countRows++;
    ZeroExists = false;
}
Console.WriteLine($"Кiлькiсть рядкiв, що не мають жодного нульового елемента = {countRows}");
// Find the number of rows which don't have zero-element


ZeroExists = false;
int countCols = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (matrix[j, i] == 0)
            ZeroExists = true;

        if (j == m - 1 && !ZeroExists)
        {
            countCols++;
        }
    }
    ZeroExists = false;
}
Console.WriteLine($"Кiлькiсть стовпцiв, що не мають жодного нульового елемента = {countCols}");
// Find the number of cols which don't have zero-element


count = 0;
Max = Int32.MinValue;
int indexRow = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        for (int k = j+1; k < m; k++)
        {
            if (matrix[i,j] == matrix[i, k])
            {
                count++;
            }
        }

        if (count > Max)
        {
            Max = count;
            indexRow = i;
        }
    }
    count = 0;
}
Console.WriteLine($"Рядок №{indexRow} має найбiльшу серiю однакових елементiв ({Max})");
// Find the row which has the biggest set of the same numbers


int result = 1;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        result *= matrix[i, j];
        if (matrix[i, j] < 0)
            break;
        if (j == m - 1)
        {
            Console.WriteLine($"Рядок №{i} має добуток чисел {result}, бо не має вiд'ємних елементiв");
        }
    }
    result = 1;
}
// Find rows which don't have negative elements. Print product of numbers in that row


int MaxSum = Int32.MinValue;
int DiagonalCounter = Math.Max(n, m);
int sum = 0;

for (int i = 1; i < DiagonalCounter; i++)
{
    for (int j = 0; ; j++)
    {
        if (j < n && j + i < m) { 
            sum += matrix[j, j + i];
        }
        else
            break;
    }
    if (sum > MaxSum)
        MaxSum = sum;

    sum = 0;
    int x = i;
    int y = 0;
    for (int j = 0; j < m - i; j++)
    {
        sum += matrix[x, y];
        x++;
        y++;
    }

    if (sum > MaxSum)
        MaxSum = sum;

    sum = 0;
}

Console.WriteLine($"Максимальна сума дiагоналей в матрицi, паралельнi головнiй = {MaxSum}");
// Max sum of diagonal elements not including the primary one

result = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        result += matrix[j, i];
        if (matrix[j, i] < 0)
            break;
        if (j == n - 1)
        {
            Console.WriteLine($"Стовпець №{i} має суму елементiв = {result}, якi не вiд'ємнi");
        }
    }
    result = 0;
}
// Sum of elements in column which doesn't have any negative numbers


int MinSum = Int32.MaxValue;
DiagonalCounter = Math.Max(n, m);
sum = 0;

for (int i = 1; i < DiagonalCounter; i++)
{
    int x = i;
    int y = m - 1;
    for (int j = 0; j < m-i ; j++)
    {
        sum += matrix[x,y];
        x++;
        y--;
    }
    if (Math.Abs(sum) < MinSum)
        MinSum = Math.Abs(sum);

    sum = 0;
}

for (int  i = 0; i < DiagonalCounter-1; i++)
{
    int x = 0;
    int y = m - 2 - i;
    for (int j = 0; j < m - i - 1; j++)
    {
        sum += matrix[x, y];
        x++;
        y--;
    }
    if (Math.Abs(sum) < MinSum)
        MinSum = Math.Abs(sum);

    sum = 0;
}

Console.WriteLine($"Мiнiмальна сума модулей дiагоналей в матрицi, паралельнi побiчнiй = {MinSum}");
// Min sum of module diagonal elements not including the side one

sum = 0;
count = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        sum += matrix[j, i];
        if (matrix[j, i] < 0)
            count++;
        if (j == m - 1 && count >= 1)
            Console.WriteLine($"Сума елементiв стовпця №{i}, котрий має хоча б одне вiд'ємне число = {sum}");
    }
    sum = 0;
}
// Sum of columns's elements, if it has at least 1 negative number


Console.WriteLine("Транспонована матриця: ");
int[,] transp_matrix = new int[m, n];
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        transp_matrix[i, j] = matrix[j, i];
        Console.Write($"{transp_matrix[i, j],4}");
    }
    Console.WriteLine();
}
// Matrix transposition
