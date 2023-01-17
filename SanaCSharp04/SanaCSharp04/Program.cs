using System;
using System.Linq;    
using System.Collections.Generic;

namespace SanaCSharp04
{

    class Program
    {
        //range to generate numbers
        public static int A = -1, B = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix size: ");
            int n = int.Parse(Console.ReadLine()), m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            Random rnm = new Random();

            for(int i = 0;i < n; i++)
            {
                for(int j = 0; j < m;j++)
                {
                    matrix[i, j] = rnm.Next() % (B - A + 1) + A;

                    Console.Write(string.Format("{0,4}", matrix[i,j]));
                }
                Console.WriteLine();
            }

            IEnumerable<int> queue = matrix.Cast<int>();

            //count of positive numbers
            int count = queue.Where((x) => x > 0).Count();
            Console.WriteLine("Count of positive numbers: " + count);

            //max repeated number
            bool finded = false;
            int max = A;
            foreach(int num in queue)
            {
                if (queue.Count((x) => x == num) > 1 && num > max)
                {
                    finded = true;
                    max = num;
                }
            }
            Console.WriteLine(finded?"Max repeated number: " + max:"Matrix doesn't contain repeated numbers");

            //count of rows without zero
            count = n;

            for(int i = 0; i < n; i++)
            {
                bool contains = false;

                for(int j = 0; j < m; j++)
                {
                    if(matrix[i,j] == 0)
                    {
                        contains = true;
                        break;
                    }
                }
                if (contains) count--;
            }

            Console.WriteLine("Count of rows without zero: " + count);

            //count of colons that contains at least one zero
            count = 0;

            for(int j = 0; j < m; j++)
            {
                bool contains = false;

                for(int i = 0; i < n; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        contains = true;
                        break;
                    }
                }
                if (contains) count++;
            }
            Console.WriteLine("Count of colums that contains at least one zero: " + count);

            //longest identical sub-sequence
            int longestlength = 0, row = 0;

            for(int i = 0; i < n; i++)
            {
                int[] map = new int[m];
                map[0] = 1;

                for(int j = 1; j < m; j++)
                {
                    if (matrix[i, j] == matrix[i, j]) map[j] = map[j - 1] + 1;
                }

                int maxlen = map.Max();
                if (maxlen > longestlength)
                {
                    row = i;
                    longestlength = maxlen;
                }
            }

            Console.WriteLine("Row with the longest identical sub-sequence: " + row);

            //multiply rows that without negative numbers

            Console.WriteLine("Multiply of rows that without negative numbers:");
            for(int i = 0; i < n; i++)
            {
                int mul = 1;
                bool contains_negative = false;
                for(int j = 0; j < m; j++)
                {
                    if(matrix[i,j] < 0)
                    {
                        contains_negative = true;
                        break;
                    }

                    mul *= matrix[i, j];
                }

                if (contains_negative == false)
                    Console.WriteLine($"{i + 1} row: {mul}");
            }

            //max sum of all diagonals that parallel main diagonal
            int maxsum = A * Math.Max(n, m);

            for(int k = 0; k < n; k++) // start point
            {
                int i = k, j = 0;
                int sum = 0;
                for (; i < n && j < m;){

                    sum += matrix[i, j];

                    i++; j++;
                }

                if (maxsum < sum) maxsum = sum;
            }
            for(int k = 1; k < m; k++)//main diagonal we don't count
            {
                int i = 0, j = k;
                int sum = 0;
                for (; i < n && j < m;)
                {
                    sum += matrix[i, j];

                    i++; j++;
                }

                if (maxsum < sum) maxsum = sum;
            }

            Console.WriteLine("Max sum of all diagonals that parallel to main " + maxsum);


            //sum of rows that without negative numbers

            Console.WriteLine("Sum of rows that without negative numbers:");
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                bool contains_negative = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        contains_negative = true;
                        break;
                    }

                    sum += matrix[i, j];
                }

                if (contains_negative == false)
                    Console.WriteLine($"{i + 1} row: {sum}");
            }

            //max sum of all diagonals that parallel antidiagonal
             maxsum = A * Math.Max(n, m);

            for (int k = 0; k < n; k++) // start point
            {
                int i = k, j = 0;
                int sum = 0;
                for (; i < n && j >= 0;)
                {

                    sum += matrix[i, j];

                    i++; j--;
                }

                if (maxsum < sum) maxsum = sum;
            }
            for (int k = 1; k < m; k++)//antidiagonal we don't count
            {
                int i = 0, j = k;
                int sum = 0;
                for (; i < n && j >= 0;)
                {
                    sum += matrix[i, j];

                    i++; j--;
                }

                if (maxsum < sum) maxsum = sum;
            }

            Console.WriteLine("Max sum of all diagonals that parallel to antidiagonal " + maxsum);

            Console.WriteLine("Sum of colums that have at least one negative numbers:");
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                bool contains_negative = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                        contains_negative = true;

                    sum += matrix[i, j];
                }

                if (contains_negative == true)
                    Console.WriteLine($"{i + 1} row: {sum}");
            }

            //matrix transport
            int[,] matrix_t = new int[m, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    matrix_t[j, i] = matrix[i, j];
                }
            }

            Console.WriteLine("Transported matrix");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0,4}", matrix_t[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
