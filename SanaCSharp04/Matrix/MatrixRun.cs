using System;

namespace Matrix
{
    public static class MatrixRun
    {
        static void Main()
        {
            int matrixHeight, matrixWidth;
            Console.Write($"Enter matrix width -> ");
            while (true)
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out matrixWidth))
                {
                    Console.WriteLine("Incorrect value");
                    continue;
                }
                break;
            }

            Console.Write($"Enter matrix height -> ");
            while (true)
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out matrixHeight))
                {
                    Console.WriteLine("Incorrect value");
                    continue;
                }
                break;
            }

            var matrix = MatrixRunHelpers.GenerateMatrix(matrixWidth, matrixHeight);
            MatrixRunHelpers.
                        PrintMatrix(matrix);

            int countOfPositive = 0;
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixHeight; j++)
                    if (matrix[i, j] > 0)
                    {
                        countOfPositive++;
                    }
            }

            Console.WriteLine($"Number of positive elements: {countOfPositive}");

            int maxRepeated = int.MinValue;
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixHeight; j++)
                {
                    var current = matrix[i, j];
                    var count = 0;
                    for (int i1 = 0; i1 < matrixWidth; i1++)
                    {
                        for (int j1 = 0; j1 < matrixHeight; j1++)
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
            Console.WriteLine($"The maximum number that occurs in the given matrix more than once: {maxRepeated}");


            var countRowsWithoutZero = 0;
            for (int i = 0; i < matrixWidth; i++)
            {
                var hasZero = false;
                for (int j = 0; j < matrixHeight; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero)
                {
                    countRowsWithoutZero++;
                }
            }
            Console.WriteLine($"The number of rows that do not contain any zero elements: {countRowsWithoutZero}");

            var countColsWithZero = 0;
            for (int j = 0; j < matrixWidth; j++)
            {
                var hasZero = false;
                for (int i = 0; i < matrixHeight; i++)
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                if (hasZero) { countColsWithZero++; }
            }
            Console.WriteLine($"The number of columns that contain at least one null element: {countColsWithZero}");

            int longestSeriesLength = 0;
            int longestSeriesRow = 0;
            for (int i = 0; i < matrixWidth; i++)
            {
                var current = matrix[i, 0];
                var currentLength = 1;
                var maxLength = 1;
                for (int j = 1; j < matrixHeight; j++)
                {
                    if (matrix[i, j] == current) { currentLength++; }
                    else
                    {
                        if (currentLength > maxLength) { maxLength = currentLength; }
                        current = matrix[i, j];
                        currentLength = 1;
                    }
                }
                if (maxLength > longestSeriesLength)
                {
                    longestSeriesLength = maxLength;
                    longestSeriesRow = i;
                }
            }
            Console.WriteLine($"Row number in which there is the longest series of identical elements: {longestSeriesRow}");

            int productWithoutNegatives = 1;
            for (int i = 0; i < matrixWidth; i++)
            {
                var hasNegative = false;
                int rowSum = 0;
                for (int j = 0; j < matrixHeight; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                    else
                    {
                        rowSum *= matrix[i, j];
                    }
                }
                if (!hasNegative)
                {
                    productWithoutNegatives += rowSum;
                }
            }
            Console.WriteLine($"The product of the elements in those rows that do not contain negative elements: {productWithoutNegatives}");

            int maxSum = int.MinValue;
            for (int k = 1 - matrixWidth; k < matrixHeight; k++)
            {
                int sum = 0;
                for (int i = 0; i < matrixWidth; i++)
                {
                    int j = i + k;
                    if (j >= 0 && j < matrixHeight)
                    {
                        sum += matrix[i, j];
                    }
                }
                if(sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            Console.WriteLine($"The maximum among the sums of diagonal elements parallel to the man diagonal of the matrix: {maxSum}");

            int sumWithoutNegatives = 0;
            for (int i = 0; i < matrixWidth; i++)
            {
                var hasNegative = false;
                int rowSum = 0;
                for (int j = 0; j < matrixHeight; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                    else
                    {
                        rowSum += matrix[i, j];
                    }
                }
                if (!hasNegative)
                {
                    sumWithoutNegatives += rowSum;
                }
            }
            Console.WriteLine($"The sum of elements in those columns that do not contain negative elements: {sumWithoutNegatives}");

            int minAbsSum = int.MaxValue;
            for (int k = matrixWidth - 1; k >= -matrixHeight + 1; k--)
            {
                int sum = 0;
                for (int i = 0; i < matrixWidth; i++)
                {
                    int j = i + k;
                    if (j >= 0 && j < matrixHeight) sum += Math.Abs(matrix[i, j]);
                }
                if(sum < minAbsSum)
                {
                    minAbsSum = sum;
                }
            }
            Console.WriteLine($"The minimum among the sums of the modules of the elements of the diagonals parallel to the side diagonal of the matrix: {minAbsSum}");

            int sumWithNegatives = 0;
            for (int i = 0; i < matrixWidth; i++)
            {
                var hasNegative = false;
                int rowSum = 0;
                for (int j = 0; j < matrixHeight; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                    else
                    {
                        rowSum += matrix[i, j];
                    }
                }
                if (hasNegative)
                {
                    sumWithNegatives += rowSum;
                }
            }
            Console.WriteLine($"The sum of elements in those columns that contain at least one negative element: {sumWithNegatives}");

            int[,] transposedMatrix = new int[matrixWidth, matrixHeight];
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixHeight; j++)
                {
                    transposedMatrix[j, i] = matrix[i, j];
                }
            }
            Console.WriteLine("Transposed matrix: ");
            MatrixRunHelpers.PrintMatrix(transposedMatrix);
        }
    }
}