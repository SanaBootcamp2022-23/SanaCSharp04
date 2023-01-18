using static Utils.Predicates;
using static Utils.Terminal;
using static Matrix.MatrixMethods;

namespace Matrix
{
    public class MatrixStatsBase
    {
        public int NegativeCount { get; set; }
        public int PositiveCount { get; set; }
        public int ZeroCount { get; set; }

        public bool NoNegativeNums => NegativeCount == 0;
        public bool NoZeroNums => ZeroCount == 0;
    }

    public class MatrixColStats : MatrixStatsBase { };

    public class MatrixRowStats : MatrixStatsBase
    {
        public int LongestElementsSeries { get; set; }
    };

    public class MatrixStats : MatrixStatsBase
    {
        private int[,] Matrix;
        /// <summary>
        /// Dictionary (matrix element -> appearances counter)
        /// </summary>
        public Dictionary<int, int> Frequency { get; set; }
        /// <summary>
        /// Dictionary (row -> it's statistics)
        /// </summary>
        public Dictionary<int, MatrixRowStats> RowsStats { get; set; }
        /// <summary>
        /// Dictionary (column -> it's statistics)
        /// </summary>
        public Dictionary<int, MatrixColStats> ColsStats { get; set; }

        public MatrixStats(int[,] matrix)
        {
            Matrix = matrix;

            Frequency = new Dictionary<int, int>();
            RowsStats = new Dictionary<int, MatrixRowStats>();
            ColsStats = new Dictionary<int, MatrixColStats>();

            GenStats();
        }

        private void GenStats()
        {
            var (rows, cols) = MatrixSize(Matrix);

            for (int row = 0; row < rows; row++)
            {
                var rowStats = new MatrixRowStats();

                for (int col = 0; col < cols; col++)
                {
                    if (!ColsStats.ContainsKey(col))
                    {
                        ColsStats.Add(col, new MatrixColStats());
                    }
                    var colStats = ColsStats[col];

                    int el = Matrix[row, col];

                    {
                        if (!Frequency.ContainsKey(el))
                            Frequency.Add(el, 0);

                        Frequency[el] += 1;
                    }

                    if (isPositive(el))
                    {
                        PositiveCount++;
                        rowStats.PositiveCount += 1;
                        colStats.PositiveCount += 1;
                    }
                    else if (isNegative(el))
                    {
                        NegativeCount++;
                        rowStats.NegativeCount += 1;
                        colStats.NegativeCount += 1;
                    }
                    else
                    {
                        ZeroCount++;
                        rowStats.ZeroCount += 1;
                        colStats.ZeroCount += 1;
                    }

                    {
                        int series = 0;

                        for (int innerCol = col + 1; innerCol < cols; innerCol++)
                        {
                            int nextEl = Matrix[row, innerCol];

                            if (nextEl != el)
                                break;

                            series += 1;
                        }

                        if (series > rowStats.LongestElementsSeries)
                            rowStats.LongestElementsSeries = series;
                    }

                    ColsStats[col] = colStats;
                }

                RowsStats[row] = rowStats;
            }
        }

        public bool AtLeastOneSeriesExists
        => RowsStats
            .Where(row => row.Value.LongestElementsSeries > 0)
            .Any();
    }

    internal class MatrixMethods
    {
        public static (int rows, int cols) MatrixSize<T>(T[,] matrix)
        => (matrix.GetLength(0), matrix.GetLength(1));

        public static void PrintMatrix<T>(T[,] matrix, int padding = 5)
        {
            var (rows, cols) = MatrixSize(matrix);
            var formatString = "{0," + padding + "}";

            NewLine();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var el = matrix[row, col];
                    Console.Write(formatString, el);
                }

                NewLine();
            }
            NewLine();
        }

        public static void FillIntMatrix(int[,] matrix, int maximum, int minimum)
        {
            var (rows, cols) = MatrixSize(matrix);
            var rand = new Random();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int num = rand.Next(maximum, minimum);
                    matrix[row, col] = num;
                }
            }
        }

        public static T[,] TransposeMatrix<T>(T[,] matrix)
        {
            var (rows, cols) = MatrixSize(matrix);

            T[,] transposedMatrix = new T[cols, rows];

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    transposedMatrix[col, row] = matrix[row, col];

            return transposedMatrix;
        }

        public static int MaxSumAmongMainParallelDiagonals(int[,] matrix)
        {
            var (rows, cols) = MatrixSize(matrix);

            Stack<int> sums = new();

            // Above main diagonal
            for (int col = 1; col < cols; col++)
            {
                sums.Push(0);

                for (
                    int dRow = 0, dCol = col
                    ; dRow < rows && dCol < cols
                    ; dRow++, dCol++
                )
                {
                    sums.Push(sums.Pop() + matrix[dRow, dCol]);
                }
            }

            // Under main diagonal
            for (int row = 1; row < rows; row++)
            {
                sums.Push(0);

                for (
                    int dCol = 0, dRow = row
                    ; dCol < cols && dRow < rows
                    ; dCol++, dRow++
                )
                {
                    sums.Push(sums.Pop() + matrix[dRow, dCol]);
                }
            }

            return sums.Max();
        }

        public static int MinAbsSumAmongSecondaryParallelDiagonals(int[,] matrix)
        {
            var (rows, cols) = MatrixSize(matrix);

            Stack<int> sums = new();

            // Above secondary diagonal
            for (int col = cols - 2; col >= 0; col--)
            {
                sums.Push(0);

                for (
                    int dRow = 0, dCol = col
                    ; dRow < rows && dCol >= 0
                    ; dRow++, dCol--
                )
                {
                    sums.Push(sums.Pop() + Math.Abs(matrix[dRow, dCol]));
                }
            }

            // Under secondary diagonal
            for (int row = 1; row < rows; row++)
            {
                sums.Push(0);

                for (
                    int dCol = cols - 1, dRow = row
                    ; dCol >= 0 && dRow < rows
                    ; dRow++, dCol--
                )
                {
                    sums.Push(sums.Pop() + Math.Abs(matrix[dRow, dCol]));
                }
            }

            return sums.Min();
        }
    }
}
