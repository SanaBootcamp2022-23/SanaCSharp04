using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Matrix
{
    public class MatrixFunctions
    {
        public static void Print(int[,] arr)
        {
            for(int i=0; i<arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i,j], 5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
        }
        public static int PositiveElements(int[,] arr)
        {
            int AmountPosNumbers=0;
            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > 0)
                    {
                        AmountPosNumbers++;
                    }   
                }
            }
            return AmountPosNumbers;
        }
        public static void MaxElWithStreak(int[,] arr)
        {
            int[,] arr_clone = new int[arr.GetLength(0), arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr_clone[i, j] = arr[i, j];
                }
            }


            int max = 0, iteration = 0;
            bool flag = false;
            do
            {
                max = arr_clone[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (max < arr_clone[i, j]) max = arr_clone[i, j];
                    }
                }

                iteration = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr_clone[i, j] == max) iteration++;
                    }
                }

                if (iteration > 1) flag = true;
                else
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (arr_clone[i, j] == max) arr_clone[i, j] = int.MinValue;
                        }
                    }
                }

            } while (!flag);
            int res = max;
            if (res == int.MinValue) Console.WriteLine("\nThere is no max number that occurs in the given matrix more than once");
            else Console.WriteLine($"\nMax number that occurs in the given matrix more than once = {res}");
            Console.WriteLine("");
        }
        public static void RowsWithoutZero(int[,] arr)
        {
            int NotZeroElementsAmount = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int NotZeroElements = 0;

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != 0)
                    {
                        NotZeroElements++;
                    }
                }
                if(NotZeroElements== arr.GetLength(1))
                {
                    NotZeroElementsAmount++;
                }
            }

            Console.WriteLine($"Amount of rows without zero = {NotZeroElementsAmount}");
            Console.WriteLine("");

        }
        public static void ColumnsWithZero(int[,] arr) 
        {
            int ZeroElements = 0;
            int ZeroElementsAmount = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, j] == 0)
                    {
                        ZeroElements++;
                        break;
                    }
                }
            }

            Console.WriteLine($"Amount of columns with zero = {ZeroElements}");
            Console.WriteLine("");

        }
        public static void MaxValueStreak(int[,] arr)
        {
            int max_streak = 0;
            int max_streak_clone = 0;
            int row_number = 0;
            for(int i=0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    max_streak = 0;
                    int j_clone = j+1;
                    
                    while (j_clone < arr.GetLength(1))
                    {
                        if (arr[i,j] == arr[i,j_clone])
                        {
                            max_streak++;
                        }
                        j_clone++;
                    }
                    if (max_streak > max_streak_clone)
                    {
                        max_streak_clone = max_streak+1;
                        row_number = i;
                    }
                }

            }
            Console.WriteLine($"Max streak of same {max_streak_clone} elements have a {row_number} row ");
            Console.WriteLine("");


        }
        public static void MultWithoutNegElRow(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int MultRes = 1;
                int row_number = 0;
                int NegExist = 1;

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    MultRes *= arr[i, j];
                    if (arr[i, j] < 0)
                    {
                        NegExist--;
                        continue;
                    }
                }

                if (NegExist == 1)
                {
                    row_number = i;
                    Console.WriteLine($"Multiplication result of {row_number} row that without negative elements is {MultRes}");
                }

            }
            Console.WriteLine("");

        }
        public static void MaxDiagSummMain(int[,] arr)
        {
            int MaxSumm = 0;
            for(int i =1; i < arr.GetLength(0); i++)
            {
                int coordRow = i, coordCol = 0;
                int DiagSumm = 0;
                for(int k =0; k < arr.GetLength(0) - i; k++)
                {
                    DiagSumm+=arr[coordRow, coordCol];
                    coordCol++;
                    coordRow++;
                }
                if (DiagSumm > MaxSumm)
                {
                    MaxSumm = DiagSumm;
                }
            }
            for (int j = 1; j < arr.GetLength(1); j++)
            {
                int coordRow = 0, coordCol = j;
                int DiagSumm = 0;
                for (int k = 0; k < arr.GetLength(1) - j; k++)
                {
                    DiagSumm += arr[coordRow, coordCol];
                    coordCol++;
                    coordRow++;
                }
                if (DiagSumm > MaxSumm)
                {
                    MaxSumm = DiagSumm;
                }
            }
            Console.WriteLine($"Max summ of diagonal elements, which are parallel to the main diagonal, except main diagonal, is {MaxSumm}");
            Console.WriteLine("");

        }
        public static void SummWithoutNegElCol(int[,] arr)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                int MultRes = 0;
                int row_number = 0;
                int NegExist = 1;

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    MultRes += arr[i, j];
                    if (arr[i, j] < 0)
                    {
                        NegExist--;
                        continue;
                    }
                }

                if (NegExist == 1)
                {
                    row_number = j;
                    Console.WriteLine($"Summ result of {row_number} column that without negative elements is {MultRes}");
                }

            }
            Console.WriteLine("");

        }
        public static void MinDiagSummSide(int[,] arr)
        {
            int MinSumm = int.MaxValue;
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                int coordRow = i, coordCol = arr.GetLength(1)-1;
                int DiagSumm = 0;
                for (int k = 0; k < arr.GetLength(0) - i; k++)
                {
                    DiagSumm += Abs(arr[coordRow, coordCol]);
                    coordCol--;
                    coordRow++;
                }
                if (DiagSumm < MinSumm)
                {
                    MinSumm = DiagSumm;
                }
            }
            int n = 1;
            for (int j = arr.GetLength(1)-2; j > -1; j--)
            {
                int coordRow = 0, coordCol = j;
                int DiagSumm = 0;
                
                for (int k = 0; k < arr.GetLength(1) - n; k++)
                {
                    DiagSumm += Abs(arr[coordRow, coordCol]);

                    coordCol--;
                    coordRow++;
                    
                }
                n++;
                if (DiagSumm < MinSumm)
                {
                    MinSumm = DiagSumm;
                }
            }
            Console.WriteLine($"Min absolute summ of diagonal elements, which are parallel to the side diagonal, except side diagonal, is {MinSumm}");
            Console.WriteLine("");

        }
        public static void SummWithNegElCol(int[,] arr)
        {
            for(int j=0; j<arr.GetLength(1);j++)
            {
                int NegElExist =0;
                int Summ = 0;
                int Col = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, j] < 0)
                    {
                        NegElExist++;
                    }
                }
                if (NegElExist > 0)
                {
                    Col = j+1;
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        Summ+=arr[i, j];
                    }
                    Console.WriteLine($"Summ of {Col} column with negative elements = {Summ}");
                }
            }
            Console.WriteLine("");

        }
        public static void Transpose(int[,] arr)
        {
            int[,] arr_clone = new int[arr.GetLength(1), arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr_clone[j,i] = arr[i,j];
                }
            }
            Console.WriteLine("Transposed matrix");
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write($"{arr_clone[i, j],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");

        }

    }

}
