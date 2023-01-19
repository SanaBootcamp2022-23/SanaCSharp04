using System;
using System.Numerics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Random random = new Random();
        int n = 0,
            m = 0,
            min = 0,
            max = 0;
        Console.Write("Кiлькiсть рядкiв: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Кiлькiсть стовпцiв: ");
        m = int.Parse(Console.ReadLine());
        Console.Write("Мiнiмальне значення: ");
        min = int.Parse(Console.ReadLine());
        Console.Write("Максимальне значення: ");
        max = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(min, max);
            }
        }
        printMatrix(matrix);
        getPositiveNumbersCount(matrix);
        maxMoreThanTwoTimes(matrix);
        getNotNullRowsCount(matrix);
        getColsWithNullCount(matrix);
        getLongestSeriesRowIndex(matrix);
        getProductOfRowsWhithoutNegative(matrix);
        maxParallelDiagonal(matrix);
        sumOfColumnWhereNoNegative(matrix);
        MinDiagonales(matrix);
        sumOfColumnWhereContainsNegative(matrix);
        transposeMatrix(matrix);
        Console.WriteLine("Трансформована матриця: ");
        printMatrix(matrix);
    }
    static public void getPositiveNumbersCount(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > 0)
                    count++;
            }
        }
        Console.WriteLine($"Кількість додатних елементів: {count}");
    }
    static public void maxMoreThanTwoTimes(int[,] matrix)
    {
        int t = 0, t1 = 0, r = 0, t2;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                t2 = matrix[i, j];
                matrix[i, j] = 0;

                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    for (int f = 0; f < matrix.GetLength(0); f++)
                    {
                        if (t2 == matrix[k, f])
                        {
                            t = matrix[k, f];
                        }
                        else
                            r++;
                    }

                    if (t1 > t)
                        t = t1;
                }
                t1 = t;
                matrix[i, j] = t2;
            }
        }
        Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {t}");
    }
    static public void getNotNullRowsCount(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            bool isNotNullRow = true;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                if (matrix[i, j] == 0)
                    isNotNullRow = false;
            }
            if (isNotNullRow)
                count++;
        }
        Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента: {count}");
    }
    static public void getColsWithNullCount(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            bool isNullCol = false;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] == 0)
                {
                    isNullCol = true;
                    break;
                }
            }
            if (isNullCol)
                count++;
        }
        Console.WriteLine($"Кількість стовпців, які містять хоча б один нульовий елемент: {count}");
    }
    static public void getLongestSeriesRowIndex(int[,] matrix)
    {
        int maxRangeCount = 0;
        int maxRangeRow = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int prevElement = matrix[i, 0];
            int rangeCount = 1;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == prevElement)
                {
                    rangeCount++;
                }
                else
                {
                    rangeCount = 0;
                    prevElement = matrix[i, j];
                }
            }
            if (rangeCount > maxRangeCount)
            {
                maxRangeCount = rangeCount;
                maxRangeRow = i;
            }
        }
        Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {maxRangeRow}");
    }
    static public void getProductOfRowsWhithoutNegative(int[,] matrix)
    {
        Console.WriteLine($"Добуток елементів в тих рядках, які не містять від’ємних елементів:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int product = 1;
            bool isNoNegativeInRow = true;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                {
                    isNoNegativeInRow = false;
                    break;
                }
                product *= matrix[i, j];
            }
            if (isNoNegativeInRow)
            {
                Console.WriteLine($"\tДобуток рядка {i}: {product}");
            }
        }

    }
    static public void maxParallelDiagonal(int[,] matrix)
    {
        int? max = null;
        for (int i = 1 - matrix.GetLength(1); i < matrix.GetLength(1); i++)
        {
            int sum = 0;
            int j = i < 0 ? -i : 0;
            int r = i < 0 ? 0 : i;
            while (j < matrix.GetLength(0) && r < matrix.GetLength(1))
            {
                sum += matrix[j++, r++];
            }
            if (max == null || sum > max) { max = sum; }
        }
        Console.WriteLine($"Максимум серед сум елементiв дiагоналей, паралельних головнiй дiагоналi матрицi: {max}");
    }
    static public void sumOfColumnWhereNoNegative(int[,] matrix)
    {
        Console.WriteLine($"Сума елементів в тих стовпцях, які не містять від’ємних елементів:");
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            bool isNoNegativeCol = true;
            int sum = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] < 0)
                {
                    isNoNegativeCol = false;
                    break;
                }
                sum += matrix[i, j];
            }
            if (isNoNegativeCol)
            {
                Console.WriteLine($"\tСума елементів стовпця {i}: {sum}");
            }
        }
    }
    static public void MinDiagonales(int[,] matrix)
    {
        int min = int.MaxValue;
        for (int k = 1; k != matrix.GetLength(0); k++)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = matrix.GetLength(0) - 1, j = 0; i >= k; i--, j++)
            {
                sum1 += Math.Abs(matrix[i - k, j]);
                sum2 += Math.Abs(matrix[i, j + k]);
            }
            min = Math.Min(min, Math.Min(sum1, sum2));
        }
        Console.WriteLine("Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: " + min);
    }
    static public void sumOfColumnWhereContainsNegative(int[,] matrix)
    {
        Console.WriteLine($"Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент:");
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            bool isNegativeContains = false;
            int sum = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] < 0)
                {
                    isNegativeContains = true;
                    break;
                }
                sum += matrix[i, j];
            }
            if (isNegativeContains)
            {
                Console.WriteLine($"\tСума елементів стовпця {i}: {sum}");
            }
        }
    }
    static public void transposeMatrix(int[,] matrix)
    {
        int t;
        for (int i = 0; i < matrix.GetLength(0); ++i)
        {
            for (int j = i; j < matrix.GetLength(1); ++j)
            {
                t = matrix[i, j];
                matrix[i, j] = matrix[j, i];
                matrix[j, i] = t;
            }
        }
    }
    static public void printMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}