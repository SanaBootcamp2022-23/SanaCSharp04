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

uint positiveNumberCount = 0;

foreach (int value in matrix)
    if (value > 0) positiveNumberCount++;

Console.WriteLine($"Count a positive number matrix = {positiveNumberCount}");

// Завдання 2
// Для матриці N на M цілого типу визначити: максимальне із чисел, що зустрічається в заданій матриці більше одного разу;

int maxNumber = int.MinValue;
bool twoIdenticalNumbersArePresent = false;
for (int lineOne = 0; lineOne < matrixHeight; lineOne++)

    for (int columnOne = 0; columnOne < matrixWidth; columnOne++)

        for (int lineTwo = 0; lineTwo < matrixHeight; lineTwo++)

            for (int columnTwo = 0; columnTwo < matrixWidth; columnTwo++)
                if (lineOne != lineTwo && columnOne != columnTwo &&
                    matrix[lineOne, columnOne] == matrix[lineTwo, columnTwo] &&
                    maxNumber < matrix[lineOne, columnOne])
                {
                    maxNumber = matrix[lineOne, columnOne];
                    twoIdenticalNumbersArePresent = true;
                }

if (twoIdenticalNumbersArePresent) 
    Console.WriteLine($"The maximum number that occurs in the given matrix more than once = {maxNumber}");
else
    Console.WriteLine("There are no identical elements in the matrix");

// Завдання 3
// Для матриці N на M цілого типу визначити: кількість рядків, які не містять жодного нульового елемента;

bool thereIsAZeroInTheLine = false;
int theNumberOfRowsWithoutZeroElements = 0;

for (int lineOne = 0; lineOne < matrixHeight; lineOne++)
{
    for (int columnOne = 0; columnOne < matrixWidth; columnOne++)
    {
        if (matrix[lineOne, columnOne] == 0)
        {
            thereIsAZeroInTheLine = true;
            break;
        }
    }
    if (!thereIsAZeroInTheLine)
    {
        theNumberOfRowsWithoutZeroElements++;
    }
    thereIsAZeroInTheLine = false;
}
Console.WriteLine($"The number of rows without zero elements = { theNumberOfRowsWithoutZeroElements} ");

// Завдання 4
// Для матриці N на M цілого типу визначити: кількість стовпців, які містять хоча б один нульовий елемент;
thereIsAZeroInTheLine = false;
int theNumberOfColumnsThatContainZero = 0;


for (int column = 0; column < matrixWidth; column++)
{
    for (int line = 0; line < matrixHeight; line++)
    {
        if (matrix[line, column] == 0)
        {
            thereIsAZeroInTheLine = true;
            break;
        }
    }
    if (thereIsAZeroInTheLine)
        theNumberOfColumnsThatContainZero++;

    thereIsAZeroInTheLine = false;
}
Console.WriteLine($"The number of columns that contain at least one null element = { theNumberOfColumnsThatContainZero}");
// Завдання 6
// Для матриці N на M цілого типу визначити: добуток елементів в тих рядках, які не містять від’ємних елементів;

bool stringHasANegativeElement = false;

int productElements = 1;

for (int lineOne = 0; lineOne < matrixHeight; lineOne++)
{
    for (int columnOne = 0; columnOne < matrixWidth; columnOne++)
    {
        if (matrix[lineOne, columnOne] < 0)
        {
            stringHasANegativeElement = true;
            break;
        }
    }
    if (stringHasANegativeElement)
    {
        stringHasANegativeElement = false;
        continue;
    }
    for (int columnOne = 0; columnOne < matrixWidth; columnOne++)
    {
        if (matrix[lineOne, columnOne] != 0) productElements *= matrix[lineOne, columnOne];
    }

}
Console.WriteLine($"The number of rows without zero elements { productElements} ");

// Завдання 7
// Для матриці N на M цілого типу визначити: максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;

int[] sumOfDiagonalsWidth = new int[matrixWidth];
for (int i = 0; i < matrixWidth; i++)
{
    for (int lineOne = 0; lineOne < matrixHeight; lineOne++)
    {
        for (int columnOne = i; columnOne < matrixWidth; columnOne++)
        {
            if (lineOne + i == columnOne)
            {
                sumOfDiagonalsWidth[i] += matrix[lineOne, columnOne];
            }
        }
    }
}
int[] sumOfDiagonalsHeight = new int[matrixHeight];
for (int i = 0; i < matrixWidth; i++)
{
    for (int lineOne = i; lineOne < matrixHeight; lineOne++)
    {
        for (int columnOne = 0; columnOne < matrixWidth; columnOne++)
        {
            if (lineOne == columnOne + i)
            {
                sumOfDiagonalsHeight[i] += matrix[lineOne, columnOne];
            }
        }
    }
}

Console.WriteLine($" { Math.Max(sumOfDiagonalsHeight.Max(), sumOfDiagonalsWidth.Max())} ");

// Завдання 8
// Для матриці N на M цілого типу визначити: суму елементів в тих стовпцях, які не містять від’ємних елементів;

bool columHasANegativeElement = false;

int sumElements = 0;

for (int columnOne = 0; columnOne < matrixWidth; columnOne++)
{
    for (int lineOne = 0; lineOne < matrixHeight; lineOne++)
    {
        if (matrix[lineOne, columnOne] < 0)
        {
            columHasANegativeElement = true;
            break;
        }
    }
    if (columHasANegativeElement)
    {
        columHasANegativeElement = false;
        continue;
    }
    for (int lineOne = 0; lineOne < matrixHeight; lineOne++)
    {
        if (matrix[lineOne, columnOne] != 0) sumElements += matrix[lineOne, columnOne];
    }

}
Console.WriteLine($"The count of rows without zero elements { sumElements} ");
