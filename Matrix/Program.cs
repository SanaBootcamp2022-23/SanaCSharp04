using WorkWithMatrix;

namespace Matrix
{

    internal class Program
    {
        static int amoutOfPositivNumbers(int[,] arr, int N, int M)
        {
            int counter = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] > 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        static int maxValue(int[,] arr, int N, int M)
        {
            int max = 0;

            int[] aditionalArr = new int[N * M];

            int counter = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    aditionalArr[counter] = arr[i, j];
                    counter++;
                }
            }


            Array.Sort(aditionalArr);


            max = aditionalArr[N * M - 1];
            for (int i = N * M - 1; i > 0; i--)
            {
                if (max == aditionalArr[i - 1])
                {
                    break;
                }
                else
                {
                    max = aditionalArr[i - 1];
                }
            }

            return max;
        }

        static int unzeroRowsNumber(int[,] arr)
        {
            int counter = arr.GetLength(0);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        counter--;
                        break;
                    }
                }
            }

            return counter;
        }

        static int zeroColumnsNumber(int[,] arr)
        {
            int counter = 0;

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] == 0)
                    {
                        counter++;
                        break;
                    }
                }
            }

            return counter;
        }

        static int findTheNumberOfRow(int[,] arr)
        {
            int number = 0, max = 0;
            int[] aditionalArr = new int[arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                max = 0;
                number = 0;
                for (int j = 0; j < arr.GetLength(1) - 1; j++)
                {
                    if (arr[i, j] == arr[i, j + 1])
                    {
                        number++;
                        continue;
                    }
                    if (arr[i, j] != arr[i, j] || j + 1 != arr.GetLength(1))
                    {
                        if (number > max)
                        {
                            max = number;
                            number = 0;
                        }
                    }
                }
                aditionalArr[i] = max;
            }
            max = 0;
            int counter = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (max < aditionalArr[i])
                {
                    max = aditionalArr[i];
                    counter = i;
                }
            }

            return counter;
        }

        public static void rowProdact(int[,] arr)
        {

            bool isCounting;
            int product = 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                isCounting = true;
                product = 1;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < 0)
                    {
                        isCounting = false;
                        break;
                    }

                    product *= arr[i, j];
                }
                if (isCounting)
                {
                    Console.WriteLine($"|{$"Number of row is: {i + 1}",-20}| |{$"The product is: {product}",-23}|");
                }
                else
                {
                    Console.WriteLine($"|{$"Number of row is: {i + 1}",-20}| |{"The row has minus value",-20}|");
                }
            }
        }

        public static void maxDiagonalSum(int[,] arr)
        {
            int sum;
            int f = 0;
            int max = arr.GetLength(0), min = -arr.GetLength(1) + 1;
            int[] sums = new int[arr.GetLength(0) + arr.GetLength(1) - 1];
            Console.WriteLine("All the sums of diagonals:");
            for (int k = min; k < max; k++)
            {
                sum = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (i - j == k)
                        {
                            sum += arr[i, j];
                        }
                    }
                }
                sums[f] = sum;
                f++;
                Console.Write($"{sum} ");
            }
            Console.WriteLine();
            Array.Sort(sums);
            Console.WriteLine($"\nMax value: {sums[sums.Length - 1]}");

        }

        public static void sumOfColumns(int[,] arr)
        {
            bool isCounting;
            int sum = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                isCounting = true;
                sum = 0;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] < 0)
                    {
                        isCounting = false;
                        break;
                    }

                    sum += arr[j, i];
                }
                if (isCounting)
                {
                    Console.WriteLine($"|{$"Number of column is: {i + 1}",-20}| |{$"The sum is: {sum}",-26}|");
                }
                else
                {
                    Console.WriteLine($"|{$"Number of column is: {i + 1}",-20}| |{"The column has minus value",-20}|");
                }
            }
        }

        public static void minDiagonalSum(int[,] arr)
        {
            int sum;
            int f = 0;
            int max = arr.GetLength(0), min = -arr.GetLength(1) + 1;
            int[] sums = new int[arr.GetLength(0) + arr.GetLength(1) - 1];
            Console.WriteLine("All the sums of diagonals:");
            for (int k = 0; k < (arr.GetLength(0) + arr.GetLength(1) - 1); k++)
            {
                sum = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (i + j == k)
                        {
                            sum += arr[i, j];
                        }
                    }
                }
                sums[f] = sum;
                f++;
                Console.Write($"{sum} ");
            }
            Console.WriteLine();
            Array.Sort(sums);
            Console.WriteLine($"\nMin value: {sums[0]}");
        }

        public static void sumOfColumnsWithMinusValues(int[,] arr)
        {
            bool isCounting;
            int sum = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                isCounting = false;
                sum = 0;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    sum += arr[j, i];
                    if (arr[j, i] < 0)
                    {
                        isCounting = true;
                    }
                }
                if (isCounting)
                {
                    Console.WriteLine($"|{$"Number of column is: {i + 1}",-20}| |{$"The sum is: {sum}",-29}|");
                }
                else
                {
                    Console.WriteLine($"|{$"Number of column is: {i + 1}",-20}| |{"The column hasn't minus value",-20}|");
                }
            }
        }

        public static void transposedMatrix(int[,] arr)
        {
            int[,] matrix = new int[arr.GetLength(1), arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    matrix[i, j] = arr[j, i];
                }
            }

            ConsoleWork.printArr(matrix, matrix.GetLength(0), matrix.GetLength(1));
        }




        static void Main(string[] args)
        {
            int N = 0;
            int M = 0;

            Console.WriteLine("Enter the value of N: ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of M: ");
            M = Convert.ToInt32(Console.ReadLine());

            int[,] arr;
            arr = new int[N, M];

            ConsoleWork.getArr(arr, N, M);
            ConsoleWork.printArr(arr, N, M);

            Console.WriteLine($"1) Amount of positive numbers: {amoutOfPositivNumbers(arr, N, M)}");

            Console.WriteLine($"2) Max value which has been repeated : {maxValue(arr, N, M)}");

            Console.WriteLine($"3) Amount of rows which do not have zero value: {unzeroRowsNumber(arr)}");

            Console.WriteLine($"4) Amount of columns which have zero value: {zeroColumnsNumber(arr)}");

            Console.WriteLine($"5) Number of row which has the longest identical sequence of values: {findTheNumberOfRow(arr)}");

            Console.WriteLine("6) Products of row's values which do not have minus values:\n");
            rowProdact(arr);
            Console.WriteLine("7) Max sum of diagonals of matrix:\n");
            maxDiagonalSum(arr);
            Console.WriteLine("8) Sums arr's values columns which do not have minus values:\n");
            sumOfColumns(arr);
            Console.WriteLine("9) Min sum of side diagonals of matrix:\n");
            minDiagonalSum(arr);
            Console.WriteLine("10) Sums arr's values columns which have minus values:\n");
            sumOfColumnsWithMinusValues(arr);
            Console.WriteLine("11) Transposed matrix:\n");
            transposedMatrix(arr);

        }
    }
}