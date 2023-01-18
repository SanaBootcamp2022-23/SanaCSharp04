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

            Console.WriteLine("RESULTS:");
            Console.WriteLine($"\n1) Count of positive elements: {positiveElements}");
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
            Console.Write($"   {name} = ");
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == 0)
                    Console.Write("    /");

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