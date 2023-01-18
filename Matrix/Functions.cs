using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Numerics;
using System.Diagnostics.CodeAnalysis;

namespace Matrix
{
    internal class Functions
    {
        public static int[,] GenerateMatrix(int rowCount, int colCount) 
        {
            int[,] matrix = new int[rowCount, colCount];
            Random rand = new Random();
            Console.Write("\nВведіть число A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введіть число B: ");
            int b = int.Parse(Console.ReadLine());
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = rand.Next(a, b + 1);
            }
            return matrix;
        }
        public static void PrintMatrix(int[,] matrix) 
        {
            Console.WriteLine("\nЗгенерована матриця: ");
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write($"{matrix[i, j], 3} ");
                Console.WriteLine("");    
            }
        }
        public static void posCount(int[,] matrix ) 
        {
            int posCount = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0) { 
                        posCount++; 
                    }
                }
            }
            Console.WriteLine($"\n1. Кількість додатніх елементів у матриці: {posCount}\n");
        }
        public static void maxElement(int[,] matrix, int rowCount, int colCount)
        {
            int p = 0, max = int.MinValue, count = 0;
            int[] arr = new int[rowCount * colCount], frequency = new int[rowCount * colCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    arr[p++] = matrix[i, j];
                }
            }
            for (int k = 0; k < p; k++)
            {
                frequency[k] = -1;
                count = 1;
                for (int l = k + 1; l < p; l++)
                {
                    if (arr[k] == arr[l])
                    {
                        count++;
                        frequency[l] = 0;
                    }
                }
                if (frequency[k] != 0) frequency[k] = count;
            }
            Console.Write("2. Максимальний елемент масиву, який зустрічався більше разу: ");
            for (int k = 0; k < p; k++)
            {
                if (max < arr[k] && frequency[k] > 1) max = arr[k];
            }
            Console.Write($"{max}\n");
        }
        public static void countOfRowsWithoutZeroes(int[,] matrix)
        {
            int rowsWith0 = 0, count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if (matrix[i, j] == 0)
                        rowsWith0++;
                }
                if (rowsWith0 == 0) 
                    count++;
                rowsWith0 = 0;
            }
            Console.WriteLine($"\n3. Кількість рядків, які не містять жодного нульового елемента: {count}");
        }
        public static void countOfColsWithZeroes(int[,] matrix)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        count++;
                        break;
                    }
                }
            }
            Console.Write($"\n4. Кількість стовпців, які містять хоча б один нульовий елемент: ");
            if (count == 0) Console.Write("відсутні");
            else Console.WriteLine($"{count}");
        }
        public static void maxSerieOfElements(int[,] matrix) {
            int maxSerie = 0, cycleSeries = 1, row = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == matrix[i, j - 1])
                        cycleSeries++;
                    else
                    {
                        if (cycleSeries > maxSerie) {
                            maxSerie = cycleSeries;
                            row = i;
                        }
                        cycleSeries = 1;
                    }
                }
                if (cycleSeries > maxSerie)
                {
                    maxSerie = cycleSeries;
                    row = i;
                }
                cycleSeries = 1;
            }
            Console.Write($"\n5. Найдовша серія елементів: ");
            if (maxSerie == 1) Console.Write("відсутня");
            else Console.Write($"{maxSerie} в рядку {row + 1}");
        }
        public static void prodOfElementsInRowsWithoutNegElements(int[,] matrix) {
            Int64 totalProd = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool notANull = false;
                long cycleProd = 1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    cycleProd *= matrix[i, j];
                    if (matrix[i, j] > 0)
                        notANull = true;
                    else break;
                }
                if (notANull == true)
                    totalProd *= cycleProd;
                else break;
            }
            Console.Write($"\n\n6. Добуток елементів в тих рядках, які не містять від'ємних елементів: ");
            if (totalProd == 1) Console.Write("відсутній");
            else Console.Write($"{totalProd}");
        }
        public static void maxOfDiagonales(int[,] matrix)
        {
            Console.Write("\n\n7. Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: ");
            int rowCoord, colCoord, sum = 0, max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum = 0;
                rowCoord = i;
                colCoord = 0;
                for (int k = 0; k < matrix.GetLength(1) - i; k++)
                {
                    if (rowCoord != colCoord)
                    {
                        sum += matrix[rowCoord, colCoord];
                        rowCoord++;
                        colCoord++;
                        if (max < sum) max = sum;
                    }
                }
            }
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                sum = 0;
                rowCoord = 0;
                colCoord = j;
                for (int k = 0; k < matrix.GetLength(1) - j; k++)
                {
                    if (rowCoord != colCoord)
                    {
                        sum += matrix[rowCoord, colCoord];
                        rowCoord++;
                        colCoord++;
                        if (max < sum) max = sum;
                    }
                }
            }
            Console.Write($"{max}\n");
        }
        public static void sumInRowsWithoutNegElements(int[,] matrix)
        {
            int totalSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                bool negative = false;
                int cycleSum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    cycleSum += matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        negative = true;
                    }
                }
                if (negative == false)
                {
                    totalSum += cycleSum;
                }
                else break;
            }
            Console.Write($"\n8. Сума елементів в тих рядках, які не містять від'ємних елементів: ");
            if (totalSum == 0) Console.Write("відсутня");
            else Console.Write($"{totalSum}");
        }
        public static void minOfDiagonales(int[,] matrix)
        {
            Console.Write("\n\n9. Мінімум серед сум елементів елементів діагоналей, паралельних побічній діагоналі матриці: ");
            int rowCoord, colCoord, sum = 0, min = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum = 0;
                rowCoord = i;
                colCoord = matrix.GetLength(0) - 1;
                for (int k = 0; k < matrix.GetLength(1) - i; k++)
                {
                    if (rowCoord != colCoord)
                    {
                        sum += Math.Abs(matrix[rowCoord, colCoord]);
                        rowCoord++;
                        colCoord--;
                        if (min > sum) min = sum;
                    }
                }
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum = 0;
                rowCoord = 0;
                colCoord = matrix.GetLength(1) - 1;
                for (int k = 0; k < j; k++)
                {
                    if (rowCoord != colCoord)
                    {
                        sum += Math.Abs(matrix[rowCoord, colCoord]);
                        rowCoord++;
                        colCoord--;
                        if (min > sum) min = sum;
                    }
                }
            }
            Console.Write($"{min}\n");
        }
        public static void sumOfElementsInColsWithAtlOneNegElement(int[,] matrix)
        {
            int total = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                bool negative = false;
                int cyclesum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    cyclesum += matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        negative = true;
                    }
                }
                if (negative == true) total += cyclesum;
                else break;
            }
            Console.Write("\n10. Сума елементів в стовбцях, які містять хоча б один від'ємний елемент: ");
            if (total == 0) Console.Write("відсутня");
            else Console.Write($"{total}");
        }
        public static void TransponedMatrix(int[,] matrix)
        {
            Console.WriteLine("\n\n11.Транспонована матриця");
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    Console.Write($"{matrix[i, j], 3} ");
                }
                Console.WriteLine("");
            } 
        }
    }
}
