namespace BankingSystem
{
    public class Utils
    {
        // NavBar
        public static void NavBar()
        {
            DateTime dateTime = DateTime.Now;
            string userName = "shubham";
            Console.WriteLine("\n");
            Console.WriteLine("             ----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("             |                                                  State Bank Of Bharat                                                    |");
            Console.WriteLine($"             | Date: {dateTime.Day}-{dateTime.Month}-{dateTime.Year}                                                                                            User: {userName} |");
            Console.WriteLine("             ----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n");

        }

        public static void boxMaker(int boxSize, int leftPadding, string label)
        {
            string line = "";
            for (int i = 0; i < boxSize; i++)
            {
                line += "-";
            }
            line = line.PadLeft(boxSize + leftPadding, ' ');

            label = "| " + label;
            label = label.PadLeft(leftPadding + label.Length, ' ');
            label = label.PadRight((label.Length) + (boxSize + leftPadding - label.Length - 1), ' ') + "|";

            String input = "|";
            input = input.PadLeft(leftPadding + 1, ' ');
            input = input.PadRight(input.Length + boxSize - 2, ' ') + "|";

            Console.WriteLine(line);
            Console.WriteLine(label);
            Console.WriteLine(input);
            Console.WriteLine(line + "\n");
        }

        public static void boxMaker2(int boxSize, int leftPadding, string label)
        {
            string line = "";
            for (int i = 0; i < boxSize; i++)
            {
                line += "-";
            }
            line = line.PadLeft(boxSize + leftPadding, ' ');


            label = label.PadLeft(leftPadding + label.Length, ' ');
            label = label.PadRight((label.Length) + (boxSize + leftPadding - label.Length - 1), ' ');

            String input = "|";
            input = input.PadLeft(leftPadding + 1, ' ');
            input = input.PadRight(input.Length + boxSize - 2, ' ') + "|";


            Console.WriteLine(label);
            Console.WriteLine(line);
            Console.WriteLine(input);
            Console.WriteLine(line + "\n");
        }
    }
}
