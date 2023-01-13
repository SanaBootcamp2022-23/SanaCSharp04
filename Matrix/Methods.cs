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
        /// <returns>Count of positive elements (x>0).</returns>
        public static int CountPositiveElements(int[,] matrix)
        {
            int count = 0;
            foreach (int element in matrix)
                if (element > 0) count++;
            return count;
        }
    }
}
