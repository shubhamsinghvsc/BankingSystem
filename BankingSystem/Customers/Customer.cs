using BankingSystem.Administrator;
using BankingSystem.Models;
using Newtonsoft.Json;

namespace BankingSystem.Customers;
public class Customer
{
    private const string filePath = "users.json";

    public static void AdminLogin()
    {
        Console.Clear();
        Utils.NavBar();
        Admin.AdminMainMenu();
        Console.ReadLine();
    }

    public static void Exit()
    {

        Console.WriteLine("Reparation ...");
        Console.Write("Press Enter to Continue");
        Console.ReadLine();
    }
    private static bool IsEmailExist(List<Users> users, string email)
    {
        //foreach (Users user1 in users)
        //{
        //    if (user1.Email == email)
        //    {
        //        return true;
        //    }
        //}
        //return false;
        return users.Any(user => user.Email == email);
    }

    private static bool IsPasswordMatched(List<Users> users, string password)
    {
        //foreach (Users user1 in users)
        //{
        //    if (user1.Password == password)
        //    {
        //        return true;
        //    }
        //}
        //return false;
        return users.Any(user => user.Password == password);
    }

    private static List<Users> LoadUsers()
    {
        if (!File.Exists(filePath))
        {
            return new List<Users>();
        }
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Users>>(json) ?? new List<Users>();
    }

    private static void SaveUsers(List<Users> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
    public static void Withdraw()
    {
        //string jsonString = File.ReadAllText(@"C:\Users\VSOFT\source\repos\BankingSystem\BankingSystem\bin\Debug\net8.0\users.json");
        // string json = File.ReadAllText("users.json");
        // dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

        List<Users> users = LoadUsers();
        var user = users.FirstOrDefault(user => user.Email == Utils.whoIsLoggedIn);

        if (user == null)
        {
            return;
        }

        Console.Clear();
        Utils.NavBar();
        Console.WriteLine("\t\t\t\t\t\t\t\t     WITHDRAW");
        Console.WriteLine("\t\t\t\t\t\t\t\t     --------\n");
        Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t       Balance : {user.BankBalance}\n");
        Utils.boxMaker2(40, 55, "Withdraw Amount ");


        Console.SetCursorPosition(0, 21);
        Utils.button(20, 65, "    withdraw");

        Console.SetCursorPosition(56, 15);
        Console.CursorVisible = true;

        int withdrawAmount = Utils.OnlyIntegerInput();
        Console.CursorVisible = false;

        if (withdrawAmount == -1)
        {
            return;
        }

        Console.SetCursorPosition(0, 21);
        Console.ForegroundColor = ConsoleColor.Green;
        Utils.button(20, 65, "    withdraw");
        Console.ResetColor();

        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            if (user.BankBalance < withdrawAmount)
            {
                Console.SetCursorPosition(61, 18);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Insufficent Balance");
                Thread.Sleep(1500);
                Console.ResetColor();
            }
            else
            {
                user.BankBalance -= withdrawAmount;
                Console.SetCursorPosition(61, 18);
                Console.WriteLine($"Rs. {withdrawAmount} Withdrawed");
            }
        }
        else if (key.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            Utils.NavBar();
            return;
        }

        SaveUsers(users);

        Console.ReadLine();
        Console.Clear();
        Utils.NavBar();
        return;

    }
    public static void Deposit()
    {
        List<Users> users = LoadUsers();
        var user = users.FirstOrDefault(user => user.Email == Utils.whoIsLoggedIn);
        if (user == null) return;


        Console.Clear();
        Utils.NavBar();
        Console.WriteLine("\t\t\t\t\t\t\t\t     Deposite");
        Console.WriteLine("\t\t\t\t\t\t\t\t     --------\n");
        Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t       Balance : {user.BankBalance}\n");

        Utils.boxMaker2(40, 55, "Deposite Amount ");

        Console.CursorVisible = true;
        Console.SetCursorPosition(56, 15);
        int depositeAmount = Utils.OnlyIntegerInput();
        if (depositeAmount == -1)
        {
            return;
        }

        user.BankBalance += depositeAmount;
        Console.SetCursorPosition(56, 18);
        Console.WriteLine($"Rs. {depositeAmount} Amount Deposited");


        SaveUsers(users);

        Console.ReadLine();
        Console.Clear();
        Utils.NavBar();
        return;

    }
    public static void TransferMoney()
    {
        List<Users> users = LoadUsers();
        var sender = users.FirstOrDefault(user => user.Email == Utils.whoIsLoggedIn);
        if (sender == null) return;



        Console.Clear();
        Utils.NavBar();
        //Console.SetCursorPosition(80, 10);
        Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t       Balance : {sender.BankBalance}");
        Utils.HeadingUnderlined("Transfer Money", 67);
        Utils.boxMaker2(40, 55, "Account Number");
        Utils.boxMaker2(40, 55, "Reenter Account Number");
        Utils.boxMaker2(40, 55, "Amount");

        Console.CursorVisible = true;

        int accountNumber;
        int reenterAccountNumber;
        int amount = 0;
        bool accountExist = false;
        do
        {
            do
            {
                Console.SetCursorPosition(57, 16);
                accountNumber = Utils.OnlyIntegerInputHidden();
                if (accountNumber == -1)
                {
                    return;
                }
                Console.SetCursorPosition(57, 21);
                reenterAccountNumber = Utils.OnlyIntegerInput();
                if (reenterAccountNumber == -1)
                {
                    return;
                }
                else if (accountNumber != reenterAccountNumber)
                {
                    string msgAccNumber = "Account Number does not match !!";

                    Utils.EraseText(10, 57, 16);
                    Utils.EraseText(10, 57, 21);
                    Utils.EraseText(10, 57, 26);

                    Console.SetCursorPosition(57, 12);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msgAccNumber);
                    Thread.Sleep(1500);
                    Utils.EraseText(msgAccNumber.Length, 57, 12);
                    Console.ResetColor();

                    continue;

                }
                Console.SetCursorPosition(57, 26);
                amount = Utils.OnlyIntegerInput();
                if (amount == -1)
                {
                    return;
                }
            } while (accountNumber != reenterAccountNumber);


            var receiver = users.FirstOrDefault(user => user.AccountNumber == accountNumber);


            if (receiver == null)
            {
                Utils.EraseText(10, 57, 16);
                Utils.EraseText(10, 57, 21);
                Utils.EraseText(10, 57, 26);

                string msgAccNumber = "!! Account Number Does Not Exist. !!";
                Console.SetCursorPosition(57, 12);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msgAccNumber);
                Thread.Sleep(1500);
                Utils.EraseText(msgAccNumber.Length, 57, 12);
                Console.ResetColor();

            }

