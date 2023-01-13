using Matrix;
using System.Dynamic;
using System.Formats.Asn1;
using System.Numerics;

namespace Matrix
{
    class Program
    {
        static int[,]Matrix;
        static uint RowCount = 0, ColCount = 0;
        static void Main(string[] args)
        {
            int start = 0, finish = 0;
            try
            {
                Console.Write("Enter the count of matrix rows: ");
                RowCount = uint.Parse(Console.ReadLine());
                Console.Write("Enter the count of matrix cols: ");
                ColCount = uint.Parse(Console.ReadLine());
                Console.WriteLine("Enter the interval of matrix: ");

                if (RowCount <= 0 || ColCount <= 0)
                    ExitWithError("Incorrect size of matrix.");

                Console.Write("start: ");
                start = int.Parse(Console.ReadLine());
                Console.Write("finish: ");
                finish = int.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                ExitWithError(ex.ToString());
            }

            Matrix = MyMatrix.GenerateRandomMatrix(RowCount, ColCount, start, finish);
            MyMatrix.DisplayMatrix(Matrix);
            SubTask1();
            SubTask2();
            SubTask3();
            SubTask4();
            SubTask5();
            SubTask6();
            SubTask7();
            SubTask8();
            SubTask9();
            SubTask10();
            SubTask11();
        }

        #region SubTask
        static void SubTask1()
        {
            //1. Count of positive elements
            ColorText("\nSubTask1:", 12);
            uint countPos = 0;
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    if (Matrix[i, j] > 0)
                        countPos++;
            Console.WriteLine($"Count of positive elements: {countPos}");

        }
        static void SubTask2()
        {
            //2. Maximal value that repeat more than one time 
            ColorText("\nSubTask2:", 12);
            int maxValue = Matrix[0, 0];
            bool exist = false;
            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColCount; j++)
                    if (Matrix[i, j] > maxValue)
                    {
                        bool next = false;
                        for (int iTemp = 0; iTemp < RowCount && !next; iTemp++)
                            for (int jTemp = 0; jTemp < ColCount && !next; jTemp++)
                                if (Matrix[i, j] == Matrix[iTemp, jTemp] && i != iTemp)
                                {
                                    maxValue = Matrix[i, j];
                                    next = true;
                                    exist = true;
                                }
                    }

