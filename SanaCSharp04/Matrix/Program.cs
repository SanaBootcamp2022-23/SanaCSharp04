using System.Text;

namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            int rowCount, colCount;
            bool fine;

            do
            {
                Console.Write("Введіть кількість рядків: ");
                fine = int.TryParse(Console.ReadLine(), out rowCount);
                if (!fine || rowCount <= 0)
                    Console.WriteLine("Помилка! Спробуйте ще раз.");
            } while (!fine || rowCount <= 0);
            do
            {
                Console.Write("Введіть кількість стовпців: ");
                fine = int.TryParse(Console.ReadLine(), out colCount);
                if (!fine || colCount <= 0)
                    Console.WriteLine("Помилка! Спробуйте ще раз.");
            } while (!fine || colCount <= 0);

            //0. Виводимо матрицю
            int[,] matrix = new int[rowCount, colCount];
            const int min = -9, max = 9;
            Matrix.RandomValuesInMatrix(matrix, min, max);
            Matrix.PrintMatrix(matrix);

            uint positiveCount = 0;
            //1. Кількість додатних елементів
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                {
                    if (matrix[i, j] > 0)
                        positiveCount++;//1
                }
            Console.WriteLine($"1. Кількість додатніх елементів: {positiveCount}");

            //2. Максимальне із чисел, що зустрічається в заданій матриці більше одного разу
            int[] array = Matrix.ConvertMatrixToArray(matrix);
            int repeatMaxValue = array.Max();
            bool findValue = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array.Count(item => item == repeatMaxValue) > 1)
                {
                    findValue = true;
                    break;
                }
                else
                {
                    var Arr = array.Where(item => item < repeatMaxValue);
                    if (Arr != null && Arr.Count() > 0)
                        repeatMaxValue = Arr.Max();
                }
            }
            string maxRepeatedValue = findValue ? repeatMaxValue.ToString() : "Такого чисела немає";
            Console.WriteLine($"2. Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: " +
                $"{maxRepeatedValue}");

            //3. Кількість рядків, які не містять жодного нульового елемента
            int rowCountZero = matrix.GetLength(0);
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                    if (matrix[i, j] == 0)
                    {
                        rowCountZero--;//3
                        break;
                    }
            Console.Write($"3. Кількість рядків, які не містять ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"нуль: ");
            Console.ResetColor();
            Console.WriteLine($"{rowCountZero}");
            
            //4. Кількість стовпців, які містять хоча б один нульовий елемент
            int colCountZero = 0;
            for (int j = 0; j < colCount; j++)
                for (int i = 0; i < rowCount; i++)
                    if (matrix[i, j] == 0)
                    {
                        colCountZero++;//4
                        break;
                    }
            Console.Write($"4. Кількість стовпців, які містять ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"нуль: ");
            Console.ResetColor();
            Console.WriteLine($"{colCountZero}");

            //5. Номер рядка, в якому знаходиться найдовша серія однакових елементів
            int[] rowSeriesOfSameElements = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Matrix.GetMatrixRow(matrix, i);
                int rowSeriesCount = row.Count(item => item == row[0]);
                for (int j = 1; j < matrix.GetLength(1); j++)
                    if (row.Count(item => item == row[j]) > rowSeriesCount)
                        rowSeriesCount = row.Count(item => item == row[j]);
                rowSeriesOfSameElements[i] = rowSeriesCount;
            }
            Console.WriteLine($"5. Індекс рядка, в якому знаходиться найдовша серія однакових елементів: " +
                $"{rowSeriesOfSameElements.ToList().IndexOf(rowSeriesOfSameElements.Max())}");

            //6. Добуток елементів в тих рядках, які не містять від’ємних елементів:
            Console.Write($"6. Добуток елементів в тих рядках, які не містять ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"від’ємних ");
            Console.ResetColor();
            Console.WriteLine($"елементів:");
            bool findProduct = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = Matrix.GetMatrixRow(matrix, i);
                if (!row.Any(item => item <= 0))
                {
                    Console.WriteLine($"Добуток елементів в {i+1} рядку: {row.Multiply()}");
                    findProduct = true;
                }
            }
            if (!findProduct)
                Console.WriteLine("Таких рядків немає");
            Console.ResetColor();

            //7. Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці:
            int diagonalCount = colCount + rowCount - 1;
            int[] diagonalSumma = new int[diagonalCount];
            int currentRow = matrix.GetUpperBound(0);
            int currentCol = 0;
            bool position = false;
            for (int k = 0; k < diagonalCount; k++)
            {
                int i = currentRow, j = currentCol;
                while (i < rowCount && j < colCount)
                {
                    diagonalSumma[k] += matrix[i, j];
                    i++;
                    j++;
                }
                if (currentRow == 0)
                    position = true;
                if (!position)
                    currentRow--;
                else
                    currentCol++;
            }
            uint maxSumIndex = 0;
            for (uint i = 1; i < diagonalCount; i++)
                if (diagonalSumma[maxSumIndex] < diagonalSumma[i])
                    maxSumIndex = i;
            Console.WriteLine($"7. Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: " +
                $"{diagonalSumma[maxSumIndex]}, має діагональ з номером: {maxSumIndex}");

            //8. Cума елементів в тих стовпцях, які не містять від’ємних елементів:
            Console.Write($"8. Сума елементів в тих стовпцях, які не містять ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"від’ємних ");
            Console.ResetColor();
            Console.WriteLine($"елементів:");
            bool findSumm = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                var column = Matrix.GetMatrixCol(matrix, j);
                if (!column.Any(item => item <= 0))
                {
                    Console.WriteLine($"Сума елементів в {j + 1} стовпцю: {column.Sum()}");
                    findSumm = true;
                }
            }
            if (!findSumm)
                Console.WriteLine("Таких стовпців немає");
            Console.ResetColor();

            //9. Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці:
            int sideDiagonalCount = colCount + rowCount - 1;
            int[] sumDiagonal = new int[sideDiagonalCount];
            int currentSideRow = 0;
            int currentSideCol = 0;
            bool before = false;
            for (uint k = 0; k < sideDiagonalCount; k++)
            {
                int i = currentSideRow, j = currentSideCol;
                while (i >= 0 && j < colCount)
                {
                    sumDiagonal[k] += Math.Abs(matrix[i, j]);
                    i--;
                    j++;
                }
                if (currentSideRow + 1 >= rowCount)
                    before = true;
                if (!before)
                    currentSideRow++;
                else
                    currentSideCol++;
            }
            uint minSumIndex = 0;
            for (uint i = 1; i < sideDiagonalCount; i++)
                if (sumDiagonal[minSumIndex] > sumDiagonal[i])
                    minSumIndex = i;
            Console.WriteLine($"9. Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: " +
                $"{sumDiagonal[minSumIndex]}, має діагональ з номером: {minSumIndex}");

            //10. Сума елементів в тих стовпцях, які містять хоча б один від’ємний елемент:
            Console.Write($"10. Сума елементів в тих стовпцях, які містять хоча б один ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"від’ємний ");
            Console.ResetColor();
            Console.WriteLine($"елемент:");
            bool fintNegativeSumm = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                var column = Matrix.GetMatrixCol(matrix, j);
                if (column.Any(item => item < 0))
                {
                    Console.WriteLine($"Сума елементів в {j + 1} стовпцю: {column.Sum()}");
                    fintNegativeSumm = true;
                }
            }
            if (!fintNegativeSumm)
                Console.WriteLine("Таких стовпців немає");
            Console.ResetColor();

            //11. Транспонована матриця:
            int[,] transposedMatrix = Matrix.TransposeMatrix(matrix);
            Console.WriteLine("11. Транспонована матриця:");
            Matrix.PrintMatrix(transposedMatrix);
        }
    }
}


