using System.Linq;

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
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(min, max);
        }

        /// <summary>
        /// Print matrix to the terminal.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="textColor">Matrix content font color.</param>
        public static void PrintMatrix(int[,] matrix, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.WriteLine();
            Console.ForegroundColor = textColor;
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++) 
                    Console.Write($"{matrix[i,j],7}");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
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
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i,j] == 0)
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
            for (int j = 0; j < matrix.GetLength(1); j++)
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i,j] == 0)
                        { count++; break; }
            return count;
        }
    }
}
