using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixFunctions
    {
        public static void PrintMatrix(int[,] Array)
        {
            Console.WriteLine();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write(Array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static int NumberOfPositiveElements(int[,] Array)
        {
            int countPositivElements = 0;

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] > 0)
                    {
                        countPositivElements++;
                    }
                }
            }
            return countPositivElements;
        }
        public static int MaxNumberOccursMoreThanOnce(int[,] Array)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (dict.ContainsKey(Array[i, j]))
                    {
                        dict[Array[i, j]]++;
                    }
                    else
                    {
                        dict[Array[i, j]] = 1;
                    }
                }
            }

            int maxNum = 0;
            int maxCount = 0;
            foreach (var num in dict)
            {
                if (num.Value > 1 && num.Key > maxNum)
                {
                    maxNum = num.Key;
                    maxCount = num.Value;
                }
            }
            return maxNum;
        }
        public static int NumberOfRowsDoNotWithoutZeros(int[,] Array)
        {
            int count = 0;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                bool hasZero = false;
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero)
                {
                    count++;
                }
            }
            return count;
        }
        public static int NumberOfColumnsWithZeroes(int[,] Array)
        {
            int count = 0;
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                bool hasZero = false;
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    if (Array[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    count++;
                }
            }
            return count;
        }
        public static int FindLongestSeriesRows(int[,] Array)
        {
            int maxLength = 0;
            int maxRow = 0;
            int currentLength = 1;

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 1; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] == Array[i, j - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                            maxRow = i;
                        }
                        currentLength = 1;
                    }
                }
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxRow = i;
                }
                currentLength = 1;
            }
            maxRow++;
            return maxRow;
        }
        public static int MultiplicationOfPositiveElementsInRows(int[,] Array)
        {
            int product = 1;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                bool hasNegative = false;
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (!hasNegative)
                {
                    for (int j = 0; j < Array.GetLength(1); j++)
                    {
                        product *= Array[i, j];
                    }
                }
            }
            return product;
        }
        public static int MaxSumOfElementsInDiagonals(int[,] Array)
        {
            int maxSum = int.MinValue;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = i, k = 0; j < Array.GetLength(0) && k < Array.GetLength(1); j++, k++)
                {
                    sum += Array[j, k];
                }
                maxSum = Math.Max(maxSum, sum);
            }

            for (int i = 1; i < Array.GetLength(1); i++)
            {
                int sum = 0;
                for (int j = 0, k = i; k < Array.GetLength(1); j++, k++)
                {
                    sum += Array[j, k];
                }
                maxSum = Math.Max(maxSum, sum);
            }
            return maxSum;
        }
        public static int SumOfElementsInColumnsWithoutNegatives(int[,] Array)
        {
            int sum = 0;
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                bool hasNegative = false;
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    if (Array[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (!hasNegative)
                {
                    for (int i = 0; i < Array.GetLength(0); i++)
                    {
                        sum += Array[i, j];
                    }
                }
            }
            return sum;
        }
        public static int MinSumOfAbsoluteValuesInDiagonals(int[,] Array)
        {
            int minSum = int.MaxValue;
            for (int i = 0; i < Array.GetLength(1); i++)
            {
                int sum = 0;
                for (int j = 0, k = i;
                     j < Array.GetLength(0) && k >= 0
                     ; j++, k--)
                {
                    sum += Math.Abs(Array[j, k]);
                }
                minSum = Math.Min(minSum, sum);
            }
            for (int i = 1; i < Array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = i, k = Array.GetLength(1) - 1;
                     j < Array.GetLength(0);
                     j++, k--)
                {
                    sum += Math.Abs(Array[j, k]);
                }
                minSum = Math.Min(minSum, sum);
            }
            return minSum;
        }
        public static int SumOfElementsInColumnsWithNegatives(int[,] Array)
        {
            int sum = 0;
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                bool hasNegative = false;
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    if (Array[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (hasNegative)
                {
                    for (int i = 0; i < Array.GetLength(0); i++)
                    {
                        sum += Array[i, j];
                    }
                }
            }
            return sum;
        }
        public static int[,] TransposeMatrix(int[,] Array)
        {
            int[,] transposedMatrix = new int[Array.GetLength(1), Array.GetLength(0)];
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    transposedMatrix[j, i] = Array[i, j];
                }
            }
            return transposedMatrix;
        }
    }
}
