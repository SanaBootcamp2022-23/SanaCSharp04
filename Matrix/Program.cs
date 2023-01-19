using System.Diagnostics.Metrics;
using System.Numerics;
using System.Text;

System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
customCulture.NumberFormat.NumberDecimalSeparator = ".";
System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;


int[,] matrix = CreateNewMatrix();

GenerateMatrixWithRandom(matrix);
PrintMatrix(matrix);
FindCountOfPositiveElems(matrix);
FindMaximumRepeatedNum(matrix);
CountingNonNullRows(matrix);
CountNullColumns(matrix);
FindLongestSeries(matrix);
Console.ReadLine();

void FindLongestSeries(int[,] matrix)
{
    int longestSeries = 0;
    int rowWithLongestSeries = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int currentSeries = 1;
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            if (matrix[i, j] == matrix[i, j + 1])
            {
                currentSeries++;
            }
            else
            {
                if (currentSeries > longestSeries)
                {
                    longestSeries = currentSeries;
                    rowWithLongestSeries = i;
                }
                currentSeries = 1;
            }
        }
        if (currentSeries > longestSeries)
        {
            longestSeries = currentSeries;
            rowWithLongestSeries = i;
        }
    }
    Console.WriteLine($"Найдовша серія однакових чисел: {longestSeries}, в рядку {rowWithLongestSeries + 1} ");
}
void CountNullColumns(int[,] matrix)
{
    int NullColumns = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        bool isThereNull = false;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[j, i] == 0)
            {
                isThereNull = true;
                break;
            }
        }
        if (isThereNull)
        {
            NullColumns++;
        }
    }
    Console.WriteLine($"Стовпців з 0 елементами : {NullColumns}");
}
void CountingNonNullRows(int[,] matrix)
{
    int nonNullRows = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        bool isThereNull = false;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 0)
            {
                isThereNull = true;
                break;
            }
        }
        if(isThereNull != true) { 
            nonNullRows++;
        }
    }
    Console.WriteLine($"Рядків з не 0 елементами : {nonNullRows}");
}
void FindMaximumRepeatedNum(int[,] matrix)
{
    int max = int.MinValue;
    Dictionary<int,int> numbers = new Dictionary<int, int>();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (numbers.ContainsKey(matrix[i, j]))
            {
                numbers[matrix[i, j]]++;
                if (numbers[matrix[i, j]] > 1 && matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
            else
            {
                numbers.Add(matrix[i, j], 1);
            }
        }
    }
    Console.WriteLine($"Максимальний повторюваний елемент: {max}");

}

int[,] CreateNewMatrix()
{
    int n, m;
    bool isNOk = false, isMOk = false;

    do
    {
        Console.WriteLine("\nВведіть n: ");
        isNOk = int.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Введіть m: ");
        isMOk = int.TryParse(Console.ReadLine(), out m);

    } while (isMOk != true && isNOk != true);

    int[,] matrix = new int[n, m];

    return matrix;
}

void FindCountOfPositiveElems(int[,] matrix)
{
    int counter = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > 0)
                counter++;
        }
    }

    Console.WriteLine($"Кількість додатніх елементів: {counter}");
}

void GenerateMatrixWithRandom(int[,] matrix)
{
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(-10, 10);
        }
    }
}

void SetMatrixNumbers(int[,] matrix)
{
    bool isOk = false;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            do
            {
                Console.WriteLine($"Введіть matrix[{i},{j}]: ");
                isOk = int.TryParse(Console.ReadLine(), out matrix[i, j]);
            } while (isOk != true);
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write("\t" + matrix[i, j]);
        }
        Console.WriteLine();
    }
}