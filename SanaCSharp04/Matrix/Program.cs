using System.Text;
using System;
using Matrix;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

int n, m;

Console.Write("n: ");
n = Convert.ToInt32(Console.ReadLine());

Console.Write("m: ");
m = Convert.ToInt32(Console.ReadLine());

int[,] Array = new int[n, m];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)

    {
        Console.Write("[" + (i + 1) + "][" + (j + 1) + "]: ");
        Array[i, j] = Convert.ToInt32(Console.ReadLine());
    }
}
MatrixFunctions.PrintMatrix(Array);
Console.WriteLine("Кількість додатних елементів: " + MatrixFunctions.NumberOfPositiveElements(Array));
Console.WriteLine("Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: " + MatrixFunctions.MaxNumberOccursMoreThanOnce(Array));
Console.WriteLine("Кількість рядків, які не містять жодного нульового елемента: " + MatrixFunctions.NumberOfRowsDoNotWithoutZeros(Array));
Console.WriteLine("Кількість стовпців, які містять хоча б один нульовий елемент: " + MatrixFunctions.NumberOfColumnsWithZeroes(Array));
Console.WriteLine("Номер рядка, в якому знаходиться найдовша серія однакових елементів: " + MatrixFunctions.FindLongestSeriesRows(Array));
Console.WriteLine("Добуток елементів в тих рядках, які не містять від’ємних елементів: " + MatrixFunctions.MultiplicationOfPositiveElementsInRows(Array));
Console.WriteLine("Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: " + MatrixFunctions.MaxSumOfElementsInDiagonals(Array));
Console.WriteLine("Суму елементів в тих стовпцях, які не містять від’ємних елементів: " + MatrixFunctions.SumOfElementsInColumnsWithoutNegatives(Array));
Console.WriteLine("Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: " + MatrixFunctions.MinSumOfAbsoluteValuesInDiagonals(Array));
Console.WriteLine("Суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: " + MatrixFunctions.SumOfElementsInColumnsWithNegatives(Array));
Console.WriteLine("\nТранспонована матриця");
int[,] ArrayTranspose = MatrixFunctions.TransposeMatrix(Array);
MatrixFunctions.PrintMatrix(ArrayTranspose);
Console.Read();
