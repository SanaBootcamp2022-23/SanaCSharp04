using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class Matrix
    {
        public static int[,] CreateMatrix(int rowCount, int colCount)
        {
            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"matrix[{i},{j}] = ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            return matrix;
        }

        public static int[,] GenerateMatrix(int rowCount, int colCount)
        {
            int[,] matrix = new int[rowCount, colCount];
            Random rand = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rand.Next(-7, 8);

            return matrix;
        }

        public static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write($"{matrix[i, j],6}");

                    Console.ResetColor();
                }
                        

                Console.WriteLine();
            }
                
        }

        public static void ShowInfo(string str, object obj)
        {
            Console.WriteLine($"{str}: {obj}");
        }

        public static int CountPositiveElem(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > -1)
                        count++;

            return count;
        }

        public static object MaxRepeatElem(int[,] matrix)
        {
            int[] maxElem = {int.MinValue, 0};
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        foreach (int value in matrix)
                            if (value == matrix[i, j])
                                count++;

                        if (count > 1 && ((count > maxElem[1]) || count == maxElem[1] && matrix[i, j] > maxElem[0]))
                        {
                            maxElem[0] = matrix[i, j];
                            maxElem[1] = count;
                        }

                        count = 0;
                    }
            return (maxElem[0] != int.MinValue) ? maxElem[0] : "Не знайдено елемент";
        }

        public static int CountRowWithoutZero(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        break;

                    if (j + 1 == matrix.GetLength(1))
                        count++;
                }
            return count;

        }

        public static int CountColWithZero(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    if (matrix[j, i] == 0)
                    {
                        count++;
                        break;
                    }
            return count;
        }

        public static int IndexLineEqualElem(int[,] matrix)
        {
            int countStart = 0, countFinal = 0;
            int index = -1;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                countStart = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                        if (matrix[i, j] == matrix[i, k])
                            countStart++;

                    if (index == -1 || (index != -1 && index != i && countFinal < countStart))
                            {
                                countFinal = countStart;
                                index = i;
                            }
            }
            return index+1;

        }

        public static void MultiplyPositiveElem(int[,] matrix)
        {
            int multRes = 1;
            int checkFor = 0, checkWrite = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        checkFor = 1;
                        break;
                    }
                        
                    multRes *= matrix[i, j];
                }
                if (checkFor == 0)
                {
                    Console.WriteLine($"Добуток {i + 1} рядка = {multRes}");
                    checkWrite = 1;
                }
                    
                checkFor = 0;
                multRes = 1;
            }
            if (checkWrite == 0)
                Console.WriteLine("Такого рядка не знайдено");
        }

        public static object MaxAndMinSumDiagonal(int[,] matrix, int mode = 0)
        {
            int sum = 0;

            int maxSum = int.MinValue;
            int minSum = int.MaxValue;
            int maxGetLength = Math.Max(matrix.GetLength(0), matrix.GetLength(1));
                for (int i = 1; i < maxGetLength; i++)
                {
                    sum = 0;
                    for (int j = 0; ; j++)
                    { 
                        if (j < matrix.GetLength(0) && j + i < matrix.GetLength(1))
                            sum+= matrix[j, j + i];
                        else
                            break;
                    }
                if (sum > maxSum)
                    maxSum = sum;
                if (Math.Abs(sum) < minSum)
                    minSum = Math.Abs(sum);

                    sum = 0;

                    for (int j = 0; ; j++)
                    {
                        if (j < matrix.GetLength(1) && j + i < matrix.GetLength(0))
                            sum += matrix[i+j, j];
                        else
                            break;
                    }
                if (sum > maxSum)
                    maxSum = sum;
                if (Math.Abs(sum) < minSum)
                    minSum = Math.Abs(sum);
            }

                if(mode == 0)
                    if (maxSum != int.MinValue)
                        return maxSum;

                if(mode == 1)
                    if (minSum != int.MaxValue)
                        return minSum;

            return "Не знайдено";
        }

        public static void SumPositiveElem(int[,] matrix)
        {
            int sum = 0;
            int checkNegativeElem = 0;
            int checkWrite = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        checkNegativeElem = 1;
                        break;
                    }

                    sum += matrix[j, i];
                }
                if(checkNegativeElem == 0)
                {
                    Console.WriteLine($"Сума елементів {i}-го стовпця = {sum}");
                    checkWrite = 1;
                }
                    
                sum = 0;
            }
            if (checkWrite == 0)
                Console.WriteLine("Не знайдено стовпців, які не містять від'ємних елементів");
        }

        public static void SumNegativeElem(int[,] matrix)
        {
            int sum = 0;
            int checkNegativeElem = 0;
            int checkWrite = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                        checkNegativeElem = 1;

                    sum += matrix[j, i];

                }
                if (checkNegativeElem != 0)
                {
                    Console.WriteLine($"Сума елементів {i}-го стовпця = {sum}");
                    checkWrite = 1;
                }

                sum = 0;
            }
            if (checkWrite == 0)
                Console.WriteLine("Не знайдено стовпців, які не містять від'ємних елементів");
        }

        public static void ShowTranspositionMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($"{matrix[j,i],6}");
                }
                Console.WriteLine();
            }
        }
    }
}
