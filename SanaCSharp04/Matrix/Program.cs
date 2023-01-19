using System;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            
            int rowsCount = InputChecker("Input number of rows: ");
            int columnsCount = InputChecker("Input number of columns: ");

            int[,] matrix = new int[rowsCount, columnsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    matrix[i, j] = rnd.Next(-5, 5);
                    Console.Write($"{matrix[i,j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Amount of positive elements: {PositiveNumsCount(matrix)}");
            Console.WriteLine($"Max repeated max element: {FindMax(matrix)}");
            Console.WriteLine($"Amount of rows without zeros: {FindRowsWithoutZeros(matrix)}");
            Console.WriteLine($"Amount of columns with at least 1 zero: {FindZeroColumns(matrix)}");
            Console.WriteLine($"Number of row with the longest series of identical elements: {MaxSerial(matrix)}");
            ProductWithoutNegRow(matrix);
            SumWithoutNegCols(matrix);
            SumWithAtLeastOneNegEl(matrix);
            Console.WriteLine("Transposed matrix:");
            var transposedMatrix = Transpose(matrix, rowsCount, columnsCount);
            for (int i = 0; i < transposedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < transposedMatrix.GetLength(1); j++)
                {
                    Console.Write($"{transposedMatrix[i,j]}\t");
                }
                Console.WriteLine();
            }

          


            
        }
        
        private static int InputChecker(string prompt)
        {
            int value;
            do
            {
                Console.Write(prompt);
                var checker = int.TryParse(Console.ReadLine(), out value);
                if (checker == false || value <= 0)
                {
                    Console.WriteLine("Error. Incorrect input, try again.");
                }
                else
                {
                    break;
                }
            } while (true);
                
            return value;
        }

        private static int PositiveNumsCount(int[,] matrix)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static int FindMax(int[,] matrix)
        {
            
            int max = matrix[0,0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > max && MoreThanOneTime(matrix[i,j], matrix))
                    { 
                        max = matrix[i,j];
                    }
                }
            }

            return max;
        }

        private static bool MoreThanOneTime(int number, int[,] matrix) // вспомогательный
        {

            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == number)
                    {
                        counter++;
                        if(counter> 1)
                        {
                            return true;
                        }
                    }

                }
            }

            return false;

        }

        private static int FindRowsWithoutZeros(int[,] matrix)
        {
            int zeroCount = 0;
            int rows = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroCount++;
                    }
                }

                if (zeroCount == 0)
                {
                    rows++;
                }

                zeroCount = 0;
            }

            return rows;
        }

        private static int FindZeroColumns(int[,] matrix)
        {
            int zeroCount = 0;
            int columns = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroCount++;
                    }
                }

                if (zeroCount > 0)
                {
                    columns++;
                }
                zeroCount = 0;
            }

            return columns;
        }

        private static int MaxSerial(int[,] matrix)
        {
            int counter = 0;
            int row = 0;
            int counterMax = matrix[0,0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (counter > counterMax)
                    {
                        counterMax = counter;
                        row = i;
                    }

                    if (matrix[i, j] == matrix[i, j - 1])
                    { 
                        counter++;
                    }
                    if (matrix[i, j] != matrix[i, j - 1])
                    { 
                        counter = 0;
                    }
                }
            }

            return row + 1;
        }

        private static void ProductWithoutNegRow(int[,] matrix)
        {
            int product = 1;
            int negativeCount = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    product *= matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        negativeCount++;
                    }
                }
                if (negativeCount == 0)
                {
                    Console.WriteLine($"Product of {i + 1} row = {product}");
                }
                product = 1;
                negativeCount = 0;
            }
        }

        private static void SumWithoutNegCols(int[,] matrix)
        {
            int sum = 0;
            int negativeCount = 0;
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] < 0)
                    { 
                        negativeCount++;
                    }
                }

                if (negativeCount == 0)
                { 
                    Console.WriteLine($"Sum of {j+1} column = {sum}");
                }
                sum = 0;
                negativeCount = 0;
            }
        }

        private static void SumWithAtLeastOneNegEl(int[,] matrix)
        {
            int sum = 0;
            int negCount = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] < 0)
                    { 
                        negCount++;
                    }

                }

                if (negCount > 0)
                { 
                    Console.WriteLine($"Sum of {j + 1} column with at least one negative element = {sum}");
                }
                sum = 0;
                negCount = 0;
            }
        }

        private static int[,] Transpose(int[,] matrix, int rowsCount, int columnsCount)
        {
            int[,] transposedMatrix = new int[columnsCount, rowsCount];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    transposedMatrix[j, i] = matrix[i, j];
                }
            }
            return transposedMatrix;
        }
    }


}
