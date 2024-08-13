using BankingSystem.Customers;
namespace BankingSystem
{
    internal class Program
    {

        //Main Menu
        public static void MainMenu()
        {
            string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Login", "\n\t\t\t\t\t\t\t     2. SignUp", "\n\t\t\t\t\t\t\t     3. Admin Login", "\n\t\t\t\t\t\t\t     4. Exit" };
            int menuSelector = 0;
            bool done = false;

            Console.WriteLine("\t\t\t\t\t\t\t  WelCome to State Bank of Bharat");
            Console.WriteLine("\n\n\t\t\t\t\t\t\t     Choose a Option to continue");
            do
            {
                //Console.Clear();

                // Utils.NavBar();
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

                if ((keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.Tab))
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

                            //Customer.Login();
                            Login.CustomerLogin("Customer");
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 1:
                            Console.Clear();
                            Signup.CustomerSignup();
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 2:
                            Customer.AdminLogin();
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 3:
                            done = true;
                            break;
                        default:
                            Console.WriteLine("oops something went wrong");
                            break;
                    }
                }
            } while (!done);
        }

        //Main Method
        static void Main(string[] args)
        {
            Console.Title = "State Bank Of Bharat";
            Utils.NavBar();
            // Utils.NavBar2();
            MainMenu();
            // ManageUsers.DeleteUser();
            // Customer.CustomerMainMenu();
            // testing development of customer menu
            // Customer.CustomerMainMenu();


            Console.ReadLine();

        }
    }
}

// To-Do

// Add transaction history for withdrawals and deposits.
// Automatically generate transaction IDs.
// Secure passwords using hashing.
// Validate emails using regular expressions.
// Include a login button on the signup page.
// Ensure input length is properly handled.