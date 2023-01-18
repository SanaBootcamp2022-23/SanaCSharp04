using Matrix;
using System.Reflection.Metadata.Ecma335;
using System.Text;

internal class Program
{
    private static int Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        Console.Write("Введіть розміри квадратної матриці: ");
        int size = int.Parse(Console.ReadLine());
        if (size <= 0)
        {
            Console.WriteLine("\nНеправильно введені дані, спробуйте ще раз");
            return 0;
        }
        int[,] matrix = Functions.GenerateMatrix(size, size);
        Functions.PrintMatrix(matrix);
        Functions.posCount(matrix);
        Functions.maxElement(matrix, size, size);
        Functions.countOfRowsWithoutZeroes(matrix);
        Functions.countOfColsWithZeroes(matrix);
        Functions.maxSerieOfElements(matrix);
        Functions.prodOfElementsInRowsWithoutNegElements(matrix);
        Functions.maxOfDiagonales(matrix);
        Functions.sumInRowsWithoutNegElements(matrix);
        Functions.minOfDiagonales(matrix);
        Functions.sumOfElementsInColsWithAtlOneNegElement(matrix);
        Functions.TransponedMatrix(matrix);
        return 0;
    }
}