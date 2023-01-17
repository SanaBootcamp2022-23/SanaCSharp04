using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Method
    {
        public static int[,] CreateMatrix(int rows,int cols)
        {
            int[,] Array = new int[rows,cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    try
                    {
                        Console.WriteLine("Введiть елемент на позицiї:(" + (i + 1) + "," + (j + 1) + ")");
                                            Array[i, j] = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неправильно введено!");
                    }
                    
                }

            }
            return Array;
        }
        public static int ShowPositiveElement(int[,] Array)
        {
            int positive = 0;////кількість додатних елементів
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {

                    if (Array[i, j] > 0)
                    {
                        positive++;
                    }
                }
            }
            return positive;
        }
        public static int ElementRepit(int[,] Array)
        {
            int[] counter = new int[10000];
            for (int i=0;i< Array.GetLength(0); i++)
            {
                for(int j=0;j< Array.GetLength(1); j++)
                {
                    counter[Math.Abs(Array[i, j])]++;
                }
            }
            int max_num = -1;//максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] > 1)
                {
                    max_num = i;

                }
            }
            return max_num;
        }
        public static int NumbRowWtZero(int[,] Array)
        {
            int rowsWithOut = 0;////кількість рядків, які не містять жодного нульового елемента;

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                bool exist = false;
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] == 0)
                    {
                        exist = true;
                        break;
                    }

                }
                if (!exist)
                {
                    rowsWithOut++;
                }
            }
            return rowsWithOut;
        }
        public static int NumbColWtZero(int[,] Array)
        {
            int colCount = 0;//кількість стовпців, які містять хоча б один нульовий елемент;

            for (int j = 0; j < Array.GetLength(1); j++)
            {
                bool hasZero = false;
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    if (Array[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (hasZero)
                {
                    colCount++;
                }
            }
            return colCount;
        }
        public static int NumbrMostRep(int[,] Array)
        {
            int maxLength = 0;
            int maxRow = 0;//номер рядка в якому знаходиться найдовша серія однакових чисел
            int currentLength = 1;

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 1; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] == Array[i, j - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                            maxRow = i;
                        }
                        currentLength = 1;
                    }
                }
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxRow = i;
                }
                currentLength = 1;
            }
            maxRow++;
            return maxRow;
        }
        public static double MultipNumbWithTNegative(int[,] Array)
        {
            double product = 1;////добуток елементів в тих рядках, які не містять від’ємних елементів;


            for (int i = 0; i < Array.GetLength(0); i++)
            {
                bool hasNegative = false;
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (!hasNegative)
                {
                    for (int j = 0; j < Array.GetLength(1); j++)
                    {
                        product *= Array[i, j];
                    }
                }
            }
            return product;
        }
        public static int MaximumsOfSumFirstDiagonal(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maximumSum = int.MinValue;

            for (int i = -(rows - 1); i < cols; ++i)
            {
                int curSum = 0;
                for (int j = 0; j < rows; ++j)
                {
                    if (j >= 0 && j < rows && (j + i) >= 0 && (j + i) < cols)
                        curSum += matrix[j, j + i];
                }
                maximumSum = Math.Max(curSum, maximumSum);
                curSum = 0;
            }
            return maximumSum;
        }

        public static int SumOfElementWithoutNegative(int[,] Array)
        {
            int sumElCol = 0;//суму елементів в тих стовпцях, які не містять від’ємних елементів;
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                bool hasNegative = false;
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    if (Array[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (!hasNegative)
                {
                    for (int i = 0; i < Array.GetLength(0); i++)
                    {
                        sumElCol += Array[i, j];
                    }
                }
            }
            return sumElCol;
        }
        public static int MinimumSumOfModules(int[,] matrix)
        {
            int minSum = int.MaxValue;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            //loop through diagonals that are perpendicular to the main diagonal
            for (int i = 0; i < rows + cols - 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        if (j + k == i)
                        {
                            sum += Math.Abs(matrix[j, k]);
                        }
                    }
                }
                minSum = Math.Min(minSum, sum);
            }
            return minSum;
        }
        public static int SumOfColsWhichHaveNegativeElement(int[,] Array)
        {
            int sumColl = 0;//суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                bool hasNegative = false;
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    if (Array[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (hasNegative)
                {
                    for (int i = 0; i < Array.GetLength(0); i++)
                    {
                        sumColl += Array[i, j];
                    }
                }
            }
            return sumColl;
        }
        public static void TransponMatrixOutPut(int[,] Array)
        {
            int[,] transposed = new int[Array.GetLength(1), Array.GetLength(0)];//транспонована матриця
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    transposed[j, i] = Array[i, j];
                }

            }
            Console.WriteLine("Транспонована матриця:");
            for (int i = 0; i < Array.GetLength(1); i++)
            {
                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    Console.Write(transposed[i, j] + " ");
                }
                Console.Write("\n");
            }

        }
        public static void OutPutMatrix(int[,] Array)
        {
            Console.WriteLine("Введена матриця:");
            for(int i = 0; i < Array.GetLength(0); i++)
            {
                for(int j=0;j< Array.GetLength(1); j++)
                {
                    Console.Write(Array[i, j]+" ");
                }
                Console.Write("\n");
            }
        }


    }
}
