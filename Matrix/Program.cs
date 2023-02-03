Console.Write("Write N : ");

int n = Convert.ToInt32(Console.ReadLine());

Console.Write("Write M : ");

int m = Convert.ToInt32(Console.ReadLine());

int[,] matrix = new int[n, m];
int[,] trans = new int[m, n];

Random random = new Random();

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-3, 6);
    }
}

for (int i = 0; i < matrix.GetLength(0); i++)

{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j] + "\t");
    }
    Console.WriteLine();
}

int PositiveNumbers(int[,] matrix)
{
    int count = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > 0)
                count++;
        }
    }

    return count;

}
int PositiveRows(int[,] matrix)
{
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        bool isNull = false;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 0)
            {
                isNull = true;
                break;
            }

        }
        if (isNull == false)
        {
            count++;
        }

    }
    return count;

}

int PosCols(int[,] matrix)
{
    int count = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        bool isNull = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, j] == 0)
            {
                isNull = true;
                break;
            }

        }
        if (isNull == true)
        {
            count++;
        }

    }
    return count;

}
void ProductOfPositiveElemnts(int[,] matrix)
{
    int count = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int product = 1;
        bool negative = false;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < 0)
            {
                negative = true;

            }
            else
                product *= matrix[i, j];


        }
        if (negative == false)
        {
            count++;
            Console.WriteLine($"Product of row {i} = {product}");
        }
    }
    if (count == 0)
    {
        Console.WriteLine("No positive rows!");
    }
}

void SumOfPositiveElemnts(int[,] matrix)
{
    int count = 0;

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        int sum = 0;
        bool negative = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, j] < 0)
            {
                negative = true;

            }
            else
                sum += matrix[i, j];


        }
        if (negative == false)
        {
            count++;
            Console.WriteLine($"Sum of cols {j} = {sum}");
        }
    }
    if (count == 0)
    {
        Console.WriteLine("No positive cols!");
    }
}
void SumOfNulCol(int[,] matrix)
{
    int count = 0;

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        int sum = 0;
        bool negative = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i, j];

            if (matrix[i, j] < 0)
                negative = true;


        }
        if (negative == true)
        {
            count++;
            Console.WriteLine($"Sum of neggative cols {j} = {sum}");
        }
    }
    if (count == 0)
    {
        Console.WriteLine("No negative cols!");
    }
}

void TransMatrix(int[,] matrix)
{
    Console.WriteLine("Transposed matrix : ");
    Console.WriteLine();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            trans[i, j] = matrix[j, i];
            Console.Write(trans[i, j] + "\t ");
        }
        Console.WriteLine();
    }
}









Console.WriteLine($"1.Positive count : {PositiveNumbers(matrix)}");
Console.WriteLine($"3.Count of positive rows : {PositiveRows(matrix)}");
Console.WriteLine($"4.Count of PosCols : {PosCols(matrix)}");
Console.Write("6. "); ProductOfPositiveElemnts(matrix);
Console.Write("8. "); SumOfPositiveElemnts(matrix);
Console.Write("10. "); SumOfNulCol(matrix);
Console.Write("11. "); TransMatrix(matrix);

