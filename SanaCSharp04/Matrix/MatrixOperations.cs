using System;
using System.Linq;
using System.Xml.Linq;

namespace Matrix
{
    internal class MatrixOperations
    {
        public static int[,] GenerateMatrix(int N, int M, int min, int max)
        {
            var matrix = new int[N, M];

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = new Random().Next(min, max);
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0,4}", matrix[i, j])); ;
                }
                Console.WriteLine();
            }
        }

        public static int GetCountOfPositiveNumbers(int[,] matrix)
        {
            var count = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int GetNumberThatRepeatsMoreThanOneTime(int[,] matrix)
        {
            return 0;
        }

        public static int GetCountOfNotContainedZeroForRows(int[,] matrix)
        {
            var count = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                if (!GetRow(matrix, i).Contains(0))
                {
                    count++;
                }
            }

            return count;
        }

        public static int[] GetRow(int[,] matrix, int rowIndex)
        {
            var array = new int[matrix.GetLength(1)];
            for (var j = 0; j < array.Length; j++)
            {
                array[j] = matrix[rowIndex, j];
            }

            return array;
        }

        public static int GetCountOfContainedZeroForColumns(int[,] matrix)
        {
            var count = 0;
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (GetColumn(matrix, j).Contains(0))
                {
                    count++;
                }
            }

            return count;
        }

        public static int[] GetColumn(int[,] matrix, int columnIndex)
        {
            var array = new int[matrix.GetLength(0)];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = matrix[i, columnIndex];
            }

            return array;
        }

        public static void MultiplicationOfRowsWithoutNegativeNumbers(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var row = GetRow(matrix, i);
                if (!row.Any(item => item < 0))
                {
                    Console.WriteLine($"Рядок {i}: {GetMultiplicationOfElemInRow(row)}");
                }
            }
        }

        public static int GetMultiplicationOfElemInRow(int[] arr)
        {
            var mul = 1;
            for (var i = 0; i < arr.Length; i++)
            {
                mul *= arr[i];
            }

            return mul;
        }


        public static int GetMaxAmongSumsOfDiagonalElementsParallelToMain(int[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int indexRow, indexCol;
                var maxSum = 0;
                for (var j = 1; j < matrix.GetLength(1); j++)
                {
                    indexRow = 0;
                    indexCol = j;
                    var sum = 0;
                    for (var i = 0; i < matrix.GetLength(0) - j; i++)
                    {
                        sum += matrix[indexRow, indexCol];
                        indexRow++;
                        indexCol++;
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }

                for (var i = 1; i < matrix.GetLength(0); i++)
                {
                    indexRow = i;
                    indexCol = 0;
                    var sum = 0;
                    for (var j = 0; j < matrix.GetLength(1) - i; j++)
                    {
                        sum += matrix[indexRow, indexCol];
                        indexRow++;
                        indexCol++;
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }

                return maxSum;
            }
            else
            {
                return 0;
            }
        }

        public static void SumOfColumnsWithoutNegativeNumbers(int[,] matrix)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                var column = GetColumn(matrix, j);
                if (!column.Any(item => item < 0))
                {
                    Console.WriteLine($"Cтовпець {j}: {column.Sum()}");
                }
            }
        }

        public static int GetMinSumAmongSumsOfDiagonalElementsParallelToSide(int[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int indexRow, indexCol;
                var minSum = int.MaxValue;
                for (var j = matrix.GetLength(1); j > 1; j--)
                {
                    indexRow = 0;
                    indexCol = j - 2;
                    var sum = 0;
                    for (var i = 0; i < j - 1; i++)
                    {
                        sum += Math.Abs(matrix[indexRow, indexCol]);
                        indexRow++;
                        indexCol--;
                    }
                    if (sum < minSum)
                    {
                        minSum = sum;
                    }
                }
                for (var i = 1; i < matrix.GetLength(0); i++)
                {
                    indexRow = i;
                    indexCol = matrix.GetLength(1) - 1;
                    var summa = 0;
                    for (var j = 0; j < matrix.GetLength(1) - i; j++)
                    {
                        summa += Math.Abs(matrix[indexRow, indexCol]);
                        indexRow++;
                        indexCol--;
                    }
                    if (summa < minSum)
                    {
                        minSum = summa;
                    }
                }
                return minSum;
            }
            else
            {
                return 0;
            }
        }

        public static void SumOfColumnsWithNegativeNumbers(int[,] matrix)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                var column = GetColumn(matrix, j);
                if (column.Any(item => item < 0))
                {
                    Console.WriteLine($"Cтовпець {j}: {column.Sum()}");
                }
            }
        }

        public static void PrintTransportMatrix(int[,] matrix)
        {
            var matrix_t = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix_t[j, i] = matrix[i, j];
                }
            }

            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                for (var j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(string.Format("{0,4}", matrix_t[i, j]));
                }
                Console.WriteLine();
            }
        }

        public static int GetMaxElemMoreThanOneTime(int[,] matrix)
        {
            var maxRepeated = int.MinValue;
            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                for (var j = 0; j < matrix.GetLength(0); j++)
                {
                    var count = 0;
                    var current = matrix[i, j];
                    for (var i1 = 0; i1 < matrix.GetLength(1); i1++)
                    {
                        for (var j1 = 0; j1 < matrix.GetLength(0); j1++)
                        {
                            if (matrix[i1, j1] == current)
                            {
                                count++;
                            }
                        }
                        if (count > 1 && current > maxRepeated)
                        {
                            maxRepeated = current;
                        }
                    }
                }
            }

            return maxRepeated;
        }

        public static int GetRowIndexWithLargestRepeated(int[,] matrix)
        {
            var counter = 1;
            var rowIndexWithMaxElement = 0;
            var maxElementsInRow = 1;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        counter++;
                        if (counter > maxElementsInRow)
                        {
                            maxElementsInRow = counter;
                            rowIndexWithMaxElement = i;
                        }
                    }
                }
                counter = 1;
            }

            return rowIndexWithMaxElement;
        }

    }
}
