using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix
{
    internal class Matrix
    {
        public static uint MatrixLength()
        {
            uint nubmer;
            while (!uint.TryParse(Console.ReadLine(), out nubmer) || nubmer <= 0)
            {
                Console.Write($"Невірна введенно значення, введіть ще раз = ");
            }
            return nubmer;
        }
        public static double[,] GenerateMatrix(uint rowCount, uint colCount)
        {
            double[,] matrix = new double[rowCount, colCount];
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(0, 9);
                }
            }
            return matrix;
        }
        public static void DisplayMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],10}");
                }
                Console.WriteLine();
            }

        }
        public static int CountPositiveElements(double[,] matrix)
        {
            int positivecount = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        positivecount++;
                    }
                }

            }
            return positivecount;
        }
        public static double MaximumNubmerMoreThanOnce(double[,] matrix)
        {
            double max = -999, countmaxelement = 0, maxelemen = -999, maxserias = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    max = matrix[i, j];
                    countmaxelement = 0;
                    for (int tempi = 0; tempi < matrix.GetLength(0); tempi++)
                    {

                        for (int tempj = 0; tempj < matrix.GetLength(1); tempj++)
                        {
                            if (matrix[tempi, tempj] == max)
                            {
                                countmaxelement++;
                            }
                        }
                    }
                    if (countmaxelement >= maxserias && max > maxelemen && countmaxelement > 1)
                        maxelemen = max;
                    maxserias = countmaxelement;



                }

            }
            return maxelemen;

        }
        public static int CountRowDontZeroElements(double[,] matrix)
        {
            int countrowpositive = matrix.GetLength(0);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] == 0)
                    {
                        countrowpositive--;
                        break;
                    }

                }

            }
            return countrowpositive;
        }

        public static int CountColHaveZeroElements(double[,] matrix)
        {
            int countcolpositive = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        countcolpositive++;
                        break;
                    }

                }

            }
            return countcolpositive;
        }
        public static int LongDublicateElements(double[,] matrix)
        {

            int serias = 0, count = 0, rowindex = -1, countserias = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        count++;
                        if (count > serias)
                            serias = count;

                    }
                    else
                        count = 0;

                }
                if (serias > countserias)
                {
                    countserias = serias;
                    rowindex = i;
                }

            }
            return rowindex;
        }
        public static void DobutokElemensRowDontNegativeElements(double[,] matrix)
        {
            double dobutok;
            int negative;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dobutok = 1;
                negative = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dobutok *= matrix[i, j];

                    if (matrix[i, j] < 0)
                    {
                        dobutok = 1;
                        negative++;
                        break;

                    }

                }
                if (negative == 0)
                {
                    Console.WriteLine($"Добуток елементів в {i} ряду який не містить від'ємних елементів  = {dobutok}");
                }
                else
                    Console.WriteLine($"Рядок {i} містить від'ємні елементи");

            }
        }
        public static void MaxSumParalelGeneralDiagonal(double[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int cordRow, cordCol;
                double maxsumma = 0, numberdiagonal = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    cordRow = 0;
                    cordCol = j;
                    double summa = 0;
                    for (int i = 0; i < matrix.GetLength(0) - j; i++)
                    {
                        summa += matrix[cordRow, cordCol];
                        cordRow++;
                        cordCol++;
                    }
                    if (summa > maxsumma)
                    {
                        maxsumma = summa;
                        numberdiagonal = j;
                    }
                }
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    cordRow = i;
                    cordCol = 0;
                    double summa = 0;
                    for (int j = 0; j < matrix.GetLength(1) - i; j++)
                    {
                        summa += matrix[cordRow, cordCol];
                        cordRow++;
                        cordCol++;

                    }
                    if (summa > maxsumma)
                    {
                        maxsumma = summa;
                        numberdiagonal = i * (-1);
                    }
                }
                Console.WriteLine($"Максимум серед сум діагоналей паралельних головній = {maxsumma} це {numberdiagonal}  діагональ");
            }
            else
                Console.WriteLine($"Матриця не квадратна");

        }
        public static void SumElemensColDontNegativeElements(double[,] matrix)
        {
            double sum, chek;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum = 0;
                chek = 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        sum = 0;
                        chek = 0;
                        break;
                    }

                }
                if (chek != 0)
                {
                    Console.WriteLine($"Сума елементів в {j} стовпчику який не містить від'ємних елементів  = {sum}");
                }
                else
                    Console.WriteLine($"Стовпчик {j} містить від'ємні елементи");

            }
        }
        public static void MinSumParalelSideDiagonal(double[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int cordRow, cordCol;
                double minsumma = 999, numberdiagonal = 0;
                for (int j = matrix.GetLength(1); j > 1; j--)
                {
                    cordRow = 0;
                    cordCol = j - 2;
                    int temp = j - 1;
                    double summa = 0;
                    for (int i = 0; i < temp; i++)
                    {
                        summa += Math.Abs(matrix[cordRow, cordCol]);
                        cordRow++;
                        cordCol--;
                    }
                    if (summa < minsumma)
                    {
                        minsumma = summa;
                        numberdiagonal = j;
                    }
                }
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    cordRow = i;
                    cordCol = matrix.GetLength(1) - 1;
                    double summa = 0;
                    for (int j = 0; j < matrix.GetLength(1) - i; j++)
                    {
                        summa += Math.Abs(matrix[cordRow, cordCol]);
                        cordRow++;
                        cordCol--;
                    }
                    if (summa < minsumma)
                    {
                        minsumma = summa;
                        numberdiagonal = i * (-1);
                    }
                }
                Console.WriteLine($"Минимум серед сум діагоналей паралельних побічній = {minsumma} це {numberdiagonal}  діагональ");
            }
            else
                Console.WriteLine($"Матриця не квадратна");
        }
        public static void SumElemensColHaveNegativeElements(double[,] matrix)
        {
            double sum, chek;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum = 0;
                chek = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        chek++;
                    }

                }

                if (chek != 0)
                {
                    Console.WriteLine($"Сума елементів в {j} стовпчику який містить хоча б один від'ємний елемент = {sum}");
                }
                else
                    Console.WriteLine($"Стовпчик {j} не містить від'ємних елементів");

            }
        }
        public static double[,] TransposedMatrix(double[,] matrix)
        {
            double[,] transposedMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];
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
