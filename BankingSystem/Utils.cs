namespace BankingSystem
{
    public class Utils
    {
        public static String whoIsLoggedIn = "";
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

        // Input Box 1
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

        // Input Box 2
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

        // Button 1
        public static void button(int boxSize, int leftPadding, string label)
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


            Console.WriteLine(line);
            Console.WriteLine(label);
            Console.WriteLine(line + "\n");
        }

        // Line 
        public static void LineMaker(int length, int padding)
        {
            string line = "";
            for (int i = 0; i < length; i++)
            {
                line += "-";
            }
            Console.WriteLine(line.PadLeft(padding, ' '));
        }

        // Heading
        public static void Heading(string heading, int padding)
        {
            Console.WriteLine(heading.PadLeft(padding + heading.Length, ' '));
            Console.WriteLine("\n\n");
        }
        // Heading Underlined
        public static void HeadingUnderlined(string heading, int padding)
        {
            string line = "-";
            for (int i = 0; i < heading.Length - 1; i++)
            {
                line += "-";
            }
            Console.WriteLine(heading.PadLeft(padding + heading.Length, ' '));
            Console.WriteLine(line.PadLeft(padding + heading.Length, ' '));
            Console.WriteLine("\n\n");
        }
        public static int OnlyIntegerInput()
        {
            string value = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool parseSuccesfull = double.TryParse(key.KeyChar.ToString(), out val);
                    if (parseSuccesfull)
                    {
                        value += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && value.Length > 0)
                    {
                        value = value.Substring(0, (value.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            if (value.Length > 0)
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return 0;
            }
        }

        public static void EraseText(int size, int x, int y)
        {
            string line = " ";
            for (int i = 0; i < size; i++)
            {
                line += " ";
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine(line);


        }
    }
}
