using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program
{
    class MatrixEdit
    {
        public static void FillingArray(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Random rand = new Random();
                    newArr[i, j] = rand.Next(-2, 10);
                }
            } 
        }
        public static void PrintArray(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,4}", newArr[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static void AmountOfPos(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int counter = 0; 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(newArr[i,j] > 0) 
                    {
                        counter++;
                    }
                }               
            }
            Console.WriteLine($"Amount of positive elements: {counter}");
        }
        public static void MaxOfPares(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int cntr = 0;
            int maxElement = 0;
            bool flag = false;
            do
            {

                maxElement = newArr[0, 0];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        if (maxElement < newArr[i, j])
                            maxElement = newArr[i, j];
                
                cntr = 0;
                for (int i = 0; i < rows; i++) { 
                    for (int j = 0; j < columns; j++) 
                    {
                        if (newArr[i, j] == maxElement)
                            cntr++;
                    }
                }


                if (cntr > 1)
                    flag = true;
                else
                    for (int i = 0; i < rows; i++) 
                    { 
                        for (int j = 0; j < columns; j++)
                            if (newArr[i, j] == maxElement) 
                            { 
                                newArr[i, j] = int.MinValue; 
                            }
                    }

            } while (!flag);
            Console.WriteLine(maxElement);
        }
        public static void RowsWithoutZero (int[,] newArr) 
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int cntr = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++) 
                {
                    if(newArr[i, j] == 0)
                    {
                        cntr++;
                    }         
                }
                if (cntr == 0)
                {
                    Console.WriteLine($"Row {i+1} without zero.");
                }
                cntr = 0;
            }
        }
        public static void ColumnsWithoutZero(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int cntr = 0;
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (newArr[i, j] == 0)
                    {
                        cntr++;
                    }
                }
                if (cntr == 0)
                {
                    Console.WriteLine($"Column {j + 1} without zero.");
                }
                cntr = 0;
            }
        }
        public static void MostReapetedElements(int[,] newArr) 
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int cntr = 1;
            int indexWithMaxElement = 0; 
            int maxElements = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns-1; j++)
                {
                    if (newArr[i,j] == newArr[i,j+1]) 
                    {
                        cntr++;
                        if (cntr > maxElements)
                        {
                            maxElements = cntr;

                            indexWithMaxElement = i;
                        }
                    }
                }
               
                cntr = 1;
            }
            Console.WriteLine($"Row {indexWithMaxElement + 1} in which there is the longest series of identical elements({maxElements})");
        }
        public static void ProductOfRowWithoutNegativElements(int[,] newArr) 
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int ProductOfOneRow = 1;
            int ProductOfAllRows = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(newArr[i, j] < 0) 
                    {
                        ProductOfOneRow = 1;
                        break;
                    }
                    else 
                    {
                        ProductOfOneRow = ProductOfOneRow * newArr[i, j];
                    }                    
                }
                if(ProductOfOneRow != 1) 
                {
                    Console.WriteLine($"Product of element in row {i + 1} without negative elements is {ProductOfOneRow}");
                }
                ProductOfAllRows = ProductOfOneRow * ProductOfAllRows;
                

            }
            if(ProductOfAllRows == 1) 
            {
                Console.WriteLine("We have all rows with negative elements");
            }
            else 
            {
                Console.WriteLine($"Product of element in all rows without negative elements is {ProductOfAllRows}");
            }
            
        }
        public static void MaximumAmongTheSumsOfDiagonal(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int maxSum = 0;

            for (int j = -(rows - 1); j < columns; ++j)
            {
                int currentSum = 0;
                for (int i = 0; i < rows; ++i)
                {
                    if (i >= 0 && i < rows && (j + i) >= 0 && (j + i) < columns)
                        currentSum += newArr[i, j + i];
                }
                if(currentSum > maxSum) 
                {
                    maxSum = currentSum;
                }
                currentSum = 0;
            }
            Console.WriteLine($"Maximum among the sums of diagonals is: {maxSum}");
        }
        public static void MinimumAmongTheSumsOfDiagonal(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int minSum = 0;

            for (int j = -(rows - 1); j < columns; ++j)
            {
                int currentSum = 0;
                for (int i = 0; i < rows; ++i)
                {
                    if (i >= 0 && i < rows && (j + i) >= 0 && (j + i) < columns) 
                    {
                        currentSum += Math.Abs(newArr[i, j + i]);
                    }
                        
 
                }
                if (minSum == 0) 
                {
                    minSum = currentSum;
                }
                if (currentSum < minSum)
                {
                    minSum = currentSum;
                }
                currentSum = 0;
            }
            Console.WriteLine($"Minimum among the sums of diagonals is: {minSum}");
        }
        public static void SumInColumnsWithoutNegativeElements(int[,] newArr) 
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int SumOfOneColumn = 0;
            int SumOfAllColumns = 0;
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (newArr[i, j] < 0)
                    {
                        SumOfOneColumn = 0;
                        break;
                    }
                    else
                    {
                        SumOfOneColumn = SumOfOneColumn + newArr[i, j];
                    }
                }
                if (SumOfOneColumn != 0)
                {
                    Console.WriteLine($"Sum of element in column {j + 1} without negative elements is {SumOfOneColumn}");
                }
                SumOfAllColumns = SumOfOneColumn + SumOfAllColumns;


            }
            if (SumOfAllColumns == 0)
            {
                Console.WriteLine("We have all columns with negative elements");
            }
            else
            {
                Console.WriteLine($"Sum of element in all columns without negative elements is {SumOfAllColumns}");
            }
        }
        public static void SumInColumnsWithNegativeElements(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int count = 0;
            int SumOfOneColumn = 0;
            int SumOfAllColumns = 0;
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    
                    if (newArr[i, j] < 0)
                    {
                        count++;
                    }
                    SumOfOneColumn += newArr[i, j];

                }

                if (count > 0)
                {
                    SumOfAllColumns += SumOfOneColumn;
                    Console.WriteLine($"Sum of element in column {j + 1} with negative elements is {SumOfOneColumn}");
                    count = 0;
                }
                else
                {
                    SumOfOneColumn = 0;
                    count = 0;
                    Console.WriteLine("All elements are positive in this column");
                }
            }
            Console.WriteLine($"Sum of element in all columns without negative elements is {SumOfAllColumns}");
        }
        public static void TransposeTheMatrix(int[,] newArr)
        {
            int rows = newArr.GetLength(0);
            int columns = newArr.GetLength(1);
            int newRows = columns;
            int newColumns = rows;
            int[,] transMatrix = new int[newRows, newColumns];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    transMatrix[i, j] = newArr[j, i];
                }
            }
            Console.WriteLine("Your transponsed matrix:");
            PrintArray(transMatrix);
            
        }
    }
}
