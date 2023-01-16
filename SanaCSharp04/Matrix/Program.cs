using Methods;
using System.Text;
Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.Write("rowCount = ");
int N = int.Parse(Console.ReadLine());
Console.Write("colCount = ");
int M = int.Parse(Console.ReadLine());

//int[,] matrix = Matrix.CreateMatrix(N, M);
int[,] matrix = Matrix.GenerateMatrix(N, M);

Matrix.ShowMatrix(matrix);
Matrix.ShowInfo("Кількість додатних елементів", Matrix.CountPositiveElem(matrix));
Matrix.ShowInfo("Mаксимальне із чисел, що зустрічається в заданій матриці більше одного разу", Matrix.MaxRepeatElem(matrix));
Matrix.ShowInfo("Кількість рядків, які НЕ містять жодного нульового елемента", Matrix.CountRowWithoutZero(matrix));
Matrix.ShowInfo("Кількість стовпців, які містять хоча б один нульовий елемент", Matrix.CountColWithZero(matrix));
Matrix.ShowInfo("Номер рядка, в якому знаходиться найдовша серія однакових елементів", Matrix.IndexLineEqualElem(matrix));
Matrix.ShowInfo("Добуток елементів в тих рядках, які не містять від’ємних елементів", "");
Matrix.MultiplyPositiveElem(matrix);
Matrix.ShowInfo("Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці", Matrix.MaxAndMinSumDiagonal(matrix));
Matrix.SumPositiveElem(matrix);
Matrix.ShowInfo("Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці", Matrix.MaxAndMinSumDiagonal(matrix, 1));
Matrix.SumNegativeElem(matrix);
Matrix.ShowTranspositionMatrix(matrix);

