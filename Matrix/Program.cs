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


//Filling matrix
for(int i = 0;i< countRow; i++)
{
    for(int j = 0; j< countCol; j++)
    {
        array[i,j] = random.Next(bottomDegre, topDegre + 1);
    }
}
//Print matrix and finding count positiv elements
int countPositivElem = 0;
for (int i = 0; i < countRow; i++)
{
    for (int j = 0; j < countCol; j++)
    {
        if (array[i, j] > 0)
        {
            countPositivElem++;
        }
        Console.Write($"{array[i, j],5}");
    }
    Console.WriteLine('\n');
}

int countRowsWithoutZero = countRow;

//Count rows without zero element
for (int i = 0; i < countRow; i++)
{
    for (int j = 0; j < countCol; j++)
    {
       if(array[i,j] ==0)
       {
           countRowsWithoutZero--;
           break;
       }
    }
}

// Count columns that have one or more zero elements
int countColWithZero = 0;
for (int i = 0; i < countRow; i++)
{
    for (int j = 0; j < countCol; j++)
    {
        if (array[j, i] == 0)
        {
            countColWithZero++;
            break;
        }
    }
}

int? maxElemMoreTwoPoints = null;
int countElem = 0;

// Max number that is in matrix more than one point

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

//номер рядка, в якому знаходиться найдовша серія однакових елементів;
//int countElemRepeatInRows = 0;
//int[,] arrayCountRepeatElemInRows = new int[countRow, countCol];

//for (int p = 0; p < countRow; p++)
//{
//    for (int k = 0; k < countCol; k++)
//    {
//        countElemRepeatInRows = 0;
//        for (int i = 0; i < countCol; i++)
//        {

//            if(array[p, k] == array[p, i])
//            {
//                countElemRepeatInRows++;
//            }

//        }
//        arrayCountRepeatElemInRows[p,k] = countElemRepeatInRows;
//    }
//}

//for (int i = 0; i < countRow; i++)
//{
//    for (int j = 0; j < countCol; j++)
//    {

//    }

//}


//The multiplication of the elements in those rows that do not contain negative elements;
int?[] arrayMultipleEachRow = new int?[countRow];
int? multipleValue = 1;
for (int i = 0; i < countRow; i++)
{
    multipleValue = 1;
    for (int j = 0; j < countCol; j++)
    {
        if(array[i, j] >= 0)
        {
            multipleValue *= array[i, j];
        }
        else
        {
            multipleValue = null;
            break;
        }
    }
    arrayMultipleEachRow[i]=multipleValue;
}

//максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці;

//int maxSumElemDiagonale = array[0, array.GetLength(1) - 1];
//int countParallelDiagonaleInArray = array.GetLength(0) - 1 + array.GetLength(1)-1;


//for(int p = 0;p< countParallelDiagonaleInArray; p++)
//{
//    for (int i = 0; i < array.GetLength(0); i++)
//    {
//        for (int j = 0; j < array.GetLength(1); j++)
//        {
//            if (i != j)
//            {
//               if()
//            }
//        }
//    }
//}











//The sum of elements in those columns that do not contain negative elements;

int?[] arraySumEachRow = new int?[countCol];
int? sumValue = 0;
for (int i = 0; i < countCol; i++)
{
   sumValue = 0;
    for (int j = 0; j < countRow; j++)
    {
        if (array[j, i] >= 0)
        {
            sumValue += array[j, i];
        }
        else
        {
            sumValue = null;
            break;
        }
    }
    arraySumEachRow[i] = sumValue;
}



//Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;


//the sum of elements in those columns that contain at least one negative element;
int?[] arraySumElement= new int?[countCol];
int? sumValueCol = 0;
bool hasNegativElem = false;
for (int i = 0; i < countCol; i++)
{
    hasNegativElem = false;
    sumValueCol = 0;
    for (int j = 0; j < countRow; j++)
    {
        if (array[j, i] < 0)
        {
            hasNegativElem = true;
        }
        sumValueCol += array[j, i];
    }
    if (hasNegativElem == true)
    {
        arraySumElement[i] = sumValueCol;
    }
    else
    {
        arraySumElement[i] = null;
    }
    
}




//транспоновану матрицю





Console.WriteLine($"Кількість додатних елементів масиву -> {countPositivElem}");
if (maxElemMoreTwoPoints == null)
{
    Console.WriteLine("В масиві відсутні числа які повторюються більше одного разу!");
}
else { 

    Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу -> {maxElemMoreTwoPoints}");
}
Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента -> {countRowsWithoutZero}");
Console.WriteLine($"Кількість стовпців, які містять хоча б один нульовий елемент -> {countColWithZero}");

for(int i = 0; i < arrayMultipleEachRow.Length; i++)
{
    if (arrayMultipleEachRow[i] != null)
    {
        Console.WriteLine($"Добуток елементів {i+1} рядка матриці -> {arrayMultipleEachRow[i]}");
    }
}

for (int i = 0; i < arraySumEachRow.Length; i++)
{
    if (arraySumEachRow[i] != null)
    {
        Console.WriteLine($"Сума елементів {i + 1} стовпця матриці який не містить від'ємний елемент -> {arraySumEachRow[i]}");
    }
}

for (int i = 0; i < arraySumElement.Length; i++)
{
    if (arraySumElement[i] != null)
    {
        Console.WriteLine($"Сума елементів {i + 1} стовпця який містить хоча б один від'ємний елемент -> {arraySumElement[i]}");
    }
}
