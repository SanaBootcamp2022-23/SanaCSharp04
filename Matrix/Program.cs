using System;
using System.Linq.Expressions;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 0, columns = 0;
            rows = int.Parse(Console.ReadLine());
            columns = int.Parse(Console.ReadLine());
            int[,] arr = new int[rows, columns];
            MatrixEdit.FillingArray(arr);
            Console.WriteLine("Your matrix:");
            MatrixEdit.PrintArray(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.AmountOfPos(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.MaxOfPares(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.RowsWithoutZero(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.ColumnsWithoutZero(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.MostReapetedElements(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.ProductOfRowWithoutNegativElements(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.MaximumAmongTheSumsOfDiagonal(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.SumInColumnsWithoutNegativeElements(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.MinimumAmongTheSumsOfDiagonal(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.SumInColumnsWithNegativeElements(arr);
            Console.WriteLine("------------------------------------------------------------------------");
            MatrixEdit.TransposeTheMatrix(arr);

        }
    }
}

