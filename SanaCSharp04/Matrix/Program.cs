bool chekingPossCreateMatrix = false;
uint columCount = 0, rowsCount = 0;
do
{
    Console.Write("Imput colum -> "); columCount = uint.Parse(Console.ReadLine());
    Console.Write("Imput rows -> "); rowsCount = uint.Parse(Console.ReadLine());
    if (columCount < 1 || rowsCount < 1) { Console.WriteLine("\nCannot create Matrix\n"); }
    else
    {
        chekingPossCreateMatrix = true;
    }
} while (chekingPossCreateMatrix == false);

int[,] matrix = new int[columCount, rowsCount];

Matrix.Matrix.LibraryMatrix.GenerationMatrix(columCount, rowsCount, matrix);
Console.WriteLine("");
Matrix.Matrix.LibraryMatrix.DisplayMatrix(matrix);
Console.WriteLine("");

//task_01
Console.WriteLine("Кiлькiсть додатних елементiв;");
Matrix.Matrix.LibraryMatrix.CountPositiveElem(matrix);

//task_02
Console.WriteLine("Максимальне iз чисел, що зустрiчається в заданiй матрицi бiльше одного разу;");
Matrix.Matrix.LibraryMatrix.MaxRepeatValue(matrix);

//task_03
Console.WriteLine("Кiлькiсть рядкiв, якi не мiстять жодного нульового елемента;");
Matrix.Matrix.LibraryMatrix.RowsAintZeroValue(matrix);

//task_04
Console.WriteLine("Кiлькiсть стовпцiв, якi мiстять хоча б один нульовий елемент;");
Matrix.Matrix.LibraryMatrix.ColumZeroValue(matrix);

//task_05
Console.WriteLine("Номер рядка, в якому знаходиться найдовша серiя однакових елементiв;");
Matrix.Matrix.LibraryMatrix.NumberRowsWithMaxSeriesValue(matrix);

//task_06
Console.WriteLine("Добуток елементiв в тих рядках, якi не мiстять вiд’ємних елементiв;");
Matrix.Matrix.LibraryMatrix.ProductValueINRowsAintNegativeValue(matrix);

//task_07
Console.WriteLine("Максимум серед сум елементiв дiагоналей, паралельних головнiй дiагоналi матрицi;");
Matrix.Matrix.LibraryMatrix.MaxSumMainDiagonals(matrix);

//task_08
Console.WriteLine("Суму елементiв в тих стовпцях, якi не мiстять вiд’ємних елементiв;");
Matrix.Matrix.LibraryMatrix.SummaValueINRowsAintNegativeValue(matrix);

//task_09
Console.WriteLine("Мiнiмум серед сум модулiв елементiв дiагоналей, паралельних побiчнiй дiагоналi матрицi;");
Matrix.Matrix.LibraryMatrix.MinSumMainDiagonals(matrix);

//task_10
Console.WriteLine("Суму елементiв в тих стовпцях, якi  мiстять хоча б один вiд’ємний елемент;");
Matrix.Matrix.LibraryMatrix.SummaValueInColumWithNegativeElement(matrix);

//task_11
Console.WriteLine("Транспоновану матрицю.");
Matrix.Matrix.LibraryMatrix.TransposedMatrix(matrix);