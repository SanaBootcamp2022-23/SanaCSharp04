using System.Diagnostics.Metrics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Xml;


namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            uint rowCount, colCount;
            Console.WriteLine("Row count: ");
            rowCount = uint.Parse(Console.ReadLine());
            Console.WriteLine("Column count: ");
            colCount = uint.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            var matrix = new double[rowCount, colCount];
            Random random = new Random();

            GenerateMatrix(matrix, random);

            var moreThan0 = 0;

            moreThan0 = FindPositiveElements(matrix, moreThan0);
            var maxValue = MaxRepeatedElements(rowCount, colCount, matrix);
            var rowsNotEqTo0 = FindRowsWithoutZeros(matrix);
            var ColsEqTo0 = FindZeroColumns(matrix);

            Console.ForegroundColor = ConsoleColor.White;

            FindProduct(matrix);
            FindSum(matrix);
            FindNegativeSum(matrix);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Transposed matrix: ");
            CreateAndShowTranspozedMatrix(rowCount, colCount, matrix);

            Console.ForegroundColor = ConsoleColor.White;
            int row = MaxAmountOfRepeatedElements(matrix);

            Answers(moreThan0, maxValue, rowsNotEqTo0, ColsEqTo0, row);
        }

        static int MaxAmountOfRepeatedElements(double[,] matrix)
        {
            var counter = 0;
            var row = 0;
            var counterMax = int.MinValue;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 1; j < matrix.GetLength(1); j++)
                {
                    if (counter > counterMax)
                    {
                        counterMax = counter;
                        row = i;
                    }

                    if (matrix[i, j] == matrix[i, j - 1])
                        counter++;

                    if (matrix[i, j] != matrix[i, j - 1])
                        counter = 0;
                }
            }

            return row;
        }

        private static void CreateAndShowTranspozedMatrix(uint rowCount, uint colCount, double[,] matrix)
        {
            var newMatrix = new double[colCount, rowCount];

            for (var i = 0; i < colCount; i++)
            {
                for (var j = 0; j < rowCount; j++)
                {
                    newMatrix[j, i] = matrix[i, j];
                }
            }

            for (var i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < newMatrix.GetLength(1); j++)
                {

                    Console.Write($"{newMatrix[i, j]} \t");

                }

                Console.WriteLine("\n");
            }
        }

        private static void FindNegativeSum(double[,] matrix)
        {
            var sumOfColsWithAtLeast1NegEl = 0.0;
            var elLessThan0 = 0;
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    sumOfColsWithAtLeast1NegEl += matrix[i, j];
                    if (matrix[i, j] < 0)
                        elLessThan0++;

                }

                if (elLessThan0 > 0)
                    Console.WriteLine($"Sum of column number {j + 1} with at least 1 negative element = {sumOfColsWithAtLeast1NegEl}");
                sumOfColsWithAtLeast1NegEl = 0;
                elLessThan0 = 0;
            }
        }

        private static void FindSum(double[,] matrix)
        {
            var sumOfColsMoreThan0 = 0.0;
            var colsLessThan0 = 0;
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    sumOfColsMoreThan0 += matrix[i, j];
                    if (matrix[i, j] < 0)
                        colsLessThan0++;
                }

                if (colsLessThan0 == 0)
                    Console.WriteLine($"Sum of column number {j + 1} = {sumOfColsMoreThan0}");
                sumOfColsMoreThan0 = 0;
                colsLessThan0 = 0;
            }
        }

        private static void FindProduct(double[,] matrix)
        {
            var dobutokOfRowsMoreThan0 = 1.0;
            var lessThan0 = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    dobutokOfRowsMoreThan0 *= matrix[i, j];
                    if (matrix[i, j] < 0)
                        lessThan0++;

                }
                if (lessThan0 == 0)
                    Console.WriteLine($"Dobutok of row number {i + 1} = {dobutokOfRowsMoreThan0}");
                dobutokOfRowsMoreThan0 = 1;
                lessThan0 = 0;
            }
        }

        private static int FindZeroColumns(double[,] matrix)
        {
            var eqTo0 = 0;
            var ColsEqTo0 = 0;
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        eqTo0++;
                    }

                }

                if (eqTo0 > 0)
                {
                    ColsEqTo0++;

                }
                eqTo0 = 0;
            }

            return ColsEqTo0;
        }

        private static int FindRowsWithoutZeros(double[,] matrix)
        {
            var is0 = 0;
            var rowsNotEqTo0 = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        is0++;
                    }
                }

                if (is0 == 0)
                {
                    rowsNotEqTo0++;
                }

                is0 = 0;
            }

            return rowsNotEqTo0;
        }

        private static double MaxRepeatedElements(uint rowCount, uint colCount, double[,] matrix)
        {
            var maxRepeatedEl = new double[rowCount, colCount];
            var unique = new HashSet<double>();
            var duplicates = new HashSet<double>();
            for (int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    if (!unique.Add(matrix[i, j]))
                        if (duplicates.Add(matrix[i, j]))
                        {
                            maxRepeatedEl[i, j] = matrix[i, j];
                        }

            var maxValue = double.MinValue;

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (maxRepeatedEl[i, j] > maxValue)
                        maxValue = maxRepeatedEl[i, j];
                }
            }

            return maxValue;
        }

        private static int FindPositiveElements(double[,] matrix, int moreThan0)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        moreThan0++;
                }
            }

            return moreThan0;
        }

        private static void GenerateMatrix(double[,] matrix, Random random)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-3, 15);
                    Console.Write($"{matrix[i, j]} \t");
                }

                Console.WriteLine("\n");
            }
        }

        static void Answers(int moreThan0, double maxRepeatedElement, int rowsNotEqTo0, int ColsEqTo0, int tmp3)
        {
            Console.WriteLine($"Row with the biggest amount of repeated elements: {tmp3 + 1}");
            Console.WriteLine($"Amount of elements more than 0: {moreThan0}");
            Console.WriteLine($"Max repeated element = {maxRepeatedElement}");
            Console.WriteLine($"Amount of rows, which don't contatin 0: {rowsNotEqTo0}");
            Console.WriteLine($"Amount of cols, which contatin 0: {ColsEqTo0}");
        }
    }
}