// See https://aka.ms/new-console-template for more information
using System.Text;

System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
 System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
customCulture.NumberFormat.NumberDecimalSeparator = ".";
System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int countRow, countCol;
int bottomDegre, topDegre;
bool Ok1, Ok2, Ok3, Ok4;
Random random = new Random();

do
{
    Console.Write("Введіть кількість рядків матриці -> ");
    Ok1 = int.TryParse(Console.ReadLine(), out countRow);
    if (!Ok1)
    {
        Console.WriteLine("Помилка введення");
    }
} while (!Ok1 || countRow < 1);

do
{
    Console.Write("Введіть кількість колонок матриці -> ");
    Ok2 = int.TryParse(Console.ReadLine(), out countCol);
    if (!Ok2)
    {
        Console.WriteLine("Помилка введення");
    }
} while (!Ok2 || countCol < 1);


do
{
    Console.Write("Введіть нижню межу значень елементів -> ");
    Ok3 = int.TryParse(Console.ReadLine(), out bottomDegre);
    if (!Ok3)
    {
        Console.WriteLine("Помилка введення");
    }
} while (!Ok3);


do
{
    Console.Write("Введіть верхню межу значень елементів -> ");
    Ok4 = int.TryParse(Console.ReadLine(), out topDegre);
    if (!Ok4)
    {
        Console.WriteLine("Помилка введення");
    }
} while (!Ok4 || topDegre < bottomDegre);

double[] array = new double[countCol*countRow];




int countPositivElem = 0;

for(int i = 0;i< array.Length; i++)
{
    array[i] = random.Next(bottomDegre, topDegre + 1);
    if (array[i] > 0)
    {
        countPositivElem++;
    }
}



