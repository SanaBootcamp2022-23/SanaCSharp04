using System.Text;

System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
customCulture.NumberFormat.NumberDecimalSeparator = ".";
System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;


int[,] matrix = CreateNewMatrix();

GenerateMatrixWithRandom(matrix);
PrintMatrix(matrix);
FindCountOfPositiveElems(matrix);

Console.ReadLine();



int[,] CreateNewMatrix()
{
    int n, m;
    bool isNOk = false, isMOk = false;

    do
    {
        Console.WriteLine("\nВведіть n: ");
        isNOk = int.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Введіть m: ");
        isMOk = int.TryParse(Console.ReadLine(), out m);

    } while (isMOk != true && isNOk != true);

    int[,] matrix = new int[n, m];

    return matrix;
}

void FindCountOfPositiveElems(int[,] matrix)
{
    int counter = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > 0)
                counter++;
        }
    }

    Console.WriteLine($"Кількість додатніх елементів: {counter}");
}

void GenerateMatrixWithRandom(int[,] matrix)
{
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(-10, 10);
        }
    }
}

void SetMatrixNumbers(int[,] matrix)
{
    bool isOk = false;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            do
            {
                Console.WriteLine($"Введіть matrix[{i},{j}]: ");
                isOk = int.TryParse(Console.ReadLine(), out matrix[i, j]);
            } while (isOk != true);
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write("\t" + matrix[i, j]);
        }
        Console.WriteLine();
    }
}