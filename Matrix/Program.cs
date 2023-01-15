using System;
using System.Collections.Generic;

namespace Matrix;
public class Program {
    public static void Main(string[] args) {
        Console.Write("Enter N (rows count): ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter M (cols count): ");
        int M = int.Parse(Console.ReadLine());

        int[,] matrix = MatrixUtils.GenerateRandomMatrix(N, M, -3, 10);
        Console.WriteLine(MatrixUtils.StringRepresentation(matrix));

        int positivesCount = MatrixUtils.PositivesCount(matrix);
        Console.WriteLine($"1. Matrix has {positivesCount} positive elements");

        int maxNotSingleElement;
        try {
            maxNotSingleElement = MatrixUtils.MaxNotSingleElement(matrix);
            Console.WriteLine($"2. Max not single element is {maxNotSingleElement}");
        } catch (InvalidOperationException) {
            Console.WriteLine("2. Matrix contains only distinct elements");
        }

        int rowsWithoutZerosCount = MatrixUtils.RowsWithoutZerosCount(matrix);
        Console.WriteLine($"3. Matrix has {rowsWithoutZerosCount} rows without zeros");

        int columnsWithZerosCount = MatrixUtils.ColumnsWithZerosCount(matrix);
        Console.WriteLine($"4. Matrix has {columnsWithZerosCount} columns with zeros");

        int rowWithLongestContiniusSeries = MatrixUtils.RowWithLongestContiniusSeries(matrix);
        Console.WriteLine($"5. Row {rowWithLongestContiniusSeries} (zero based)" + 
                " has the longest continius series of elements");

        Dictionary<int, int> rowsProducts = MatrixUtils.ProductsOfPositiveRows(matrix);
        Console.WriteLine("6. Products of rows without negative elements (rowIndex -> product)");
        if (rowsProducts.Count == 0)
            Console.WriteLine("    ...Empty");
        foreach (KeyValuePair<int, int> rowProduct in rowsProducts) {
            Console.WriteLine($"    {rowProduct.Key} -> {rowProduct.Value}");
        }

        int maxSumOfMainDiagonal = MatrixUtils.MaxSumMainDiagonal(matrix);
        Console.WriteLine($"7. Max sum of diagonal that is parallel to main is {maxSumOfMainDiagonal}");

        Dictionary<int, int> colsSums = MatrixUtils.SumOfPositiveCols(matrix);
        Console.WriteLine("8. Sums of cols without negative elements (colIndex -> sum)");
        if (colsSums.Count == 0)
            Console.WriteLine("    ...Empty");
        foreach (KeyValuePair<int, int> colSum in colsSums) {
            Console.WriteLine($"    {colSum.Key} -> {colSum.Value}");
        }

        int minSumOfAntidiagonalAbs = MatrixUtils.MinSumAbsAntidiagonal(matrix);
        Console.WriteLine("9. Min sum of diagonal's absolute values that is" + 
                $" parallel to antidiagonal is {minSumOfAntidiagonalAbs}");

        Dictionary<int, int> negativeColsSums = MatrixUtils.SumOfNegativeCols(matrix);
        Console.WriteLine("10. Sums of cols with negative elements (colIndex -> sum)");
        if (negativeColsSums.Count == 0)
            Console.WriteLine("    ...Empty");
        foreach (KeyValuePair<int, int> colSum in negativeColsSums) {
            Console.WriteLine($"    {colSum.Key} -> {colSum.Value}");
        }

        int[,] transposedMatrix = MatrixUtils.TransposeMatrix(matrix);
        Console.WriteLine("11. Tranposed matrix: ");
        Console.WriteLine(MatrixUtils.StringRepresentation(transposedMatrix));
    }
}
