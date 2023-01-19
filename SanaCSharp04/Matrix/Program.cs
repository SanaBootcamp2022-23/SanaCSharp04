using Helpers;

namespace Matrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("The program \"Matrix\"");

            ConsoleReader.MakeCustomSeparator();

            Console.WriteLine("\nPlease enter count of ROWS of matrix.");
            var rows = ConsoleReader.ReadInt("rows", 1);
            Console.WriteLine("Please enter count of COLUMNS of matrix.");
            var columns = ConsoleReader.ReadInt("columns", 2);

            var matrix = new int[rows, columns];

            Console.WriteLine("\nPlease select the array filling option: 1 - User; 2 - Random");
            var menu = ConsoleReader.ReadInt("menu", 1, 2);

            if (menu == 1)
            {
                Console.WriteLine("\nPlease enter items of array.");
                FillUserMatrix(matrix);
            }
            else
            {
                Console.WriteLine("\nPlease enter min and max generation limits.");
                var min = ConsoleReader.ReadInt("min");
                var max = ConsoleReader.ReadInt("max");

                if (min <= max)
                {
                    FillRandomMatrix(matrix, min, max);
                }
                else
                {
                    Console.WriteLine("\nError: Min limit cannot less max limit.");
                }
            }

            Console.WriteLine("\nYour matrix:");
            PrintMatrix(matrix, "A");

            var matrixOperations = new MatrixOperations.MatrixOperations(matrix);

            var positiveElements = matrixOperations.GetCountOfPositiveElements();
            var maxOfRepeatNumbers = matrixOperations.GetMaxOfRepeatNumbers();
            var countOfRowsWithoutZeroElements = matrixOperations.GetCountOfRowsWithoutZeroElements();
            var countOfColumnsWithZeroElements = matrixOperations.GetCountOfColumnsWithZeroElements();
            var rowIdWithMaxSeriesSameElements = matrixOperations.FindRowIdWithMaxSeriesSameElements();
            var productsInRowsWithoutNegativeElements =
                matrixOperations.GetProductElementsInRowWithoutNegativeElements();
            var maxOfSumsParallelOfMainDiagonal = matrixOperations.GetMaxOfSumsParallelOfMainDiagonal();
            var sumsInColumnsWithoutNegativeElements = matrixOperations.GetSumsInColumnsWithoutNegativeElements();
            var minOfAbsSumsParallelOfSideDiagonal = matrixOperations.GetMinOfAbsSumsParallelOfSideDiagonal();
            var sumsInColumnsWithNegativeElements = matrixOperations.GetSumsInColumnsWithAnyNegativeElements();
            var transposedMatrix = matrixOperations.GetTransposedMatrix();

            Console.WriteLine("RESULTS:");
            Console.WriteLine($"1) Count of positive elements: {positiveElements}");

            Console.WriteLine(maxOfRepeatNumbers != null
                ? $"\n2) Maximum number that occurs in the given matrix more than once: {maxOfRepeatNumbers}"
                : "\n2) Maximum number that occurs in the given matrix more than once: Elements are not repeated");

            Console.WriteLine($"\n3) Count of rows without zero elements: {countOfRowsWithoutZeroElements}");
            Console.WriteLine($"\n4) Count of columns with zero elements: {countOfColumnsWithZeroElements}");

            Console.WriteLine(rowIdWithMaxSeriesSameElements == -1
                ? $"\n5) Number of row with maximum series same elements: No row with a series of same elements"
                : $"\n5) Number of row with maximum series same elements: {rowIdWithMaxSeriesSameElements + 1}");

            if (productsInRowsWithoutNegativeElements.Count > 0)
            {
                Console.WriteLine("\n6) Products in rows without negative elements:");

                foreach (var product in productsInRowsWithoutNegativeElements)
                {
                    Console.WriteLine($"\t\t\t\t\tRow = {product.Key + 1} Product = {product.Value}");
                }
            }
            else
            {
                Console.WriteLine("\n6) Products in rows without negative elements: No rows without negative elements");
            }

            Console.WriteLine($"\n7) Maximum of sums of diagonal elements parallel to the main diagonal (Including main diagonal): {maxOfSumsParallelOfMainDiagonal}");

            if (sumsInColumnsWithoutNegativeElements.Count > 0)
            {
                Console.WriteLine("\n8) Sum in columns without negative elements:");

                foreach (var sum in sumsInColumnsWithoutNegativeElements)
                {
                    Console.WriteLine($"\t\t\t\t\tColumn = {sum.Key + 1} Sum = {sum.Value}");
                }
            }
            else
            {
                Console.WriteLine("\n8) Sums in columns without negative elements: No columns without negative elements");
            }

            Console.WriteLine($"\n9) Minimum of sums of modules elements of diagonals parallel to side diagonal (Including side diagonal): {minOfAbsSumsParallelOfSideDiagonal}");

            if (sumsInColumnsWithNegativeElements.Count > 0)
            {
                Console.WriteLine("\n10) Sum in columns with any negative elements:");

                foreach (var sum in sumsInColumnsWithNegativeElements)
                {
                    Console.WriteLine($"\t\t\t\t\tColumn = {sum.Key + 1} Sum = {sum.Value}");
                }
            }
            else
            {
                Console.WriteLine("\n10) Sums in columns with any negative elements: No columns with any negative elements");
            }

            Console.WriteLine("\n11) Transposed matrix: ");
            PrintMatrix(transposedMatrix, "A (T)");
        }

        private static void FillUserMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ConsoleReader.ReadInt($"arr[{i + 1}][{j + 1}]");
                }
            }
        }

        private static void FillRandomMatrix(int[,] matrix, int min, int max)
        {
            var random = new Random();

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(min, max + 1);
                }
            }
        }

        private static void PrintMatrix(int[,] matrix, string name = "M")
        {
            Console.Write($"\t{name} = \n");
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == 0)
                    Console.Write("\t   /");

                else if (i == matrix.GetLength(0) - 1)
                    Console.Write("\t   \\");

                else
                    Console.Write("\t   |");

                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],8}");
                }

                if (i == 0)
                    Console.Write("\t\\\n");
                else if (i == matrix.GetLength(0) - 1)
                    Console.Write("\t/\n");
                else
                    Console.Write("\t |\n");
            }

            Console.WriteLine("\n");
        }
    }
}