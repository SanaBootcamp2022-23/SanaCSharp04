// See https://aka.ms/new-console-template for more information

uint rowCount, colCount;
Console.WriteLine("Row count:");
rowCount = uint.Parse(Console.ReadLine());
Console.WriteLine("Col count:");
colCount = uint.Parse(Console.ReadLine());  
int[,] matrix = new int[rowCount, colCount];
Random random = new Random();

for(int i = 0; i< matrix.GetLength(0); i++)
{
    for(int j = 0; j< matrix.GetLength(1); j++)
    {
        matrix[i,j] = random.Next(-10, 10);
    }
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]} \t");

    }
    Console.WriteLine();

}

int positiveCount = 0;

//кількість додатних елементів;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > 0)
            positiveCount += 1;
    }
}
Console.WriteLine("Positive count = " + positiveCount);

//максимальне із чисел, що зустрічається в заданій матриці більше одного разу;

        int maxEl = int.MinValue;
        bool none = true;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[i, j];
                for (int k = i; k < matrix.GetLength(0); k++)
                {
                    if (!none && temp <= maxEl)
                        break;
                    int u;
                    if (k == i)
                        u = j + 1;
                    else u = 0;
                    for (; u < matrix.GetLength(1); u++)
                    {
                        if (temp == matrix[k, u]) if (none || maxEl < temp) { maxEl = temp; none = false; break; }
                    }
                }
            }

        if (maxEl == int.MinValue)
        {
            Console.WriteLine("There is no repeted elements");

        }
        else
            Console.WriteLine($"Max repeated element = {maxEl}");
   

//кількість рядків, які не містять жодного нульового елемента;
int countRow = 0;
for (int i = 0; i < matrix.GetLength(0); i++) { 
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        {
            if (matrix[i, j] == 0)
                break;

            if (j + 1 == matrix.GetLength(1))
                countRow++;
        }
    }
}
Console.WriteLine("Rows without zero = " + countRow);

//кількість стовпців, які містять хоча б один нульовий елемент;
int countCol = 0;
for (int i = 0; i < matrix.GetLength(1); i++)
{
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (matrix[j, i] == 0)
        {
            countCol++;
            break;
        }
    }
}
Console.WriteLine("Cols with zero = " + countCol);

//номер рядка, в якому знаходиться найдовша серія однакових елементів;
int count1 = 0, count2 = 0;
int index = -1;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    count1 = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
        for (int k = j + 1; k < matrix.GetLength(1); k++)
            if (matrix[i, j] == matrix[i, k])
                count1++;

    if (index == -1 || (index != -1 && index != i && count2 < count1))
    {
        count2 = count1;
        index = i;
    }
}
//добуток елементів в тих рядках, які не містять від’ємних елементів;
int res = 1;
int a = 0, q = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] <= 0)
        {
            a = 1;
            break;
        }

        res *= matrix[i, j];
    }
    if (a == 0)
    {
        Console.WriteLine($"Product {i + 1} row = {res}");
        q = 1;
    }

    a = 0;
    res = 1;
}
if (q == 0)
    Console.WriteLine("That row doest't exists");
//максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;
double sumDiagonal = 0, diagonalC = 0;
if (matrix.GetLength(0) == matrix.GetLength(1))
{
    int colCoord, rowCoord;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        rowCoord = 0;
        colCoord = j;
        double suma = 0;
        for (int k = 0; k < matrix.GetLength(0) - j; k++)
        {
            suma += matrix[rowCoord, colCoord];
            rowCoord++;
            colCoord++;
        }
        if (sumDiagonal < suma)
            sumDiagonal = suma;
        diagonalC++;
        Console.WriteLine($"diagonal #{diagonalC} = {suma}");
    }
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        rowCoord = i;
        colCoord = 0;
        double sum7 = 0;
        for (int k = 0; k < matrix.GetLength(1) - i; k++)
        {
            sum7 += matrix[rowCoord, colCoord];
            rowCoord++;
            colCoord++;
        }
        if (sumDiagonal < sum7)
            sumDiagonal = sum7;
        diagonalC++;
        Console.WriteLine($"diagonal #{diagonalC} = {sum7}");
    }
}
//суму елементів в тих стовпцях, які не містять від’ємних елементів;
int sum = 0;
int negElem = 0;
int w = 0;
for (int i = 0; i < matrix.GetLength(1); i++)
{
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (matrix[j, i] < 0)
        {
            negElem = 1;
            break;
        }

        sum += matrix[j, i];
    }
    if (negElem == 0)
    {
        Console.WriteLine($"Sum elements {i} column = {sum}");
        w = 1;
    }

    sum = 0;
}
if (w == 0)
    Console.WriteLine("There is no columns with negative elemets");

//мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;
double diagonalCount = 0, maxV = 0; ;
if (matrix.GetLength(0) == matrix.GetLength(1))
{
    int colC, rowC; 
    int up = matrix.GetUpperBound(1);
    for (int j = matrix.GetLength(1); j > 0; j--)
    {
        rowC = 0;
        colC = up;
        double sum9 = 0;
        for (int k = 0; k < j; k++)
        {
            sum9 += Math.Abs(matrix[rowC, colC]);
            rowC++;
            colC--;
        }
        if (maxV > sum9)
            maxV = sum9;
        up--;
        diagonalCount++;
        Console.WriteLine($"diagonal #{diagonalCount} = {sum9}");
    }
    up = matrix.GetUpperBound(0);
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        rowC = i;
        colC = up;
        double sum9 = 0;
        for (int k = 0; k < matrix.GetLength(0) - i; k++)
        {
            sum9 += Math.Abs(matrix[rowC, colC]);
            rowC++;
            colC--;
        }
        if (maxV > sum9)
            maxV = sum9;
        diagonalCount++;
        Console.WriteLine($"diagonal #{diagonalCount} = {sum9}");
    }
}
//суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент;
int summa = 0;
int NegativeElem = 0;
int e = 0;
for (int i = 0; i < matrix.GetLength(1); i++)
{
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        if (matrix[j, i] < 0)
            NegativeElem = 1;

        summa += matrix[j, i];

    }
    if (NegativeElem != 0)
    {
        Console.WriteLine($"Sum elements {i} сcolumn = {summa}");
        e = 1;
    }

    summa = 0;
}
if (e == 0)
    Console.WriteLine("There is no columns with negative elemets");

//Транспорт матриця
for (int i = 0; i < matrix.GetLength(1); i++)
{
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        Console.Write($"{matrix[j, i],6}");
    }
    Console.WriteLine();
}



