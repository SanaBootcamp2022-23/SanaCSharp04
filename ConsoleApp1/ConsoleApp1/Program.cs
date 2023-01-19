namespace Matrix
{
    internal class MatriXCl
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("Уведіть розміри матриці NxM");
            Console.Write("Уведіть значення m :");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Уведіть значення n :");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            var ramdom = new Random();
            Console.WriteLine("Початкова матриця:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ramdom.Next(-2, 10);
                    Console.Write($"{matrix[i, j],-5}");

                }
                Console.WriteLine();
            }
           