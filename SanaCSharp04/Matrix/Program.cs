using System.Numerics;

uint rowCount, colCount;
Console.WriteLine("Rows count:");
rowCount = Convert.ToUInt32(Console.ReadLine());
Console.WriteLine("Columns count:");
colCount = Convert.ToUInt32(Console.ReadLine());

int[,] matrix = new int[rowCount, colCount];
for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        Console.Write($"Matrix[{i}, {j}] = ");
        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
    }
}

for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        Console.Write($"{matrix[i, j],6}");
    }
    Console.WriteLine();
}

//кількість додатних елементів
uint positiveCount = 0;

for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {

        if (matrix[i, j] > 0)
        {
            positiveCount++;
        }
    }
}
Console.WriteLine($"The number of positive elements = {positiveCount}");


//максимальне із чисел, що зустрічається в заданій матриці більше одного разу
int maxElement = int.MinValue;
int prevMaxEl = maxElement;
int maxCount = 1;
for (int i = 0; i < colCount; i++)
{
    for (int j = 0; j < rowCount; j++)
    {
        if (matrix[i, j] > maxElement)
        {
            if (maxCount > 1)
            {
                prevMaxEl = maxElement;
            }
            maxCount = 1;
            maxElement = matrix[i, j];
        }
        else if (matrix[i, j] == maxElement)
        {
            maxCount++;
        }
    }
}
Console.WriteLine($"The maximum number that occurs in the given matrix more than once = {(maxCount > 1 ? maxElement : (prevMaxEl != int.MinValue ? prevMaxEl : "There are not"))}");

//кількість рядків, які не містять жодного нульового елемента
int rowCount0 = 0;
for (int i = 0; i < rowCount; i++)
{
    bool haveZeroValue = false;
    for (int j = 0; j < colCount; j++)
    {
        if (matrix[i, j] == 0)
        {
            haveZeroValue = true;
        }
    }
    if (!haveZeroValue)
    {
        rowCount0++;
    }
}
Console.WriteLine($"The number of rows that do not contain any null elements = {rowCount0}");


//кількість стовпців, які містять хоча б один нульовий елемент
int colCount0 = 0;
for (int i = 0; i < colCount; i++)
{
    bool haveOneValue1 = false;
    for (int j = 0; j < rowCount; j++)
    {
        if (matrix[j, i] == 0)
        {
            haveOneValue1 = true;
        }
    }

    if (haveOneValue1)
    {
        colCount0++;
    }
}
Console.WriteLine($"The number of columns that contain at least one null element = {colCount0}");


//номер рядка, в якому знаходиться найдовша серія однакових елементів
int numberRow = 1;
int maxSer = 1;
for (int i = 0; i < rowCount; i++)
{
    int maxSerInRow = 1;
    int count = 1;
    for (int j = 1; j < colCount; j++)
    {
        if (matrix[i, j] == matrix[i, j - 1])
        {
            count++;
        }
        else
        {
            if (count > maxSerInRow)
            {
                maxSerInRow = count;
            }
            count = 1;
        }
    }
    if (count > maxSerInRow)
    {
        maxSerInRow = count;
    }
    if (maxSerInRow > maxSer)
    {
        numberRow = i + 1;
        maxSer = maxSerInRow;
    }
}
Console.WriteLine($"Row number in which there is the longest series of identical elements = {numberRow}");

//добуток елементів в тих рядках, які не містять від’ємних елементів
int[] prod = new int[rowCount];

for (int i = 0; i < rowCount; i++)
{
    prod[i] = 1;
    for (int j = 0; j < colCount; j++)
    {
        if (matrix[i, j] < 0)
        {
            prod[i] = -1;
            break;
        }
        prod[i] *= matrix[i, j];
    }
}

//Console.WriteLine("Mnoj of non zero rows:");
Console.WriteLine("The product of the elements in those rows that do not contain negative elements:");
for (int i = 0; i < prod.Length; i++)
{
    if (prod[i] != -1)
    {
        Console.WriteLine($"    {i + 1} = {prod[i]}");
    }
    else
    {
        Console.WriteLine($"    {i + 1} there are not");
    }
}

//максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці
{
    uint i = rowCount - 1;
    uint j = 0;
    int maxSum = int.MinValue;
    while (j != colCount)
    {
        int sum = 0;
        for (uint ii = i, jj = j; ii < rowCount && jj < colCount; ii++, jj++)
        {
            sum += matrix[ii, jj];
        }
        if (sum > maxSum)
        {
            maxSum = sum;
        }
        if (i != 0)
        {
            i--;
            if (i == 0)
            {
                j++;
            }
        }
        else
        {
            j++;
        }
    }
    Console.WriteLine($"The maximum among the sums of diagonal elements parallel to the main diagonals of the matrix = {maxSum}");
}

//суму елементів в тих стовпцях, які не містять від’ємних елементів
{
    int[] sums = new int[colCount];

    for (int i = 0; i < colCount; i++)
    {
        sums[i] = 0;
        for (int j = 0; j < rowCount; j++)
        {
            if (matrix[j, i] < 0)
            {
                sums[i] = -1;
                break;
            }
            sums[i] += matrix[j, i];
        }
    }

    Console.WriteLine("The sum of elements in those columns that do not contain negative elements:");
    for (int i = 0; i < sums.Length; i++)
    {
        if (sums[i] != -1)
        {
            Console.WriteLine($"    {i + 1} = {sums[i]}");
        }
        else
        {
            Console.WriteLine($"    {i + 1} there are not");
        }
    }
}

//мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці
{
    int i = 0;
    int j = 0;
    int minSum = int.MaxValue;
    while (j != colCount - 1 || i != rowCount)
    {
        int sum = 0;
        for (int ii = i, jj = j; ii < rowCount && jj >= 0; ii++, jj--)
        {
            sum += Math.Abs(matrix[ii, jj]);
        }
        if (sum < minSum)
        {
            minSum = sum;
        }
        if (j != colCount - 1)
        {
            j++;
            if (j == colCount - 1)
            {
                i++;
            }
        }
        else
            i++;
    }
    Console.WriteLine($"The minimum among the sums of the modules of the elements of the diagonals parallel to the side diagonal of the matrix = {minSum}");
}

//суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент
{
    int[] sum = new int[colCount];
    bool[] hasNegative = new bool[colCount];

    for (int i = 0; i < colCount; i++)
    {
        sum[i] = 0;
        for (int j = 0; j < rowCount; j++)
        {
            if (matrix[j, i] < 0)
            {
                hasNegative[i] = true;
            }
            sum[i] += matrix[j, i];
        }
    }

    Console.WriteLine("The sum of elements in those columns that contain at least one negative element:");
    for (int i = 0; i < sum.Length; i++)
    {
        if (hasNegative[i])
        {
            Console.WriteLine($"    {i + 1} = {sum[i]}");
        }
        else
        {
            Console.WriteLine($"    {i + 1} there are not");
        }
    }
}

//транспонованa матрицю
{
    Console.WriteLine("Transposed matrix");
    for (int i = 0; i < colCount; i++)
    {
        for (int j = 0; j < rowCount; j++)
        {
            Console.Write($"{matrix[j, i],6}");
        }
        Console.WriteLine();
    }
}