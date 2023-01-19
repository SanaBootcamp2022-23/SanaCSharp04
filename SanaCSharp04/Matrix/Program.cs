using System;
            int rowCount, colCount;
            int counter, maxRepeatRow = 0, coordRow, coordCol;
            int positiveCount = 0, rowsWithoutZero = 0, colWithZero = 0, rowWithMaxRepetition = 0;
            double maxRepeatingValue = 0, multiplicationResult = 0, summa = 0, maxDiagonalSum = int.MinValue, sumPositiveCols = 0, minDiagonalSum = int.MaxValue, sumNegativeCols = 0;

            Console.WriteLine("К-ть рядків:");
            rowCount = int.Parse(Console.ReadLine());
            Console.WriteLine("К-ть стовпчиків:");
            colCount = int.Parse(Console.ReadLine());

            double[,] arr = new double[rowCount, colCount];
            Random random = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(-1000, 1001);
                    Console.Write($"{arr[i, j]} \t");


                    if (arr[i, j] > 0)
                        positiveCount++;

                    for (int i2 = i; i2 < arr.GetLength(0); i2++)       
                    {
                        for (int j2 = j + 1; j2 < arr.GetLength(1); j2++)
                        {
                            if (arr[i2, j2] == arr[i, j] && arr[i, j] > maxRepeatingValue)
                            {
                                maxRepeatingValue = arr[i, j];
                            }
                        }
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < arr.GetLength(0); i++)       
            {
                counter = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                        counter++;
                }
                if (counter == 0)
                    rowsWithoutZero++;
            }

            for (int j = 0; j < arr.GetLength(0); j++)      
            {
                counter = 0;
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    if (arr[i, j] == 0)
                        counter++;
                }
                if (counter > 0)
                    colWithZero++;
            }

            for (int i = 0; i < arr.GetLength(0); i++) 
            {
                counter = 0;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == arr[i, j - 1])
                    {
                        counter++;
                    }
                }
                if (counter > maxRepeatRow)
                {
                    maxRepeatRow = counter;
                    rowWithMaxRepetition = i;
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)   
            {
                counter = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < 0)
                    {
                        counter++;
                    }
                }
                if (counter == 0)
                {
                    for (int k = 0; k < arr.GetLength(1); k++)
                    {
                        multiplicationResult *= arr[i, k];
                    }
                }
            }

            for (int j = 1; j < arr.GetLength(1); j++)  
            {
                coordRow = 0;
                coordCol = j;
                summa = 0;
                while (coordRow < arr.GetLength(0) && coordCol < arr.GetLength(1))
                {
                    summa += arr[coordRow, coordCol];
                    coordRow++;
                    coordCol++;
                }
                if (summa > maxDiagonalSum)
                {
                    maxDiagonalSum = summa;
                }
            }

            for (int i = 1; i < arr.GetLength(0); i++) 
            {
                coordRow = i;
                coordCol = 0;
                summa = 0;
                while (coordRow < arr.GetLength(0) && coordCol < arr.GetLength(1))
                {
                    summa += arr[coordRow, coordCol];
                    coordRow++;
                    coordCol++;
                }
                if (summa > maxDiagonalSum)
                {
                    maxDiagonalSum = summa;
                }
            }

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                counter = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, j] < 0)
                    {
                        counter++;
                    }
                }
                if (counter == 0)
                {
                    for (int a = 0; a < arr.GetLength(0); a++)
                    {
                        sumPositiveCols += arr[a, j];
                    }
                }
            }

for (int i = 1; i < arr.GetLength(0); i++)
{ {
        summa = 0;
        coordRow = i;
        coordCol = arr.GetLength(1) - 1;
        while (coordRow < arr.GetLength(0) && coordCol >= 0)
        {
            summa += Math.Abs(arr[coordRow, coordCol]);
            coordRow++;
            coordCol--;
        }
        if (summa < minDiagonalSum)
        {
            minDiagonalSum = summa;
        }
    }
    for (int j = arr.GetLength(1) - 2; j >= 0; j--)
    {
        coordRow = 0;
        coordCol = j;
        summa = 0;
        while (coordRow < arr.GetLength(0) && coordCol >= 0)
        {
            summa += Math.Abs(arr[coordRow, coordCol]);
            coordRow++;
            coordCol--;
        }
        if (summa < minDiagonalSum)
        {
            minDiagonalSum = summa;
        }
    }

    for (int j = 0; j < arr.GetLength(1); j++)
    {
        counter = 0;
        for (int k = 0; k < arr.GetLength(0); k++)
        {
            if (arr[k, j] < 0)
            {
                counter++;
            }
        }
        if (counter > 0)
        {
            for (int a = 0; a < arr.GetLength(0); a++)
            {
                sumNegativeCols += arr[a, j];
            }
        }
    }

    Console.WriteLine("Транспонована матриця:");
    for (int k = 0; k < arr.GetLength(1); k++)
    {
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            Console.Write($"{arr[j, k],5}");
        }
        Console.WriteLine();
    }

    Console.WriteLine($"К-ть додматнії елементів = {positiveCount}");
    Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу = {maxRepeatingValue}");
    Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента = {rowsWithoutZero}");
    Console.WriteLine($"Кількість стовпців, які містять хоча б один нульовий елемент = {colWithZero}");
    Console.WriteLine($"Рядок, в якому знаходиться найдовша серія однакових елементів = {rowWithMaxRepetition}");
    Console.WriteLine($"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці = {maxDiagonalSum}");
    Console.WriteLine($"Добуток елементів в тих рядках, які не містять від’ємних елементів = {sumPositiveCols}");
    Console.WriteLine($"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці = {minDiagonalSum}");
    Console.WriteLine($"Сума елементів в тих стовпцях, які  містять хоча б один від’ємний елемент= {sumNegativeCols}");
}
   