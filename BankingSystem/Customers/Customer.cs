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
    public static void Login()
    {
        string email;
        string password;

        string filePath = "users.json";
        List<Users> users = new List<Users>();
        if (File.Exists(filePath))
        {
            string text = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<Users>>(text) ?? new List<Users>();
        }

        Console.Clear();
        Utils.NavBar();

        Console.WriteLine("LogIn".PadLeft(76, ' '));
        Console.WriteLine("-----".PadLeft(76, ' ') + "\n\n");
        Utils.boxMaker2(40, 55, "Email ID");
        Utils.boxMaker2(40, 55, "Password");
        Utils.button(15, 67, "  Log In");
        Console.CursorVisible = true;

        while (true)
        {
            Console.SetCursorPosition(57, 14);
            email = Console.ReadLine();
            email = email.ToLower();

            if (email.Length == 0)
            {
                Console.SetCursorPosition(57, 14);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email is a required field!!");
                Console.ResetColor();
                Thread.Sleep(2000);
                Console.SetCursorPosition(57, 14);
                Console.WriteLine("                           ");

            }
            else if (email.EndsWith(".com") && email.Contains('@') && !email.StartsWith('@'))
            {

                if (!IsEmailExist(users, email))
                {
                    Console.SetCursorPosition(57, 14);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Are Not Registered !! ");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.SetCursorPosition(57, 14);
                    Console.WriteLine("                             ");

                }
                else
                {
                    break;
                }

            }

            else
            {
                Console.SetCursorPosition(57, 19);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter Valid Email !!");
                Thread.Sleep(2000);
                Console.ResetColor();
                Console.SetCursorPosition(57, 19);
                Console.WriteLine("                           ");
            }
        }

        //Password
        while (true)
        {

            //password
            while (true)
            {
                Console.SetCursorPosition(57, 19);
                password = Console.ReadLine();
                Console.SetCursorPosition(57, 19);
                Console.WriteLine(new string('*', password.Length));
                if (password.Length == 0 || password.Length < 8)
                {
                    Console.SetCursorPosition(57, 19);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Password !!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.SetCursorPosition(57, 19);
                    Console.WriteLine("                              ");
                }
                else
                {
                    if (IsPasswordMatched(users, password))
                    {
                        CustomerMainMenu();
                    }
                    break;
                }

            }


        }


        Console.WriteLine("New Customer ...");
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }

    public static void SignUp()
    {


        string name;
        string email;
        string password;
        string confirmPassword;

        Console.Clear();
        Utils.NavBar();
        Console.WriteLine("Signup".PadLeft(77, ' '));
        Console.WriteLine("------".PadLeft(77, ' ') + "\n\n");
        Utils.boxMaker(40, 55, "Name");
        Utils.boxMaker2(40, 55, "Email");
        Utils.boxMaker2(40, 55, "Password (Minmum 8 Characters)");
        Utils.boxMaker2(40, 55, "Confirm Password");

        Utils.button(15, 67, "  Sign Up");

        Console.CursorVisible = true;

        string filePath = "users.json";
        List<Users> users = new List<Users>();
        if (File.Exists(filePath))
        {
            string text = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<Users>>(text) ?? new List<Users>();
        }

        //Name
        while (true)
        {
            Console.SetCursorPosition(57, 14);


            Console.SetCursorPosition(57, 14);

            name = Console.ReadLine();
            if (name == "\t")
            {
                Console.WriteLine("Tabbbbbbbbbbbbb");
                Console.SetCursorPosition(57, 19);
                break;
            }
            else if (name.Length == 0)
            {
                Console.SetCursorPosition(57, 14);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Enter Your Name. !!");
                Console.ResetColor();
                Thread.Sleep(1500);
                Console.SetCursorPosition(57, 14);
                Console.WriteLine("                          ");
            }
            else
            {
                break;
            }


        }

        //Email
        while (true)
        {
            Console.SetCursorPosition(57, 19);
            email = Console.ReadLine();
            email = email.ToLower();

            if (email.Length == 0)
            {
                Console.SetCursorPosition(57, 19);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email is a required field!!");
                Console.ResetColor();
                Thread.Sleep(2000);
                Console.SetCursorPosition(57, 19);
                Console.WriteLine("                           ");

            }
            else if (email.EndsWith(".com") && email.Contains('@') && !email.StartsWith('@'))
            {
                //Console.WriteLine("helllllllllllllllllllllllllllllllll");
                if (IsEmailExist(users, email))
                {
                    Console.SetCursorPosition(57, 19);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You Are Already Registered! ");
                    Thread.Sleep(5000);
                    Console.ResetColor();
                    Console.SetCursorPosition(57, 19);
                    Console.WriteLine("                             ");
                    Login();
                }
                break;
            }

            else
            {
                Console.SetCursorPosition(57, 19);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter Valid Email !!");
                Thread.Sleep(2000);
                Console.ResetColor();
                Console.SetCursorPosition(57, 19);
                Console.WriteLine("                           ");
            }
        }

        //Password
        while (true)
        {

            //password
            while (true)
            {
                Console.SetCursorPosition(57, 24);
                password = Console.ReadLine();
                Console.SetCursorPosition(57, 24);
                Console.WriteLine(new string('*', password.Length));
                if (password.Length == 0 || password.Length < 8)
                {
                    Console.SetCursorPosition(57, 24);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Password !!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.SetCursorPosition(57, 24);
                    Console.WriteLine("                              ");
                }
                else
                {
                    break;
                }

            }
            //confirm password
            while (true)
            {
                Console.SetCursorPosition(57, 29);
                confirmPassword = Console.ReadLine();
                Console.SetCursorPosition(57, 29);
                Console.WriteLine(new string('*', password.Length));
                if (confirmPassword.Length == 0 || confirmPassword.Length < 8)
                {
                    Console.SetCursorPosition(57, 29);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Password !!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.SetCursorPosition(57, 29);
                    Console.WriteLine("                              ");
                }
                else
                {
                    break;
                }
            }
            if (password != confirmPassword)
            {
                Console.SetCursorPosition(57, 31);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password Does't match !!");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.SetCursorPosition(57, 31);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(57, 24);
                Console.WriteLine("                        ");
                Console.SetCursorPosition(57, 29);
                Console.WriteLine("                        ");

            }
            else
            {
                break;
            }

        }

        // storing data in json file 

        List<TransactionHistory> transactionHistory = new List<TransactionHistory>
            {   new TransactionHistory{
                TransactionId = "",
                TransactionAmount = 0,
                TransactionDate = "",
                TransactionType = "",
                AccountNumber = 0,
                AccountHolderName = ""
            }
            };

        Users user = new Users
        {
            Name = name,
            Email = email,
            Password = password,
            IsNewUser = true,
            Pin = 0,
            AccountNumber = 0,
            transactionHistories = transactionHistory
        };



        users.Add(user);

        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, updatedJson);


        Console.Write("\nPress Enter to Continue");
        Console.ReadLine();
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
        Console.Clear();
        Utils.NavBar();
        Console.WriteLine("\t\t\t\t\t\t\t\t     WITHDRAW");
        Console.WriteLine("\t\t\t\t\t\t\t\t     --------\n");
        Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t       Balance : {10000}\n");
        Utils.boxMaker2(40, 55, "Withdraw Amount ");
        long witdrawAmount = Convert.ToInt64(Console.ReadLine());

        Console.ReadLine();
    }
    public static void Deposit()
    {
        Console.WriteLine("Deposit option is UNDER CONSTRUCTION");
    }
    public static void TransferMoney()
    {
        Console.WriteLine("TransferMoney option is UNDER CONSTRUCTION");
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
                        break;
                    case 1:
                        Console.Clear();
                        Deposit();
                        break;
                    case 2:
                        TransferMoney();
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

}



// use REgex