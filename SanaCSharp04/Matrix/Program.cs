using System.Text;
using System.Threading.Tasks.Dataflow;
using static System.Console;
using static System.Math;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Random rnd = new Random();

int N, M;

Write("Введіть кількість рядків матриці:");
N = int.Parse(ReadLine());

Write("Введіть кількість стовпців матриці:");
M = int.Parse(ReadLine());

int[,] mat = new int[N,M];

WriteLine("\nМатриця, згенерована на проміжку [-5;20]:");

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        mat[i,j] = rnd.Next(-5,20);
        Write("|{0,4}|", mat[i,j]);
    }
    WriteLine("");
}

int coutpos = 0;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        if (mat[i, j] > 0)
            coutpos++;
    }
}

WriteLine("\n1.Кількість додатніх елементів матриці:{0}", coutpos);

int[] masfmax = new int[N * M];
int n = 0, fl = 0;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        foreach (int rep in mat)
        {
            if (rep == mat[i, j] && fl == 1)
            {
                masfmax[n] = mat[i, j];
                n++;
                break;
            }

            if (rep == mat[i, j] && fl == 0)
            {
                fl = 1;
            }
        }

        fl = 0;
    }
}

int maxmas = masfmax[0];

for (int i = 0; i < n; i++)
{
    if (maxmas < masfmax[i])
        maxmas = masfmax[i];
}

WriteLine("\n2.Mаксимальне із чисел, що зустрічається в заданій матриці більше одного разу:{0}", maxmas);

int countlinewithoutzero = 0;
fl = 0;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        if (mat[i, j] == 0)
        {
            countlinewithoutzero++;
            break;
        }
    }
}

WriteLine("\n3.Kількість рядків, які не містять жодного нульового елемента:{0}", N - countlinewithoutzero);

int countcolumnwithzero = 0;
fl = 0;

for (int j = 0; j < M; j++)
{
    for (int i = 0; i < N; i++)
    {
        if (mat[i, j] == 0)
        {
            countcolumnwithzero++;
            break;
        }
    }
}

WriteLine("\n4.Kількість стовпців, які містять хоча б один нульовий елемент:{0}", countcolumnwithzero);

int numline = -1, maxser = 0, ser = 0;
fl = 0;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        for (int l = j + 1; l < M; l++)
        {
            if (mat[i, j] == mat[i, l])
                ser++;
        }
    }

    if (ser > maxser)
    {
        numline = i;
        maxser = ser;
    }
    ser = 0;
}

if (numline == -1)
{
    WriteLine("\n5.Такого рядка, в якому знаходиться найдовша серія однакових елементів, не найдено");
}
else
{
    WriteLine("\n5.Hомер рядка, в якому знаходиться найдовша серія однакових елементів:{0}", numline + 1);
}

int dob = 1;
fl = 0;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        if (mat[i, j] < 0)
            fl = 1;
    }

    if (fl != 1)
    {
        for (int l = 0; l < M; l++)
        {
            dob *= mat[i, l];
        }
        WriteLine("\n6.Добуток елементів в тих рядках (рядок #{0}), які не містять від’ємних елементів:{1}", i + 1, dob);
    }
    else
    {
        WriteLine("\n6.В рядку {0} є від'ємні числа.", i + 1);
    }
    dob = 1;
    fl = 0;
}

int maxdiag = 0;
int[] sumdiagonals = new int[N + M - 1];

for (int i = N - 1; i > -1; i--)
{
    for (int j = 0; j < M; j++)
    {
        sumdiagonals[N - 1 - i + j] += mat[i, j];
    }
}

for (int i = 0; i < N + M - 1; i++)
{
    if (sumdiagonals[i] > sumdiagonals[maxdiag])
        maxdiag = i;
}

WriteLine("\n7.Mаксимум серед сум елементів діагоналей, паралельних головній діагоналі матриці:{0}", sumdiagonals[maxdiag]);

int sum = 0;
fl = 0;

for (int i = 0; i < M; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (mat[j, i] < 0)
            fl = 1;
    }

    if (fl != 1)
    {
        for (int l = 0; l < N; l++)
        {
            sum += mat[l, i];
        }
        WriteLine("\n8.Сума елементів в стовпчику {0}:{1}", i + 1, sum);
    }

    else
    {
        WriteLine("\n8.В стовпчику {0} є від'ємні числа.", i + 1);
    }
    sum = 0;
    fl = 0;
}

int mindiag = 0;
int[] sumdiagonals2 = new int[N + M - 1];

for (int i = N - 1; i > -1; i--)
{
    for (int j = 0; j < M; j++)
    {
        sumdiagonals2[N - 1 - i + j] += Abs(mat[i, j]);
    }
}

for (int i = 0; i < N + M - 1; i++)
{
    if (sumdiagonals2[i] < sumdiagonals2[mindiag])
        mindiag = i;
}

WriteLine("\n9.Mінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці:{0}", sumdiagonals2[mindiag]);

int sum2 = 0;
fl = 0;

for (int i = 0; i < M; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (mat[j, i] < 0)
            fl = 1;
    }

    if (fl == 1)
    {
        for (int l = 0; l < N; l++)
        {
            sum2 += mat[l, i];
        }
        WriteLine("\n10.Сума елементів в стовпчику {0}:{1}", i + 1, sum2);
    }

    else
    {
        WriteLine("\n10.В стовпчику {0} немає від'ємних чисел.", i + 1);
    }
    sum2 = 0;
    fl = 0;
}

int[,] mattr = new int[M, N];

WriteLine("\nТранспонована матриця:");

for (int i = 0; i < M; i++)
{
    for (int j = 0; j < N; j++)
    {
        mattr[i, j] = mat[j, i];
        Write("|{0,4}|", mattr[i, j]);
    }
    WriteLine("");
}