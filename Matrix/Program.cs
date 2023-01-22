
int rows, cols;

CheckAndWriteNumber(out rows, "rows");
CheckAndWriteNumber(out cols, "columns");

int[,] arr = new int[rows, cols];

int sumPositiveElem = 0;

InputArr(rows, cols);

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Main Matrix");
OutputArr(arr);

Console.ForegroundColor= ConsoleColor.DarkCyan;
CheckPositiveElem();
MaxPositiveRepetitiveElem();
QuantityNotZeroRows();
QuantityZeroCols();
NumberRowLongestSeriesEqualElem();
MultiplicationElemWithNoNegativeElem();
MaxSumOfParallelMainDiagonal();
SumElemWithoutNegativeElem();
MinSumAbsElemDiagonalParallelLateralDiagonal();
SumElemWithNegativeElem();

Console.ForegroundColor= ConsoleColor.Red;
Console.WriteLine("Transposed Matrix");
OutputArr(TransposedMatrix(arr));

//MaxSumOfParallelMainDiagonal();
//MinSumAbsElemDiagonalParallelLateralDiagonal();

void InputArr(int rows, int cols)
{
    Random rnd = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = rnd.Next(-15, 15);
        }
    }
}

void OutputArr(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if (i % 2 == 1)
            Console.ForegroundColor = ConsoleColor.Yellow;
        else
            Console.ForegroundColor = ConsoleColor.White;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]}\t");
        }
        Console.WriteLine("\n");
    }
}

void CheckAndWriteNumber(out int number, string str)
{
    bool isRightNumber;
    do
    {
        Console.Write($"Input quantity of {str}: ");
        isRightNumber = int.TryParse(Console.ReadLine(), out number);
        if (number <= 0)
            isRightNumber = false;
        if (!isRightNumber)
        {
            Console.Write("ERROR!!!\n");
        }
    } while (!isRightNumber);
}

void CheckPositiveElem()
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] > 0)
                sumPositiveElem += arr[i, j];
        }
    }

    Console.WriteLine($"Sum of positive elements = {sumPositiveElem}");
}

void MaxPositiveRepetitiveElem()
{
    bool checkRepititveElem = false;
    int maxElem = int.MinValue;
    int[] templateMatrix = new int[arr.GetLength(0)*arr.GetLength(1)];

    int counter = 0; // counter for templateMatrix
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            templateMatrix[counter] = arr[i, j];
            counter++;
        }
    }
    Array.Sort(templateMatrix);

    while (checkRepititveElem == false)
    {
        if (templateMatrix.Count() == 1 && checkRepititveElem == false)
        {
            Console.WriteLine("Maximum repititive element isn't exist!");
            break;
        }
        if (templateMatrix[templateMatrix.GetUpperBound(0)] == templateMatrix[templateMatrix.GetUpperBound(0) - 1])// if last and prelast element equal, our task is done, differently, we deacrease our matrix on 1 element (it is the last element)
        {
            checkRepititveElem = true;
            maxElem = templateMatrix[templateMatrix.GetUpperBound(0)];
        }
        else
        {
            Array.Resize(ref templateMatrix, templateMatrix.GetUpperBound(0));
        }
    }

    if(checkRepititveElem)
    {
        Console.WriteLine($"Maximum repititive element = {maxElem}");
    }
}

void QuantityNotZeroRows()
{
    int quantityNotZeroRows = 0;
    bool checkNotZeroRows = false;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            checkNotZeroRows = false;
            if (arr[i, j] == 0)
            {
                checkNotZeroRows = true;
                continue;
            }
            if(!checkNotZeroRows)
            {
                quantityNotZeroRows++;
            }
        }
    }
    if (quantityNotZeroRows == 0)
    {
        Console.WriteLine("Rows that don't contain zero element isn't exist.");
    }
    else
    {
        Console.WriteLine($"Quantity rows that don't contain zero element = {quantityNotZeroRows}");
    }
}

void QuantityZeroCols()
{
    int quantityZeroCols = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            if (arr[j, i] == 0)
            {
                quantityZeroCols++;
                continue;
            }
        }
    }
    if (quantityZeroCols == 0)
    {
        Console.WriteLine("Cols that contain zero element isn't exist.");
    }
    else
    {
        Console.WriteLine($"Quantity cols that contain zero element = {quantityZeroCols}");
    }
}

