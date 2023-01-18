// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        int rowCount, colCount;
        Console.WriteLine("Row Count: ");
        rowCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Columns Count: ");
        colCount = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rowCount, colCount];
        Random r = new Random();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = r.Next(-5, 15);
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        //кількість додатних елементів
        int positiveCount = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)

            for (int j = 0; j < matrix.GetLength(1); j++)

            {
                matrix[i, j] = r.Next(-5, 15);

                if (matrix[i, j] > 0)
                {
                    positiveCount++;
                }
            }
        Console.WriteLine($"Positive Count = {positiveCount}");
        //максимальне із чисел, що зустрічається в заданій матриці більше одного разу
        int currentMax = int.MinValue;
        int maxValue = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (currentMax < matrix[i, j])
                {
                    maxValue = matrix[i, j];
                    int count = -1;
                    for (int l = 0; l < rowCount; l++)
                        for (int k = 0; k < colCount; k++)
                            if (maxValue == matrix[l, k]) count++;
                    if (count > 0) currentMax = maxValue;
                }

        if (currentMax != int.MinValue)
            Console.WriteLine($"Maximum number that occurs more than one time:" + currentMax);

        else Console.WriteLine($"There is no such maximum number ");

        //кількість рядків, які не містять жодного нульового елемента;
        int zero = 1;
        int h = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                    zero = 0;
            }
            h += zero;
            zero = 1;
        }
        Console.WriteLine($"Number of rows that do not contain any zero element:" + h);
        //кількість стовпців, які містять хоча б один нульовий елемент;

        int oneZeroElement = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    oneZeroElement++;
                    break;
                }
            }
        }
        Console.WriteLine($"Column that contains at least one zero element = {oneZeroElement}");

        //номер рядка, в якому знаходиться найдовша серія однакових елементів;
        int mostRepNumb = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)

        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (dict.ContainsKey(matrix[i, j]))
                        dict[matrix[i, j]]++;

                    else
                        dict[matrix[i, j]] = 1;
                }
                for (int k = 0; k < dict.Count; k++)
                {
                    if (dict[matrix[i, k]] != 1)
                        mostRepNumb = i;
                }
            }
            if (mostRepNumb == 0)
                Console.WriteLine($"There is no rows number with the longest series of identical elements");
            else
                Console.WriteLine($"Rows number with the longest series of identical elements = {mostRepNumb}");
        }
        //добуток елементів в тих рядках, які не містять від’ємних елементів
        
        for (int i = 0; i < rowCount; ++i)
        {
            int result = 1; 
            bool b = false;
            for (int j = 0; j < colCount; ++j)
            {
                
                if (matrix[i, j] >= 0 && !b)
                    result *= matrix[i, j];
                else b = true;

            }
            
                if (!b)
                    Console.WriteLine($"The product of elements in those rows that do not contain negative elements -> {0}", result);
            
        }
            //максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці
            static int ListMax(ArrayList list)
            {
                int result = (int)list[0];
                for (int i = 1; i < list.Count; i++)
                    if ((int)list[i] > result)
                        result = (int)list[i];
                return result;
            }

            ArrayList list = new ArrayList();

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                int sum1 = 0, sum2 = 0;
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    sum1 += matrix[j - i - 1, j];
                    sum2 += matrix[j, j - i - 1];
                }
                list.Add(sum1);
                list.Add(sum2);
            }
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                sum += matrix[i, i];
            list.Add(sum);

            Console.WriteLine("\n Maximum among the sums of diagonal elements parallel to the main diagonal of the matrix: " + ListMax(list));
            //суму елементів в тих стовпцях, які не містять від’ємних елементів;
            int positiveSum = 0;
            for (int i = 0; i < rowCount; i++)
            {
                sum = 0;
                for (int j = 0; j < colCount; j++)
                {
                    if (matrix[i, j] >= 0)
                        positiveSum += matrix[i, j];
                    else
                    {
                        positiveSum = 0;
                        break;
                    }
                }
                if (positiveSum != 0)
                    Console.WriteLine("\n Sum of column elements № {0} = {1}", i + 1, positiveSum);
            }
            //мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці
            int s1 = 0;
            int s2 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (i == 0) s1 += Math.Abs(matrix[i, matrix.GetLength(0) - i - 2]);
                else
                if (i == matrix.GetLength(0) - 1) s2 += Math.Abs(matrix[i, matrix.GetLength(0) - i]);
                else
                {
                    s1 += Math.Abs(matrix[i, matrix.GetLength(0) - i - 2]);
                    s2 += Math.Abs(matrix[i, matrix.GetLength(0) - i]);
                }
            Console.WriteLine($"Minimum among the sums of the modules of the elements of the diagonals: {s1}, {s2}");
            //суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент
            int sumNegativeColumns = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {

                    if (matrix[i, j] < 0)
                    {
                        for (int k = 0; k < colCount; k++)
                        { sumNegativeColumns += matrix[k, i]; }
                        j = colCount;

                    }
                }
            }
            Console.WriteLine("Sum of elements in columns with at least one negative element: " + sumNegativeColumns);
            //транспонована матриця
            int[,] transposedMatrix = new int[rowCount, colCount];
            Console.WriteLine();
            Console.WriteLine($"Transposed Matrix: ");
            Console.WriteLine();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    transposedMatrix[i, j] = matrix[j, i];
                    Console.Write(transposedMatrix[i, j] + " \t ");

                    if (j == colCount - 1)
                        Console.WriteLine();
                }
            }

            Console.ReadKey();
        }

}

        



    

