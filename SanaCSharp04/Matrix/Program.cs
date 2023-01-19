using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = InitializeArray();
            Console.WriteLine();

            GetQuantityOfPositiveElements(matrix);
            GetMatrixGreatestRepeatedElement(matrix);
            GetRowsWithoutZeroElement(matrix);
            GetColsContainZero(matrix);
            GetRowRepeatedElements(matrix);
            GetProductPositiveElements(matrix);
            GetMaxSum(matrix);
            GetSumOfPositiveElementsInCols(matrix);
            GetMinimumSumOfModules(matrix);
            GetSumOfNegativeElementsInCols(matrix);
            Console.WriteLine("Транспонована матриця: ");
            PrintArray(TransposeMatrix(matrix));
        }

        static int[,] InitializeArray()
        {
            Console.Write("Введiть кiлькiсть рядкiв: ");
            int rowCount = int.Parse(Console.ReadLine());
            Console.Write("Введiть кiлькiсть стовпцiв: ");
            int colCount = int.Parse(Console.ReadLine());
            Console.Write("Введiть мiнiмальне значення: ");
            int minValue = int.Parse(Console.ReadLine());
            Console.Write("Введiть максимальне значення: ");
            int maxValue = int.Parse(Console.ReadLine());


            int[,] array = new int[rowCount, colCount];

            Random random = new Random();

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                    array[i, j] = random.Next(minValue, maxValue);
            }

            return array;
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {

                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write($"{array[i, j]} ");

                Console.WriteLine();
            }
        }

        static void GetQuantityOfPositiveElements(int[,] array)
        {
            int quantityOfPositiveElements = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > 0)
                        quantityOfPositiveElements++;
                }

            }

            Console.WriteLine($"Кiлькiсть додатних елементiв: {quantityOfPositiveElements}\n");
        }

        static void GetRowsWithoutZeroElement(int[,] array)
        {
            int quantityOfRowsDontContainZero = array.GetLength(0);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                    {
                        quantityOfRowsDontContainZero--;
                        break;
                    }
                }

            }

            Console.WriteLine($"Кiлькiсть рядкiв, якi не мiстять жодного нульового елемента: {quantityOfRowsDontContainZero}\n");
        }

        static void GetColsContainZero(int[,] array)
        {
            int quantityOfColsContainZero = 0;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j, i] == 0)
                    {
                        quantityOfColsContainZero++;
                        break;
                    }
                }

            }

            Console.WriteLine($"Кiлькiсть стовпцiв, якi мiстять хоча б один нульовий елемент: {quantityOfColsContainZero}\n");
        }

        static void GetRowRepeatedElements(int[,] array)
        {
            int numberOfRow = -1,
                numberOfRepeat = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(1) && k != j; k++)
                    {
                        int tmp = 0;
                        if (array[i, j] == array[i, k])
                            tmp++;
                        if (tmp > numberOfRepeat)
                            numberOfRow = i;
                    }
                }

            }

            if (numberOfRow == -1)
            {
                Console.WriteLine("У рядках не зустрiчається повторних елементiв.\n");
                return;
            }

            Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серiя однакових елементiв: {numberOfRow + 1}\n");
        }

        static void GetMatrixGreatestRepeatedElement(int[,] array)
        {
            int greatestElement = array[0, 0];

            bool isRepeated = false;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (IsRepeated(array[i, j], array))
                    {
                        if (greatestElement < array[i, j])
                            greatestElement = array[i, j];

                        isRepeated = true;
                    }
                }
            }

            if (!isRepeated)
            {
                Console.WriteLine("В матрицi не зустрiчається повторних елементiв.\n");
                return;
            }

            Console.WriteLine($"Максимальне iз чисел, що зустрiчається в заданiй матрицi бiльше одного разу: {greatestElement}\n");
        }

        static bool IsRepeated(int elementToCheck, int[,] array)
        {
            int counter = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == elementToCheck)
                        counter++;
                    if (counter == 2)
                        return true;
                }
            }

            return false;
        }

        static bool CheckIfRowContainsNegativeElement(int[,] array, int rowIndex)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[rowIndex, j] < 0)
                    return true;
            }

            return false;
        }

        static bool CheckIfColContainsNegativeElement(int[,] array, int colIndex)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, colIndex] < 0)
                    return true;
            }

            return false;
        }

        static void GetProductPositiveElements(int[,] array)
        {
            bool isPositive = false;
            Console.WriteLine("Добуток елементiв в тих рядках, якi не мiстять вiд’ємних елементiв: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int result = 1;
                if (!CheckIfRowContainsNegativeElement(array, i))
                {
                    isPositive = true;
                    for (int j = 0; j < array.GetLength(1); j++)
                        result *= array[i, j];
                    Console.WriteLine($"Добуток елементiв в рядку №{i + 1}: {result}");
                }
            }

            if (!isPositive)
                Console.WriteLine("В матрицi вiдсутнi рядки без вiд’ємних елементiв.");

            Console.WriteLine();
        }

        static void GetSumOfPositiveElementsInCols(int[,] array)
        {
            bool isPositive = false;
            Console.WriteLine("Cумa елементiв в тих стовпцях, якi не мiстять вiд’ємних елементiв: ");
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int result = 0;
                if (!CheckIfColContainsNegativeElement(array, j))
                {
                    isPositive = true;
                    for (int i = 0; i < array.GetLength(0); i++)
                        result += array[i, j];
                    Console.WriteLine($"Cумма елементiв у стовпцi №{j + 1}: {result}");
                }
            }

            if (!isPositive)
                Console.WriteLine("В матрицi вiдсутнi стовпцi без вiд’ємних елементiв");

            Console.WriteLine();
        }

        static void GetSumOfNegativeElementsInCols(int[,] array)
        {
            bool isPositive = false;
            Console.WriteLine("Cумa елементiв в тих стовпцях, якi  мiстять хоча б один вiд’ємний елемент: ");
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int result = 0;
                if (CheckIfColContainsNegativeElement(array, j))
                {
                    isPositive = true;
                    for (int i = 0; i < array.GetLength(0); i++)
                        result += array[i, j];
                    Console.WriteLine($"Cумма елементiв у стовпцi №{j + 1}: {result}");
                }
            }

            if (!isPositive)
                Console.WriteLine("В матрицi вiдсутнi стовпцi з вiд’ємними елементами");

            Console.WriteLine();
        }

        static int[,] TransposeMatrix(int[,] array)
        {
            int[,] transpesedMatrix = new int[array.GetLength(1), array.GetLength(0)];

            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                    transpesedMatrix[j, i] = array[i, j];
            }

            return transpesedMatrix;
        }

        static void GetMaxSum(int[,] array)
        {
            int maxSum = 0;
            int result = 0;
            for (int i = 1; i < array.GetLength(0); i++)
            {
                int col = 0;
                int row = i;
                int currentSum = 0;

                while (col < array.GetLength(1) && row < array.GetLength(0))
                {
                    currentSum += array[row, col];
                    row++;
                    col++;
                }
                if (currentSum > maxSum)
                    maxSum = currentSum;

                result = maxSum;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int col = 1;
                int row = i;
                int currentSum = 0;

                while (col < array.GetLength(1) && row < array.GetLength(0))
                {
                    currentSum += array[row, col];
                    row++;
                    col++;
                }
                if (currentSum > maxSum)
                    maxSum = currentSum;

                if (result < maxSum)
                    result = maxSum;
            }

            Console.WriteLine($"Максимум серед сум елементiв дiагоналей, паралельних головнiй дiагоналi матрицi: {result}\n");
        }

        static void GetMinimumSumOfModules(int[,] array)
        {
            int minSum = 0;
            int result = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int col = array.GetLength(1) - 1;
                int row = i;
                int currentSum = 0;

                while (col > -1 && row < array.GetLength(0))
                {
                    currentSum += Math.Abs(array[row, col]);
                    row++;
                    col--;
                }
                if (currentSum < minSum)
                    minSum = currentSum;

                result = minSum;
            }
            for (int i = 1; i < array.GetLength(0); i++)
            {
                int col = array.GetLength(1) - 1;
                int row = i;
                int currentSum = 0;

                while (col > -1 && row < array.GetLength(0))
                {
                    currentSum += array[row, col];
                    row++;
                    col--;
                }
                if (currentSum < minSum)
                    minSum = currentSum;

                if (result < minSum)
                    result = minSum;
            }

            Console.WriteLine($"Мiнiмум серед сум модулiв елементiв дiагоналей, паралельних побiчнiй дiагоналi матрицi: {result}\n");
        }
    }
}