void NumberRowLongestSeriesEqualElem()
{
    int longSeries = 1;
    int maxLongestSeries = 1;
    int numberRowLongestSeries = 0;
    bool checkLongSeries = false;
    for (int i = 0; i < arr.GetUpperBound(0); i++)
    {
        for (int j = 0; j < arr.GetUpperBound(1); j++)
        {
            if (arr[i, j] == arr[i, j + 1])
            {
                longSeries++;
                checkLongSeries = true;
                if (longSeries > maxLongestSeries)
                {
                    numberRowLongestSeries = i;
                    maxLongestSeries = longSeries;
                }
            }
            else longSeries = 1;
        }
    }
    if(!checkLongSeries)
    {
        Console.WriteLine($"There is no rows with long repititive series of numbers.");
    }
    else
    {
        Console.WriteLine($"Rows with the longest series repititive elements = {numberRowLongestSeries}");
    }
}

void MultiplicationElemWithNoNegativeElem()
{
    int multiplicationElem = 1;
    bool checkNegativeElem = false;
    bool checkNegativeElemFirstly = false;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        checkNegativeElem = false;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] < 0)
            {
                checkNegativeElem = true;
                break;
            }
        }
        if(!checkNegativeElem)
        {
            checkNegativeElemFirstly = true;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                multiplicationElem *= arr[i, j];
            }
        }
    }
    if (checkNegativeElemFirstly)
    {
        Console.WriteLine($"Multiplication elements of rows without negative elements = {multiplicationElem}");
    }
    else
        Console.WriteLine($"There is no rows without negative elements.");
}

