using System.Globalization;
using System.Text;
using static System.Math;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Write("Введіть к-сть рядків: ");
            uint Line = uint.Parse(Console.ReadLine());

            Console.Write("Введіть к-сть стовпців: ");
            uint Column = uint.Parse(Console.ReadLine());

            int[,] Array = new int[Line, Column];

            Random random = new Random();

            Console.WriteLine("Вигляд масиву");

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Array[i, j] = random.Next(-5, 7);
                    Console.Write($"{Array[i, j],5}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("1) Кількість додатніх елементів:");
            uint CountPositive = 0;   // Кількість додатніх елементів

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] > 0)
                    {
                        CountPositive++;
                    }
                }
            }
            Console.WriteLine($"К-сть додатніх елементів масиву: {CountPositive}");

            int[] Newarray = new int[Array.Length];  // Максимальне із чисел,що зустрічається в матриці більше одного разу
            var Duplicatearray = new List<int>();
            int size = -1;

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    size++;
                    Newarray[size] = Array[i, j];
                }
            }

            for (int i = 0; i < Newarray.Length; i++)
            {
                for (int j = i + 1; j < Newarray.Length; j++)
                {
                    if (Newarray[i] == Newarray[j])
                    {
                        Duplicatearray.Add(Newarray[i]);
                    }
                }
            }

            if (Duplicatearray.Count() > 0)
            {
                int max = Duplicatearray.Max();
                Console.WriteLine($"\n2) Максимальне із чисел, що зустрічається в заданій матриці більше одного разу: {max}");
            }
            else
            {
                Console.WriteLine("\n2) Серед чисел масиву немає жодного, що повторюється більше одного разу!");
            }

            int countline = 0, dobutok = 1; // Кількість рядків , що не містять жодного нульового елемента

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    dobutok *= Array[i, j];
                }

                if (dobutok != 0)
                {
                    countline++;
                }

                dobutok = 1;
            }

            Console.WriteLine($"\n3) К-сть рядків які не містять жодного 0-го елемента: {countline}");

            int countrow = 0;  // К-сть стовпців які містять хоча б один 0 елемент
            dobutok = 1;

            for (int i = 0; i < Array.GetLength(1); i++)
            {
                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    dobutok *= Array[j, i];
                }

                if (dobutok == 0)
                {
                    countrow++;
                }

                dobutok = 1;
            }

            Console.WriteLine($"\n4) К-сть cтовпців які містять хоча б один 0-вий елемента: {countrow}");

            Console.WriteLine("\n5) Номер рядка, в якому знаходиться найдовша серія однакових елементів");
            int Maxrepeatrow = 0, Maxinrow = 0, Maxrowindex = 0;  // Номер рядка, в якому знаходиться найдовша серія однакових елементів

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 1; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j - 1] == Array[i, j])
                    {
                        counter++;
                    }

                    else
                    {
                        counter = 0;
                    }

                    if (counter > Maxinrow)
                    {
                        Maxinrow = counter;
                    }
                }

                if (Maxinrow > Maxrepeatrow)
                {
                    Maxrepeatrow = Maxinrow;
                    Maxrowindex = i + 1;
                }
            }

            if (Maxrowindex == 0)
            {
                Console.WriteLine("Жоден рядок не має серії однакових елментів!");
            }
            else
            {
                Console.WriteLine($"Номер рядка, в якому знаходиться найдовша серія однакових елементів: {Maxrowindex}");
            }

            Console.WriteLine("\n6) Добуток елементів в тих рядках, які не мають від'ємних елементів:");
            int product = 1;   // Добуток елементів в тих рядках, які не мають від'ємних елементів

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                int counter = 0;

                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (Array[i, j] < 0)
                    {
                        counter++;
                        break;
                    }
                    else
                    {
                        product *= Array[i, j];
                    }
                }

                if (counter == 0)
                {
                    Console.WriteLine($"Добуток елементів в {i + 1} рядку: {product}");
                    product = 1;
                    counter = 0;
                }
                else
                {
                    Console.WriteLine($"Рядок {i + 1} має від'ємні елементи ");
                    product = 1;
                    counter = 0;
                }
            }

            int maxi = 0;   // Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці
            int[] diagonal = new int[Array.GetLength(0) + Array.GetLength(1)];

            for (int i = Array.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    diagonal[Array.GetLength(0) - 1 - i + j] += Array[i, j];
                }
            }

            for (int i = 0; i < Array.GetLength(0) + Array.GetLength(1) - 1; i++)
            {
                if (diagonal[i] > diagonal[maxi])
                    maxi = i;
            }

            Console.WriteLine($"\n7) Максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці:{diagonal[maxi]}");

            Console.WriteLine("\n8) суму елементів в тих стовпцях, які не містять від’ємних елементів:");
            int Sums = 0; // суму елементів в тих стовпцях, які не містять від’ємних елементів;

            for (int i = 0; i < Array.GetLength(1); i++)
            {
                int counter = 0;

                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    if (Array[j, i] < 0)
                    {
                        counter++;
                        break;
                    }
                    else
                    {
                        Sums += Array[j, i];
                    }
                }

                if (counter == 0)
                {
                    Console.WriteLine($"Cума елементів в {i + 1} cтовпчику: {Sums}");
                    Sums = 0;
                    counter = 0;
                }
                else
                {
                    Console.WriteLine($"Cтовпець {i + 1} має від'ємні елементи ");
                    Sums = 0;
                    counter = 0;
                }
            }

            int mini = 0;   // Мінімум серед сум модулів елементів діагоналей, паралельних побічній діагоналі матриці;
            int[] diagonaltwo = new int[Array.GetLength(0) + Array.GetLength(1)];

            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = Array.GetLength(1) - 1; j >= 0; j--)
                {
                    diagonaltwo[Array.GetLength(0) - 1 - i + j] += Abs(Array[i, j]);
                }
            }

            for (int i = 0; i < Array.GetLength(0) + Array.GetLength(1) - 1; i++)
            {
                if (diagonaltwo[mini] > diagonaltwo[i])
                {
                    mini = i;
                }
            }

            Console.WriteLine($"\n9) Мінімум серед сум модулів елементів діагоналей, паралельних головної діагоналі матриці:{diagonaltwo[mini]}");

            Console.WriteLine("\n10) Сумa елементів в тих стовпцях, які містять хоча б один від’ємний елемент:");
            Sums = 0;  // Суму елементів в тих стовпцях, які містять хоча б один від’ємний елемент;

            for (int i = 0; i < Array.GetLength(1); i++)
            {
                int counter = 0;

                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    if (Array[j, i] < 0)
                    {
                        Sums += Array[j, i];
                        counter++;
                    }
                    else
                    {
                        Sums += Array[j, i];
                    }
                }

                if (counter > 0)
                {
                    Console.WriteLine($"Cума елементів в {i + 1} cтовпчику: {Sums}");
                    Sums = 0;
                    counter = 0;
                }
                else
                {
                    Console.WriteLine($"Cтовпець {i + 1} не має від'ємні елементи ");
                    Sums = 0;
                    counter = 0;
                }
            }

            Console.WriteLine("\n11) Вигляд транспонованої матриці");
            for (int i = 0; i < Array.GetLength(1); i++) // Транспоновану матрицю
            {
                for (int j = 0; j < Array.GetLength(0); j++)
                {
                    Console.Write($"{Array[j, i],5}");
                }
                Console.WriteLine();
            }
        }
    }
}