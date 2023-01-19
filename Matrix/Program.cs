

int N, M;
Console.Write("N = ");
N = int.Parse(Console.ReadLine());
Console.Write("M = ");
M = int.Parse(Console.ReadLine());
int[,] array = new int[N, M];

Random rnd = new Random();
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        array[i, j] = rnd.Next(-10, 10);
    }
}

int result1 = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        if (array[i, j] > 0)
        {
            result1++;
        }
    }
}

int result2 = 0;
int[] max1 = new int[N];
for (int i = 0; i < N; i++)
{
    int count1 = 0;
    for (int j = 0; j < M; j++)
    {
        if (array[i, j] >= max1[i])
        {
            if (max1[i] == array[i, j])
                count1++;
            max1[i] = array[i, j];
        }
    }

    if (count1 >= 1 && result2 < max1[i])
    {
        result2 = max1[i];
    }
}

int result3 = 0;
for (int i = 0; i < N; i++)
{
    bool flag = false;
    for (int j = 0; j < M; j++)
    {
        if (array[i, j] == 0)
        {
            flag = true;
        }
    }

    if (!flag)
    {
        result3++;
    }
}

int result4 = 0;
for (int j = 0; j < M; j++)
{
    bool flag4 = false;
    for (int i = 0; i < N; i++)
    {
        if (array[i, j] == 0)
        {
            flag4 = true;
        }
    }

    if (flag4)
    {
        result4++;
    }
}

int[] count5 = new int[N];
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        for (int k = j + 1; k < M; k++)
        {
            if (array[i, j] == array[i, k])
            {
                // Console.Write($"{array[i, j]} ");
                count5[i]++;
            }
        }
    }
}
int result5 = Array.IndexOf(count5, count5.Max());

int result6 = 1;
for (int i = 0; i < N; i++)
{
    int multiple = 0;
    bool flag = false;
    for (int j = 0; j < M; j++)
    {
        if (array[i, j] > 0)
        {
            multiple *= array[i, j];
        }
        else flag = true;
    }

    if (!flag)
    {
        result6 *= multiple;
    }
}

int result7 = 0, matr = 0;
int size = N < M ? N : M;
int[] sums = new int[size];
for (int i = 0; i < size; i++)
{
    for (int j = i + matr; j < size + matr && j < size; j++)
    {
        sums[i] += array[i, j];
    }

    matr++;
}
result7 = sums.Max();

int result8 = 0;
for (int j = 0; j < M; j++)
{
    int sum8 = 0;
    bool flag = false;
    for (int i = 0; i < N; i++)
    {
        if (array[i, j] < 0)
        {
            flag = true;
        }
        sum8 += array[i, j];
    }

    if (!flag)
    {
        result8 += sum8;
    }
}

int matr9 = 0;
int size9 = N < M ? N : M;
int[] sums9 = new int[size9];
for (int i = 0; i < size9; i++)
{
    for (int j = i + matr; j < size9 + matr9; j++)
    {
        sums9[i] += array[j, i];
    }

    matr9++;
}
int result9 = sums9.Min();

int result10 = 0;
for (int j = 0; j < M; j++)
{
    int sum10 = 0;
    bool flag = false;
    for (int i = 0; i < N; i++)
    {
        if (array[i, j] < 0)
        {
            flag = true;
        }
        sum10 += array[i, j]; 
    }

    if (flag)
    {
        result10 += sum10;
    }
}


/* Results output */
Console.WriteLine("Matrix:\n");
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        Console.Write($"{array[i, j]}\t");
    }
    Console.Write("\n");
}

Console.WriteLine($"\n1. Count of elements above zero: {result1}");
Console.WriteLine($"2. Max element (countMax > 1): {result2}");
Console.WriteLine($"3. Rows count (no zero): {result3}");
Console.WriteLine($"4. Cols count (with zero): {result4}");
Console.WriteLine($"5. Row number with max length elem: {result5}");
Console.WriteLine($"6. Multiple elements (in rows which elem>0): {result6}");
Console.WriteLine($"7. Max sum main diagonal: {result7}");
Console.WriteLine($"8. Sum elements (in cols which elem>0): {result8}");
Console.WriteLine($"9. Min sum secondary diagonal: {result9}");
Console.WriteLine($"10. Sum elements in cols (at least 1 elem < 0): {result10}");
