// See https://aka.ms/new-console-template for more information

using Matrix;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

uint rowCount = 0, colCount = 0;
bool checkFill;

/*Перевірка вводу рядків та стовпців (не нульове і не відємне значення)*/
do
{
    Console.Write("Input rows count: ");
    checkFill = uint.TryParse(Console.ReadLine(), result: out rowCount);
    if (!checkFill || rowCount <= 0)
        Console.Write("Incorect value. ");
} while (!checkFill || rowCount <= 0);

do
{
    Console.Write("Input columns count: ");
    checkFill = uint.TryParse(Console.ReadLine(), result: out colCount);
    if(!checkFill || colCount <= 0)
        Console.Write("Incorect value. ");
} while (!checkFill || colCount <= 0);

//Ініціалізація матриці методом GenerateMatrixRandomValues та її вивід
int[,] matrix = MatrixActions.GenerateMatrixRandomValues(rowCount, colCount);
Console.WriteLine($"Згенерована матриця: ");
MatrixActions.DisplayMatrix(matrix);

//1
Console.WriteLine($"1 - Кількість додатніх елементів масиву: {MatrixActions.CountOfPositiveElement(matrix)}");
//2
//Console.WriteLine($"2 - Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {MatrixActions.MaxRepeatedValue(matrix)}");
/*************/
//3
Console.WriteLine($"3 - Кількість рядків, які не містять жодного нульового елемента: {MatrixActions.CountRowWithoutZero(matrix)}");
//4
Console.WriteLine($"4 - Кількість стовпців, які містять хоча б один нульовий елемент: {MatrixActions.CountColWithZero(matrix)}");
//5
//Console.WriteLine($"5 - Номер рядка, в якому знаходиться найдовша серія однакових елементів: ");
/*************/
//6
Console.WriteLine($"6 - Добуток елементів в тих рядках, які не містять від’ємних елементів:");
MatrixActions.MultColWithoutNegativeElement(matrix);
//7
//Console.WriteLine($"7 - Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриц: ");
/*************/
//8
Console.WriteLine($"8 - Сума елементів в тих стовпцях, які не містять від’ємних елементів: ");
MatrixActions.SumColWithoutNegativeElement(matrix);
//9
//Console.WriteLine($"9 - Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: ");
/*************/
//10
Console.WriteLine($"10 - Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент: ");
MatrixActions.SumColWithNegativeElement(matrix);
//11
Console.WriteLine($"11 - Транспоновану матрицю:");
MatrixActions.TrasposedMatrix(matrix);