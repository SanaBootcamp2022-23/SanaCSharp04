using System.Text;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Write(" Введіть кількість рядків N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Введіть кількість стовпців M: ");
            int M = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[N, M];

            //ініціалізація масиву
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(-5, 10);
                }
            }

            //виводжу масив на екран
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],5}\t");
                }
                Console.WriteLine();
            }

            //First
            int Positive(int[,] arr)
            {
                int countPos = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] > 0)
                            countPos++;
                    }
                }
                return countPos;
            }
            Console.WriteLine("\n 1) Кількість додатніх чисел: " + Positive(arr));


            //Second
            int MaxElementMoreThanOne(int[,] arr)
            {
                bool fl = false;
                int max = 0;
                do
                {
                    max = arr[0, 0];
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (max < arr[i, j])
                                max = arr[i, j];
                        }
                    }
                    int count = 0;
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            if (arr[i, j] == max)
                                count++;
                        }
                    }

                    if (count > 1) fl = true;
                    else
                    {
                        for (int i = 0; i < arr.GetLength(0); i++)
                        {
                            for (int j = 0; j < arr.GetLength(1); j++)
                            {
                                if (arr[i, j] == max)
                                    arr[i, j] = -15;
                            }
                        }
                    }

                } while (!fl);
                int result = max;
                return result;
            }

            if (MaxElementMoreThanOne(arr) == -15)
                Console.WriteLine(" 2) Немає найбільшого числа, яке повторюється більше одного разу");
            else
                Console.WriteLine(" 2) Максимальне число, яке повторюється більше одного разу: " + MaxElementMoreThanOne(arr));


            //Third
            int rowsWithoutNull(int[,] arr)
            {
                int first = 1;
                int countRows = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] == 0)
                            first = 0;
                    }
                    countRows += first;
                    first = 1;
                }
                return countRows;
            }

            if (rowsWithoutNull(arr) == 0)
                Console.WriteLine(" 3) Немає рядків без нуля");
            else
                Console.WriteLine(" 3) Кількість рядків без нуля: " + rowsWithoutNull(arr));


            //Fourth
           int colsWithNull(int[,] arr)
            {
                int first = 0;
                int countCols = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        if (arr[i, j] == 0)
                            first = 1;
                    }
                    countCols += first;
                    first = 0;
                }
                return countCols;
            }

           if (colsWithNull(arr) == 0)
               Console.WriteLine(" 4) Немає стовпців з нулем");
           else
               Console.WriteLine(" 4) Кількість стовпців з нулем: " + colsWithNull(arr));


           //Fifth
            int Set(int[,] arr)
            {
                int set = 0, maxset = -1, index = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 1; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] == arr[i, j - 1])
                            set++;
                    }

                    if (maxset < set)
                    {
                        maxset = set;
                        index = i + 1;
                    }
                    set = 0;
                }
                return index;
            }

            Console.WriteLine(" 5) Найдовша серія з однакових чисел була в рядку " + Set(arr));
        }
    }
}

