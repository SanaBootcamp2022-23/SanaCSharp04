bool result;
uint matrixWidth;
uint matrixHeight;
do
{
    Console.Write("Matrix width = ");
    result = uint.TryParse(Console.ReadLine(), out matrixWidth);

    if (!result)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error! Incorrect data");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

    if (matrixWidth == 0 && result)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error! Width must be greater than zero");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
    if (matrixWidth != 0 && result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Great!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

} while (!result || matrixWidth == 0);

do
{
    Console.Write("Matrix height = ");
    result = uint.TryParse(Console.ReadLine(), out matrixHeight);

    if (!result)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error! Incorrect data");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

    if (matrixHeight == 0 && result)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error! Width must be greater than zero");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

    if (matrixHeight != 0 && result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Great!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

} while (!result || matrixHeight == 0);

int leftBorderMatrix;
do
{
    Console.Write("The left border of the matrix range = ");
    result = int.TryParse(Console.ReadLine(), out leftBorderMatrix);
    if (result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Great!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error! Incorrect data");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

} while (!result);
int rightBorderMatrix;
do
{
    Console.Write("The right border of the matrix range = ");
    result = int.TryParse(Console.ReadLine(), out rightBorderMatrix);
    if (result && rightBorderMatrix > leftBorderMatrix + 1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Great!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error! Incorrect data");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
    if (rightBorderMatrix <= leftBorderMatrix + 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The right border should be greater than the left border by two points");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

} while (!result || rightBorderMatrix <= leftBorderMatrix + 1);

int[,] matrix = new int[matrixHeight, matrixWidth];
Random rhd = new Random();

for (int line = 0; line < matrixHeight; line++)
    for (int column = 0; column < matrixWidth; column++)
        matrix[line, column] = rhd.Next(leftBorderMatrix, rightBorderMatrix);


// Завдання 1
// Для матриці N на M цілого типу визначити: кількість додатних елементів;

uint integersCount = 0;

foreach (int value in matrix)
    if (value > 0) integersCount++;

Console.WriteLine($"count integers matrix = {integersCount}");
