using System.Diagnostics;
using System.Dynamic;

class Matrix
{
	public static void Main()
	{
		uint row = 0, col = 0;
		int[,] matrix = new int[1, 1];
		NewMatrix(ref row, ref col, ref matrix);
		ShowMatrix(matrix, row,col);
		Console.WriteLine($"Count of positive numbers : {CountOfPositiveNumbers(matrix, row, col)}");
		Console.WriteLine($"Max number that occurs at least once : {MaxNumberAtLeastOnce(matrix, row, col)}");
		Console.WriteLine($"Rows without zeros : {RowsWithoutZeros(matrix, row, col)}");
		Console.WriteLine($"Columns with zeros : {ColumnsWithZeros(matrix, row, col)}");
		RowWithSameNumbers(matrix, row, col);
		Console.Write("Result of multiplication : ");
		foreach (int i in PositiveRowMultiplication(matrix, row, col))
		{
			if (i == 1 || i < 0)
			{
				Console.Write("_ ");
			}
			else
			{
				Console.Write($"{i} ");
			}
		}
		Console.WriteLine($"\nMax of sum main diagonals : {SumMainDiagonal(matrix, row, col)}");
		ColSumWithoutNegative(matrix, row, col);
		Console.Write($"\nMax of absolute sum sub diagonals : {SumSubDiagonal(matrix, row, col)}");
		ColSumWithNegative(matrix, row, col);
		TransponMatrix(matrix, row, col);

	}
	public static void NewMatrix(ref uint row, ref uint col, ref int[,] matrix)
	{
		int rangeBegin, rangeEnd;
		Console.Write("Enter row count:");
		row = uint.Parse(Console.ReadLine());
		Console.Write("Enter col count:");
		col = uint.Parse(Console.ReadLine());
		matrix= new int[row, col];
		Console.Write("Enter a range begin:");
		rangeBegin = int.Parse(Console.ReadLine());
		Console.Write("Enter a range end:");
		rangeEnd = int.Parse(Console.ReadLine());
		Random random = new Random();
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				matrix[i, j] = random.Next(rangeBegin, rangeEnd);
			}
		}
	}
	public static void ShowMatrix(int[,] matrix, uint row, uint col)
	{
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (matrix[i, j] >= 0)
				{
					Console.Write($" {matrix[i, j]}\t");
				}
				else
				{
					Console.Write($"{matrix[i, j]}\t");
				}
			}
			Console.WriteLine("");
		}
	}
	public static int CountOfPositiveNumbers(int[,] matrix, uint row, uint col)
	{
		int countOfPositive = 0;
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (matrix[i, j] >= 0)
				{
					countOfPositive++;
				}
			}
		}
		return countOfPositive;
	}
	public static int MaxNumberAtLeastOnce(int[,] matrix, uint row, uint col)
	{
		int maxRepeatNumber = 0;
		int temp1 = 0, temp2 = 0;
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				temp1 = i;
				temp2 = j;
				for (int n = 0; n < row; n++)
				{
					for (int m = 0; m < col; m++)
					{
						if (matrix[i, j] == matrix[n, m] && !(n == i && m == j) && matrix[i, j] > maxRepeatNumber)
						{
							maxRepeatNumber = matrix[i, j];
						}
					}
				}
			}
		}
		return maxRepeatNumber;
	}
	public static uint RowsWithoutZeros(int[,] matrix, uint row, uint col)
	{
		uint rowsWithoutZerosCount = row;
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (matrix[i, j] == 0)
				{
					rowsWithoutZerosCount--;
					break;
				}
			}
		}
		return rowsWithoutZerosCount;
	}
	public static int ColumnsWithZeros(int[,] matrix, uint row, uint col)
	{
		int columnsWithZerosCount = 0;
		for (int i = 0; i < col; i++)
		{
			for (int j = 0; j < row; j++)
			{
				if (matrix[j, i] == 0)
				{
					columnsWithZerosCount++;
				}
			}
		}
		return columnsWithZerosCount;
	}
	public static void RowWithSameNumbers(int[,] matrix, uint row, uint col)
	{
		List<int> rowResults = new List<int>();
		List<int> results = new List<int>();
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				int temp, count = 0;
				for (int k = 0; k < col; k++)
				{
					if (matrix[i, j] == matrix[i, k] )
						count++;
				}
				rowResults.Add(count);
				count = 0;
			}
			int maxLocalElement = rowResults.Max();
			rowResults = new List<int>();
			results.Add(maxLocalElement);
			maxLocalElement = 0;
		}
		int index = -1, maxElement = results.Max();
		for (int i = 0; i < row; i++)
		{
			if (results[i] == maxElement && maxElement > 1)
			{
				index = i + 1;
				break;
			}
		}
		if (index != -1)
		{
			Console.WriteLine($"Row with max count of same elements : {index}");
		}
		else
		{
			Console.WriteLine("Matrix haven`t same rows!");
		}
	}
	public static int[] PositiveRowMultiplication(int[,] matrix, uint row, uint col)
	{
		bool temp = true;
		int mult = 1;
		int[] results = new int[row];
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (matrix[i, j] == 0)
				{
					temp = false;
				}
			}
			if (temp)
			{
				for (int k = 0; k < col; k++)
				{
					mult *= matrix[i, k];
				}
			}
			results[i] = mult;
			mult= 1;
			temp = true;
		}
		return results;
	}
	public static int SumMainDiagonal(int[,] matrix, uint row, uint col)
	{
		int sum = 0, k;
		int i = Convert.ToInt32(row - 1);
		List<int> diagonalSums = new List<int>();
		for (int j = 0; j < col+row-1; j++)
		{
			k = j;
			i = Convert.ToInt32(row - 1);
			for (;i >= 0 && k >= 0;k--)
			{
				if (k < col)
				{
					sum += matrix[i, k];
				}
				i--;
			}
			diagonalSums.Add(sum);
			sum = 0;
		}
		return diagonalSums.Max();
	}
	public static void ColSumWithoutNegative(int[,] matrix, uint row, uint col)
	{
		int sum = 0;
		List<int> colSum = new List<int>();
		for (int j = 0; j < col; j++)
		{
			for (int i = 0; i < row; i++)
			{
				if (matrix[i, j] >= 0) 
				{
					sum += matrix[i, j];
				}
				else
				{
					sum = -1;
					break;
				}
			}
			colSum.Add(sum);
			sum = 0;
		}
		Console.Write("Positive column sum : ");
		for (int i = 0; i < col; i++)
		{
			if (colSum[i] >= 0)
			{
				Console.Write($"{colSum[i]} ");
			}
			else
			{
				Console.Write("_ ");
			}
		}
	}
	public static int SumSubDiagonal(int[,] matrix, uint row, uint col)
	{
		int sum = 0, k;
		int i = Convert.ToInt32(row - 1);
		List<int> diagonalSums = new List<int>();
		for (int j = 0; j < col + row - 1; j++)
		{
			k = j;
			i = 0;
			for (; i >= 0 && k >= 0; k--)
			{
				if (k < col && i < row)
				{
					sum += Math.Abs(matrix[i, k]);
				}
				i++;
			}
			diagonalSums.Add(sum);
			sum = 0;
		}
		return diagonalSums.Max();
	}
	public static void ColSumWithNegative(int[,] matrix, uint row, uint col)
	{
		int sum = 0;
		bool detector = false;
		List<int> colSum = new List<int>();
		for (int j = 0; j < col; j++)
		{
			for (int i = 0; i < row; i++)
			{
				if (matrix[i, j] < 0)
				{
					sum += matrix[i, j];
					detector = true;
				}
				else
				{
					sum += matrix[i, j];
				}
			}
			if (detector)
			{
				colSum.Add(sum);
			}
			else
			{
				colSum.Add(0);
			}
			sum = 0;
			detector = false;
		}
		Console.Write("\nColumn sum with negative numbers : ");
		for (int i = 0; i < col; i++)
		{
			if (colSum[i] != 0)
			{
				Console.Write($"{colSum[i]} ");
			}
			else
			{
				Console.Write("_ ");
			}
		}
		Console.WriteLine("");
	}
	public static void TransponMatrix(int[,] matrix, uint row, uint col)
	{
		if (col == row)
		{
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					if (matrix[j, i] >= 0)
					{
						Console.Write($" {matrix[j, i]}\t");
					}
					else
					{
						Console.Write($"{matrix[j, i]}\t");
					}
				}
				Console.WriteLine("");
			}
		}
		else
		{
			Console.WriteLine("Matrix should have same rows and columns!");
		}
	}
}
