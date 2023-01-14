using System.Text;

namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            bool isOk;
            short rowCount, colCount;
            do
            {
                Console.Write("Введіть кількість рядків матриці: ");
                isOk = short.TryParse(Console.ReadLine(), out rowCount);
                if (!isOk || rowCount <= 0)
                    Console.Write("Ви помилилися при введенні. Спробуйте ще.");
            } while (!isOk || rowCount <= 0 );
            do
            {
                Console.Write("Введіть кількість стовпців матриці: ");
                isOk = short.TryParse(Console.ReadLine(), out colCount);
                if (!isOk || colCount <= 0)
                    Console.Write("Ви помилилися при введенні. Спробуйте ще.");
            } while (!isOk || colCount <= 0);
            // матриця
            int[,] matrix = new int [rowCount, colCount];
            const short min = -10, max = 10;
            Matrix.FillMatrixByRandomValues(matrix, min, max);
            Console.WriteLine("Згенерована матриця:");
            Matrix.PrintMatrix(matrix);
            // приведемо матрицю до одновимірного масиву, для зручності виконання деяких завдань:
            int[] array = Matrix.ConvertToArray(matrix);
            //1) Кількість додатних елементів:
            int countOfPositiveElements = array.Count(item => item > 0);
            Console.WriteLine($"Кількість додатних елементів матриці: {countOfPositiveElements}");
            //2) максимальне із чисел, що зустрічається в заданій матриці більше одного разу:
            int maxValueThatRepeatsMoreThanOneTime = array.Max();
            bool isFound = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array.Count(item => item == maxValueThatRepeatsMoreThanOneTime) > 1)
                {
                    isFound = true;
                    break;
                }
                else
                {
                    var tmpArr = array.Where(item => item < maxValueThatRepeatsMoreThanOneTime);
                    if (tmpArr != null && tmpArr.Count() > 0)
                        maxValueThatRepeatsMoreThanOneTime = tmpArr.Max();
                }
            }
            string result = isFound ? maxValueThatRepeatsMoreThanOneTime.ToString() : "не знайдено";
            Console.WriteLine($"Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {result}");
            //3) кількість рядків, які не містять жодного нульового елемента:
            ushort countOfNotExistedZeroRows = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (!Matrix.GetRow(matrix, i).Contains(0))
                    countOfNotExistedZeroRows++;
            Console.WriteLine($"Кількість рядків, які не містять жодного нульового елемента: {countOfNotExistedZeroRows}");
            //4) кількість стовпців, які містять хоча б один нульовий елемент:
            ushort countOfExistedZeroColumns = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (Matrix.GetColumn(matrix, j).Contains(0))
                    countOfExistedZeroColumns++;
            Console.WriteLine($"Кількість стовпців, які містять хоча б один нульовий елемент: {countOfExistedZeroColumns}");
            //5) номер рядка, в якому знаходиться найдовша серія однакових елементів:
            int[] rowsMaxCountSeries = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Matrix.GetRow(matrix, i);
                int rowCountSerie = row.Count(item => item == row[0]);
                for (int j = 1; j < matrix.GetLength(1); j++)
                    if (row.Count(item => item == row[j]) > rowCountSerie)
                        rowCountSerie = row.Count(item => item == row[j]);
                rowsMaxCountSeries[i] = rowCountSerie;
            }
            Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {rowsMaxCountSeries.ToList().IndexOf(rowsMaxCountSeries.Max())}");
            //6) добуток елементів в тих рядках, які не містять від’ємних елементів:
            Console.WriteLine("Добуток елементів в тих рядках, які не містять від’ємних елементів:");
            bool isAny = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = Matrix.GetRow(matrix, i);
                if (!row.Any(item => item <= 0))
                {
                    Console.WriteLine($"Добуток елементів в {i} рядку: {row.Mul()}");
                    isAny = true;
                }
            }
            if (!isAny)
                Console.WriteLine("Не знайдено");
            //7) максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці:
            int maxSumOfAllSumsOfMatrixMainDiagonals = int.MinValue, totalSum = 0, coordRow, coordColumn;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                totalSum = 0;
                coordRow = 0;
                coordColumn = j;
                for (int k = 0; k < matrix.GetLength(0) - j; k++)
                {
                    totalSum += matrix[coordRow, coordColumn];
                    coordRow++;
                    coordColumn++;
                }
                if (totalSum > maxSumOfAllSumsOfMatrixMainDiagonals)
                    maxSumOfAllSumsOfMatrixMainDiagonals = totalSum;
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                totalSum = 0;
                coordRow = i;
                coordColumn = 0;
                for (int k = 0; k < matrix.GetLength(1) - i; k++)
                {
                    totalSum += matrix[coordRow, coordColumn];
                    coordRow++;
                    coordColumn++;
                }
                if (totalSum > maxSumOfAllSumsOfMatrixMainDiagonals)
                    maxSumOfAllSumsOfMatrixMainDiagonals = totalSum;
            }
            Console.WriteLine($"Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {maxSumOfAllSumsOfMatrixMainDiagonals}");
            //8) сума елементів в тих стовпцях, які не містять від’ємних елементів:
            Console.WriteLine("Сума елементів в тих стовпцях, які не містять від’ємних елементів:");
            isAny = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                var column = Matrix.GetColumn(matrix, j);
                if (!column.Any(item => item <= 0))
                {
                    Console.WriteLine($"Сума елементів в {j} стовпцю: {column.Sum()}");
                    isAny = true;
                }
            }
            if (!isAny)
                Console.WriteLine("Не знайдено");
            //9) мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці:
            int minAbsSumOfAllSumsOfMatrixCollateralDiagonals = int.MaxValue, totalAbsSum = 0;
            for (int j = matrix.GetLength(1) - 1, i = 0; j >= 0; j--, i++)
            {
                totalAbsSum = 0;
                coordRow = 0;
                coordColumn = j;
                for (int k = 0; k < matrix.GetLength(0) - i; k++)
                {
                    totalAbsSum += Math.Abs(matrix[coordRow, coordColumn]);
                    coordRow++;
                    coordColumn--;
                }
                if (totalAbsSum < minAbsSumOfAllSumsOfMatrixCollateralDiagonals)
                    minAbsSumOfAllSumsOfMatrixCollateralDiagonals = totalAbsSum;
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                totalAbsSum = 0;
                coordRow = i;
                coordColumn = matrix.GetLength(1) - 1;
                for (int k = 0; k < matrix.GetLength(1) - i; k++)
                {
                    totalAbsSum += Math.Abs(matrix[coordRow, coordColumn]);
                    coordRow++;
                    coordColumn--;
                }
                if (totalAbsSum < minAbsSumOfAllSumsOfMatrixCollateralDiagonals)
                    minAbsSumOfAllSumsOfMatrixCollateralDiagonals = totalAbsSum;
            }
            Console.WriteLine($"Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці: {minAbsSumOfAllSumsOfMatrixCollateralDiagonals}");
            //10) сума елементів в тих стовпцях, які містять хоча б один від’ємний елемент:
            Console.WriteLine("Сума елементів в тих стовпцях, які містять хоча б один від’ємний елемент:");
            isAny = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                var column = Matrix.GetColumn(matrix, j);
                if (column.Any(item => item < 0))
                {
                    Console.WriteLine($"Сума елементів в {j} стовпцю: {column.Sum()}");
                    isAny = true;
                }
            }
            if (!isAny)
                Console.WriteLine("Не знайдено");
            //11) транспонована матриця:
            int[,] transposedMatrix = Matrix.TransposeMatrix(matrix);
            Console.WriteLine("Транспонована матриця:");
            Matrix.PrintMatrix(transposedMatrix);
        }
    }
}