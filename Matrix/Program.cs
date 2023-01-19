Console.WriteLine("Enter matrix size(n, m):");
int N = Convert.ToInt32(Console.ReadLine());
int M = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[N,M];
int[] array = new int[N * M];
Random rand = new Random();
int s = 0;
int zel = 0;
for (int i = 0; i < N; i++)
{
    bool k = true;
    for (int j = 0; j < M; j++)
    {
        int random_value = rand.Next(-10, 10);
        matrix[i,j] = random_value;
        array[s] = random_value;
        s++;
        if(matrix[i, j] == 0)
        {
            k = false;
        }
    }
    if (k)
    {
        zel++;
    }
}
int pos = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        Console.Write(string.Format("{0,4}", matrix[i, j]));
        if(matrix[i, j] > 0)
        {
            pos++;
        }
    }
    Console.Write("\n");
}
Console.Write("\n");
Console.WriteLine("Task 1: " + pos);
int[] array1 = new int[N * M];
int s1 = 0;
for (int i = 0; i < s; i++)
{
    int k = 0;
    for (int j = 0; j < s; j++)
    {
        if (array[i] == array[j]) {
            k++;
        }
    }
    if(k > 1)
    {
        array1[s1] = array[i];
        s1++;
    }
}
int max = array1[0];
for (int i = 0; i < s1; i++)
{
    if (max < array1[i])
    {
        max = array1[i];
    }
}
Console.WriteLine("Task 2: " + max);
Console.WriteLine("Task 3: " + zel);
Console.WriteLine("Task 4: " + (N - zel));


int[] array2 = new int[N];
for (int i = 0; i < N; i++)
{
    int l = 0;
    for (int j = 0; j < M; j++)
    {
        l = 0;
        for (int q = j; q < M; q++)
        {
            if (matrix[i,j] == matrix[i,q]) { 
                l++;
            }
            else
            {
                break;
            }
        }
        if (array2[i] < l)
        {
            array2[i] = l;
        }
        l = 0;
    }
}
int longs = 0;
for (int i = 0; i < N; i++)
{
    if (array2[i] > array2[longs]) {
        longs = i;
    }
}
Console.WriteLine("Task 5: " + (longs + 1));


Console.WriteLine("Task 6, 8: ");

int dob = 1, sum = 0;
for (int i = 0; i < N; i++)
{
    bool k = true;
    for (int j = 0; j < M; j++)
    {
        if (matrix[i, j] < 0)
        {
            k = false;
        }
    }
    if (k) {
        for (int j = 0; j < M; j++)
        { 
            sum += matrix[i, j];
            dob *= matrix[i, j];
        }
        Console.WriteLine((i + 1) + " - Dobutok = " + dob + " Sum = " + sum);
        dob = 1; sum = 0;  
    }
}
int max1 = 0;
if (N > 1 && M > 1)
{
    int[] array3 = new int[N + M - 3];
    for (int i = 0; i < N; i++)
    {
        for (int j = i + 1; j < M; j++)
        {
            array3[j - 1 - i] += matrix[i, j];
        }
    }
    array3[M - 2] = 0;
    for (int j = 0; j < M; j++)
    {
        for (int i = j + 1; i < N; i++)
        {
            array3[M - 2 + i - 1 - j] += matrix[i, j];
        }
    }
    array3[N + M - 4] = 0;
    max1 = array3[0];
    for (int i = 0; i < N + M - 4; i++)
    {
        if (max1 < array3[i])
        {
            max1 = array3[i];
        }
    }
}
Console.WriteLine("Task 7: " + max1);

int min2 = 0;
if (N > 1 && M > 1)
{
    int[,] matrix2 = new int[N, M];
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            matrix2[i, j] = matrix[i, M - j - 1];
        }
    }
    int[] array3 = new int[N + M - 3];
    for (int i = 0; i < N; i++)
    {
        for (int j = i + 1; j < M; j++)
        {
            array3[j - 1 - i] += Math.Abs(matrix2[i, j]);
        }
    }
    array3[M - 2] = 0;
    for (int j = 0; j < M; j++)
    {
        for (int i = j + 1; i < N; i++)
        {
            array3[M - 2 + i - 1 - j] += Math.Abs(matrix2[i, j]);
        }
    }
    array3[N + M - 4] = 0;
    min2 = array3[0];
    for (int i = 0; i < N + M - 4; i++)
    {
        if (min2 > array3[i])
        {
            min2 = array3[i];
        }
    }
}
Console.WriteLine("Task 9: " + min2);


int sum1 = 0;
Console.WriteLine("Task 10: ");

for (int i = 0; i < N; i++)
{
    bool k = true;
    for (int j = 0; j < M; j++)
    {
        if (matrix[i, j] < 0)
        {
            k = false;
        }
    }
    if (!k)
    {
        for (int j = 0; j < M; j++)
        {
            sum1 += matrix[i, j];
        }
        Console.WriteLine((i + 1) + " - Sum = " + sum1);
        sum1 = 0;
    }
}

Console.WriteLine("Task 11: ");

for (int j = 0; j < M; j++)
{
    for (int i = 0; i < N; i++)
    {
        Console.Write(string.Format("{0,4}", matrix[i, j]));
    }
    Console.Write("\n");
}