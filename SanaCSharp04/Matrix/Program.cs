namespace Matrix
{
   //Усі рядки виводяться згідно завдань , якщо в завданні сказано за номером , виводиться номер ( 1 ,2 ,3)
   //     Якщо сказано за індексом - індекс ( 0,1,2)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("Введіть размірність матриці NxM");
            Console.Write("Введіть значення m :");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введіть значення n :");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            var ramdom = new Random();
            Console.WriteLine("Початкова матриця:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = ramdom.Next(-2, 10);
                    Console.Write($"{matrix[i, k],-5}");

                }
                Console.WriteLine();
            }
            int? resultFirtsTast = firstTast(matrix);
            Console.WriteLine("Кількість позитивних елементів : {0}", resultFirtsTast == null ? 0 : resultFirtsTast);
            int? resultSecondTast = secondTast(matrix);
            Console.WriteLine("Максимальне із чисел, що зустрічається в заданій матриці більше одного разу : {0}", resultSecondTast == null ? "такого елемента не існує" : resultSecondTast);
            int? resultThirdTast = thirdTask(matrix);
            Console.WriteLine("Kількість рядків, які не містять жодного нульового елемента:{0}", resultThirdTast == null ? 0 : resultThirdTast);
            int? resultFourth = fourthTask(matrix);
            Console.WriteLine("Kількість стовпців, які містять хоча б один нульовий елемент:{0}", resultFourth == null ? 0 : resultFourth);
            int? resultFifth = fifthTask(matrix);
            Console.WriteLine("Hомер рядка, в якому знаходиться найдовша серія однакових елементів:{0}", resultFifth == null ? "такого рядка не існує" : resultFifth);
            sixthTask(matrix);
            Console.WriteLine("Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці(не враховуючи саму головну діагональ): {0}", seventhTask(matrix));
            eigthTast(matrix);
            Console.WriteLine("Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці(не враховуючи саму побічну діагональ): {0}", ninethTast(matrix));
            tenthTast(matrix);
            eleventhTast(matrix);
        }

        static private int? firstTast(int[,] matrix)
        {
            int? numberOfPozitiveElements = 0;
            foreach (var element in matrix)
            {
                if (element > 0) numberOfPozitiveElements++;
            }

            return numberOfPozitiveElements > 0 ? numberOfPozitiveElements : null;
        }

        static private int? secondTast(int[,] matrix)
        {
            List<int> repeatedNumberOFMatrix = new List<int>();
            foreach (var element in matrix)
            {
                int counter = 0;
                foreach (var j in matrix)
                {
                    if (counter >= 2) { repeatedNumberOFMatrix.Add(element); break; }
                    if (element == j) { counter++; }

                }

            }
            int? maxElement = repeatedNumberOFMatrix.Count > 0 ? repeatedNumberOFMatrix[0] : null;
            if (maxElement != null)
            {
                foreach (var j in repeatedNumberOFMatrix)
                {
                    if (maxElement < j) { maxElement = j; }

                }
            }


            return maxElement;
        }

        static private int? thirdTask(int[,] matrix)
        {
            int countOfCols = 0;
            int count = 1;
            int numberOfZero = 0;
            foreach (var element in matrix)
            {
                if (element == 0) numberOfZero++;

                if (count == matrix.GetLength(1))
                {
                    if (numberOfZero == 0)
                        countOfCols++;

                    numberOfZero = 0;
                    count = 0;
                }
                count++;
            }


            return countOfCols == 0 ? null : countOfCols;
        }

        static private int? fourthTask(int[,] matrix)
        {
            int countOfRows = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[k, i] == 0) { countOfRows++; break; }
                }
            }


            return countOfRows == 0 ? null : countOfRows;
        }

        static private int? fifthTask(int[,] matrix)
        {

            int findedValueOfMatrix = 0;
            int maxValueOfMatrix = 0;
            int maxRow = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[i, j] == matrix[i, k]) findedValueOfMatrix++;
                    }
                }
                if (findedValueOfMatrix > maxValueOfMatrix)
                {
                    maxRow = i;
                    maxValueOfMatrix = findedValueOfMatrix;
                }
                findedValueOfMatrix = 0;
            }


            return maxRow == -1 ? null : maxRow + 1;
        }

        static private void sixthTask(int[,] matrix)
        {
            Console.WriteLine("Добуток елементів в тих рядках, які не містять від’ємних елементів");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int productOfMaterix = 1;
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] >= 0) productOfMaterix *= matrix[i, k];
                    else { productOfMaterix = -1; break; }
                }

                if (productOfMaterix != -1) Console.WriteLine("Добуток елементів у {0} рядку = {1}", i + 1, productOfMaterix);
                productOfMaterix = 1;

            }



        }

        static private int seventhTask(int[,] matrix)
        {
            int[] array = new int[2 * (matrix.GetLength(0)> matrix.GetLength(1)? matrix.GetLength(0) : matrix.GetLength(1)) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {   
                    if(i!= matrix.GetLength(1) - 1 - j)
                        array[i+j] += matrix[i, matrix.GetLength(1) - 1 - j];
                }
            return array.Max();

        }

        static private void eigthTast(int[,] matrix)
        {
            Console.WriteLine("Суму елементів в тих стовпцях, які не містять від’ємних елементів;");

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sumtOfMaterix = 0;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[k, i] >= 0) sumtOfMaterix += matrix[k, i];
                    else { sumtOfMaterix = -1; break; }
                }

                if (sumtOfMaterix != -1) Console.WriteLine("Сума елементів у {0} рядку = {1}", i + 1, sumtOfMaterix);
                sumtOfMaterix = 0;

            }



        }

        static private int ninethTast(int[,] matrix) 
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            int[] array;
            if (m==n)
            array = new int[2 * (matrix.GetLength(0) > matrix.GetLength(1) ? matrix.GetLength(0) : matrix.GetLength(1)) -1];
            else
                array = new int[2 * (matrix.GetLength(0) > matrix.GetLength(1) ? matrix.GetLength(0) : matrix.GetLength(1)) - Math.Abs(m-n)-1];


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[i + j] += Math.Abs(matrix[i,j]);
                }
                
            }

            return array.Min();
        }

        static private void tenthTast(int[,] matrix)
        {
            Console.WriteLine("Суму елементів в тих стовпцях, які  містять хоча б один від’ємний елемент");

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                bool indecator = false;
                int sumOfMaterix = 0;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    sumOfMaterix += matrix[k, i];
                    if (matrix[k, i] < 0) indecator = true;
                }

                if (indecator) Console.WriteLine("Сума елементів у {0} стовбці = {1}", i + 1, sumOfMaterix);
                sumOfMaterix = 0;

            }

        }

        static private void eleventhTast(int[,] matrix)
        {
            Console.WriteLine("Транспонована матриця");
            for (int i = 0; i < matrix.GetLength(1); i++)
            {

                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    Console.Write($"{matrix[k, i],-5}");

                }
                Console.WriteLine();
            }


        }
    }
}