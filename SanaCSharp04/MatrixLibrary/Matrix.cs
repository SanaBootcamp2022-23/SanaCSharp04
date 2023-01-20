using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixLibrary
{
    public class Matrix
    {
        public static int[,] GenerateMatrix(int n, int m)
        {
            Random random = new Random();
            int[,] arr = new int[n,m];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(-1, 6);
                }
            return arr;
        }

        public static void outPut(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],10}");
                }
                Console.WriteLine("");
            }
        }
        public static int PosotiveCount(int[,] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > 0)
                        count++;
                }
            }
            return count;
        }

       

        public static int LineCountWithoutZero(int[,] arr)
        {
            int LineZeroCount = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                        count++;
                }
                if(count>0)
                    LineZeroCount++;
            }
            int res = arr.GetLength(0) - LineZeroCount;
            return res;
        }

        public static int ColumnCountWithZero(int[,] arr)
        {
            int LineZeroCount = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int count = 0;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] == 0)
                        count++;
                }
                if (count > 0)
                    LineZeroCount++;
            }
            return LineZeroCount;
        }

        public static int MultipleRowsWithoutNegative(int[,] arr)
        {
           List<int> list = new List<int>();
               
           for (int i = 0; i < arr.GetLength(0); i++)
                {
                   int RowIndex = -1;
               for (int j = 0; j < arr.GetLength(1); j++)
               {
                  if (arr[i, j] < 0)
                  {
                    RowIndex = i;
                  }
               }
                if (RowIndex != -1)
                    list.Add(RowIndex);
           }

            int multiple = 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (list.IndexOf(i) != -1)
                    continue;
                else
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        multiple *= arr[i, j];
                    }
                }
            }
            return multiple;
        }


        public static int SumColumnsWithoutNegative(int[,] arr)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int RowIndex = -1;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] < 0)
                    {
                        RowIndex = i;
                    }
                }
                if (RowIndex != -1)
                    list.Add(RowIndex);
            }

            int sum = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
               for (int j = 0; j < arr.GetLength(0); j++)
               {
                    if (list.IndexOf(i) != -1)
                        continue;
                    else
                       sum += arr[j, i];
               }
            }
        return sum;
        }

        public static int SumColumnsWithNegative(int[,] arr)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int RowIndex = -1;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] < 0)
                    {
                        RowIndex = i;
                    }
                }
                if (RowIndex != -1)
                    list.Add(RowIndex);
            }

            int sum = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (list.IndexOf(i) == -1)
                        continue;
                    else
                        sum += arr[j, i];
                }
            }
            return sum;
        }


        public static void Transposed(int[,] arr)
        {
            Console.WriteLine("Transpose:");
            int[,] newArr = new int [arr.GetLength(1),arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    newArr[i, j] = arr[j, i];
                }
            }

            for (int i = 0; i < newArr.GetLength(0); i++)
            {
                for (int j = 0; j < newArr.GetLength(1); j++)
                {
                    Console.Write($"{newArr[i, j],7}");
                }
                Console.WriteLine();
            }
        }

        public static void DiagonalMaxParalelToMain(int[,] arr)
        {
            int start, move, sum;
            List<int> listSum = new List<int>();
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                start = 0;
                move = i;
                sum = 0;
                for (int j = 0; j < arr.GetLength(1)-i; j++)
                {
                    sum += arr[start, move];
                    start++;
                    move++;
                }
                listSum.Add(sum);
            }
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                start = i;
                move = 0;
                sum = 0;
                for (int j = 0; j < arr.GetLength(1) - i; j++)
                {
                    sum += arr[start, move];
                    start++;
                    move++;
                }
                listSum.Add(sum);
                
            }
            int max = listSum[0];
            for (int i = 0; i < listSum.Count; i++)
            {
                if (listSum[i] > max) max = listSum[i];
            }
            Console.WriteLine("Max between sums of diagonals of paralels of main:");
            for (int i = 0; i < listSum.Count; i++)
            {
                Console.Write($"{listSum[i],3}");
            }
            Console.WriteLine();
            Console.WriteLine($"Max paralel diagonal sum = {max}");

        }

        public static void DiagonalMinParalelToSecond(int[,] arr)
        {
            int start, move, sum, step = 1, secstep = 1;
            List<int> listSum = new List<int>();
            for (int i = arr.GetLength(0) - 1-1; i >= 0; i--)
            {
                start = 0;
                move = i;
                sum = 0;
                for (int j = arr.GetLength(1) - 1 - step; j >= 0; j--)
                {
                    // Console.WriteLine($"arr[{start},{move}]");
                    sum += Math.Abs(arr[start, move]);
                    start++;
                    move--;
                }
                listSum.Add(sum);
                step++;
            }
           // Console.WriteLine($"------------------------------");

            for (int i = 1; i < arr.GetLength(0); i++)
            {
                start = arr.GetLength(0) - 1;
                move = i;
                sum = 0;
                for (int j = arr.GetLength(1) - 1 - secstep; j >= 0; j--)
                {
                    //Console.WriteLine($"arr[{start},{move}]");
                    sum += Math.Abs(arr[start, move]);
                    start--;
                    move++;
                }
                listSum.Add(sum);
                secstep++;
            }


            int min = listSum[0];
            for (int i = 0; i < listSum.Count; i++)
            {
                if (listSum[i] < min) min = listSum[i];
            }
            Console.WriteLine("Min between ABS => |sums| of diagonals of paralels of second:");
            for (int i = 0; i < listSum.Count; i++)
            {
                Console.Write($"{listSum[i],3}");
            }
            Console.WriteLine();
            Console.WriteLine($"Min second paralel diagonal sum = {min}");

        }

     
        public static int FindMaxList(List<int> list)
        {
            int max = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > max) max = list[i];
            }
            return max;
        }
        public static List<int> ArrayToList(int[,] arr)
        {
            List<int> list = arr.Cast<int>().ToList();
            return list;
        }
        public static void MaxNumOverOneTime(int[,] arr)
        {
            bool isFind = false;
            List<int> list = ArrayToList(arr);
            int FirsMax = 0, SecMax = 0;

            do
            {

                FirsMax = FindMaxList(list);
                //Console.WriteLine($"Max  number : {FirsMax}");
                list.RemoveAt(list.IndexOf(FirsMax));
                SecMax = FindMaxList(list);
                //Console.WriteLine($"Max  number2 : {SecMax}");
                if (FirsMax == SecMax)
                {
                    isFind = true;
                }

            } while (!isFind);
            Console.WriteLine($"Max  number, that is finded more than 1 time is : {FirsMax}");
        }




        public static void NumberRowWithHighestCountOfDublicates(int[,] arr)
        {
            Console.WriteLine("Duplicates: ");

            int[] RowElements = new int[arr.GetLength(1)];
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    RowElements[j] = arr[i, j];
                }
                int count;
                var duplicatesToList = RowElements.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Row = i, Item = y.Key, Count = y.Count() })
              .ToList();
                var duplicatesToDict = RowElements.GroupBy(x => x)
               .Where(g => g.Count() > 1)
               .ToDictionary(x => i, y => y.Count());
                foreach (var item in duplicatesToDict)
                {
                    dictionary.Add(item.Key, item.Value);
                }
                for (int j = 0; j < duplicatesToList.Count; j++)
                {
                    Console.WriteLine(duplicatesToList[j]);
                }
            }
            List<int> ListWithMaxes = new List<int>();
            int max = int.MinValue;
            foreach (var item in dictionary)
            {
                if (item.Value > max) {
                    max = item.Value;
                }
            }
            foreach (var item in dictionary)
            {
                if (item.Value == max)
                {
                    ListWithMaxes.Add(item.Key);
                }
            }
            if (ListWithMaxes.Count != 0)
            {
                Console.Write("All max duplicates in rows: ");
                for (int i = 0; i < ListWithMaxes.Count; i++)
                {
                    Console.Write($" {ListWithMaxes[i]},");
                }
            }
            else {
                Console.Write($"No duplicates in row!");
            }

        }
        }
}
