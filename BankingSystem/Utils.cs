using BankingSystem.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BankingSystem
{
    public class Utils
    {
        public static String whoIsLoggedIn = "";
        public static String LoggedUserName = "";

        public static string filePath = "users.json";
        public static List<Users> LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                return new List<Users>();
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Users>>(json) ?? new List<Users>();
        }

        public static void SaveUsers(List<Users> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public static void DisplayError(int cordinateX, int cordinateY, string message, int sleepDuration = 1500)
        {
            Console.SetCursorPosition(cordinateX, cordinateY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Thread.Sleep(sleepDuration);
            Console.ResetColor();
            Console.SetCursorPosition(cordinateX, cordinateY);
            Console.Write(new string(' ', message.Length));
        }
        public static void DisplaySuccess(int cordinateX, int cordinateY, string message, int sleepDuration = 1500)
        {
            Console.SetCursorPosition(cordinateX, cordinateY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Thread.Sleep(sleepDuration);
            Console.SetCursorPosition(cordinateX, cordinateY);
            Console.Write(new string(' ', message.Length));
        }

        public static bool IsEmailExist(List<Users> users, string email)
        {
            return users.Any(user => user.Email == email);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            try
            {
                email = email.ToLower();
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // NavBar
        public static void NavBar2()
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

        public static void NavBar()
        {
            int boxSize = 130;
            int padding = 10;
            string line = "-";
            for (int i = 1; i < boxSize; i++)
            {
                line += "-";
            }
            line = line.PadLeft(padding + boxSize, ' ');

            string bankName = "State Bank of Bharat";
            DateTime dateTime = DateTime.Now;
            string userName = "shubham";
            string secondLine = "";
            string paddingLine = "";
            for (int i = 0; i < padding; i++)
            {
                paddingLine += " ";
            }
            secondLine += paddingLine;
            secondLine += $"|  Date: {dateTime.Day}-{dateTime.Month}-{dateTime.Year}";
            string name = LoggedUserName;
            string username = (LoggedUserName.Length > 0 ? $"User: {name}  |" : "|");

            string middlespace = "";
            int time = (boxSize + padding) - (secondLine.Length + username.Length);
            for (int i = 0; i < time; i++)
            {
                middlespace += " ";
            }
            secondLine = secondLine + middlespace + username;

            string title = "";

            title += paddingLine + "|";
            int size = (boxSize - 3) - bankName.Length;
            size = size / 2;
            for (int i = 0; i < size; i++)
            {
                title += " ";
            }
            title += bankName;
            for (int i = 0; i <= size; i++)
            {
                title += " ";
            }

            title += (bankName.Length % 2 == 0 ? " |" : "|");

            Console.WriteLine("\n");
            Console.WriteLine(line);
            Console.WriteLine(title);
            Console.WriteLine(secondLine);
            Console.WriteLine(line);
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
                if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                else if (key.Key != ConsoleKey.Backspace)
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
        public static int OnlyIntegerInputHidden()
        {
            string value = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool parseSuccesfull = double.TryParse(key.KeyChar.ToString(), out val);
                    if (parseSuccesfull)
                    {
                        value += key.KeyChar;
                        Console.Write("*");
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

        public static int OnlyIntegerInputHiddenInput()
        {
            string value = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool parseSuccesfull = double.TryParse(key.KeyChar.ToString(), out val);
                    if (parseSuccesfull)
                    {
                        value += key.KeyChar;
                        Console.Write(" ");
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

        public static void EraseText(int textSize, int cursorPositionX, int cursorPositionY)
        {
            string line = " ";
            for (int i = 0; i < textSize; i++)
            {
                line += " ";
            }
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.WriteLine(line);


        }

        public static string OnlyStringInput()
        {
            string value = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    return null;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (value.Length > 0)
                    {
                        value = value.Substring(0, value.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return value;
                }
                else
                {
                    value += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            while (true);
        }
        public static string OnlyStringInputHidden()
        {
            string value = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    return null;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (value.Length > 0)
                    {
                        value = value.Substring(0, value.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return value;
                }
                else
                {
                    value += key.KeyChar;
                    Console.Write("*");
                }
            }
            while (true);
        }
        public static void MiddleBar(string firstItemKey, string firstItemValue, string secondItemKey, string secondItemValue, int padding, int boxSize)
        {
            string firstItem = "";
            string middleItem = "";
            string lastItem = "";

            firstItem = $"| {firstItemKey}: {firstItemValue}";
            firstItem = firstItem.PadLeft(firstItem.Length + padding);
            lastItem = $"{secondItemKey}: {secondItemValue} |";
            int size = ((boxSize + padding) - (firstItem.Length + lastItem.Length));

            for (int i = 0; i < size; i++)
            {
                middleItem += " ";
            }
            Console.WriteLine(firstItem + middleItem + lastItem);
        }
        public static void HistoryBar(string Tid, string Ttype, string Tamount, string Tdate, string name, string AcNumber)
        {
            int boxSize = 112;
            int padding = 18;
            string line = "";
            for (int i = 0; i < boxSize; i++)
            {
                line += "-";
            }
            line = line.PadLeft(boxSize + padding, ' ');

            Console.WriteLine(line);
            MiddleBar("Name", name, "Date", Tdate, padding, boxSize);
            MiddleBar("A/c Number", AcNumber, "Amount", Tamount, padding, boxSize);
            MiddleBar("Transaction Id", Tid, "", Ttype, padding, boxSize);
            Console.WriteLine(line);
        }

        public static void DisplayBox(
            string firstItemKey, string firstItemValue, string secondItemKey, string secondItemValue,
            int padding, int boxSize)
        {
            //int boxSize = 112;
            //int padding = 18;
            string line = "";
            for (int i = 0; i < boxSize; i++)
            {
                line += "-";
            }
            line = line.PadLeft(boxSize + padding, ' ');

            string firstItem = "";
            string middleItem = "";
            string lastItem = "";

            firstItem = $"| {firstItemKey}: {firstItemValue}";
            firstItem = firstItem.PadLeft(firstItem.Length + padding);
            lastItem = $"{secondItemKey}: {secondItemValue} |";
            int size = ((boxSize + padding) - (firstItem.Length + lastItem.Length));

            for (int i = 0; i < size; i++)
            {
                middleItem += " ";
            }
            Console.WriteLine(line);
            Console.WriteLine(firstItem + middleItem + lastItem);
            Console.WriteLine(line);

        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}