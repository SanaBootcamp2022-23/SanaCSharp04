using MatrixLibrary;
using System.Runtime.CompilerServices;
using System.Text;

namespace Matrix
{

	internal class Program
	{
		static void inputIntNumber(ref int value, string variableName)
		{
			Console.Write($"Введіть значення змінної {variableName}: ");
			try
			{
				value = int.Parse(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.WriteLine("Введіть число!");
				inputIntNumber(ref value, variableName);
			}
		}

		static void Task_01(int[,] matrix)
		{
			int count = 0;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] > 0)
					{
						count++;
					}
				}
			}
			Console.WriteLine("Кількість додатніх елементів = {0}", count);
		}
		static void Task_02(int[,] matrix)
		{
			int max = matrix[0, 0];
			int[] arr = new int[matrix.GetLength(0) * matrix.GetLength(1)];

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					arr[i * matrix.GetLength(1) + j] = matrix[i, j];
				}
			}
			Array.Sort(arr);
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write($"{arr[i]} ");
			}
			Console.WriteLine();
			for (int i = arr.Length - 1; i > 0; i--)
			{
				if (arr[i] == arr[i - 1])
				{
					Console.WriteLine("Максимальний елемент = {0}", arr[i]);
					break;
				}
			}
		}
		static void Task_03(int[,] matrix)
		{
			int count = matrix.GetLength(0);
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] == 0)
					{
						count--;
						break;
					}
				}
			}
			Console.WriteLine("Кількість рядків, що не містять нуль = {0}", count);
		}
		static void Task_04(int[,] matrix)
		{
			int count = 0;
			for (int i = 0; i < matrix.GetLength(1); i++)
			{
				for (int j = 0; j < matrix.GetLength(0); j++)
				{
					if (matrix[j, i] == 0)
					{
						count++;
						break;
					}
				}
			}
			Console.WriteLine("Кількість стовпчиків, що містять хоча б 1 нуль = {0}", count);
		}
		static void Task_05(int[,] matrix)
		{
			int[] combo = new int[matrix.GetLength(0)];
			int max = 0, count = 0;

			for (int i = 0; i < matrix.GetLength(0); i++)
			{

				max = 0;
				count = 0;
				for (int j = 0; j < matrix.GetLength(1)-1; j++)
				{
					if (matrix[i, j] == matrix[i, j + 1])
					{
						count++;
						continue;
					}
						
					if (matrix[i, j] != matrix[i, j + 1] || j + 1 != matrix.GetLength(1))
					{
						if (count > max)
						{
							max = count;
							count = 0;
						}
					}
				}
				combo[i] = max;
				Console.Write("{0} ",combo[i]);
			}
			max = 0;
			int max_i = 0;
			for (int i = 0; i < combo.Length; i++)
				if (combo[i] > max)
				{
					max = combo[i];
					max_i= i;
				}

			Console.WriteLine("Номер рядка з найбільшою серією = {0}", max_i+1);
		}
		static void Task_06(int[,] matrix)
		{
			int dob;
			bool skip;

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				dob = 1;
				skip = false;
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (matrix[i, j] < 0)
					{
						skip = true;
						break;
					}
					else
					{
						dob *= matrix[i, j];
					}
				}
				if (!skip)
				{
					Console.WriteLine("Добуток елементів {0}-го рядка = {1}", i + 1, dob);
				}
			}
		}
		static void Task_07(int[,] matrix)
		{
			int max=matrix.GetLength(0), min=-matrix.GetLength(1)+1;
			int sum = 0;
			List<int> list = new List<int>();

			for (int l = min; l < max; l++)
			{
				sum = 0;
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					for (int j = 0; j < matrix.GetLength(1); j++)
					{
						if (i - j == l)
						{
							sum+= matrix[i, j];
						}
					}
				}
				list.Add(sum);
			}

			max = list[0];
			for (int i = 0; i < list.Count; i++)
			{
				Console.Write("{0} ",list[i]);
				if (list[i] > max)
					max = list[i];
			}
			Console.WriteLine("Максимум серед сум діагоналей = {0}",max);
			

		}
		static void Task_08(int[,] matrix)
		{
			int sum = 0;
			bool skip = false;

			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				sum = 0;
				skip = false;
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					if (matrix[i, j] > 0)
					{
						sum += matrix[i, j];
					}
					else
					{
						skip = true;
						break;
					}
				}
				if (!skip)
				{
					Console.WriteLine("Сума елементів {0}-го стовбчика = {1}",
						j+1, sum);
				}
			}
		}
		static void Task_09(int[,] matrix)
		{
			int max = matrix.GetLength(0)+matrix.GetLength(1)-1, min = 0;
			int sum = 0;
			List<int> list = new List<int>();

			for (int l = min; l < max; l++)
			{
				sum = 0;
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					for (int j = 0; j < matrix.GetLength(1); j++)
					{
						if (i + j == l)
						{
							sum += Math.Abs(matrix[i, j]);
						}
					}
				}
				list.Add(sum);
			}

			min = list[0];
			for (int i = 0; i < list.Count; i++)
			{
				Console.Write("{0} ",list[i]);
				if (list[i] < min)
					max = list[i];
			}
			Console.WriteLine("Мінімум серед сум модулів елементів поб діагоналі = {0}", min);

		}
		static void Task_10(int[,] matrix)
		{
			int sum = 0;
			bool skip;

			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				sum = 0;
				skip = true;
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					sum += matrix[i, j];

					if (matrix[i, j] < 0)
					{
						skip = false;
					}
				}
				if (!skip)
				{
					Console.WriteLine("Сума елементів {0}-го стовбчика = {1}",
						j + 1, sum);
				}
			}
		}
		static void Task_11(int[,] matrix)
		{
			int[,] additional_matrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					additional_matrix[j, i] = matrix[i, j];
				}
			}
			MatrixLib.printMatrix(additional_matrix);
		}


		static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;

			int N = 4, M = 8;
			/*inputIntNumber(ref N, "N");
			inputIntNumber(ref M, "M");*/
			int[,] arr = new int[N, M];
			MatrixLib.fillRandMatrix(arr, -2, 3);
			MatrixLib.printMatrix(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("1.");
			Task_01(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("2.");
			Task_02(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("3.");
			Task_03(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("4.");
			Task_04(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("5.");
			Task_05(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("6.");
			Task_06(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("7.");
			Task_07(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("8.");
			Task_08(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("9.");
			Task_09(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("10.");
			Task_10(arr);


			Console.WriteLine("--------------");
			Console.WriteLine("11.");
			Task_11(arr);


			

		}
	}
}