using System;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            uint matrixWidth = CheckCorrectness.SizeMatrix(NameEnum.Width);

            uint matrixHeight = CheckCorrectness.SizeMatrix(NameEnum.Height);

            int leftBorderMatrix = CheckCorrectness.LeftBorder();

            int rightBorderMatrix = CheckCorrectness.RightBorder();

            CreateMatrix mtrOne = new CreateMatrix(matrixWidth, matrixHeight, leftBorderMatrix, rightBorderMatrix);

            int[,] matrix = mtrOne.MatrixCreate();

            // Завдання 1
            // Для матриці N на M цілого типу визначити:
            // кількість додатних елементів;

            int positiveNumberCount = PositiveNumberCount(matrix);

            // Завдання 2
            // Для матриці N на M цілого типу визначити:
            // максимальне із чисел, що зустрічається в заданій матриці більше одного разу;

            int maxNumber = MaxNumber(matrix);

            // Завдання 3
            // Для матриці N на M цілого типу визначити:
            // кількість рядків, які не містять жодного нульового елемента;

            int theNumberOfRowsWithoutZeroElements = TheNumberOfRowsWithoutZeroElements(matrix);

            // Завдання 4
            // Для матриці N на M цілого типу визначити:
            // кількість стовпців, які містять хоча б один нульовий елемент;

            int theNumberOfColumnsThatContainZero = TheNumberOfColumnsThatContainZero(matrix);

            // Завдання 5
            // Для матриці N на M цілого типу визначити:
            // номер рядка, в якому знаходиться найдовша серія однакових елементів;

            int numberRows = NumberRows(matrix);

            // Завдання 6
            // Для матриці N на M цілого типу визначити:
            // добуток елементів в тих рядках, які не містять від’ємних елементів;

            int productElements = ProductElements(matrix);

            // Завдання 7
            // Для матриці N на M цілого типу визначити:
            // максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;

            int sum = SumOfDiagonalsWidth(matrix);

            // Завдання 8
            // Для матриці N на M цілого типу визначити:
            // суму елементів в тих стовпцях, які не містять від’ємних елементів;

            int smnElements = SumElements(matrix);

            // Завдання 9
            // Для матриці N на M цілого типу визначити:
            // мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;

            int sumOfDiagonalsWidth1 = SumOfDiagonalsWidth1(matrix);

            // Завдання 10
            // Для матриці N на M цілого типу визначити:
            // суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент;

            int sumElements1 = SumElements1(matrix);

            // Завдання 11
            // Для матриці N на M цілого типу визначити: транспоновану матрицю;

            MatrixTranspon(matrix);
            Console.WriteLine();
            ;
        }

        static int NumberRows(int[,] matrix)
        {
            //int[,] matrixTranspon = new int[matrix.GetLength(1), matrix.GetLength(0)];
            int[] vs = new int[matrix.GetLength(0)];
            int value;
            int index;
            for (int line = 0; line < matrix.GetLength(0); line++)
            {
                int[] gf = new int[matrix.GetLength(1)];
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    //Console.Write(matrix[line, column]+"\t");
                    int count = 0;
                    for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)
                    {
                        if (columnOne != column && matrix[line, column] == matrix[line, columnOne]) count++;
                    }
                    gf[column] = count;
                }
                vs[line] = gf.Max();
                //Console.WriteLine();

            }
            value = vs.Max();
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i] == value)
                    index = i;
            }
            index = -1;
            Console.WriteLine($"Number of the first row, which has the longest row of identical elements ={index}");
            return index;
        }

        static void MatrixTranspon(int[,] matrix)
        {
            int[,] matrixTranspon = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int line = 0; line < matrix.GetLength(0); line++)
                {
                    matrixTranspon[column, line] = matrix[line, column];
                    Console.Write($"{matrixTranspon[column, line]} \t");
                }
                Console.WriteLine();
            }
        }

        static int SumElements1(int[,] matrix)
        {
            bool columHasANegativeElement = true;
            int sumElements1 = 0;

            for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)
            {
                for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
                {
                    if (matrix[lineOne, columnOne] < 0)
                    {
                        columHasANegativeElement = false;
                        break;
                    }
                }
                if (columHasANegativeElement)
                {
                    continue;
                }
                for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
                {
                    if (matrix[lineOne, columnOne] != 0) sumElements1 += matrix[lineOne, columnOne];
                }
                columHasANegativeElement = true;

            }
            Console.WriteLine($"The count of rows which contain at least one negative element ={ sumElements1} ");
            return sumElements1;
        }

        static int SumOfDiagonalsWidth1(int[,] matrix)
        {
            int[] sumOfDiagonalsWidth1 = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
                {
                    for (int columnOne = (int)matrix.GetLength(1) - 1 - i; columnOne >= 0; columnOne--)
                    {
                        if (lineOne + columnOne == (int)matrix.GetLength(1) - 1 - i)
                        {
                            sumOfDiagonalsWidth1[i] += Math.Abs(matrix[lineOne, columnOne]);
                        }
                    }
                }
            }
            int[] sumOfDiagonalsHeight1 = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
                {
                    for (int columnOne = (int)matrix.GetLength(1) - 1; columnOne >= 0; columnOne--)
                    {

                        if (lineOne + columnOne == (int)matrix.GetLength(1) - 1 + i)
                        {
                            sumOfDiagonalsHeight1[i] += Math.Abs(matrix[lineOne, columnOne]);
                        }
                    }
                }
            }
            int res = Math.Min(sumOfDiagonalsHeight1.Min(), sumOfDiagonalsWidth1.Min());
            Console.WriteLine($"The minimum among the sums of the modules of the elements of the diagonals ={ res} ");
            return res;
        }

        static int SumElements(int[,] matrix)
        {
            bool columHasANegativeElement = false;

            int sumElements = 0;

            for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)
            {
                for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
                {
                    if (matrix[lineOne, columnOne] < 0)
                    {
                        columHasANegativeElement = true;
                        break;
                    }
                }
                if (columHasANegativeElement)
                {
                    columHasANegativeElement = false;
                    continue;
                }
                for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
                {
                    if (matrix[lineOne, columnOne] != 0) sumElements += matrix[lineOne, columnOne];
                }

            }
            Console.WriteLine($"The count of rows without zero elements ={ sumElements} ");
            return sumElements;
        }

        static int SumOfDiagonalsWidth(int[,] matrix)
        {
            int[] sumOfDiagonalsWidth = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
                {
                    for (int columnOne = i; columnOne < matrix.GetLength(1); columnOne++)
                    {
                        if (lineOne + i == columnOne)
                        {
                            sumOfDiagonalsWidth[i] += matrix[lineOne, columnOne];
                        }
                    }
                }
            }
            int[] sumOfDiagonalsHeight = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int lineOne = i; lineOne < matrix.GetLength(0); lineOne++)
                {
                    for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)
                    {
                        if (lineOne == columnOne + i)
                        {
                            sumOfDiagonalsHeight[i] += matrix[lineOne, columnOne];
                        }
                    }
                }
            }
            int res = Math.Max(sumOfDiagonalsHeight.Max(), sumOfDiagonalsWidth.Max());
            Console.WriteLine($"The maximum among the sums of the elements of the diagonals ={res} ");
            return res;
        }

        static int ProductElements(int[,] matrix)
        {
            bool stringHasANegativeElement = false;

            int productElements = 1;

            for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
            {
                for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)
                {
                    if (matrix[lineOne, columnOne] < 0)
                    {
                        stringHasANegativeElement = true;
                        break;
                    }
                }
                if (stringHasANegativeElement)
                {
                    stringHasANegativeElement = false;
                    continue;
                }
                for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)
                {
                    if (matrix[lineOne, columnOne] != 0) productElements *= matrix[lineOne, columnOne];
                }

            }
            Console.WriteLine($"The product of the elements in those rows that do not contain negative elements ={productElements} ");
            return productElements;
        }

        static int TheNumberOfColumnsThatContainZero(int[,] matrix)
        {
            bool thereIsAZeroInTheLine = false;
            int theNumberOfColumnsThatContainZero = 0;


            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int line = 0; line < matrix.GetLength(0); line++)
                {
                    if (matrix[line, column] == 0)
                    {
                        thereIsAZeroInTheLine = true;
                        break;
                    }
                }
                if (thereIsAZeroInTheLine)
                    theNumberOfColumnsThatContainZero++;

                thereIsAZeroInTheLine = false;
            }
            Console.WriteLine($"The number of columns that contain at least one null element = { theNumberOfColumnsThatContainZero}");
            return theNumberOfColumnsThatContainZero;
        }

        static int PositiveNumberCount(int[,] matrix)
        {
            int positiveNumberCount = 0;
            foreach (int value in matrix)
                if (value > 0) positiveNumberCount++;

            Console.WriteLine($"Count a positive number matrix = {positiveNumberCount}");
            return positiveNumberCount;
        }

        static int MaxNumber(int[,] matrix)
        {
            int maxNumber = int.MinValue;
            bool twoIdenticalNumbersArePresent = false;
            for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)

                for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)

                    for (int lineTwo = 0; lineTwo < matrix.GetLength(0); lineTwo++)

                        for (int columnTwo = 0; columnTwo < matrix.GetLength(1); columnTwo++)
                            if ((lineOne != lineTwo || columnOne != columnTwo) &&
                                matrix[lineOne, columnOne] == matrix[lineTwo, columnTwo] &&
                                maxNumber < matrix[lineOne, columnOne])
                            {
                                maxNumber = matrix[lineOne, columnOne];
                                twoIdenticalNumbersArePresent = true;
                            }

            if (twoIdenticalNumbersArePresent)
                Console.WriteLine($"The maximum number that occurs in the given matrix more than once = {maxNumber}");
            else
                Console.WriteLine("There are no identical elements in the matrix");
            return maxNumber;
        }

        static int TheNumberOfRowsWithoutZeroElements(int[,] matrix)
        {
            bool thereIsAZeroInTheLine = false;
            int theNumberOfRowsWithoutZeroElements = 0;

            for (int lineOne = 0; lineOne < matrix.GetLength(0); lineOne++)
            {
                for (int columnOne = 0; columnOne < matrix.GetLength(1); columnOne++)
                {
                    if (matrix[lineOne, columnOne] == 0)
                    {
                        thereIsAZeroInTheLine = true;
                        break;
                    }
                }
                if (!thereIsAZeroInTheLine)
                {
                    theNumberOfRowsWithoutZeroElements++;
                }
                thereIsAZeroInTheLine = false;
            }
            Console.WriteLine($"The number of rows without zero elements = { theNumberOfRowsWithoutZeroElements} ");
            return theNumberOfRowsWithoutZeroElements;
        }
    }
}
