using System;
using System.Diagnostics.Metrics;
using System.Text;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            const int rowCount = 4, colCount = 4;

            int posValueCount = 0,
                maxValue = 0,
                moreThanOnсeValue = 0;

            bool isZeroRow = false,
                isZeroColumn = false;

            int noZeroRow = 0,
                zeroColumn = 0,
                mostRepeatedRow = 0,
                maxRepeatsRow = 0,
                row = 0, col = 0,
                counter = 0;

            float res = 0, diagonalSum = 0, 
                sumPosValuesInCol = 0,
                sumNegValuesInCol = 0,
                minDiagonalSum = 0;
;

            List<int> moreThanOnceList = new List<int>();



            int[,] arr = Generate2DArray(rowCount, colCount);
            Print2DArray(arr);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] >= 0) posValueCount++;
                    if (arr[i, j] == 0) isZeroRow = true;

                    moreThanOnсeValue = arr[i, j];
                    if (moreThanOnсeValue == arr[i, j]) moreThanOnceList.Add(arr[i, j]);
                }
                if (!isZeroRow) noZeroRow++;
                isZeroRow = false;
            }

            foreach (var value in moreThanOnceList)
            {
                if (value > maxValue) maxValue = value;
            }

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, j] == 0) isZeroColumn = true;
                }
                if (isZeroColumn) zeroColumn++;
                isZeroColumn = false;
            }


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                counter = 0;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == arr[i, j - 1])
                    {
                        counter++;
                    }
                }
                if (counter > mostRepeatedRow)
                {
                    mostRepeatedRow = counter;
                    maxRepeatsRow = i;
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                counter = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < 0)
                    {
                        counter++;
                    }
                }
                if (counter == 0)
                {
                    for (int k = 0; k < arr.GetLength(1); k++)
                    {
                        res *= arr[i, k];
                    }
                }
            }

            for (int j = 1; j < arr.GetLength(1); j++) 
            {
                row = 0;
                col = j;
                res = 0;
                while (row < arr.GetLength(0) && col < arr.GetLength(1))
                {
                    res += arr[row, col];
                    row++;
                    col++;
                }
                if (res > diagonalSum)
                {
                    diagonalSum = res;
                }
            }

            for (int i = 1; i < arr.GetLength(0); i++) 
            {
                row = i;
                col = 0;
                res = 0;
                while (row < arr.GetLength(0) && col < arr.GetLength(1))
                {
                    res += arr[row, col];
                    row++;
                    col++;
                }
                if (res > diagonalSum)
                {
                    diagonalSum = res;
                }
            }

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                counter = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, j] < 0)
                    {
                        counter++;
                    }
                }
                if (counter == 0)
                {
                    for (int a = 0; a < arr.GetLength(0); a++)
                    {
                        sumPosValuesInCol += arr[a, j];
                    }
                }
            }

            for (int i = 1; i < arr.GetLength(0); i++)
            {
                res = 0;
                row = i;
                col = arr.GetLength(1) - 1;
                while (row < arr.GetLength(0) && col >= 0)
                {
                    res += Math.Abs(arr[row, col]);
                    row++;
                    col--;
                }
                if (res < minDiagonalSum)
                {
                    minDiagonalSum = res;
                }
            }
            for (int j = arr.GetLength(1) - 2; j >= 0; j--)
            {
                row = 0;
                col = j;
                res = 0;
                while (row < arr.GetLength(0) && col >= 0)
                {
                    res += Math.Abs(arr[row, col]);
                    row++;
                    col--;
                }
                if (res < minDiagonalSum)
                {
                    minDiagonalSum = res;
                }
            }

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                counter = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, j] < 0)
                    {
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    for (int a = 0; a < arr.GetLength(0); a++)
                    {
                        sumNegValuesInCol += arr[a, j];
                    }
                }
            }


            Console.WriteLine($"К-сть додатніх елементів: {posValueCount}");
            Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {maxValue}");
            Console.WriteLine($"К-сть рядків які не містять нульових елементів: {noZeroRow}");
            Console.WriteLine($"К-сть стовпців які містять нульові елементи: {zeroColumn}");
            Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {maxRepeatsRow}");
            Console.WriteLine($"Добуток елементів в тих рядках, які не містять від’ємних елементів: {res}");
            Console.WriteLine($"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {diagonalSum}");
            Console.WriteLine($"Cуму елементів в тих стовпцях, які не містять від’ємних елементів: {sumPosValuesInCol}");
            Console.WriteLine($"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {minDiagonalSum}");
            Console.WriteLine($"суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: {sumNegValuesInCol}");
            Console.WriteLine($"Транспонована матриця: ");
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write($"{arr[j, i],5}");
                }
                Console.WriteLine();
            }
        }
        private static int[,] Generate2DArray(int rowCount, int colCount)
        {
            int[,] arr = new int[rowCount, colCount];
            Random random = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(-5, 10);
                }
            }
            return arr;
        }


        private static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}