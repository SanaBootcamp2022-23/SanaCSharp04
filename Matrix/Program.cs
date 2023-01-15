using MyMatrix;
using System;
using System.Text;
using System.Xml.Linq;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;
uint rowCount, colCount;

Console.Write($"Кількість рядків = ");
rowCount = Matrix.MatrixLength();
Console.Write($"Кількість стовпчиків = ");
colCount = Matrix.MatrixLength();
double[,] matrix = Matrix.GenerateMatrix(rowCount, colCount);
Matrix.DisplayMatrix(matrix);
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine($"Кількість додатніх елементів в матриці = {Matrix.CountPositiveElements(matrix)}");
if (Matrix.MaximumNubmerMoreThanOnce(matrix) == -999)
    Console.WriteLine($"Максимальне число, що зустрічається більше одного разу відсутнє");
else
    Console.WriteLine($"Максимальне число, що зустрічається більше одного разу  = {Matrix.MaximumNubmerMoreThanOnce(matrix)}");
Console.WriteLine($"Кількість рядків без нульових елементів = {Matrix.CountRowDontZeroElements(matrix)}");
Console.WriteLine($"Кількість стовбців з нульовими елементами = {Matrix.CountColHaveZeroElements(matrix)}");

if (Matrix.LongDublicateElements(matrix) != -1)
    Console.WriteLine($"Номер рядка з найдовшою серією однакових елементів  = {Matrix.LongDublicateElements(matrix)}");
else
{
    Console.WriteLine($"Серії однакових елементів не існує");
}

Matrix.DobutokElemensRowDontNegativeElements(matrix);
Matrix.MaxSumParalelGeneralDiagonal(matrix);
Matrix.SumElemensColDontNegativeElements(matrix);
Matrix.MinSumParalelSideDiagonal(matrix);
Matrix.SumElemensColHaveNegativeElements(matrix);
double[,] transposedMatrix = Matrix.TransposedMatrix(matrix);
Console.WriteLine($"Транспонована матриця:");
Matrix.DisplayMatrix(transposedMatrix);
Console.ForegroundColor = ConsoleColor.Gray;
