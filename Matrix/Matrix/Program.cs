using System.Text;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int n, m;
            bool ok;

            do
            {
                Console.WriteLine("Введіть кількість рядків: ");
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok)
                {
                    Console.WriteLine("Некоректно введені дані");
                }

            } while (!ok || n < 1);

            do
            {
                Console.WriteLine("Введіть кількість стовпців: ");
                ok = int.TryParse(Console.ReadLine(), out m);
                if (!ok)
                {
                    Console.WriteLine("Некоректно введені дані");
                }

            } while (!ok || m < 1);
           



            int[,] matrix = new int[n, m];
            Random random = new Random();

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }

            Console.WriteLine("Матриця: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }


            getCountPositiveElements(matrix);
            getMaxElementMoreOneTimes(matrix);
            getCountRowsWithoutZeroElement(matrix);
            getCountColumnsWithZero(matrix);
            getRowWithLongestSeries(matrix);
            getProductOfNonNegativeRows(matrix);
            getMaxSumParallelToMainDiagonal(matrix);
            getSumColumnsWithoutNegatives(matrix);
            getMinSumParallelDiagonal(matrix);
            getSumColumnsWithNegativeElements(matrix);
            getTransposeMatrix(matrix);
        }


        public static void getCountPositiveElements(int[,] matrix)
        {
            int count = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        count++;
                    }
                }
            }
            if(count == 0)
            {
                Console.WriteLine("\nВідсутні додатні елементи");
            }
            else
            {
                Console.WriteLine($"\nКількість додатних елементів: {count}");
            }

        }

        public static void getMaxElementMoreOneTimes(int[,] matrix)
        {
            int maxNum = int.MinValue;
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    count = 0;

                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        for (int f = 0; f < matrix.GetLength(1); f++)
                        {
                            if (matrix[i, j] == matrix[k, f])
                                count++;
                        }
                    }

                    if (count > 1 && matrix[i, j] > maxNum)
                        maxNum = matrix[i, j];
                }
            }
            if (maxNum == int.MinValue)
            {
                Console.WriteLine("Відсутні числа які повторюються більше одного разу");
            }
            else
            {
                Console.WriteLine("Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: " + maxNum);
            }
        }

        public static void getCountRowsWithoutZeroElement(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rowSum++;
                        break;
                    }
                }
                if (rowSum == 0)
                {
                    count++;
                }
            }
            if(count == 0)
            {
                Console.WriteLine("Відсутні нулі");
            }
            else
            {
                Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента: {count}");
            }

        }

        public static void getCountColumnsWithZero(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int count = 0;

            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        count++;
                        Console.WriteLine("Стовпець {0} містить хоча б один нульовий елемент", j);
                        break;
                    }
                }
            }

            Console.WriteLine("Сумарна кількість стовпців з хоча б одним нульовим елементом: {0}", count);
        }

        public static void getRowWithLongestSeries(int[,] matrix)
        {
            int rowWithLongestSeries = 0;
            int longestSeriesLength = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int currentLength = 1;
                int currentNum = matrix[i, 0];

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == currentNum)
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (currentLength > longestSeriesLength)
                        {
                            rowWithLongestSeries = i;
                            longestSeriesLength = currentLength;
                        }
                        currentLength = 1;
                        currentNum = matrix[i, j];
                    }
                }

                if (currentLength > longestSeriesLength)
                {
                    rowWithLongestSeries = i;
                    longestSeriesLength = currentLength;
                }
            }
            Console.WriteLine("Номер рядка, в якому знаходиться найдовша серія однакових елементів: " + rowWithLongestSeries);
        }

        public static void getProductOfNonNegativeRows(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int product = 1;
                int j = 0;

                while (j < columns && matrix[i, j] >= 0)
                {
                    product *= matrix[i, j];
                    j++;
                }

                if (j == columns)
                {
                    Console.WriteLine($"Добуток елементів у рядку {i}: {product}");
                }
            }
        }

        public static void getMaxSumParallelToMainDiagonal(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int maxSum = int.MinValue;

            // проходимо по діагоналях, що починаються на першому рядку
            for (int j = 0; j < columns; j++)
            {
                int sum = 0;
                int i = 0;
                int k = j;

                while (i < rows && k < columns)
                {
                    sum += matrix[i, k];
                    i++;
                    k++;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            // проходимо по діагоналях, що починаються на першому стовпці
            for (int i = 1; i < rows; i++)
            {
                int sum = 0;
                int j = 0;
                int k = i;

                while (j < columns && k < rows)
                {
                    sum += matrix[k, j];
                    j++;
                    k++;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            Console.WriteLine("Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: " + maxSum);
        }

        public static void getSumColumnsWithoutNegatives(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int sum = 0;
                        
            for (int j = 0; j < columns; j++)
            {
                int columnSum = 0;
                           
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        columnSum = -1;
                        break;
                    }
                    columnSum += matrix[i, j];
                }

                if (columnSum != -1)
                {
                    sum += columnSum;
                }
            }
            Console.WriteLine("Cума елементів в тих стовпцях, які не містять від’ємних елементів: " + sum);
        }

        public static void getMinSumParallelDiagonal(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int minSum = int.MaxValue;

            // перший цикл проходить по діагоналям, які знаходяться нижче побічної діагоналі
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                int row = i;
                int col = 0;

                // другий цикл обчислює суму модулів елементів на діагоналі
                while (row < rows && col < columns)
                {
                    sum += Math.Abs(matrix[row, col]);
                    row++;
                    col++;
                }

                if (sum < minSum)
                {
                    minSum = sum;
                }
            }

            // третій цикл проходить по діагоналям, які знаходяться вище побічної діагоналі
            for (int j = 1; j < columns; j++)
            {
                int sum = 0;
                int row = 0;
                int col = j;

                // четвертий цикл обчислює суму модулів елементів на діагоналі
                while (row < rows && col < columns)
                {
                    sum += Math.Abs(matrix[row, col]);
                    row++;
                    col++;
                }

                if (sum < minSum)
                {
                    minSum = sum;
                }
            }
            Console.WriteLine("Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: " + minSum);
        }

        public static void getSumColumnsWithNegativeElements(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int sum = 0;

            
            for (int j = 0; j < columns; j++)
            {
                int columnSum = 0;
                bool hasNegative = false;

                
                for (int i = 0; i < rows; i++)
                {
                    columnSum += matrix[i, j];
                    if (!hasNegative && matrix[i, j] < 0)
                    {
                        hasNegative = true;
                    }
                }

                
                if (hasNegative)
                {
                    sum += columnSum;
                }
            }
            Console.WriteLine("Cума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: " + sum);
        }

        public static void getTransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[,] transposedMatrix = new int[columns, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    transposedMatrix[j, i] = matrix[i, j];
                }
            }

            Console.WriteLine("транспонована матриця:");

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(transposedMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}