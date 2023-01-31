using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    //методи для роботи з двовимірними матрицями
    public class MatrixActions
    {
        //генерування матриці
        public static int[,] GenerateMatrixRandomValues(uint rowCount, uint colCount)
        {
            int[,] matrix = new int[rowCount, colCount];
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(-1, 5);
            return matrix;
        }
        //вивід матриці в консоль
        public static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j], 10}");
                Console.WriteLine();
            }
        }
        //1-кількість додатніх елементів матриці
        public static int CountOfPositiveElement(int[,] matrix)
        {   
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0)
                        count++;
            }
            return count;
        }
        //2-максимальне число яке повторюється
        public static int MaxRepeatValue(int[,] matrix)
        {
            int[] toArray = new int[matrix.GetLength(0) * matrix.GetLength(1)];
            int k = 0;
            //перетворення двувимірного масиву в одновимірний для простішого пошуку елементу
            for (int i=0; i<matrix.GetLength(0); i++)
                for(int j=0; j<matrix.GetLength(1); j++) {
                    toArray[k] = matrix[i, j];
                    k++;
                }
            //знаходження елементів які повторюються
            int[] repeatValue = new int[toArray.GetLength(0)];
            for (int x = 0; x < toArray.GetLength(0); x++)
                for (int y = x + 1; y < toArray.GetLength(0); y++)
                    if (toArray[x] == toArray[y])
                        repeatValue[x] = toArray[y];

            return repeatValue.Max();
        }

        //3-кількість рядків без нульового елемента
        public static int CountRowWithoutZero(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        break;
                    if (j + 1 == matrix.GetLength(1))
                        count++;
                }
            return count;
        }
        //4-кількість стовпців з нульовим елементом
        public static int CountColWithZero(int[,] matrix)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i, j] == 0)
                    {
                        count++;
                        break;
                    }
            return count;
        }

        //5-Номер рядка, в якому знаходиться найдовша серія однакових елементів
        public static int RowNumberMaxRepeatElement(int[,] matrix)
        {
            int rowIndex = int.MinValue, countEqual = 0, countMaxEqual = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                        countEqual++;

                    if (countMaxEqual < countEqual)
                    {
                        countMaxEqual = countEqual;
                        rowIndex = i+1;
                    }
                    else
                        countEqual = 1;
                }
            return rowIndex;
        }


        //6-добуток елемнтів рядку в яких відсутні відємні елементи
        public static void MultColWithoutNegativeElement(int[,] matrix)
        {
            int rowMult = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] >= 0)
                        rowMult *= matrix[i, j];
                    else
                    {
                        rowMult = 1;
                        break;
                    }

                    if (j == matrix.GetLength(1) - 1)
                        Console.WriteLine($"\tРядок {i + 1} з добутком {rowMult}");
                }
        }

        //7-Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриц(тільки для квадтратни матриць)
        public static int MaxSumParallelMainDiagonal(int[,] matrix)
        {
            int[] upperSum = new int[matrix.GetLength(0) + matrix.GetLength(1)];
            int[] lowwerSum = new int[matrix.GetLength(0) + matrix.GetLength(1)];
            int coordRow, coordCol;
            for (int j = 1; j < matrix.GetLength(0); j++)
            {
                int sum = 0;
                coordRow = 0;
                coordCol = j;
                for (int k = 0; k < matrix.GetLength(1) - j; k++)
                {
                    sum += matrix[coordRow, coordCol];
                    coordCol++;
                    coordRow++;
                }
                upperSum[j - 1] = sum;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                coordRow = i;
                coordCol = 0;
                for (int k = 0; k < matrix.GetLength(1) - i; k++)
                {
                    sum += matrix[coordRow, coordCol];
                    coordCol++;
                    coordRow++;
                }
                lowwerSum[i - 1] = sum;
            }

            return Math.Max(upperSum.Max(), lowwerSum.Max());
        }


        //8-сума стовпців в яких відсутні відємні елементи
        public static void SumColWithoutNegativeElement(int[,] matrix)
        {
            int colSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] >= 0)
                        colSum += matrix[i, j];
                    else
                    {
                        colSum = 0;
                        break;
                    }

                    if (i == matrix.GetLength(0) - 1)
                        Console.WriteLine($"\tСтовпець {j + 1} з сумою {colSum}");
                }
        }

        //9-Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці(тільки для квадратних матриць)
        public static int MinSumParallelSideDiagonal(int[,] matrix)
        {
            int[] upperSum = new int[matrix.GetLength(0)];
            int[] lowwerSum = new int[(matrix.GetLength(0)) - 1];
            int coordRow, coordCol;
            for (int j = matrix.GetLength(1) - 1, i = 0; j >= 0; j--, i++)
            {
                int sum = 0;
                coordRow = 0;
                coordCol = j;
                for (int k = 0; k < matrix.GetLength(0) - i; k++)
                {
                    sum += Math.Abs(matrix[coordRow, coordCol]);
                    coordRow++;
                    coordCol--;
                }
                upperSum[i] = sum;
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                coordRow = i;
                coordCol = matrix.GetLength(1) - 1;
                for (int k = 0; k < matrix.GetLength(1) - i; k++)
                {
                    sum += Math.Abs(matrix[coordRow, coordCol]);
                    coordRow++;
                    coordCol--;
                }

                lowwerSum[i - 1] = sum;
            }
            return Math.Min(upperSum.Min(), lowwerSum.Min());
        }

        //10-сума стовпців в яких є відємні елементи
        public static void SumColWithNegativeElement(int[,] matrix)
        {
            int count = 0;
            int colSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                        colSum += matrix[i, j];
                    }
                    else
                        colSum += matrix[i, j];

                    if (count != 0 && i == matrix.GetLength(0) - 1)
                        Console.WriteLine($"\tСтовпець {j + 1} з сумою {colSum}");
                }
        }

        //11-транспонована матриця
        public static void TrasposedMatrix(int[,] matrix)
        {
            int[,] transpMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    transpMatrix[j,i] = matrix[i, j];
            
            DisplayMatrix(transpMatrix);
        }
    }
}