            string outputText;
            if (!exist)
                outputText = "don't exist";
            else
                outputText = maxValue.ToString();
            Console.WriteLine($"Maximal value that repeat more then one time: {outputText}");
        }
        static void SubTask3()
        {
            //3. Count of rows that haven't element zero
            ColorText("\nSubTask3:", 12);
            uint countRowsWithoutZero = 0;
            for (int i = 0; i < RowCount; i++)
            {
                bool existZero = false;
                for (int j = 0; j < ColCount; j++)
                    if (Matrix[i, j] == 0)
                    { existZero = true; break; }
                if (!existZero)
                    countRowsWithoutZero++;
            }
            Console.WriteLine($"Count of rows that haven't elemnet zero: {countRowsWithoutZero}");
        }
        static void SubTask4()
        {
            //4. Count of cols that have element zero
            ColorText("\nSubTask4:", 12);
            uint countColsWithZero = 0;
            for (int j = 0; j < ColCount; j++)
            {
                for (int i = 0; i < RowCount; i++)
                    if (Matrix[i, j] == 0)
                    {
                        countColsWithZero++;
                        break;
                    }
            }
            Console.WriteLine($"Count of cols that have element zero: {countColsWithZero}");
        }
        static void SubTask5()
        {
            //5. Number of row that have largest series of same elements

            //Gets array with count of max series in rows\
            ColorText("\nSubTask5:", 12);
            uint[,] rowInfo = new uint[RowCount, 1];
            for (int i = 0; i < RowCount; i++)
            {
                uint maxCountRepeat = 0;
                for (int j = 0; j < ColCount; j++)
                {
                    uint countRepeat = 0;
                    for (int jTemp = 0; jTemp < ColCount; jTemp++)
                        if (jTemp != j && Matrix[i, j] == Matrix[i, jTemp])
                            countRepeat++;
                    if (countRepeat > maxCountRepeat)
                        maxCountRepeat = countRepeat;

                }
                rowInfo[i, 0] = maxCountRepeat;
            }

            //Gets number of rows that have max series repeat
            uint maxSeries = 0;
            for (int i = 1; i < RowCount; i++)
                if (rowInfo[i, 0] > maxSeries)
                    maxSeries = rowInfo[i, 0];

            //Output all rows, which have max series
            Console.Write($"Number of row that have largest series of same elements: ");
            for (int i = 0; i < RowCount; i++)
                if (rowInfo[i, 0] == maxSeries)
                    Console.Write($"{i}, ");
            Console.WriteLine($"count of repeat = {maxSeries}");
        }
        static void SubTask6()
        {
            //Product of elements in rows that haven't negative elements
            ColorText("\nSubTask6:", 12);
            for (uint i = 0; i < RowCount; i++)
            {
                int product=1;
                bool negElement = false;
                for (uint j = 0; j < ColCount; j++)
                {
                    if (Matrix[i, j] >= 0)
                        product *= Matrix[i, j];
                    else
                    {
                        negElement = true;
                        break;
                    }
                }
                if (!negElement)
                    Console.WriteLine($"Product of {i} row: {product}");
                else
                    Console.WriteLine($"Row {i} have negative element");
            }
        }
        static void SubTask7()
        {
            //Maximum value diagonal sum of parallel to main diagonal 
            ColorText("\nSubTask7:", 12);
            uint countDiagonal = ColCount + RowCount - 1;
            int[] sumDiagonal = new int[countDiagonal];
            int curI = Matrix.GetUpperBound(0);
            int curJ = 0;
            bool before = false;
            for (uint k = 0; k < countDiagonal; k++){
                int i=curI, j=curJ;
                while (i<RowCount&& j<ColCount)
                {
                    sumDiagonal[k] += Matrix[i, j];
                    i++;
                    j++;
                }

                if (curI == 0)
                    before = true;

                if (!before)
                    curI--;
                else
                    curJ++;
            }
            
            //Gets index of max sum with array
            uint indexMaxSum = 0;
            for (uint i = 1; i < countDiagonal; i++)
                if (sumDiagonal[indexMaxSum] < sumDiagonal[i])
                    indexMaxSum = i;

            //Display the color matrix and value of max side diagonal sum
            MyMatrix.DisplayMatrixDiagonalColor(Matrix);
            Console.WriteLine($"Maximal value diagonal sum of parallel to main diagonal: {sumDiagonal[indexMaxSum]}, have diagonal with number: {indexMaxSum}");
        }
        static void SubTask8()
        {
            //Sum of elements in cols that haven't negative elements
            ColorText("\nSubTask8:", 12);
            for (uint j = 0; j < ColCount; j++)
            {
                int sum = 0;
                bool negElement = false;
                for (uint i = 0; i < RowCount; i++)
                {
                    if (Matrix[i, j] >= 0)
                        sum += Matrix[i, j];
                    else
                    {
                        negElement = true;
                        break;
                    }
                }
                if (!negElement)
                    Console.WriteLine($"Sum elements of {j} col: {sum}");
                else
                    Console.WriteLine($"Col {j} have negative element");
            }
        }
        static void SubTask9()
        {
            //Minimal value of the sum of elements of diagonal parallel to the side diagonal 
            ColorText("\nSubTask9:", 12);
            uint countDiagonal = ColCount + RowCount - 1;
            int[] sumDiagonal = new int[countDiagonal];
            int curI = 0;
            int curJ = 0;
            bool before = false;
            for (uint k = 0; k < countDiagonal; k++)
            {
                int i = curI, j = curJ;
                while (i >=0 && j < ColCount)
                {
                    sumDiagonal[k] += Math.Abs(Matrix[i, j]);
                    i--;
                    j++;
                }

                if (curI + 1 >= RowCount)
                    before = true;

                if (!before)
                    curI++;
                else
                    curJ++;
            }

            //Gets the index of the min sum with array
            uint indexMinSum = 0;
            for (uint i = 1; i < countDiagonal; i++)
                if (sumDiagonal[indexMinSum] > sumDiagonal[i])
                    indexMinSum = i;

            //Display the color matrix and value of min diagonal sum
            MyMatrix.DisplayMatrixSideDiagonalColor(Matrix);
            Console.WriteLine($"Minimal value of the sum of elements of the diagonal parallel to the side diagonal: {sumDiagonal[indexMinSum]}, have diagonal with number: {indexMinSum}");
        }
        static void SubTask10()
        {
            //Sum of elements cols that have at least one negative element
            ColorText("\nSubTask10:", 12);
            for (uint j = 0; j < ColCount; j++)
            {
                int sum = 0;
                bool negElement = false;
                for (uint i = 0; i < RowCount; i++)
                {
                    sum += Matrix[i, j];
                    if (Matrix[i,j]<0)
                        negElement = true;
                }
                if (negElement)
                    Console.WriteLine($"Sum elements of {j} col: {sum}");
                else
                    Console.WriteLine($"Col {j} haven't negative element");
            }

        }
        static void SubTask11()
        {
            //Gets transposed matrix
            ColorText("\nSubTask11",12);
            Matrix = MyMatrix.TransponsMatrix(Matrix);
            Console.WriteLine("Transosed matrix:");
            MyMatrix.DisplayMatrix(Matrix);
        }
        #endregion

        #region Additional functions
        static void ExitWithError(string ex)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Program crashed: " + ex);
            Environment.Exit(1);
        }
        static void ColorText(string text, short color)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        #endregion
    }
}