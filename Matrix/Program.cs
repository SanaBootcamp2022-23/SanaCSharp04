using Matrix;

const int N = 5, M = 3;
int[,] matrix = new int[N, M];
Methods.FillMatrixWithRandomNumbers(ref matrix, -32, 32);

Console.WriteLine($"Matrix[{N},{M}]:");
Methods.PrintMatrix(matrix, ConsoleColor.Magenta);

Console.WriteLine($"\nКількість додатніх елементів: {Methods.CountPositiveElements(matrix)}");
Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {Methods.GetMaxDuplicatedElement(matrix)}");
