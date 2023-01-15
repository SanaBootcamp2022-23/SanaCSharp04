using System;
using System.Linq;
using System.Net;

class Program
{
    public static void Main(string[] args)
    {
        int n, m, ans;
        Console.WriteLine("Enter the value of the size of x of the array");
        Console.Write("-> ");
        m = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the value of the size of y of the array");
        Console.Write("-> ");
        n = int.Parse(Console.ReadLine());
        Console.WriteLine("Do u want ant arr to be generated? [1-yes, 2-no]");
        Console.Write("-> ");
        ans = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, m];
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        switch (ans)
        {
            case 1: arr = CreateMatrix(n, m); break;
            case 2: arr = InputMatrix(n, m); break;
            default: throw new Exception("[error] incorrect input");
        }
        PrintMatrix(arr);

        int pos_num = FindPosNum(arr);
        Console.WriteLine($"num of elemets of matrix > 0 -> {pos_num}");

        int index_max_row = FindLongesdDubs(arr);
        if (index_max_row > 0) Console.WriteLine($"longest sequense is in the row -> {index_max_row + 1}");
        else Console.WriteLine("no dublicates, so there is no longest sequense");

        int num_of_rows_with0= NumOfRows0(arr);
        Console.WriteLine($"num of rows without zeros -> {rows - num_of_rows_with0}");

        int num_of_cols_with0 = NumOfCols0(arr);
        Console.WriteLine($"num of cols with zeros -> {num_of_cols_with0}");

        if (index_max_row > 0) {
            int maxValue = FindMaxDupl(arr);
            Console.WriteLine($"max dubl-> {maxValue}");
        }
        else Console.WriteLine("no dublicates, so there is no max duplicate");

        FindRowProduct(arr);

        FindColumnsWithNegs(arr);

        int maxDiag = MaxMainDiag(arr, rows, cols);
        Console.WriteLine($"Max among main diagonals -> {maxDiag}");

        int minDiag = MinSecDiag(arr, rows, cols);
        Console.WriteLine($"Min among sec diagonals -> {minDiag}");

        int[,] transposedMatrix = TransportMatrix(arr);

