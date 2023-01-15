int rows, 
    columns, 
    diagonalCount = 0, 
    positiveElementsCount = 0,
    zeroRowsCount = 0,
    noZeroRowsCount = 0,
    zeroColumnsCount = 0;
double sumaDiagonalesMax = 0,
    maxValue = double.MaxValue,
    minValue = double.MinValue;
Random rnd = new Random();
Console.Write("\t\tMATRIX GENERATOR.\n\nEnter rows: ", Console.ForegroundColor = ConsoleColor.Cyan);
rows = int.Parse(Console.ReadLine());
Console.Write("Enter columns: ");
columns = int.Parse(Console.ReadLine());
if(rows < 1 || columns < 1) //Checking is it possible to create matrix
{
    Console.WriteLine("\nCannot create Matrix.");
    return;
}
double[,] matrix = new double[rows, columns];
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkYellow;

//Matrix generating
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = rnd.Next(-10, 10);//random numbers < -10 ; 10 )
        Console.Write($"{matrix[i, j],3}\t");//Task #1: Finding count of positive numbers in matrix.
        if (matrix[i,j] > 0)
            positiveElementsCount++;
    }
    Console.WriteLine();
}
Console.ForegroundColor = ConsoleColor.White;

//Task #2: Maximum streak number
double [] arrTmp = new double[rows * columns];
int tmpElement = 0;
double maxStreakNumber = double.MinValue;
//Creating tmp array with matrix elements
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        arrTmp[tmpElement] = matrix[i,j];
        tmpElement++;
    }
}
//Finding maximum streak number in tmp array
for (int i = 0; i < arrTmp.GetLength(0); i++)
    for (int j = i + 1; j < arrTmp.GetLength(0); j++)
    {
        if (arrTmp[i] == arrTmp[j] && arrTmp[i] > maxStreakNumber)
        {
            maxStreakNumber = arrTmp[i];
        }
    }

//Task #3: Finding rows without zero.
for (int i = 0; i < matrix.GetLength(0); i++)
    for (int j = 0;j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
        {
            zeroRowsCount++;
            if (zeroRowsCount > 0)
                break;
        }
    }
if(zeroRowsCount > 0)
    noZeroRowsCount = matrix.GetLength(0) - zeroRowsCount;
else 
    noZeroRowsCount = matrix.GetLength(0);

//Task #4: Finding columns which include zero.
for (int j = 0; j < matrix.GetLength(1); j++)
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] == 0)
        {
            zeroColumnsCount++;
            if (zeroColumnsCount > 0)
                break;
        }
    }

//Task #5: Finding a row with a highest streak of element.
int highestStreak = 1,
    streakRowNumber = 0,
    rowNumber = 0;
for (int i = 0; i < matrix.GetLength(0); i++) {
    int streak = 1;
    for (int j = 0; j < matrix.GetUpperBound(1); j++)
    {
        if (matrix[i, j] == matrix[i, j + 1])
            streak++;
    }
    if (streak > 1)
    {
        highestStreak = streak;
        rowNumber = streakRowNumber;
    }
    streakRowNumber++;
}

//Task #6: Finding multiplication of positive rows.
int numberOfRow = 1;
Console.WriteLine("\nTask #6. Finding multiplication of positive rows.");
for (int i = 0; i < matrix.GetLength(0); i++) 
{
    double multiplyRow = 1;
    int positiveRowCount = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] >= 0)
        {
            positiveRowCount++;
            multiplyRow *= matrix[i, j];
        }
    }
    if (positiveRowCount == matrix.GetLength(1))
        Console.WriteLine($"Multiplication of positive row #{numberOfRow}: {multiplyRow}");
    numberOfRow++;
}

//Task #7: Finding maximum sum of main diagonales.
if (matrix.GetLength(0) == matrix.GetLength(1))
{
    Console.WriteLine($"\nTask #7\nSum of main diagonales in matrix[{rows},{columns}]:");
    //Finding sums of longest diagonal and upper
    int colCoord, rowCoord; 
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        rowCoord = 0;
        colCoord = j;
        double suma = 0;
        for (int k = 0; k < matrix.GetLength(0) - j; k++)
        {
            suma += matrix[rowCoord, colCoord];
            rowCoord++;
            colCoord++;
        }
        if (sumaDiagonalesMax < suma)
            sumaDiagonalesMax = suma;
        diagonalCount++;
        Console.WriteLine($"diagonal #{diagonalCount} = {suma}");
    }
    //Finding sums under longest diagonal
    for (int i = 1; i < matrix.GetLength(0); i++) 
    {
        rowCoord = i;
        colCoord = 0;
        double suma = 0;
        for (int k = 0; k < matrix.GetLength(1) - i; k++)
        {
            suma += matrix[rowCoord, colCoord];
            rowCoord++;
            colCoord++;
        }
        if (sumaDiagonalesMax < suma)
            sumaDiagonalesMax = suma;
        diagonalCount++;
        Console.WriteLine($"diagonal #{diagonalCount} = {suma}");
    }
}

