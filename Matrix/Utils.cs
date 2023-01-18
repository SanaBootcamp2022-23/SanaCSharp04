namespace Utils
{
    internal class Predicates
    {
        public static bool isPositive(double num) => num > 0;
        public static bool isNegative(double num) => num < 0;
    }

    internal class Idx
    {
        public static int toIdx(int num) => num - 1;
        public static int toNum(int idx) => idx + 1;
    }

    internal class Terminal
    {
        public static void NewLine(int amount = 1)
        => Enumerable.Range(0, amount)
            .ToList()
            .ForEach(i => Console.WriteLine());

        public static void PrintAsListItem(string value, bool tabbed = false)
        => Console.WriteLine($"{(tabbed ? "\t" : "")} - {value}");

        public static int ParseIntVar(string varName)
        {
            bool success;
            int result;

            do
            {
                Console.Write($"Insert value for {varName}: ");
                success = int.TryParse(Console.ReadLine(), out result);

                if (!success)
                    Console.WriteLine("\nParsing error, try again");
            } while (!success);

            return result;
        }
    }
}
