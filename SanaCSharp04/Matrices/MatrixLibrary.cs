

namespace MatrixLibrary
{
	public class MatrixLib
	{
		static public void fillRandMatrix(int[,] matrix, int leftBorder, int rigthBorder)
		{
			Random rn= new Random();
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i,j]=rn.Next(leftBorder,rigthBorder);
				}
			}
		}

		static public void printMatrix(int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write($"{matrix[i,j]}\t");
				}
				Console.WriteLine();
			}
			
		}
	}
}