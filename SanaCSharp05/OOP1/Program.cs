using OOP1;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Realizing classes Airplane and Date");
        Airplane FirstTicket = new Airplane("Tokyo", "New York", new Date(2023, 2, 6, 20, 00), new Date(2023, 2, 7, 12, 45));
        Airplane SecondTicket = new Airplane("Kyiv", "London", new Date(2024, 8, 7, 20, 00), new Date(2024, 8, 8, 4, 45));
        Console.WriteLine($"Total time of First flight: {FirstTicket.GetTotalTime()} minutes");
        Console.WriteLine($"Total time of Second flight: {SecondTicket.GetTotalTime()} minutes");
        if (FirstTicket.IsArrivingToday())
            Console.WriteLine("The First flight will arrive on the same day");
        else if (SecondTicket.IsArrivingToday())
            Console.WriteLine("The Second flight will arrive on the same day");
        else
            Console.WriteLine("None of the flights will arrive on the same day");
    }
}