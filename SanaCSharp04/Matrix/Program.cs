// See https://aka.ms/new-console-template for more information

using Matrix;
using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;

public class MainProg
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        int n, m;

        Console.Write("Кiлькiсть рядкiв: ");
        n = int.Parse(Console.ReadLine());

        Console.Write("Кiлькiсть стовпцiв: ");
        m = int.Parse(Console.ReadLine());

        int[,] matr = MatrixAct.GenerateMatrix(n, m);
        Console.WriteLine($"МАТРИЦЯ:");
        MatrixAct.DisplayMatrix(matr);
 
        countPositiveNums(matr);
        countRepeatedMaxNums(matr);
        nonZeroNumsCounter(matr);
        getColWithZeroNum(matr);
        getInLineNumMaxCount(matr);
        multiplyNonNegativeRows(matr);
        getMaxSumParallelToMainDiagonal(matr);
        getSumOfColumnWithoutNegativeNums(matr);
        getMinSumAbsNotMainDiagonales(matr);
        getSumOfColumnContainsNegative(matr);
        Console.WriteLine("Транспонована матриця: ");
        getTransposeMatr(matr);

    }
    static public void countPositiveNums(int[,] matr)
    {
        int countPositive = 0;

        for (int i = 0; i < matr.GetLength(0); i++)
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                if (matr[i, j] > 0)
                    countPositive++;
            }
        Console.WriteLine($"Додатні числа: {countPositive}");
    }
    static public void countRepeatedMaxNums(int[,] matr)
    {
        int countRepeatedMax = 0;
        int currentMax = int.MinValue;
        int possibleMax = 0;

        for (int i = 0; i < matr.GetLength(0); i++)
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                if (currentMax < matr[i, j])
                {
                    possibleMax = matr[i, j];
                    int count = -1;
                    for (int l = 0; l < matr.GetLength(0); l++)
                        for (int k = 0; k < matr.GetLength(1); k++)
                            if (possibleMax == matr[l, k]) count++;
                    if (count > 0) currentMax = possibleMax;
                }
                if (currentMax != int.MinValue)
                {
                    countRepeatedMax = currentMax;
                }
            }
        Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {countRepeatedMax}");

    }
    static public void nonZeroNumsCounter(int[,] matr)
    {
        int nonZeroCounter = 0;
        bool indikator;
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            indikator = true;
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                if (matr[i, j] == 0)
                    indikator = false;
            }
            if (indikator)
                nonZeroCounter++;
        }
        Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента: {+nonZeroCounter}");
    }
    static public void getColWithZeroNum(int[,] matr)
    {
    int colWithZero = 0;
    bool indikator;
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            indikator = false;
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                if (matr[j, i] == 0)
                    indikator = true;
            }
            if (indikator)
                colWithZero++;
        }
        Console.WriteLine($"Кількість стовпців, які містять хоча б один нульовий елемент: {colWithZero}");
    }
    static public void getInLineNumMaxCount(int[,] matr)
    {
        int lineNumMaxCount = 0;
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matr.GetLength(1) - 1; j++)
            {
                if (matr[i, j] != matr[i, j + 1]) continue;
                count++;
            }
            if (lineNumMaxCount >= count) continue;
            lineNumMaxCount = count;
            lineNumMaxCount = i;
        }
        Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {lineNumMaxCount + 1}");
    }
    static public void multiplyNonNegativeRows(int[,] matr)
    {
        List<int> composition = new List<int>();
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            int mult = 1;
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                if (matr[i, j] > 0)
                {
                    mult *= matr[i, j];
                    if (j == matr.GetLength(0) - 1)
                    {
                        composition.Add(mult);
                        mult = 1;
                    }
                }
                else
                {
                    mult = 1;
                    break;
                }
            }
        }
        Console.WriteLine($"Кількість рядків без від’ємних елементів: {composition.Count}");
        if (composition.Count > 0)
        {
            foreach (var i in composition)
            {
                Console.WriteLine($"   Добуток елементів в рядку, який не містить від’ємних елементів: {i}");
            }
            Console.WriteLine();
        }

    }
    static public void getMaxSumParallelToMainDiagonal(int[,] matr)
    {
        int start, step, sum;
        List<int> listSum = new List<int>();
       
        //початок з правої верхньої діагоналі
        for (int i = 1; i < matr.GetLength(0); i++)
        {
            start = 0;
            step = i;
            sum = 0;
            for (int j = 0; j < matr.GetLength(1) - i; j++)
            {
                sum += matr[start, step];
                start++;
                step++;
            }
            listSum.Add(sum);
        }

        //початок з лівої нижньої діагоналі
        for (int i = 1; i < matr.GetLength(0); i++)
        {
            start = i;
            step = 0;
            sum = 0;
            for (int j = 0; j < matr.GetLength(1) - i; j++)
            {
                sum += matr[start, step];
                start++;
                step++;
            }
            listSum.Add(sum);

        }

        int maxSum = listSum[0];
        for (int i = 0; i < listSum.Count; i++)
        {
            if (listSum[i] > maxSum) 
                maxSum = listSum[i];
        }
        Console.WriteLine($"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {maxSum}");
    }   
    static public void getSumOfColumnWithoutNegativeNums(int[,] matr)
    {
        Console.WriteLine($"Сума елементів в тих стовпцях, які не містять від’ємних елементів:");
        for (int i = 0; i < matr.GetLength(1); i++)
        {
            int sumCol = 0;
            bool indikator = true;
            for (int j = 0; j < matr.GetLength(0); j++)
            {
                if (matr[j, i] < 0)
                {
                    indikator = false;
                    break;
                }
                sumCol += matr[j, i];
            }
            if (indikator)
            {
                Console.WriteLine($"\tСума елементів стовпця {i+1}: {sumCol}");
            }
        }
    }
    static public void getMinSumAbsNotMainDiagonales(int[,] matr)
    {
        //сума діагоналей паралельних побічній починаючи з правого верхньго кутка
        int start, move, sum, step = 1, sideStep = 1;
        List<int> totalList = new List<int>();
        for (int i = matr.GetLength(0) - 1 - 1; i >= 0; i--)
        {
            start = 0;
            move = i;
            sum = 0;
            for (int j = matr.GetLength(1) - 1 - step; j >= 0; j--)
            {
                sum += Math.Abs(matr[start, move]);
                start++;
                move--;
            }
            totalList.Add(sum);
            step++;
        }

        //сума діагоналей паралельних побічній починаюси з лівого нижнього кутка
        for (int i = 1; i < matr.GetLength(0); i++)
        {
            start = matr.GetLength(0) - 1;
            move = i;
            sum = 0;
            for (int j = matr.GetLength(1) - 1 - sideStep; j >= 0; j--)
            {
                sum += Math.Abs(matr[start, move]);
                start--;
                move++;
            }
            totalList.Add(sum);
            sideStep++;
        }

        int min = totalList[0];
        for (int i = 0; i < totalList.Count; i++)
        {
            if (totalList[i] < min) 
                min = totalList[i];
        }
        Console.WriteLine($"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {min}");
    }
    static public void getSumOfColumnContainsNegative(int[,] matr)
    {

        Console.WriteLine($"Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент:");
        for (int i = 0; i < matr.GetLength(1); i++)
        {
            int sumCol = 0;
            bool indikator = false;
            for (int j = 0; j < matr.GetLength(0); j++)
            {
                if (matr[j, i] < 0)
                {
                    indikator = true;
                }
               sumCol += matr[j, i];
            }
            if (indikator)
            {
                Console.WriteLine($"\tСума елементів стовпця {i + 1}: {sumCol}");
            }
        }
        Console.WriteLine($"");
    }
    static public void getTransposeMatr(int[,] matr)
    {
        int t;
        for (int i = 0; i < matr.GetLength(0); ++i)
        {
            for (int j = i; j < matr.GetLength(1); ++j)
            {
                t = matr[i, j];
                matr[i, j] = matr[j, i];
                matr[j, i] = t;
            }
        }
    
        for (int i = 0; i < matr.GetLength(0); i++)
        {
            for (int j = 0; j < matr.GetLength(1); j++)
            {
                Console.Write($"{matr[i, j],5}");
            }
            Console.WriteLine("\n");
        }

    }
}