        Console.WriteLine("transportrd matrix is ->");
        PrintMatrix(transposedMatrix);

    }
    public static int[,] CreateMatrix(int rows, int cols)
    {
        Console.WriteLine("The given matrix:");

        Random rnd = new Random();
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rnd.Next(-50, 50);
            }
        }
        return matrix;
    }
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]}\t");
            Console.WriteLine();
        }
    }
    public static int[,] InputMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.WriteLine($"Enter the value of {i + 1} {j + 1} element");
                Console.Write("-> ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return matrix;
    }
    public static int FindLongesdDubs(int[,] matrix)
    {
        int index = -1, curr_max=0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int dub_num = 0;
            HashSet<int> unique_nums = new HashSet<int>();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (!unique_nums.Add(matrix[i, j]))
                {
                    dub_num++;
                }
            }
            if (dub_num > curr_max)
            {
                curr_max = dub_num; index = i;
            }
        }
    return index;
    }
    public static int NumOfRows0(int[,] arr)
    {
        int zero_count_row = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
            if (Enumerable.Range(0, arr.GetLength(1)).Any(x => arr[i, x] == 0)) // enumerable.range (start, number of sequens) - generates a sequense, kinda like for. returns a sequens obviously. .Any returns bool;
                zero_count_row++;
        return zero_count_row;
    }
    public static int FindPosNum(int[,] arr)
    {
        int num= arr.Cast<int>().Where(x => x > 0).Count();
        return num;
    }
    public static int FindMaxDupl(int[,] arr)
    {
        List<int> duplicates = new List<int>();
        HashSet<int> uniqueNums = new HashSet<int>();//hashset is like list but without repetitives...
        foreach (int num in arr)
        {
            if (!uniqueNums.Add(num))
            {
                duplicates.Add(num);
            }
        }
        return duplicates.Max();
    }
    public static int NumOfCols0(int[,] arr)
    {
        int zero_count_col = 0;
        for (int i = 0; i < arr.GetLength(1); i++)
            if (Enumerable.Range(0, arr.GetLength(0)).Any(x => arr[x, i] == 0)) // enumerable.range (start, number of sequens) - generates a sequense, kinda like for. returns a sequens obviously. .Any returns bool;
                zero_count_col++;
        return zero_count_col;
    }
    public static void FindRowProduct(int[,] arr)
    {
        int rowProduct;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            if (!Enumerable.Range(0, arr.GetLength(1)).Any(x => arr[i, x] < 0))
            {
                rowProduct = Enumerable.Range(0, arr.GetLength(1)).Select(k => arr[i, k]).Aggregate((x, y) => x * y);
                Console.WriteLine($"row {i} has no negatives, so its product is -> {rowProduct}");
            }
        }
    }
    public static void FindColumnsWithNegs(int[,] arr)
    {
        int columnSum;

        for (int i = 0; i < arr.GetLength(1); i++)
        {

            if (!Enumerable.Range(0, arr.GetLength(0)).Any(x => arr[x, i] < 0))
            {
                columnSum = Enumerable.Range(0, arr.GetLength(0)).Select(x => arr[x, i]).Sum();
                Console.WriteLine($"{i} col has sero negs, so its sum is -> {columnSum}");
            }
            else
            {
                columnSum = Enumerable.Range(0, arr.GetLength(0)).Select(x => arr[x, i]).Sum();
                Console.WriteLine($"sum of {i} (it has at least one neg) col -> {columnSum}");
            }
        }
    }
    public static int[,] TransportMatrix(int[,] arr)
    {
        int[,] transposedMatrix = new int[arr.GetLength(1), arr.GetLength(0)];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                transposedMatrix[j, i] = arr[i, j];
            }
        }
        return transposedMatrix;
    }
    public static int MaxMainDiag(int[,] arr, int rows, int cols)
    {
        List<int> diagonals = new List<int>();
        int max = rows > cols ? rows : cols;
        int min = rows > cols ? cols : rows;
        for (int i = 0; i < max; i++)
        {
            int diagonalSum = 0;
            for (int j = 0; j < min; j++)
                if ((i + j) >= max)
                    break;
                else
                    diagonalSum += rows > cols ? arr[i + j, j] : arr[j, i + j];
           diagonals.Add(diagonalSum);
        }
        for (int i = 1; i < min; i++)
        {
            int diagonalSum = 0;
            for (int j = 0; j < max; j++)
                if ((i + j) >= min)
                    break;
                else
                    diagonalSum += rows > cols ? arr[j, i + j] : arr[i + j, j];
            diagonals.Add(diagonalSum);
        }
        return diagonals.Max();
    }
    public static int MinSecDiag(int[,] arr, int rows, int cols)
    {
        List<int> diagonals = new List<int>();
        int max = rows > cols ? rows : cols;
        int min = rows > cols ? cols : rows;
        for (int i = 0; i < max; i++)
        {
            int diagonalSum = 0;
            for (int j = 0; j < min; j++)
                if ((i + j) >= max)
                    break;
                else
                    diagonalSum += rows > cols ? Math.Abs(arr[rows - (i + j)-1, j]) : Math.Abs(arr[j, cols-(i + j)-1]);
            diagonals.Add(diagonalSum);
        }
        for (int i = 1; i < min; i++)
        {
            int diagonalSum = 0;
            for (int j = 0; j < max; j++)
                if ((i + j) >= min)
                    break;
                else
                    diagonalSum += rows > cols ? Math.Abs(arr[rows - j-1, (i + j)]) : Math.Abs(arr[ i + j, cols -j-1 ]);
            diagonals.Add(diagonalSum);
        }
        return diagonals.Min();
    }
}