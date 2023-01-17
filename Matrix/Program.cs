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


int[,] array = new int[countRow, countCol];
int [] arrayAddition = new int[countRow*countCol];


//Filling array
for(int i = 0;i< countRow; i++)
{
    for(int j = 0; j< countCol; j++)
    {
        array[i,j] = random.Next(bottomDegre, topDegre + 1);
        Console.WriteLine(array[i,j]);
    }
}


int countPositivElem = 0;
// Array operations
for (int i = 0; i < countRow; i++)
{
    for (int j = 0; j < countCol; j++)
    {
       if(array[i,j] > 0)
       {
            countPositivElem++;
       }
    }
}
Console.WriteLine($"Кількість додатних елементів масиву -> {countPositivElem}");


int? maxElemMoreTwoPoints = null;
int countElem = 0;

for (int p = 0; p < countRow; p++)
{
    
    for (int k = 0; k < countCol; k++)
    {
        countElem = 0;
        for (int i = 0; i < countRow; i++)
        {
            for (int j = 0; j < countCol; j++)
            {
                if (array[p, k] == array[i, j])
                {
                    countElem++;
                }

                if (countElem > 1)
                {
                    if(maxElemMoreTwoPoints == null)
                    {
                        maxElemMoreTwoPoints = array[p, k];
                    }else if(maxElemMoreTwoPoints< array[p, k])
                    {
                        maxElemMoreTwoPoints = array[p, k];
                    }
                } 
            }
        }
    }
}
if (maxElemMoreTwoPoints == null)
{
    Console.WriteLine("В масиві відсутні числа які повторюються більше одного разу!");
}
else { 

    Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу -> {maxElemMoreTwoPoints}");
}
