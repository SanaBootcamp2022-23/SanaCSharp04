using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    static class Matrix
    {
        public class LibraryMatrix
        {
            public static string vision = "-------";
            public static void DisplayMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"  {matrix[i, j],3}  ");
                    }
                    Console.WriteLine();
                }
            }
            public static int[,] GenerationMatrix(uint columCount, uint rowsCount, int[,] matrix)
            {
                var rand = new Random();
                for (int i = 0; i < columCount; i++)
                {
                    for (int j = 0; j < rowsCount; j++)
                    {
                        matrix[i, j] = rand.Next(-5, 11);
                    }
                }
                return matrix;
            }
            public static void CountPositiveElem(int[,] matrix)
            {
                uint posnumber = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            posnumber++;
                        }
                    }
                }
                Console.WriteLine($"{vision}");
                Console.WriteLine($"Task_01\n-->{posnumber,3}");
                Console.WriteLine($"{vision}");
            }
            public static void MaxRepeatValue(int[,] matrix)
            {
                int[] array = new int[matrix.GetLength(0) * matrix.GetLength(1)]; int trash = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        array[i * matrix.GetLength(1) + j] = matrix[i, j];
                    }
                }
                Array.Sort(array);
                for (int i = array.Length - 1; i > 0; i--)
                {
                    if (array[i] == array[i - 1])
                    {
                        Console.WriteLine($"{vision}");
                        Console.WriteLine($"Task_02\n-->{array[i],3}");
                        Console.WriteLine($"{vision}");
                        i = 0; trash++;
                    }
                }
                if (trash == 0)
                {
                    Console.WriteLine($"{vision}");
                    Console.WriteLine($"Task_02\n-->All values ​​occur only once");
                    Console.WriteLine($"{vision}");
                }
            }
            public static void RowsAintZeroValue(int[,] matrix)
            {
                int countzero = 0, rowsaintzero = matrix.GetLength(0);
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 0) { countzero++; j = matrix.GetLength(1); }
                    }
                }
                rowsaintzero = rowsaintzero - countzero;
                Console.WriteLine($"{vision}");
                Console.WriteLine($"Task_03\n-->{rowsaintzero,3}");
                Console.WriteLine($"{vision}");
            }
            public static void ColumZeroValue(int[,] matrix)
            {
                int countzero = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] == 0) { countzero++; i = matrix.GetLength(0); }
                    }
                }
                Console.WriteLine($"{vision}");
                Console.WriteLine($"Task_04\n-->{countzero,3}");
                Console.WriteLine($"{vision}");
            }
            public static void NumberRowsWithMaxSeriesValue(int[,] matrix)
            {
                int rowsIndx = -1, maxseries = 1, trash = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int series = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        for (int k = j; k < matrix.GetLength(1); k++)
                        {
                            if (matrix[i, j] == matrix[i, k]) { series++; }
                            if (series > maxseries && series >= 2)
                            {
                                rowsIndx = i;
                                maxseries = series;
                                trash++;
                            }
                        }
                    }
                }
                if (trash == 0)
                {
                    Console.WriteLine($"{vision}");
                    Console.WriteLine("Task_05\n-->Ain't found");
                    Console.WriteLine($"{vision}");
                }
                else if (trash > 0)
                {
                    Console.WriteLine($"{vision}");
                    Console.WriteLine($"Task_05\n-->{rowsIndx,3}");
                    Console.WriteLine($"{vision}");
                }
            }
            public static void ProductValueINRowsAintNegativeValue(int[,] matrix)
            {
                int product = 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int rows = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            rows++;
                            break;
                        }
                    }
                    if (rows == 0)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            product *= matrix[i, k];
                        }
                    }
                }
                if (product == 1)
                {
                    Console.WriteLine($"{vision}");
                    Console.WriteLine($"Task_06\n-->Ain't found");
                    Console.WriteLine($"{vision}");
                }
                else
                {
                    Console.WriteLine($"{vision}");
                    Console.WriteLine($"Task_06\n-->{product,3}");
                    Console.WriteLine($"{vision}");
                }
            }
            public static void MaxSumMainDiagonals(int[,] matrix)
            {
                int max = matrix.GetLength(0), min = -matrix.GetLength(1) + 1;
                int summa = 0, k = 0;
                int[] array = new int[matrix.GetLength(0) * matrix.GetLength(1)];

                for (int l = min; l < max; l++)
                {
                    summa = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (i - j == l)
                            {
                                summa += matrix[i, j];
                            }
                        }
                    }
                    array[k] = summa;
                    k++;
                }

                max = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > max)
                        max = array[i];
                }
                Console.WriteLine($"{vision}");
                Console.WriteLine($"Task_07\n-->{max,3}");
                Console.WriteLine($"{vision}");
            }
            public static void SummaValueINRowsAintNegativeValue(int[,] matrix)
            {
                int summa = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int colums = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            colums++;
                            break;
                        }
                    }
                    if (colums == 0)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            summa += matrix[k, j];
                        }
                    }
                }
                if (summa == 0)
                {
                    Console.WriteLine($"{vision}");
                    Console.WriteLine($"Task_08\n-->Ain't found");
                    Console.WriteLine($"{vision}");
                }
                else
                {
                    Console.WriteLine($"{vision}");
                    Console.WriteLine($"Task_08\n-->{summa,3}");
                    Console.WriteLine($"{vision}");
                }
            }
            public static void MinSumMainDiagonals(int[,] matrix)
            {
                int max = matrix.GetLength(0) + matrix.GetLength(1) - 1;
                int summa = 0, k = 0, min = 0;
                int[] array = new int[matrix.GetLength(0) * matrix.GetLength(1)];

                for (int l = min; l < max; l++)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (i + j == l)
                            {
                                summa += Math.Abs(matrix[i, j]);
                            }
                        }
                    }
                    array[k] = summa;
                    k++;
                    summa = 0;
                }
                min = array[0];
                for (int i = 0; i < k - 1; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                    if (min > matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1])
                    {
                        min = Math.Abs(matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);
                    }
                }
                Console.WriteLine($"{vision}");
                Console.WriteLine($"Task_09\n-->{min,3}");
                Console.WriteLine($"{vision}");
            }
            public static void SummaValueInColumWithNegativeElement(int[,] matrix)
            {
                int summa = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bool negetivecount = false;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negetivecount = true;
                            break;
                        }
                    }
                    if (negetivecount)
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            summa += matrix[i, j];
                        }
                    }
                }
                Console.WriteLine($"{vision}");
                Console.WriteLine($"Task_10\n-->{summa,3}");
                Console.WriteLine($"{vision}");
            }
                
            public static void TransposedMatrix(int[,] matrix)
            {
                int[,] array = new int[matrix.GetLength(1), matrix.GetLength(0)];

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        array[i, j] = matrix[j, i];
                    }
                }
                Console.WriteLine($"{vision}");
                Console.WriteLine($"Task_11\n-->");
                DisplayMatrix(array);
                Console.WriteLine($"{vision}");
            }
        }
    }
}
