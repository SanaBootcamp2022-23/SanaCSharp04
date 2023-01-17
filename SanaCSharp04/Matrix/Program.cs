// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

namespace MatrixProject {
    public static class MatrixTools
    {
        public static int[,] RandomMatrixGeneration(int rows, int cols, int min = -10, int max = 10)
        {
            Random randomGeneration = new Random();
            int[,] matrixResult = new int[rows, cols];

            for (int i = 0; i < matrixResult.GetLength(0); ++i)
            {
                for (int j = 0; j < matrixResult.GetLength(1); ++j)
                {
                    matrixResult[i, j] = randomGeneration.Next(min, max);
                }
            }
            return matrixResult;
        }

        public static String DisplayingStrings(int[,] matrix)
        {
            StringBuilder builder = new StringBuilder();

            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex)
            {
                builder.Append("| ");
                builder.Append(
                    string.Join(" ", GetRow(matrix, rowIndex).Select(number => string.Format("{0, 5}", number)))
                );
                builder.Append(" |");
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        public static IEnumerable<int> GetRow(int[,] matrix, int rowIndex)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1); ++colIndex)
                yield return matrix[rowIndex, colIndex];
        }

        public static IEnumerable<int> GetColumn(int[,] matrix, int colIndex)
        {
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex)
                yield return matrix[rowIndex, colIndex];
        }

        //кількість додатних елементів;
        public static int CountPositives(int[,] matrix)
        {
            return matrix.Cast<int>()
                    .Where(number => number > 0)
                    .Count();
        }

        //максимальне із чисел, що зустрічається в заданій матриці більше одного разу;

        public static int MaxRepetitiveNumber(int[,] matrix)
        {
            return matrix.Cast<int>()
                    .GroupBy(number => number)
                    .Select(group => new { Number = group.Key, Count = group.Count() })
                    .Where(obj => obj.Count > 1)
                    .Max(obj => obj.Number);
        }

        //кількість рядків, які не містять жодного нульового елемента;

        public static int RowsWithoutZeroCounts(int[,] matrix)
        {
            int result = 0;
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex)
            {
                result += GetRow(matrix, rowIndex).Contains(0) ? 0 : 1;
            }
            return result;
        }
        //кількість стовпців, які містять хоча б один нульовий елемент;
        public static int ColsWithZeroCounts(int[,] matrix)
        {
            int result = 0;
            for (int columnIndex = 0; columnIndex < matrix.GetLength(1); ++columnIndex)
            {
                result += GetColumn(matrix, columnIndex).Contains(0) ? 1 : 0;
            }
            return result;
        }

        //номер рядка, в якому знаходиться найдовша серія однакових елементів;
        public static int RowWithLongestSimilarElements(int[,] matrix)
        {
            int rowIndexOfLongestNumber = 0;
            int maxLongestNum = 1;

            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex)
            {
                int currentLongestNum = LongestSimilarElements(GetRow(matrix, rowIndex).ToArray());
                if (currentLongestNum > maxLongestNum)
                {
                    rowIndexOfLongestNumber = rowIndex;
                    maxLongestNum = currentLongestNum;
                }
            }
            return rowIndexOfLongestNumber;
        }

       
        private static int LongestSimilarElements(int[] array)
        {
            int longest = 1;
            int currentLongest = 1;

            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] == array[i - 1])
                {
                    currentLongest++;
                    longest = Math.Max(longest, currentLongest);
                }
                else
                {
                    currentLongest = 1;
                }
            }
            return longest;
        }

        //добуток елементів в тих рядках, які не містять від’ємних елементів;

        public static Dictionary<int, int> PositiveRowsProduct(int[,] matrix)
        {
            Dictionary<int, int> productsRows = new Dictionary<int, int>();

            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); ++rowIndex)
            {
                IEnumerable<int> row = GetRow(matrix, rowIndex);
                if (row.Count(number => number < 0) == 0)
                    productsRows.Add(rowIndex, row.Aggregate(1, (a, b) => a * b));
            }
            return productsRows;
        }

        //максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;
        public static int MainDiagonalsMaxSum(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int maximumSum = int.MinValue;

            for (int j = -(rows - 1); j < cols; ++j)
            {
                int curSum = 0;
                for (int i = 0; i < rows; ++i)
                {
                    if (i >= 0 && i < rows && (j + i) >= 0 && (j + i) < cols)
                        curSum += matrix[i, j + i];
                }
                maximumSum = Math.Max(curSum, maximumSum);
                curSum = 0;
            }
            return maximumSum;
        }

        //cуму елементів в тих стовпцях, які не містять від’ємних елементів;

        public static Dictionary<int, int> PositiveColsSum(int[,] matrix)
        {
            Dictionary<int, int> colsSum = new Dictionary<int, int>();

            for (int colIndex = 0; colIndex < matrix.GetLength(1); ++colIndex)
            {
                IEnumerable<int> col = GetColumn(matrix, colIndex);
                if (col.Count(number => number < 0) == 0)
                    colsSum.Add(colIndex, col.Aggregate(0, (a, b) => a + b));
            }
            return colsSum;
        }

        //мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;

        public static int MinOfElementsModuleSum(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int minSum = int.MaxValue;

            for (int j = cols + rows - 2; j >= 0; --j)
            {
                int curSum = 0;
                for (int i = 0; i < rows; ++i)
                {
                    if (i >= 0 && i < rows && (j - i) >= 0 && (j - i) < cols)
                        curSum += Math.Abs(matrix[i, j - i]);
                }
                minSum = Math.Min(curSum, minSum);
                curSum = 0;
            }
            return minSum;
        }

        //суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент;

        public static Dictionary<int, int> NegativeColsSum(int[,] matrix)
        {
            Dictionary<int, int> colsSum = new Dictionary<int, int>();

            for (int colIndex = 0; colIndex < matrix.GetLength(1); ++colIndex)
            {
                IEnumerable<int> col = GetColumn(matrix, colIndex);
                if (col.Count(number => number < 0) > 0)
                    colsSum.Add(colIndex, col.Aggregate(0, (a, b) => a + b));
            }
            return colsSum;
        }

        //транспоновану матрицю.
        public static int[,] TransposedMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[,] transposedMatrix = new int[cols, rows];

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                    transposedMatrix[j, i] = matrix[i, j];
            }
            return transposedMatrix;
        }
    }
}

