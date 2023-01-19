using static System.Math;
using Matrix;
using System.Numerics;

Console.WriteLine("Enter amount of rows");
int rowAmount=int.Parse(Console.ReadLine());
Console.WriteLine("Enter amount of columns");
int colAmount =int.Parse(Console.ReadLine());

int[,] arr = new int[rowAmount, colAmount];

Random random = new Random();

for(int i=0; i<rowAmount; i++)
{
    for(int j=0; j<colAmount; j++)
    {
        arr[i, j] = random.Next(-1, 11);
    }
}
Console.ForegroundColor = ConsoleColor.White;
MatrixFunctions.Print(arr);

Console.ForegroundColor = ConsoleColor.DarkMagenta;

Console.WriteLine($"Amount of positive elemnts = {MatrixFunctions.PositiveElements(arr)}");

Console.ForegroundColor = ConsoleColor.DarkYellow;
MatrixFunctions.MaxElWithStreak(arr);

Console.ForegroundColor = ConsoleColor.Red;
MatrixFunctions.RowsWithoutZero(arr);

Console.ForegroundColor = ConsoleColor.Yellow;
MatrixFunctions.ColumnsWithZero(arr);

Console.ForegroundColor = ConsoleColor.Green;
MatrixFunctions.MaxValueStreak(arr);

Console.ForegroundColor = ConsoleColor.Blue;
MatrixFunctions.MultWithoutNegElRow(arr);

Console.ForegroundColor = ConsoleColor.DarkRed;
MatrixFunctions.MaxDiagSummMain(arr);

Console.ForegroundColor = ConsoleColor.Magenta;
MatrixFunctions.SummWithoutNegElCol(arr);

Console.ForegroundColor = ConsoleColor.DarkCyan;
MatrixFunctions.MinDiagSummSide(arr);

Console.ForegroundColor = ConsoleColor.DarkBlue;
MatrixFunctions.SummWithNegElCol(arr);

Console.ForegroundColor = ConsoleColor.White;
MatrixFunctions.Transpose(arr);

Console.ForegroundColor = ConsoleColor.White;



