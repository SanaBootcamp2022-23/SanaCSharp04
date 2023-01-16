
Console.Write("Введіть параметри матриці\n" +
    "Рядків: ");
int rows = int.Parse(Console.ReadLine());
Console.Write("Стовпців: ");
int num_positive=0, 
    num_rows_not_null=0,
    num_col_null=0,
    columns = int.Parse(Console.ReadLine());
bool flag_rows_not_null=true;
int[,] arr = new int[rows, columns];

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        flag_rows_not_null = true;
        Console.Write($"Arr[{i}][{j}]=");
        arr[i, j] = int.Parse(Console.ReadLine());
        if (arr[i, j] > 0)
        {
            num_positive++;
        }
        else flag_rows_not_null = false;
    }
    if (flag_rows_not_null) num_rows_not_null++;
}
int max_el = arr[rows, columns];

for (int j = 0; j < columns; j++)
{
    for (int i = 0; i < rows; i++)
    {
        if (arr[i,j]==0)
        {
            num_col_null++;
            break;
        }
    }
}

Console.WriteLine("");


for (int j = 0; j < columns; j++)
{
    for (int i = 0; i < rows; i++)
    {   
        Console.Write(arr[i, j]+" ");
    }
    Console.WriteLine();
}