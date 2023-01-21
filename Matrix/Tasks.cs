namespace Matrix
{
using System;
using System.Linq;


    public class Tasks
    {
        public static void CountPositiveElements(int[,] matrix)
        {
            int positiveElements = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        positiveElements++;
                }
            }
            Console.WriteLine($"1- Кількість додатних елементів: {positiveElements}\n");
        } //1
        public static void MaxRepeatElement(int[,] matrix)
        {
            int maxRepeat = 0;
            int[] sort = matrix.Cast<int>().ToArray();

            Array.Sort(sort);
            Array.Reverse(sort);

            for (int i = 0; i < sort.Length; i++)
            {
                if (sort[i] == sort[i + 1])
                {
                    maxRepeat = sort[i + 1];
                    break;
                }
            }
            Console.WriteLine($"2- Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {maxRepeat}\n ");
        }//2
        public static void CountRowWithoutZero(int[,] matrix)
        {
            int countRow = 0, countCol;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                countCol = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        countCol++;
                }
                if (countCol == 0)countRow++;

            }
            Console.WriteLine($"3- Кількість рядків, які не містять жодного нульового елемента: {countRow}\n ");
        }//3
        public static void CountColWithoutZero(int[,] matrix)
        {
            int countCol = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {   
                    if (matrix[j, i] == 0)
                    {
                        countCol++;
   
                    }
                }         
            }
            Console.WriteLine($"4- Кількість стовпців, які містять хоча б один нульовий елемент: {countCol}\n ");
        }//4
        public static void NumRowMaxSeriesRepeatElement(int[,] matrix)
        {
            int count = 0, rowWithMaxRepeat = 0;
            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        count++;
                        if (count > rowWithMaxRepeat)
                        rowWithMaxRepeat = i + 1;
                        else count = 1;
                    }
                }
            }
            Console.WriteLine($"5- Номер рядка, в якому знаходиться найдовша серія однакових елементів: {rowWithMaxRepeat} \n ");
        }//5
        public static void MultiplyElementsRowWithoutZero(int[,] matrix)
        {
            int count = 0;
            Console.WriteLine("6- Добуток елементів в тих рядках, які не містять від’ємних елементів");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int multiply = 1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0) { matrix[i, j] = 1; }
                    else if (matrix[i, j] > 0)
                    {
                        multiply *= matrix[i, j];
                    }
                    else if (matrix[i, j] < 0) { multiply = 1; break; }
                }
                if (multiply != 1)
                {
                    Console.WriteLine($"\tДобуток: {multiply}  -  Рядок: {i + 1}");
                    count++;
                }
            }
            if (count == 0) { Console.WriteLine("\tУсі рядки мають від'ємний елемент\n"); }
            else Console.WriteLine();
        }//6
        public static void MaxSumDiagonalParalelMain(int[,] matrix)
        {
            int max = int.MinValue;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {        
                int sum = 0, coRow = 0, coCol = j;
                for (int k = 0; k < matrix.GetLength(0) - j; k++)
                {
                    sum += matrix[coRow, coCol];
                    coRow++;
                    coCol++;
                }
                if (sum > max) max = sum;
            }
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                int sum = 0, coRow = i, coCol = 0;
                for (int k = 0; k < matrix.GetLength(0) - i; k++)
                {
                    sum += matrix[coRow, coCol];
                    coRow++;
                    coCol++;
                } 
                if (sum > max) max = sum;
            }
            Console.WriteLine($"7- Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {max}\n");
        }//7
        public static void SumElementsColWithoutNegativ(int[,] matrix)
        {
            int count = 0;
            Console.WriteLine("8- Сума елементів в тих стовпцях, які не містять від’ємних елементів");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {   
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                    else if (matrix[i, j] < 0) { sum = 0; break; }
                }
                if (sum != 0)
                {
                    Console.WriteLine($"\tСумма: {sum}  -  Стовпець: {j + 1}");
                    count++;
                }
            }
            if (count == 0) { Console.WriteLine("\tУсі стовпці мають від'ємний елемент\n "); }
            else Console.WriteLine();
        }//8
        public static void MinSumModulDiagonalParalelSide(int[,] matrix)
        {
            Console.WriteLine();
            int cordRow, cordCol, sum = 0, min = int.MaxValue;
            for (int j = matrix.GetLength(1) - 1, i = 0; j >= 0; j--, i++)
            {
                cordRow = 0;
                cordCol = j;
                sum = 0;
                for (int k = 0; k < matrix.GetLength(0) - i; k++)
                {
                    sum += Math.Abs(matrix[cordRow, cordCol]);
                    cordRow++;
                    cordCol--;
                }
                if (sum < min) min = sum;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                cordRow = i;
                cordCol = matrix.GetLength(1) - 1;
                sum = 0;
                for (int k = 0; k < matrix.GetLength(0) - i; k++)
                {
                    sum += Math.Abs(matrix[cordRow, cordCol]);
                    cordRow++;
                    cordCol--;
                }
                if (sum < min) min = sum;
            }
            Console.WriteLine($"9- Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {min}\n");
        }//9
        public static void SumElementsColWithNegativ(int[,] matrix)
        {
            int count = 0, count1 = 0;
            Console.WriteLine("10- Сума елементів в тих стовпцях, які містять хоча б один від’ємний елемент");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {   
                    if (matrix[i, j] < 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine($"\tСумма: {sum}  -  Стовпець: {j + 1}");
                    count1++;
                }
            }
            if (count1 == 0) { Console.WriteLine("\tСтовпці не мають від'ємних елементів!\n"); }
            else Console.WriteLine();
        }//10
        public static void TransparentMatrix(int[,] matrix)
        {
            Console.WriteLine("11- Транспонована матриця ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[j,i]}\t");
                }
                Console.WriteLine();
            }
        }//11
    }
}
