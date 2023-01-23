Random rnd = new Random();

Console.WriteLine("Enter n:");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter m:");
int m = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[n, m];

//Generate matrix 
for(int i = 0; i < n; i++)
{
    for(int j = 0; j<m; j++)
    {
        matrix[i, j] = rnd.Next(-5, 5);
    }
}

//Output matrix
for(int i = 0; i < n; i++)
{
    for(int j = 0; j<m; j++)
    {
        Console.Write($"{matrix[i,j]} \t");
    }
    Console.WriteLine();
}
//Count of positive num 
int CountOfPositeNumbers(int [,] matrix)
{
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for(int j = 0; j< matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > 0)
            {
                count++;
            }
        }
    } 
    return count;
}
int CountRowWithoutZero(int[,] matrix)
{
    int count = 0;
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        bool zeroInRow = false;
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 0)
            {
                zeroInRow = true; 
                break;
            }
        }
        if(!zeroInRow)
        {
            count++;
        }
    }
    return count;
}
int CountColummWithZeroElement(int[,] matrix)
{
    int count = 0;
    for(int i=0;i< matrix.GetLength(0); i++)
    {
        bool zeroInColumm = false;
        for(int j =0; j< matrix.GetLength(1); j++)
        {
            if (matrix[i,j] == 0)
            {
                zeroInColumm = true;
                break;
            }
        }
        if(zeroInColumm)
        {
            count++;
        }
    }
    return count;
}
int ProductOfElementWithoutNeg(int[,] matrix)
{
    int product = 1;
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        bool negativeRow = false;
        for(int j = 0; j< matrix.GetLength(1); j++)
        {
            if (matrix[i,j] < 0) 
            {
                negativeRow = true;
                break;
            }
        }
        if(!negativeRow)
        {
            for(int j = 0; j< matrix.GetLength(1); j++)
            {
                product *= matrix[i,j];
            }
        }
    }
    return product;
}
int SumOfColummWithoutNegative(int[,] matrix)
{
    int sum = 0;
    for(int i = 0; i<matrix.GetLength(0); i++)
    {
        bool negativeInColumm = false;
        for(int j = 0; j<matrix.GetLength(1); j++)
        {
            if (matrix[i,j] < 0)
            {
                negativeInColumm = true;
                break;
            }
        }
        if (!negativeInColumm)
        {
            for(int j = 0; j<matrix.GetLength(1); j++)
            {
                sum+= matrix[i,j];
            }
        }
    }
    return sum;
}
int SumOfElementsWithNegative(int[,] matrix)
{
    int sum = 0;
    for(int i = 0; i< matrix.GetLength(0); i++)
    {
        bool colummNegative = false;
        for(int j = 0; j< matrix.GetLength(1); j++)
        {
            if (matrix[i,j] < 0)
            {
                colummNegative = true;
                break;
            }
        }
        if(colummNegative)
        {
            for(int j = 0; j<matrix.GetLength(1); j++)
            {
                sum += matrix[i,j];
            }
        }
    }
    return sum;
}
int NumberOfLongestRow(int[,] matrix)
{
    int longestSeriesRow = 0;
    int longestSeriesLength = 0;
    int currentSeriesLength = 1;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        currentSeriesLength = 1;
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            if (matrix[i,j] == matrix[i,j + 1])
            {
                currentSeriesLength++;
            }
            else
            {
                currentSeriesLength = 1;
            }
            if (currentSeriesLength > longestSeriesLength)
            {
                longestSeriesLength = currentSeriesLength;
                longestSeriesRow = i;
            }
        }
    }
    return longestSeriesRow;
}
int MaxElementDuplicate(int[,] matrix)
{
    int max = int.MinValue;
    HashSet<int> unique = new HashSet<int>();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (!unique.Add(matrix[i, j]))
            {
                max = Math.Max(max, matrix[i,j]);
            }
        }
    }
    return max;
}
int MiminimumOfAbsSum(int[,] matrix)
{
    int minDiagonalSum = int.MaxValue;
    int diagonalSum = 0;
    for(int i = 0; i<matrix.GetLength(0); i++)
    {
        diagonalSum = 0;
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == matrix.GetLength(0) - j - 1)
            {
                diagonalSum += Math.Abs(matrix[i, j]);
            }
        }
        minDiagonalSum = Math.Min(minDiagonalSum, diagonalSum);
    }
    return minDiagonalSum;
}
int MaxOfSum(int[,] matrix)
{
    int maxDiagonalSum = int.MinValue;
    for(int i = 0; i<matrix.GetLength(0); i++)
    {
        for(int j = 0; j<matrix.GetLength(1); j++)
        {
            if(i+j == matrix.GetLength(0) - 1)
            {
                maxDiagonalSum = Math.Max(maxDiagonalSum, matrix[i, j]);
            }
        }
    }
    return maxDiagonalSum;
}
void TranformedMatrix(int[,] matrix)
{
    int row = matrix.GetLength(0);
    int col = matrix.GetLength(1);  
    int[,] trasposeMatrix = new int[row, col];
    for(int i = 0; i<row; i++)
    {
        for(int j =0; j<col; j++)
        {
            trasposeMatrix[j,i] = matrix[i, j];
        }
    }
    Console.WriteLine("Traspose Matrix:");
    for(int i = 0; i< row; i++)
    {
        for(int j = 0; j<col; j++)
        {
            Console.Write($"{trasposeMatrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}


Console.WriteLine($"Count of positive number: {CountOfPositeNumbers(matrix)}");
Console.WriteLine($"Count of row without zero elements: {CountRowWithoutZero(matrix)}");
Console.WriteLine($"Count of columm with zero elements: {CountColummWithZeroElement(matrix)}");
Console.WriteLine($"Product of elements in row without negative number: {ProductOfElementWithoutNeg(matrix)}");
Console.WriteLine($"Sum of elements in columm without negativ element: {SumOfColummWithoutNegative(matrix)}");
Console.WriteLine($"Sum of elements in columm with negativ element: {SumOfElementsWithNegative(matrix)}");
Console.WriteLine($"The longest row of similar element: {NumberOfLongestRow(matrix)}");
Console.WriteLine($"Max number of dublicate number in array: {MaxElementDuplicate(matrix)}");
Console.WriteLine($"Minimum among the sum of abs value: {MiminimumOfAbsSum(matrix)}");
Console.WriteLine($"Maximun among the sum of elements: {MiminimumOfAbsSum(matrix)}\n");
TranformedMatrix(matrix);