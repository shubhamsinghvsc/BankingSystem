using Newtonsoft.Json;

namespace BankingSystem.Customers;
public class Customer
{
    public class Users
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsNewUser { get; set; }
        public int Pin { get; set; }
        public long AccountNumber { get; set; }
        public long BankBalance { get; set; }
        public List<TransactionHistory> transactionHistories { get; set; }
    }

    public class TransactionHistory
    {
        public string TransactionId { get; set; } = string.Empty;
        public string TransactionType { get; set; }
        public long TransactionAmount { get; set; }
        public string TransactionDate { get; set; }
        public string AccountHolderName { get; set; }
        public long AccountNumber { get; set; }

    }

    public static void AdminLogin()
    {
        Console.Clear();
        Utils.NavBar();

        Console.WriteLine("Service ...");
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }

    public static void Exit()
    {

        Console.WriteLine("Reparation ...");
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }
    static bool IsEmailExist(List<Users> user, string email)
    {
        foreach (Users user1 in user)
        {
            if (user1.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    static bool IsPasswordMatched(List<Users> user, string password)
    {
        foreach (Users user1 in user)
        {
            if (user1.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    public static void Withdraw()
    {
        //string jsonString = File.ReadAllText(@"C:\Users\VSOFT\source\repos\BankingSystem\BankingSystem\bin\Debug\net8.0\users.json");
        string json = File.ReadAllText("users.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        int index = 0;
        for (int i = 0; i < jsonObj.Count; i++)
        {
            if (jsonObj[i].Email == Utils.whoIsLoggedIn)
            {
                index = i;
                break;
            }

        }

        Console.Clear();
        Utils.NavBar();
        Console.WriteLine("\t\t\t\t\t\t\t\t     WITHDRAW");
        Console.WriteLine("\t\t\t\t\t\t\t\t     --------\n");
        Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t       Balance : {jsonObj[index].BankBalance}\n");
        Utils.boxMaker2(40, 55, "Withdraw Amount ");
        Console.CursorVisible = true;
        Console.SetCursorPosition(56, 15);
        int withdrawAmount = Utils.OnlyIntegerInput();

        if (jsonObj[index].BankBalance < withdrawAmount)
        {
            Console.SetCursorPosition(56, 18);
            Console.WriteLine(" Insufficent Balance");
        }
        else
        {
            jsonObj[index]["BankBalance"] -= withdrawAmount;
            Console.SetCursorPosition(56, 18);
            Console.WriteLine($"Rs. {withdrawAmount} Amount Withdrawed");
        }

        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText("users.json", output);
        Console.ReadLine();
        return;

    }
    public static void Deposit()
    {
        string json = File.ReadAllText("users.json");
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        int index = 0;
        for (int i = 0; i < jsonObj.Count; i++)
        {
            if (jsonObj[i].Email == Utils.whoIsLoggedIn)
            {
                index = i;
                break;
            }

        }

        Console.Clear();
        Utils.NavBar();
        Console.WriteLine("\t\t\t\t\t\t\t\t     Deposite");
        Console.WriteLine("\t\t\t\t\t\t\t\t     --------\n");
        Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t       Balance : {jsonObj[index].BankBalance}\n");

        Utils.boxMaker2(40, 55, "Deposite Amount ");
        Console.WriteLine("Press escape to go to Main Menu and TAB to continue");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Escape)
        {
            return;
        }
        else if (key.Key == ConsoleKey.Tab || key.Key == ConsoleKey.Enter)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(56, 15);
            int depositeAmount = Utils.OnlyIntegerInput();

            jsonObj[index]["BankBalance"] += depositeAmount;
            Console.SetCursorPosition(56, 18);
            Console.WriteLine($"Rs. {depositeAmount} Amount Deposited");


            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("users.json", output);
        }
        Console.ReadLine();
        Deposit();
    }
    public static void TransferMoney()
    {
        Console.Clear();
        Utils.NavBar();

        Utils.HeadingUnderlined("Transfer Money", 67);
        Utils.boxMaker2(40, 55, "Account Number");
        Utils.boxMaker2(40, 55, "Reenter Account Number");
        Utils.boxMaker2(40, 55, "Amount");

        Console.CursorVisible = true;
        Console.WriteLine("Press escape to go to Main Menu");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Escape)
        {
            return;
        }
        int accountNumber;
        int reenterAccountNumber;
        int amount;
        do
        {
            Console.SetCursorPosition(57, 15);
            accountNumber = Utils.OnlyIntegerInput();

            Console.SetCursorPosition(57, 20);
            reenterAccountNumber = Utils.OnlyIntegerInput();


            Console.SetCursorPosition(57, 25);
            amount = Utils.OnlyIntegerInput();

            if (accountNumber != reenterAccountNumber)
            {
                string msgAccNumber = "Account Number does not match !!";


                Utils.EraseText(10, 57, 15);
                Utils.EraseText(10, 57, 20);
                Utils.EraseText(10, 57, 25);

                Console.SetCursorPosition(57, 28);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msgAccNumber);
                Thread.Sleep(1500);
                Utils.EraseText(msgAccNumber.Length, 57, 28);
                Console.ResetColor();

            }
        } while (accountNumber != reenterAccountNumber);

        string filePath = "users.json";
        List<Users> users = new List<Users>();
        if (File.Exists(filePath))
        {
            string text = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<Users>>(text) ?? new List<Users>();
        }
        bool accountExist = false;
        int index = 0;
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].AccountNumber == accountNumber)
            {
                accountExist = true;
                index = i;
            }
        }
        if (!accountExist)
        {
            Console.WriteLine("Account does not exist");

        }
        else
        {
            users[index].BankBalance += amount;
            //users[].BankBalance -= amount;
        }
        Console.ReadLine();
    }
    public static void Passbook()
    {
        Console.WriteLine("Passbook option is UNDER CONSTRUCTION");
    }
    public static void Menu()
    {
        string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Withdraw Money", "\n\t\t\t\t\t\t\t     2. Deposite Money", "\n\t\t\t\t\t\t\t     3. Transfer Money", "\n\t\t\t\t\t\t\t     4. Passbook", "\n\t\t\t\t\t\t\t     5. Exit" };
        int menuSelector = 0;
        bool done = false;

        Console.WriteLine("\t\t\t\t\t\t\t  WelCome to State Bank of Bharat");
        Console.WriteLine("\n\n\t\t\t\t\t     Move UP and Down arrow Key to Navigate through Options.");
        do
        {
            //Console.Clear();

            //Utils.NavBar();
            Console.CursorVisible = false;

            // Paint(61, 13, mainMenuOption, menuSelector);


            for (int i = 0; i < mainMenuOption.Length; i++)
            {
                Console.SetCursorPosition(61, 13 + i * 2);

                var color = menuSelector == i ? ConsoleColor.DarkYellow : ConsoleColor.Gray;

                Console.ForegroundColor = color;
                Console.WriteLine(mainMenuOption[i]);
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.Tab)
            {
                if (menuSelector == mainMenuOption.Length - 1)
                {
                    menuSelector = 0;
                }
                else
                {
                    menuSelector++;
                }
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                if (menuSelector == 0)
                {
                    menuSelector = mainMenuOption.Length - 1;
                }
                else
                {
                    menuSelector--;
                }

            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelector)
                {
                    case 0:
                        Console.Clear();
                        Withdraw();
                        //Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        Deposit();
                        break;
                    case 2:
                        TransferMoney();
                        Console.Clear();

                        break;

                    case 3:
                        Passbook();
                        break;
                    case 4:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("oops something went wrong");
                        break;
                }
            }
        } while (!done);
    }
    public static void CustomerMainMenu()
    {
        Console.Clear();
        Utils.NavBar();
        Menu();


    }
}





// use REgex