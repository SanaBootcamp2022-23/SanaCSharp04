using System.Runtime.CompilerServices;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

int n, m;

Console.Write("Введіть кількість рядків: ");
CheckArrayLength(Console.ReadLine(), out n);
Console.Write("Введіть кількість стовпців: ");
CheckArrayLength(Console.ReadLine(), out m);

int[,] matrix = fillMatrix(n,m);
printMatrix(matrix);
Console.WriteLine($"Кількість додатніх елементів матриці: {positiveCount(matrix)}");
Console.WriteLine($"Кількість рядків без нульових елеметів: {countOfRowsWithoutZero(matrix)}");
Console.WriteLine($"кількість стовпців, які містять хоча б один нульовий елемент: {countOfColsWithZeroEl(matrix)}");
Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {longestSequenceOfIdenticalEls(matrix)}");
Console.WriteLine($"Добуток елементів в тих рядках, які не містять від’ємних елементі:");
List<int> resMult = nultRowWithoutNegs(matrix);
foreach (int i in resMult)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
Console.WriteLine($"Суму елементів в тих стовпцях, які не містять від’ємних елементів:");
List<int> resSum = sumColsWithoutNegs(matrix);
foreach (int i in resSum)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
Console.WriteLine($"Транспонована матриця:");
printMatrix(TransopnMatrix(matrix));

Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {maxElMoreThanOnce(matrix)}");


int[,] TransopnMatrix(int[,] matrix)
{
    int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for(int i =0; i<matrix.GetLength(0); i++)
    {
        for(int j =0; j<matrix.GetLength(1); j++)
        {
            newMatrix[j,i] = matrix[i,j];
        }
    }
    return newMatrix;
}

List<int> sumColsWithoutNegs(int[,] matrix)
{
    List<int> resSum = new List<int>();
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        int sum = 1;
        bool fl = true;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (matrix[i, j] >= 0)
            {
                sum += matrix[i, j];
            }
            else
            {
                fl = false;
                break;
            }
        }
        if (fl)
            resSum.Add(sum);
    }
    return resSum;
}

List<int> nultRowWithoutNegs(int[,] matrix)
{
    List<int> resMult = new List<int>();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int mult = 1;
        bool fl = true;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i,j] >= 0)
            {
                mult *= matrix[i, j];
            }
            else
            {
                fl = false;
                break;
            }
        } 
        if(fl)
            resMult.Add(mult);
    }
    return resMult;
}

int longestSequenceOfIdenticalEls(int[,] matrix)
{
    int rowId = 0;
    int seqLength = 0;
    int maxSeq = 0;
    for(int i =0; i < matrix.GetLength(0); i++)
    {
        for(int j =1; j<matrix.GetLength(1); j++)
        {
            if(matrix[i,j-1] == matrix[i, j])
            {
                seqLength++;
            }
        }
        if (maxSeq <= seqLength)
        {
            maxSeq = seqLength;
            rowId = i;
        }
        seqLength = 0;
    }
    return rowId;
}

int countOfColsWithZeroEl(int[,] matrix)
{
    int resCount = 0;
    for(int i =0; i<matrix.GetLength(1); i++)
    {
        int count = 0;
        for(int j =0; j<matrix.GetLength(0); j++)
        {
            if(matrix[i,j] == 0)
            {
                count++;
            }
        }
        if (count > 0)
        {
            resCount++;
        }
    }
    return resCount;
}

int countOfRowsWithoutZero(int[,] matrix)
{
    int resCount = 0;
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (matrix[i,j] == 0)
            {
                count++;
            }
        }
        if (count == 0)
        {
            resCount++;
        }

    }
    return resCount;
}

int maxElMoreThanOnce(int[,] matrix)
{
    int count = 0;
    int maxEl = matrix[0,0];
    int topBorder = maxEl+1;
    do
    {
        maxEl = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (maxEl < topBorder)
                {
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                    }
                }
            }
        }
        count = countEl(matrix, maxEl);
        if ( count == 1)
        {
            topBorder = maxEl;
        }
    } while (count == 1);
    return maxEl;
}

int countEl(int[,] matrix, int el)
{
    int count = 0;
    for(int i =0; i < matrix.GetLength(0); i++)
    {
        for(int j =0; j<matrix.GetLength(1); j++)
        {
            if (matrix[i,j] == el)
            {
                count++;
            }
        }
    }
    return count;
}

int positiveCount(int[,] matrix)
{
    int count = 0;
    for(int i =0; i<matrix.GetLength(0); i++)
    {
        for(int j =0; j<matrix.GetLength(1); j++)
        {
            if (matrix[i,j] > 0)
            {
                count++;
            }
        }
    }
    return count;
}

int[,] fillMatrix(int n, int m)
{
    int[,] matrix = new int[n, m];
    for(int i =0; i<n; i++)
    {
        for(int j =0; j < m; j++)
        {
            Random r = new Random();
            matrix[i, j] = r.Next(-10, 10);
        }
    }
    return matrix;
}

void printMatrix(int[,] matrix)
{
    for(int i =0; i<matrix.GetLength(0); i++)
    {
        for(int j =0; j<matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void CheckArrayLength(string? s, out int a)
{
    bool fl = false;
    do
    {
        if (!int.TryParse(s, out a) || a <= 0)
        {
            Console.Write("\tПомилка! Невірна довжина масиву!\nВведіть ще раз: ");
            s = Console.ReadLine();
        }
        else
        {
            fl = true;
        }
    } while (!fl);
}

