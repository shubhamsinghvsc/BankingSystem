namespace BankingSystem
{
    internal class Program
    {
        static void NavBar()
        {
            DateTime dateTime = DateTime.Now;
            string userName = "shubham";
            Console.WriteLine("\n\n");
            Console.WriteLine("             ----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("             |                                                  State Bank Of Bharat                                                    |");
            Console.WriteLine($"             | Date: {dateTime.Day}-{dateTime.Month}-{dateTime.Year}                                                                                            User: {userName} |");
            Console.WriteLine("             ----------------------------------------------------------------------------------------------------------------------------");

        }
        static void Main(string[] args)
        {
            NavBar();
            Console.ReadLine();
        }
    }
}