void MaxSumOfParallelMainDiagonal()
{
    int maxSum = int.MinValue;
    int coordRow, coordCol;
    int sumOneDiagonal = 0; // variable to calculate 1 diagonal

    void CalculateSumMainDiagonal()
    {
        for (int i = 0; i < arr.GetLength(0); i++)
            sumOneDiagonal = arr[i, i];
        maxSum = Math.Max(maxSum, sumOneDiagonal);
    }

    if (arr.GetLength(1) > arr.GetLength(0))
    {
        for (int j = 1; j <= arr.GetLength(1) - arr.GetLength(0); j++)
        {
            coordRow = 0;
            coordCol = j;
            sumOneDiagonal = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }

        for (int j = 1 + arr.GetLength(1) - arr.GetLength(0); j < arr.GetLength(1); j++)
        {
            coordRow = 0;
            coordCol = j;
            sumOneDiagonal = 0;
            for (int i = 0; i < arr.GetLength(1) - j; i++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }

        for (int j = 1; j < arr.GetLength(0); j++)
        {
            coordRow = j;
            coordCol = 0;
            sumOneDiagonal = 0;
            for (int i = 0; i < arr.GetLength(0) - j; i++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }
        CalculateSumMainDiagonal();
    }
    else if(arr.GetLength(1) < arr.GetLength(0))
    {
        for (int i = 1; i <= arr.GetLength(0) - arr.GetLength(1); i++)
        {
            coordRow = i;
            coordCol = 0;
            sumOneDiagonal = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }

        for (int i = 1 + arr.GetLength(0) - arr.GetLength(1); i < arr.GetLength(0); i++)
        {
            coordRow = i;
            coordCol = 0;
            sumOneDiagonal = 0;
            for (int j = 0; j < arr.GetLength(0) - i; j++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            coordRow = 0;
            coordCol = i;
            sumOneDiagonal = 0;
            for (int j = 1; j <= arr.GetLength(1) - i; j++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }
        CalculateSumMainDiagonal();
    }
    else
    {
        for (int j = 1; j < arr.GetLength(0); j++)
        {
            coordRow = j;
            coordCol = 0;
            sumOneDiagonal = 0;
            for (int i = 0; i < arr.GetLength(0) - j; i++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            coordRow = 0;
            coordCol = i;
            sumOneDiagonal = 0;
            for (int j = 1; j <= arr.GetLength(1) - i; j++)
            {
                sumOneDiagonal += arr[coordRow, coordCol];
                coordRow++;
                coordCol++;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }
    }
    Console.ForegroundColor= ConsoleColor.DarkCyan;
    Console.WriteLine($"The maximum sum parallel of main diagonal = {maxSum}");
}

void SumElemWithoutNegativeElem()
{
    bool checkNegativeElem = false;
    bool checkNegativeElemFirstly = false;
    int SumElem = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        checkNegativeElem = false;
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            if (arr[j, i] < 0)
            {
                checkNegativeElem = true;
                break;
            }
        }
        if(!checkNegativeElem)
        {
            checkNegativeElemFirstly = true;
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                SumElem += arr[j, i];
            }
        }
    }
    if (checkNegativeElemFirstly)
    {
        Console.WriteLine($"Sum elements of cols without negative element = {SumElem}");
    }
    else
        Console.WriteLine("There is no cols without negative element.");
}

void MinSumAbsElemDiagonalParallelLateralDiagonal() //not finished
{
    int maxSum = int.MinValue;
    int coordRow, coordCol;
    int sumOneDiagonal = 0; // variable to calculate 1 diagonal

    if (arr.GetLength(0) == arr.GetLength(1))
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            coordRow = i;
            coordCol = arr.GetUpperBound(1);
            sumOneDiagonal = 0;
            for (int j = 0; j < arr.GetLength(1) - i; j++)
            {
                sumOneDiagonal += Math.Abs(arr[coordRow, coordCol]);
                coordRow++;
                coordCol--;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }

        for (int i = arr.GetUpperBound(1) - 1; i >= 0; i--)
        {
            coordRow = 0;
            coordCol = i;
            sumOneDiagonal = 0;
            for (int j = 0; j <= i; j++)
            {
                sumOneDiagonal += Math.Abs(arr[coordRow, coordCol]);
                coordRow++;
                coordCol--;
            }
            maxSum = Math.Max(maxSum, sumOneDiagonal);
        }
    }
    //else if (arr.GetLength(0) < arr.GetLength(1))
    //{
    //    for (int i = arr.GetUpperBound(0); i >= 0; i--)
    //    {
    //        coordRow = 0;
    //        coordCol = i;
    //        sumOneDiagonal = 0;
    //        for (int j = 0; j <= i; j++)
    //        {
    //            sumOneDiagonal += Math.Abs(arr[coordRow, coordCol]);
    //            coordRow++;
    //            coordCol--;
    //        }
    //        Console.WriteLine($"Sum {i} upper diagonal = {sumOneDiagonal}");
    //        maxSum = Math.Max(maxSum, sumOneDiagonal);
    //    }

    //    for (int i = arr.GetUpperBound(1); i >= arr.GetUpperBound(1) - arr.GetUpperBound(0); i--)
    //    {
    //        coordRow = 0;
    //        coordCol = i;
    //        sumOneDiagonal = 0;
    //        for (int j = 0; j <= arr.GetUpperBound(1) - arr.GetUpperBound(0); j++)
    //        {
    //            sumOneDiagonal += Math.Abs(arr[coordRow, coordCol]);
    //            coordRow++;
    //            coordCol--;
    //        }
    //        Console.WriteLine($"Sum {i} upper diagonal = {sumOneDiagonal}");
    //        maxSum = Math.Max(maxSum, sumOneDiagonal);
    //    }

    //    for (int i = 1; i <= arr.GetUpperBound(1) - arr.GetUpperBound(0); i++)
    //    {
    //        coordRow = i;
    //        coordCol = arr.GetUpperBound(1);
    //        sumOneDiagonal = 0;
    //        for (int j = i; j <= arr.GetUpperBound(0); j++)
    //        {
    //            sumOneDiagonal += Math.Abs(arr[coordRow, coordCol]);
    //            coordRow++;
    //            coordCol--;
    //        }
    //        Console.WriteLine($"Sum {i} under diagonal = {sumOneDiagonal}");
    //        maxSum = Math.Max(maxSum, sumOneDiagonal);
    //    }
    //}
}

void SumElemWithNegativeElem()
{
    bool checkNegativeElem = false;
    bool checkNegativeElemFirstly = false;
    int SumElem = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            if (arr[j, i] < 0)
            {
                checkNegativeElem = true;
                break;
            }
        }
        if (checkNegativeElem)
        {
            checkNegativeElemFirstly = true;
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                SumElem += arr[j, i];
            }
        }
    }
    if(checkNegativeElemFirstly)
    {
        Console.WriteLine($"Sum elements of cols with negative element = {SumElem}");
    }
    else
    {
        Console.WriteLine("There is no cols with negative elements.");
    }
}

int[,] TransposedMatrix(int[,]arr) // not finished
{
    int rowCountTransposed = arr.GetLength(1);
    int colCountTransposed = arr.GetLength(0);
    int[,] tranposedArr = new int[rowCountTransposed, colCountTransposed];


    for (int i = 0; i < tranposedArr.GetLength(0); i++)
    {
        for (int j = 0; j < tranposedArr.GetLength(1); j++)
        {
            tranposedArr[i, j] = arr[j, i];
        }
    }
    return tranposedArr;
}