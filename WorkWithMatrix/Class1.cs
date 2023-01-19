namespace WorkWithMatrix
{
    public class ConsoleWork
    {
        static public void getArr(int[,] arr, int N, int M)
        {
            Random random = new Random();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    arr[i, j] = random.Next(-1, 4);
                }
            }
        }

        static public void printArr(int[,] arr, int N, int M)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{arr[i, j]}" + "\t");
                }
                Console.WriteLine("\n");
            }
        }
    }
}