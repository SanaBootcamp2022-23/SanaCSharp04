using Matrix;

const int N = 5, M = 5;
int[,] matrix = new int[N, M];
Methods.FillMatrixWithRandomNumbers(ref matrix, -32, 64);

Console.WriteLine($"Matrix[{N},{M}]:");
Methods.PrintMatrix(matrix, ConsoleColor.Magenta);

Console.WriteLine($"1) Кількість додатніх елементів: {Methods.CountPositiveElements(matrix)}");
Console.WriteLine($"2) Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {Methods.GetMaxDuplicatedElement(matrix)}");
Console.WriteLine($"3) Кількість рядків, які не містять жодного нульового елемента: {Methods.CountRowsWithoutZeros(matrix)}");
Console.WriteLine($"4) Кількість стовпців, які містять хоча б один нульовий елемент: {Methods.CountColumnsWithZeros(matrix)}");
Console.WriteLine($"5) Номер рядка, в якому знаходиться найдовша серія однакових елементів: {Methods.GetRowWithLongestSeries(matrix) + 1}");
Console.WriteLine($"6) Добуток елементів в тих рядках, які не містять від’ємних елементів: {Methods.GetPositiveRowProduct(matrix)}");
