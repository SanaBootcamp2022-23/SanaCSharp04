using Matrix;
using System.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;


Console.OutputEncoding = UTF8Encoding.UTF8;
uint n, m;

Console.ForegroundColor = ConsoleColor.White;
Console.Write("Кількість рядків(N) - ");
n = uint.Parse(Console.ReadLine());
Console.Write("Кількість стовпців(M) - ");
m = uint.Parse(Console.ReadLine());

int[,] matrix = new int[n, m];
Random random = new Random();
for (uint i = 0; i < matrix.GetLength(0); i++)
{
    for (uint j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-10, 11);
    }
}
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Матриця");
for (uint i = 0; i < matrix.GetLength(0); i++)
{
    for (uint j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]} \t");
    }
    Console.WriteLine();
}
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Yellow;
Tasks.CountPositiveElements(matrix);            //1
Console.ForegroundColor = ConsoleColor.White;
Tasks.MaxRepeatElement(matrix);                 //2
Console.ForegroundColor = ConsoleColor.Yellow;
Tasks.CountRowWithoutZero(matrix);              //3
Console.ForegroundColor = ConsoleColor.White;
Tasks.CountColWithoutZero(matrix);              //4
Console.ForegroundColor = ConsoleColor.Yellow;
Tasks.NumRowMaxSeriesRepeatElement(matrix);     //5
Console.ForegroundColor = ConsoleColor.White;
Tasks.MultiplyElementsRowWithoutZero(matrix);   //6
Console.ForegroundColor = ConsoleColor.Yellow;
Tasks.MaxSumDiagonalParalelMain(matrix);        //7
Console.ForegroundColor = ConsoleColor.White;
Tasks.SumElementsColWithoutNegativ(matrix);     //8
Console.ForegroundColor = ConsoleColor.Yellow;
Tasks.MinSumModulDiagonalParalelSide(matrix);   //9
Console.ForegroundColor = ConsoleColor.White;
Tasks.SumElementsColWithNegativ(matrix);        //10
Console.ForegroundColor= ConsoleColor.Blue;
Tasks.TransparentMatrix(matrix);                //11
Console.ForegroundColor = ConsoleColor.DarkGray;