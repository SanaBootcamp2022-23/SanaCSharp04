using Matrix;
using System.Linq.Expressions;

int rowCount, colCount;
int positiveCounts = 0;
Console.WriteLine("Row Count: ");
rowCount = int.Parse(Console.ReadLine());
Console.WriteLine("Col Count: ");
colCount = int.Parse(Console.ReadLine());
int[,] matrix = new int[rowCount, colCount];
Random random = new Random();

for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-1, 10);
        if (matrix[i, j] > 0)
            positiveCounts++;
    }

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]} ");
    }
    Console.WriteLine();
}
Console.WriteLine($"positiveCounts = {positiveCounts}");

var max = int.MinValue;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (MatrixHelper.CheckOccurrences(matrix, matrix[i, j]) && max < matrix[i, j])
        {
            max = matrix[i, j];
        }
    }
}
Console.WriteLine(max != int.MinValue ? $"Max = {max}" : "Всі числа унікальні");

bool zeroFlag = false;
int rows = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
        {
            zeroFlag = true;
            break;
        }
    }
    if (zeroFlag == false)
        rows++;
    zeroFlag = false;
}
Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента ={rows}");

int cols = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[j, i] == 0)
        {
            cols++;
            break;
        }
    }
}
Console.WriteLine($"Кількість стовпців, які містять хоча б один нульовий елемент ={cols}");

int count = 0;
int sameElements = Int32.MinValue;
int indexRow = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int k = j + 1; k < matrix.GetLength(1); k++)
        {
            if (matrix[i, j] == matrix[i, k])
            {
                count++;
            }
        }
        if (count > sameElements)
        {
            sameElements = count;
            indexRow = i;
        }
    }
    count = 0;
}
Console.WriteLine($"Hомер рядка,{indexRow}в якому знаходиться найдовша серія однакових елементів ({sameElements})");

int productNegatives = 1;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        productNegatives *= matrix[i, j];
        if (matrix[i, j] < 0)
            break;
        if (j == matrix.GetLength(1) - 1)
        {
            Console.WriteLine($"Добуток елементів {i}в тих рядках,,які не містять від’ємних елементів  {productNegatives}");
        }
    }
    productNegatives = 1;
}

int maxSum = Int32.MinValue;
int diagonalCounter = Math.Max(matrix.GetLength(0), matrix.GetLength(1));
int sum = 0;

for (int i = 1; i < diagonalCounter; i++)
{
    for (int j = 0; ; j++)
    {
        if (j < matrix.GetLength(0) && j + i < matrix.GetLength(1))
        {
            sum += matrix[j, j + i];
        }
        else
            break;
    }
    if (sum > maxSum)
        maxSum = sum;
    sum = 0;
    int x = i;
    int y = 0;
    for (int j = 0; j < matrix.GetLength(1) - i; j++)
    {
        sum += matrix[x, y];
        x++;
        y++;
    }
    if (sum > maxSum)
        maxSum = sum;
    sum = 0;
}
Console.WriteLine($"Mаксимум серед сум елементів діагоналей, паралельних головній діагоналі матриці; =  {maxSum}");

int sumNegative = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        sumNegative += matrix[j, i];
        if (matrix[j, i] < 0)
            break;
        if (j == matrix.GetLength(0) - 1)
        {
            Console.WriteLine($"Сума елементів у стовпці, який не містить від’ємних чисел  {sumNegative}");
        }
    }
    sumNegative = 0;
}

Console.WriteLine("Transposed matrix: ");
int[,] transp_matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
for (int i = 0; i < matrix.GetLength(1); i++)
{
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        transp_matrix[i, j] = matrix[j, i];
        Console.Write($"{transp_matrix[i, j],4}");
    }
    Console.WriteLine();
}