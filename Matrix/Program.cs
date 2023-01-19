
int N = 3, M = 3;
int[,] arr  = new int[N, M];
Random rand = new ();

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        arr[i, j] = rand.Next(-1, 10);
    }
}

int[,] copyarr = new int[N, M];
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        copyarr[i, j] = arr[i, j];
    }
}

void printarr(int N,int M, int[,] arr)
{
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            Console.Write($"{arr[i, j],5}\t");
        }
        Console.WriteLine();
    }
}

printarr(N, M, arr);


int posElements (int N, int M, int[,] arr)
{
    int k=0;
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            if (arr[i, j] > 0) k++;
        }
    }
    return k;
}



int positive = posElements(N, M, arr);
Console.WriteLine($"\nEmount of positive elements = {positive}");

void MaxElementOccurs (int N, int M, int[,] arr, out int res)
{
    
    int max = 0, iteration = 0;
    bool flag = false;
    do
    {
        max = copyarr[0, 0];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (max < copyarr[i, j]) max = copyarr[i, j];
            }
        }

        iteration = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (copyarr[i, j] == max) iteration++;
            }
        }

        if (iteration > 1) flag = true;
        else
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (copyarr[i, j] == max) copyarr[i, j] = int.MinValue;
                }
            }
        }

    } while (!flag);
    res = max;
}

int res;
MaxElementOccurs(N, M, arr, out res);
if (res == int.MinValue) Console.WriteLine("\nThere is no max number that occurs in the given matrix more than once");
else Console.WriteLine($"\nMax number that occurs in the given matrix more than once = {res}");

int rows_without_null (int N, int M, int[,] arr)
{
    int m = 1;
    int k = 0;
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            if (arr[i, j] == 0) m = 0;
        }
        k += m;
        m = 1;
    }
    return k;
}

int rows_without_null_el = rows_without_null(N, M, arr);
Console.WriteLine($"\nAmount of rows without null element = {rows_without_null_el}");

void colums_with_null(int N, int M, int[,] arr)
{
    int m = 0;
    int k = 0;
    for (int j = 0; j < M; j++)
    {
        for (int i = 0; i < N; i++)
        {
            if (arr[i, j] == 0) m = 1;
        }
        k += m;
        m = 0;
    }
    Console.WriteLine($"\nAmount of colums with null element = {k}");
}

colums_with_null(N, M, arr);

void streak(int N, int M, int[,] arr)
{
    int streak = 0, maxstreek = -1, maxstreek_indx = 0;
    for (int i = 0; i < N; i++)
    {
        for (int j = 1; j < M; j++)
        {
            if (arr[i, j] == arr[i, j - 1]) { streak++; }
        }
        if (maxstreek < streak) { maxstreek = streak; maxstreek_indx = i + 1; }
        streak = 0;
    }
    Console.WriteLine($"\nRow number with longest series of identical elements = {maxstreek_indx}");
}


streak(N, M, arr);


void prodwithoutnegi(int N, int M, int[,] arr)
{
    Console.WriteLine("\nProduct of rows without negative elements (and 0 values)");
    for (int i = 0; i < N; i++)
    {
        int product = 1;
        for (int j = 0; j < M; j++)
        {
            if (arr[i, j] > 0) product *= arr[i, j];
            else product = 0;
        }
        if (product > 0) Console.WriteLine($"Product of {i + 1} row = {product}");
    }
}

prodwithoutnegi(N, M, arr);



void Sumwithoutnegj(int N, int M, int[,] arr)
{
    Console.WriteLine("\nSum of columns without negative elements");
    for (int j = 0; j < M; j++)
    {
        int sum = 0; bool flag0 = true;
        for (int i = 0; i < N; i++)
        {
            if (arr[i, j] >= 0) sum += arr[i, j];
            else {flag0 = false; break;}
        }
        if (flag0) Console.WriteLine($"Sum of {j + 1} column = {sum}");
    }
}

Sumwithoutnegj(N, M, arr);

void Sumofnegj(int N, int M, int[,] arr)
{
    Console.WriteLine("\nSum of columns with at least 1 negative element");

    for (int j = 0; j < M; j++)
    {
        bool flag1 = true;
        int sum = 0, k = 0;
        for (int i = 0; i < N; i++)
        {
            if (arr[i, j] < 0) k++;
            sum += arr[i, j];
            if (k != 0) flag1 = false;
            else k = 0;
        }
        if (!flag1) Console.WriteLine($"Sum of {j + 1} column = {sum}");
    }
}

Sumofnegj(N, M, arr);

void max_diag_sum(int N, int M,int[,] arr)
{
    int MaxSum = 0;
    for (int i = 1; i < N; i++)
    {
        int row = i, col = 0;
        int DiagSumm = 0;
        for (int k = 0; k < N - i; k++)
        {
            DiagSumm += arr[row, col];
            col++;
            row++;
        }
        if (DiagSumm > MaxSum)
        {
            MaxSum = DiagSumm;
        }
    }
    for (int j = 1; j < M; j++)
    {
        int row = 0, col = j;
        int DiagSum = 0;
        for (int k = 0; k < M - j; k++)
        {
            DiagSum += arr[row, col];
            col++;
            row++;
        }
        if (DiagSum > MaxSum)
        {
            MaxSum = DiagSum;
        }
    }
    Console.WriteLine($"Max summ of diagonal elements except main diagonal is {MaxSum}");
}

max_diag_sum(N, M, arr);


void transpon(int N, int M, int[,] arr)
{
    int[,] arr_clone = new int[M, N];
    for (int i = 0; i < N; i++)
    {

        for (int j = 0; j < M; j++)
        {
            arr_clone[j, i] = arr[i, j];
        }
    }
    Console.WriteLine("Transposed matrix\n");

    for (int i = 0; i < M; i++)
    {
        for (int j = 0; j < N; j++)
        {
            Console.Write($"{arr_clone[i, j],5}");
        }
        Console.WriteLine();
    }
}

transpon(N, M, arr);


void min_diag_sum(int N, int M, int[,] arr)
{
    int MinSum = int.MaxValue;
    for (int i = 1; i < arr.GetLength(0); i++)
    {
        int row = i, col = arr.GetLength(1) - 1;
        int DiagSum = 0;
        for (int k = 0; k < arr.GetLength(0) - i; k++)
        {
            DiagSum += Math.Abs(arr[row, col]);
            col--;
            row++;
        }
        if (DiagSum < MinSum)
        {
            MinSum = DiagSum;
        }
    }
    int n = 1;
    for (int j = arr.GetLength(1) - 2; j > -1; j--)
    {
        int row = 0, col = j;
        int DiagSum = 0;

        for (int k = 0; k < arr.GetLength(1) - n; k++)
        {
            DiagSum += Math.Abs(arr[row, col]);

            col--;
            row++;

        }
        n++;
        if (DiagSum < MinSum)
        {
            MinSum = DiagSum;
        }
    }
    Console.WriteLine($"Min summ of diagonal elements except side diagonal is {MinSum}");
}

min_diag_sum(N, M, arr);
