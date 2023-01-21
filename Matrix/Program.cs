using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Reflection;

uint rowCount, colCount;
int maxValue = int.MinValue,  cordRow, cordCol; ;
Console.Write("Row count: ");
rowCount = uint.Parse(Console.ReadLine());
Console.Write("Columb count: ");
colCount = uint.Parse(Console.ReadLine());
int[,] matrix  = new int[rowCount,colCount];
Random random = new Random();
for(int n = 0; n < matrix.GetLength(0); n++)
{
    for (int m = 0; m < matrix.GetLength(1); m++)
    {
       matrix[n,m] = random.Next(-5,5);
    }
}
Console.WriteLine("Your matrix:");
for (int n = 0; n < matrix.GetLength(0); n++) //виведення матриці
{
    for (int m = 0; m < matrix.GetLength(1); m++) 
    { 
        Console.Write($"{matrix[n,m]}\t");
    }
    Console.WriteLine();
}
Task1.PositiveElements(matrix);
Task2.MaxElements(matrix);
Task3.NoZeroRow(matrix);
Task4.ZeroColumbs(matrix);
Task5.LongElements(matrix);
Task6.NoNegativeRows(matrix);
Task7.SumMax(matrix);
Task8.NoNegativeColumbs(matrix);
Task9.SumMin(matrix);
Task10.NegativeElementsColumbs(matrix);
Task11.TransportMatrix(matrix);
