using BankingSystem.Models;
using Newtonsoft.Json;

namespace BankingSystem.Administrator
{
    public class Admin
    {
        public static void ViewUsers()
        {

            Utils.NavBar();
            Utils.HeadingUnderlined("Users List", 65);
            string filePath = "users.json";
            List<Users> users = new List<Users>();
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<Users>>(text) ?? new List<Users>();
            }
            for (int i = 0; i < users.Count; i++)
            {
                Utils.DisplayBox("Name", users[i].Name, "A/C Number", Convert.ToString(users[i].AccountNumber), 40, 70);
            }

            Console.ReadLine();
        }

        public static void ViewStats()
        {
            /* System Statistics

                View Total Number of Users: Show the total count of users in the system.
                View Total Number of Accounts: Display the total count of accounts.
                View Total Transactions: Provide statistics on the number of transactions that have occurred.
                View Total Balance: Display the aggregate balance of all accounts or specific account types.
            */
        }

        public static void Logout()
        {

        }
        public static void Menu()
        {
            string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. View Users", "\n\t\t\t\t\t\t\t     2. Manage Users", "\n\t\t\t\t\t\t\t     3. View Status", "\n\t\t\t\t\t\t\t     4. Logout" };
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
                            ViewUsers();
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 1:
                            Console.Clear();
                            ManageCustomer.ManageUsers();
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 2:
                            Console.Clear();
                            ViewStats();
                            Console.Clear();
                            Utils.NavBar();
                            break;


                        case 3:
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
        public static void AdminMainMenu()
        {
            Menu();

        }
    }
}