            else
            {
                accountExist = true;
                if (sender.BankBalance >= amount)
                {
                    receiver.BankBalance += amount;
                    sender.BankBalance -= amount;

                    string msgAccNumber = "Money  Transfered  Successfull";
                    Console.SetCursorPosition(57, 29);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(msgAccNumber);
                    Thread.Sleep(1500);
                    Utils.EraseText(msgAccNumber.Length, 57, 29);
                    Console.ResetColor();
                    List<TransactionHistory> senderHistory = new List<TransactionHistory>();
                    List<TransactionHistory> receiverHistory = new List<TransactionHistory>();
                    senderHistory = sender.transactionHistories;
                    receiverHistory = receiver.transactionHistories;
                    senderHistory.Add(
                        new TransactionHistory()
                        {
                            TransactionId = "1",
                            TransactionType = "DR",
                            TransactionAmount = amount,
                            TransactionDate = DateTime.Now.ToString(),
                            AccountHolderName = receiver.Name,
                            AccountNumber = accountNumber,

                        }
                        );
                    receiverHistory.Add(
                        new TransactionHistory()
                        {
                            TransactionId = "1",
                            TransactionType = "CR",
                            TransactionAmount = amount,
                            TransactionDate = DateTime.Now.ToString(),
                            AccountHolderName = sender.Name,
                            AccountNumber = sender.AccountNumber,

                        }
                        );

                    receiver.transactionHistories = receiverHistory;
                    sender.transactionHistories = senderHistory;
                }
                else
                {
                    Console.SetCursorPosition(70, 30);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient Account Balance !!");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                }

            }
        } while (!accountExist);

        SaveUsers(users);

        Console.ReadLine();
    }
    public static void Passbook()
    {
        Utils.NavBar();
        Utils.HeadingUnderlined("Transaction History", 65);

        List<Users> users = LoadUsers();
        var user = users.FirstOrDefault(user => user.Email == Utils.whoIsLoggedIn);
        if (user == null)
        {
            return;
        }

        List<TransactionHistory> userTransaction = user.transactionHistories;
        foreach (TransactionHistory transactionHistory in userTransaction)
        {
            Utils.HistoryBar(
                transactionHistory.TransactionId,
                    transactionHistory.TransactionType,
                    transactionHistory.TransactionAmount.ToString(),
                    transactionHistory.TransactionDate,
                    transactionHistory.AccountHolderName,
                    transactionHistory.AccountNumber.ToString()
                );
        }

        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;

        int keyPressed = Utils.OnlyIntegerInputHiddenInput();
        if (keyPressed == -1)
        {
            Console.Clear();
            Utils.NavBar();
            return;
        }


        Console.Clear();
        Utils.NavBar();
    }

    public static void Logout()
    {
        Utils.whoIsLoggedIn = string.Empty;
        Utils.LoggedUserName = string.Empty;
        Console.ResetColor();
        Utils.NavBar();
        Program.MainMenu();

    }
    public static void Menu()
    {
        string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Withdraw Money", "\n\t\t\t\t\t\t\t     2. Deposite Money", "\n\t\t\t\t\t\t\t     3. Transfer Money", "\n\t\t\t\t\t\t\t     4. Passbook", "\n\t\t\t\t\t\t\t     5. Logout" };
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
                        Console.Clear();
                        Utils.NavBar();
                        break;
                    case 1:
                        Console.Clear();
                        Deposit();
                        Console.Clear();
                        Utils.NavBar();
                        break;
                    case 2:
                        Console.Clear();
                        TransferMoney();
                        Console.Clear();
                        Utils.NavBar();
                        break;

                    case 3:
                        Console.Clear();
                        Passbook();
                        Console.Clear();
                        Utils.NavBar();
                        break;
                    case 4:
                        Console.Clear();
                        Logout();
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