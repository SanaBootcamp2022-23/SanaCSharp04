namespace Matrix
{
    internal class Methods
    {
        /// <summary>
        /// Fill matrix with random numbers in full or custom range.
        /// </summary>
        /// <param name="matrix">The matrix to fill.</param>
        /// <param name="min">Minimum value for random.</param>
        /// <param name="max">Maximum value for random.</param>
        public static void FillMatrixWithRandomNumbers(ref int[,] matrix, int min = int.MinValue, int max = int.MaxValue)
        {
            Random random = new();
            for (int row = 0; row < matrix.GetLength(0); row++)
                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = random.Next(min, max);
        }

        /// <summary>
        /// Print matrix to the terminal.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="textColor">Matrix content font color.</param>
        public static void PrintMatrix(int[,] matrix, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            for (int row = 0; row < matrix.GetLength(0); row++) 
            {
                Console.WriteLine();
                for (int col = 0; col < matrix.GetLength(1); col++) 
                    Console.Write($"{matrix[row,col],10}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Count positive elements in the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns><see langword="int"/>: Count of positive elements (x > 0).</returns>
        public static int CountPositiveElements(int[,] matrix)
        {
            int count = 0;
            foreach (int element in matrix)
                if (element > 0) count++;
            return count;
        }

        /// <summary>
        /// <para>Returns maximum value from the matrix that appears at least twice.</para>
        /// <para>If no duplicates are found returns <see langword="null"/>.</para>
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns><see langword="int"/>: Maximum duplicated value.</returns>
        public static int? GetMaxDuplicatedElement(int[,] matrix)
        {
            // Group the matrix into a "dictionary", find duplicated elements and convert the group back to an enum.
            IEnumerable<int> duplicates = matrix.Cast<int>().GroupBy(e => e).Where(e => e.Count() > 1).SelectMany(e => e);
            if (duplicates.Any())
                return duplicates.Max();
            return null;
        }

        /// <summary>
        /// Returns count of rows that don't contain zero values.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns><see langword="int"/>: Rows count without 0.</returns>
        public static int CountRowsWithoutZeros(int[,] matrix)
        {
            int count = matrix.GetLength(0);
            for (int row = 0; row < matrix.GetLength(0); row++)
                for (int col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row,col] == 0)
                        { count--; break; }
            return count;
        }

        /// <summary>
        /// Returns count of columns that contain at least one zero value.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns><see langword="int"/>: Columns count with 0.</returns>
        public static int CountColumnsWithZeros(int[,] matrix)
        {
            int count = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
                for (int row = 0; row < matrix.GetLength(0); row++)
                    if (matrix[row,col] == 0)
                        { count++; break; }
            return count;
        }

        /// <summary>
        /// Returns the index of the row that has the most extended series of repeated elements in it.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns><see langword="int"/>: Index of the row.</returns>
        public static int GetRowWithLongestSeries(int[,] matrix)
        {
            int maxSeries = 0, rowMax = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int series = 0;
                for (int col = 1; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] == matrix[row, col - 1])
                        series++;
                    else 
                    {
                        if (series > maxSeries)
                        {
                            maxSeries = series;
                            rowMax = row;
                        }
                        series = 0;
                    }
                if (series > maxSeries)
                {
                    maxSeries = series;
                    rowMax = row;
                }
            }
            return rowMax;
        }


    }
}
