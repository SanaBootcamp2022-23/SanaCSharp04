using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {

            uint rowCount, colCount;
            Console.WriteLine("Row Count:");
            rowCount = uint.Parse(Console.ReadLine());
            Console.WriteLine("Columns Count:");
            colCount = uint.Parse(Console.ReadLine());
            Console.WriteLine();
            int[,] matrix = new int[rowCount, colCount];
            Random random = new Random();

            uint positiveElements = 0;
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            int rowsWithoutZero = 0;
            int colsWithZero = 0;
            int numberOfElements = height * width;
            int[] array = new int[numberOfElements];
            int element = 0;
            int maxElement = 0;
            int[,] tranponedMatrix = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrix[y, x] = random.Next(0, 9);
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    array[element++] = matrix[y, x];
                }
            }

            var groups = array.GroupBy(x => x);
            bool noDuplicates = true;

            foreach (var group in groups)
            {
                if (group.Count() > 1)
                {
                    noDuplicates = false;
                    continue;
                }
            }

            foreach (var group in groups)
            {
                if (group.Count() > 1 && group.Key > maxElement)
                    maxElement = group.Key;
            }
            string maxElementResult = !noDuplicates ? $"The maximum element among duplicates ={maxElement}" : "There is no duplicates in the matrix";

            for (int y = 0; y < height; y++)
            {
                bool isRowsWithZero = false;
                for (int x = 0; x < width; x++)
                {
                    if (matrix[y, x] == 0)
                    {
                        isRowsWithZero = true;
                        break;
                    }
;
                }
                if (!isRowsWithZero)
                    rowsWithoutZero++;
            }

            for (int x = 0; x < width; x++)
            {
                bool isColsWithZero = false;
                for (int y = 0; y < height; y++)
                {
                    if (matrix[y, x] == 0)
                    {
                        isColsWithZero = true;
                        break;
                    }
;
                }
                if (isColsWithZero)
                    colsWithZero++;
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (matrix[y, x] > 0)
                        positiveElements++;
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write($"{matrix[y, x]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Transponed matrix: ");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tranponedMatrix[j, i] = matrix[i, j];
                }
            }

            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    Console.Write($"{tranponedMatrix[y, x]}\t");
                }
                Console.WriteLine();
            }

            int k = 0;
            for (int y = 0; y < height; y++)
            {
                bool isNegativeElement = false;
                int[] tempArray = new int[height];
                int sumOfRow = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (k == j)
                        {
                            tempArray[i] = (matrix[i, j]);
                            if (matrix[i, j] < 0)
                            {
                                isNegativeElement = true;
                                break;
                            }
                        }
                    }
                }
                if (!isNegativeElement)
                {
                    for (int t = 0; t < tempArray.Length; t++)
                        sumOfRow += tempArray[t];
                    Console.WriteLine("The sum of elements in a column {0} that doesn`t contain negative elements = {1}", k + 1, sumOfRow);
                }
                sumOfRow = 0;
                k++;
            }

            int m = 0;
            for (int y = 0; y < height; y++)
            {
                bool isNegativeElement = false;
                int[] tempArray = new int[height];
                int sumOfColWithNegative = 0;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (m == j)
                        {
                            tempArray[i] = (matrix[i, j]);
                            if (matrix[i, j] < 0)
                            {
                                isNegativeElement = true;
                            }
                        }
                    }
                }
                if (isNegativeElement)
                {
                    for (int t = 0; t < tempArray.Length; t++)
                        sumOfColWithNegative += tempArray[t];
                    Console.WriteLine("The sum of elements in a column {0} that contains at least one negative elements = {1}", m + 1, sumOfColWithNegative);
                }
                sumOfColWithNegative = 0;
                m++;
            }

            int row = 0;
            for (int y = 0; y < width; y++)
            {
                bool isNegativeElement = false;
                int[] tempArray = new int[width];
                int productOfRowWithoutNegative = 1;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (row == i)
                        {
                            tempArray[j] = (matrix[i, j]);
                            if (matrix[i, j] < 0)
                            {
                                isNegativeElement = true;
                                break;
                            }
                        }
                    }
                    if (!isNegativeElement && row == i)
                    {
                        for (int t = 0; t < tempArray.Length; t++)
                            productOfRowWithoutNegative = tempArray[t] * productOfRowWithoutNegative;
                        Console.WriteLine("The product of elements in a row {0} that doesn`t contain negative elements = {1}", row + 1, productOfRowWithoutNegative);
                    }
                }
                productOfRowWithoutNegative = 0;
                row++;
            }

            int maxSum = 0;
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {

                int coordRow, coordCol;
                Console.WriteLine("Sum of elements in diagonals: ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    coordRow = 0;
                    coordCol = j;
                    int sum = 0;
                    for (int s = 0; s < matrix.GetLength(0) - j; s++)
                    {
                        sum += matrix[coordRow, coordCol];
                        coordRow++;
                        coordCol++;
                    }
                    Console.WriteLine($"* {sum}");
                }
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    coordRow = i;
                    coordCol = 0;
                    int sum = 0;
                    for (int s = 0; s < matrix.GetLength(1) - i; s++)
                    {
                        sum += matrix[coordRow, coordCol];
                        coordRow++;
                        coordCol++;
                    }
                    Console.WriteLine($"* {sum}");
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                    }
                }               
            }




            Console.WriteLine($"Max sum of elements in diagonals ={maxSum}");
            Console.WriteLine($"The amount of positive elements ={positiveElements}");
            Console.WriteLine($"The rows without zero element ={rowsWithoutZero}");
            Console.WriteLine($"The columns with zero element ={colsWithZero}");
            Console.WriteLine(maxElementResult);

        }


    }
}
