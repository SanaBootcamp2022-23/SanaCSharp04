using System;
using MatrixLibrary;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int n, m;
            Console.WriteLine("Enter n: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter m: ");
            m = int.Parse(Console.ReadLine());
            int[,] arr = MatrixLibrary.Matrix.GenerateMatrix(n,m);
            Console.WriteLine("Matrix:\n");
            MatrixLibrary.Matrix.outPut(arr);
            Console.WriteLine();
            Console.WriteLine($"Positive count: {MatrixLibrary.Matrix.PosotiveCount(arr)}");
            Console.WriteLine($"Row count without zero -> {MatrixLibrary.Matrix.LineCountWithoutZero(arr)}"); 
            Console.WriteLine($"Column count with zero -> {MatrixLibrary.Matrix.ColumnCountWithZero(arr)}");
            Console.WriteLine($"Row multiple without negative -> {MatrixLibrary.Matrix.MultipleRowsWithoutNegative(arr)}");
            Console.WriteLine($"Column sum without negative -> {MatrixLibrary.Matrix.SumColumnsWithoutNegative(arr)}");
            Console.WriteLine($"Column sum with negative -> {MatrixLibrary.Matrix.SumColumnsWithNegative(arr)}");
            //Транспонування
            MatrixLibrary.Matrix.Transposed(arr);
            //максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;
            MatrixLibrary.Matrix.DiagonalMaxParalelToMain(arr);
            //мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці
            MatrixLibrary.Matrix.DiagonalMinParalelToSecond(arr);
            //максимальне із чисел, що зустрічається в заданій матриці більше одного разу;
            MatrixLibrary.Matrix.MaxNumOverOneTime(arr);
            //номер рядка, в якому знаходиться найдовша серія однакових елементів;
            MatrixLibrary.Matrix.NumberRowWithHighestCountOfDublicates(arr);
        }
    }
}
