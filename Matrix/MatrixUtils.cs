using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Matrix;
public static class MatrixUtils {
    public static int[,] GenerateRandomMatrix(int rows, int cols, int min = -10, int max = 10) {
        Random randomGenerator = new Random();
        int[,] resultMatrix = new int[rows, cols];

        for (int i = 0; i < resultMatrix.GetLength(0); ++i) {
            for (int j = 0; j < resultMatrix.GetLength(1); ++j) {
                resultMatrix[i, j] = randomGenerator.Next(min, max);
            }
        }
        return resultMatrix;
    }

    public static String StringRepresentation(int[,] matrix) {
        StringBuilder builder = new StringBuilder();

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex) {
            builder.Append("| ");
            builder.Append(
                string.Join(" ", GetRow(matrix, rowIndex).Select(number => string.Format("{0, 5}", number)))
            );
            builder.Append(" |");
            builder.Append(Environment.NewLine);
        }
        return builder.ToString();
    }

    public static IEnumerable<int> GetRow(int[,] matrix, int rowIndex) {
        for (int colIndex = 0; colIndex < matrix.GetLength(1); ++colIndex)
            yield return matrix[rowIndex, colIndex];
    }

    public static IEnumerable<int> GetColumn(int[,] matrix, int colIndex) {
        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex)
            yield return matrix[rowIndex, colIndex];
    }

    public static int PositivesCount(int[,] matrix) {
        return matrix.Cast<int>()
                .Where(number => number > 0)
                .Count();
    }

    public static int MaxNotSingleElement(int[,] matrix) {
        return matrix.Cast<int>()
                .GroupBy(number => number)
                .Select(group => new { Number = group.Key, Count = group.Count() })
                .Where(obj => obj.Count > 1)
                .Max(obj => obj.Number);
    }

    public static int RowsWithoutZerosCount(int[,] matrix) {
        int result = 0;
        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex) {
            result += GetRow(matrix, rowIndex).Contains(0) ? 0 : 1;
        }
        return result;
    }

    public static int ColumnsWithZerosCount(int[,] matrix) {
        int result = 0;
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); ++columnIndex) {
            result += GetColumn(matrix, columnIndex).Contains(0) ? 1 : 0;
        }
        return result;
    }
    
    public static int RowWithLongestContiniusSeries(int[,] matrix) {
        int rowIndexWithMaxSeries = 0;
        int maxSeriesLong = 1;

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex) {
            int currentSeriesLong = LongestContiniusSeries(GetRow(matrix, rowIndex).ToArray());
            if (currentSeriesLong > maxSeriesLong) {
                rowIndexWithMaxSeries = rowIndex;
                maxSeriesLong = currentSeriesLong;
            }
        }
        return rowIndexWithMaxSeries;
    }

    private static int LongestContiniusSeries(int[] array) {
        int maxLong = 1;
        int currentLong = 1;

        for (int i = 1; i < array.Length; ++i) {
            if (array[i] == array[i - 1]) {
                currentLong++;
                maxLong = Math.Max(maxLong, currentLong);
            } else {
                currentLong = 1;
            }
        }
        return maxLong;
    }

    public static Dictionary<int, int> ProductsOfPositiveRows(int[,] matrix) {
        Dictionary<int, int> rowsProducts = new Dictionary<int, int>();

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex) {
            IEnumerable<int> row = GetRow(matrix, rowIndex);
            if (row.Count(number => number < 0) == 0) 
                rowsProducts.Add(rowIndex, row.Aggregate(1, (a, b) => a * b));
        }
        return rowsProducts;
    }

    public static int MaxSumMainDiagonal(int[,] matrix) {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int maxSum = int.MinValue;

        for (int j = -(rows - 1); j < cols; ++j) {
            int currentSum = 0;
            for (int i = 0; i < rows; ++i) {
                if (i >= 0 && i < rows && (j + i) >= 0 && (j + i) < cols)
                    currentSum += matrix[i, j + i];
            }
            maxSum = Math.Max(currentSum, maxSum);
            currentSum = 0;
        }
        return maxSum;
    }

    public static Dictionary<int, int> SumOfPositiveCols(int[,] matrix) {
        Dictionary<int, int> colsSums = new Dictionary<int, int>();

        for (int colIndex = 0; colIndex < matrix.GetLength(1); ++colIndex) {
            IEnumerable<int> col = GetColumn(matrix, colIndex);
            if (col.Count(number => number < 0) == 0) 
                colsSums.Add(colIndex, col.Aggregate(0, (a, b) => a + b));
        }
        return colsSums;
    }

    public static int MinSumAntidiagonal(int[,] matrix) {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int minSum = int.MaxValue;

        for (int j = cols + (rows - 1); j >= 0; --j) {
            int currentSum = 0;
            for (int i = 0; i < rows; ++i) {
                if (i >= 0 && i < rows && (j - i) >= 0 && (j - i) < cols) 
                    currentSum += matrix[i, j - i];
            }
            minSum = Math.Min(currentSum, minSum);
            currentSum = 0;
        }
        return minSum;
    }

    public static Dictionary<int, int> SumOfNegativeCols(int[,] matrix) {
        Dictionary<int, int> colsSums = new Dictionary<int, int>();

        for (int colIndex = 0; colIndex < matrix.GetLength(1); ++colIndex) {
            IEnumerable<int> col = GetColumn(matrix, colIndex);
            if (col.Count(number => number < 0) > 0) 
                colsSums.Add(colIndex, col.Aggregate(0, (a, b) => a + b));
        }
        return colsSums;
    }

    public static int[,] TransposeMatrix(int[,] matrix) {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int[,] transposedMatrix = new int[cols, rows];

        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) 
                transposedMatrix[j, i] = matrix[i, j];
        }
        return transposedMatrix;
    }
}