//Task #8: Finding sum elements in columns which don`t contain negative elements
Console.WriteLine("\nTask #8\nSum elements in columns which don`t contain negative elements:");
int columnCounter = 1;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    double sumaColumns = 0;
    int countNegative = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            countNegative++;
            break;
        }
        else
            sumaColumns += matrix[i, j];
    }
    if (countNegative == 0)
        Console.WriteLine($"Suma of column #{columnCounter}: {sumaColumns}");
    columnCounter++;
}

//Task #9: Finding minimum absolute sum of symmetric diagonales.
if (matrix.GetLength(0) == matrix.GetLength(1))
{
    Console.WriteLine($"\nTask #9\nAbsolute sum of symmetric diagonales in matrix[{rows},{columns}]:");
    //For Longest diagonal and upper
    int colCoord, rowCoord; 
    int upperBound = matrix.GetUpperBound(1);
    for (int j = matrix.GetLength(1); j > 0; j--)
    {
        rowCoord = 0;
        colCoord = upperBound;
        double sumaTask9 = 0;
        for (int k = 0; k < j; k++)
        {
            sumaTask9 += Math.Abs(matrix[rowCoord, colCoord]);
            rowCoord++;
            colCoord--;
        }
        if (maxValue > sumaTask9)
            maxValue = sumaTask9;
        upperBound--;
        diagonalCount++;
        Console.WriteLine($"diagonal #{diagonalCount} = {sumaTask9}");
    }
    //For diagonales under longest one
    upperBound = matrix.GetUpperBound(0); 
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        rowCoord = i;
        colCoord = upperBound;
        double sumaTask9 = 0;
        for (int k = 0; k < matrix.GetLength(0) - i; k++)
        {
            sumaTask9 += Math.Abs(matrix[rowCoord, colCoord]);
            rowCoord++;
            colCoord--;
        }
        if (maxValue > sumaTask9)
            maxValue = sumaTask9;
        diagonalCount++;
        Console.WriteLine($"diagonal #{diagonalCount} = {sumaTask9}");
    }
}

//Task #10: Finding sum elements in columns with negative elements
columnCounter = 1;
Console.WriteLine("\nTask #10\nSum elements in columns with negative elements:");
for (int j = 0; j < matrix.GetLength(1); j++)
{
    double sumaColumnsNegative = 0;
    int countNegative = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sumaColumnsNegative += matrix[i, j];
        if (matrix[i, j] < 0)
        {
            countNegative++;
        }   
    }
    if (countNegative > 0)
        Console.WriteLine($"Suma of column #{columnCounter}: {sumaColumnsNegative}");
    columnCounter++;
}

//Task #11: Making matrix transposition
Console.WriteLine("\nTask #11\nMatrix transposition.");
Console.ForegroundColor = ConsoleColor.DarkYellow;
for (int j = 0; j < matrix.GetLength(1); j++)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"{matrix[i, j], 3}\t");
    }
    Console.WriteLine();
}

//Result block
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine($"\n\t\tRESULTS\nTASK #1: Positive elements in matrix: {positiveElementsCount}");//Result task #1
if (maxStreakNumber > double.MinValue)
    Console.WriteLine($"TASK #2: Maximum streak element: {maxStreakNumber}");//Result task #2
else
    Console.WriteLine($"TASK #2: No maximum streak element.");
Console.WriteLine($"TASK #3: Rows without zero: {noZeroRowsCount}");//Result task #3
Console.WriteLine($"TASK #4: Columns include zero: {zeroColumnsCount}");//Result task #4
Console.WriteLine($"TASK #5: Maximum streak in row #{rowNumber}: {highestStreak}");//Result task #5
if (matrix.GetLength(0) == matrix.GetLength(1))
{
    Console.WriteLine($"TASK #7: Maximum sum of main diagonales: {sumaDiagonalesMax}");//Result task #7
    Console.WriteLine($"TASK #9: Minimum absolute sum of symmetric diagonales: {maxValue}");//Result task #9
}
else
    Console.WriteLine("TASK #7: Matrix is not square.\nTASK #9: Matrix is not square.");
Console.ForegroundColor = ConsoleColor.Gray;


