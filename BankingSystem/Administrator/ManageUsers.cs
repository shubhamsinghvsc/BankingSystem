using BankingSystem.Models;

namespace BankingSystem.Administrator
{
    public class ManageUsers : Admin
    {
        public static void BlockUnblockUser()
        {

        }

        public static void SetTransactionLimit()
        {

        }

        public static void ResetUserPassword()
        {

        }
        public static void DeleteUser()
        {
            Console.Clear();
            Utils.NavBar();
            Utils.HeadingUnderlined("Delete User", 75);
            Utils.boxMaker2(40, 55, "Account Number");
            Utils.boxMaker2(40, 55, "Confirm Account Number");
            Console.SetCursorPosition(57, 15);
            int accountNumber = Utils.OnlyIntegerInputHidden();

            Console.SetCursorPosition(57, 20);
            int confirmAccountNumber = Utils.OnlyIntegerInput();

            List<Users> users = LoadUsers();
            var user = users.FirstOrDefault(user => user.AccountNumber == accountNumber);
            if (user == null)
            {

                Utils.EraseText(10, 57, 15);
                Utils.EraseText(10, 57, 20);

                string errorMsg = "Account Number Does not exist !!";

                Console.SetCursorPosition(57, 23);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMsg);
                Thread.Sleep(1000);
                Console.ResetColor();
                Utils.EraseText(errorMsg.Length, 57, 23);

            }
            else
            {
                users.Remove(user);

                Utils.EraseText(10, 57, 15);
                Utils.EraseText(10, 57, 20);

                string msg = "!! User Deleted Successfully !!";

                Console.SetCursorPosition(57, 23);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
                Thread.Sleep(1500);
                Console.ResetColor();
                Utils.EraseText(msg.Length, 57, 23);
            }
            SaveUsers(users);
            Console.ReadLine();
        }


        public static void ManageUserMenu()
        {
            /* Manage Users

                View All Users: Display a list of all users, including their usernames and account statuses.
                Create New User: Add a new user to the system. This may involve entering user details such as username, password, and account information.
                Delete User: Remove a user from the system. Ensure that associated accounts and data are handled appropriately.
                Update User Information: Modify existing user details, including personal information and account settings.
                Reset User Password: Allow admins to reset a user's password, often sending a temporary password or initiating a password reset process.
            */

            string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Block / UnBlock User", "\n\t\t\t\t\t\t\t     2. Set Transaction Limit", "\n\t\t\t\t\t\t\t     3. Reset User Password", "\n\t\t\t\t\t\t\t     4. Delete User", "\n\t\t\t\t\t\t\t     5. Go Back" };
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
                            BlockUnblockUser();
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 1:
                            Console.Clear();
                            SetTransactionLimit();
                            Console.Clear();
                            Utils.NavBar();
                            break;


                        case 2:
                            Console.Clear();
                            ResetUserPassword();
                            break;

                        case 3:
                            Console.Clear();
                            DeleteUser();
                            Console.Clear();
                            Utils.NavBar();
                            break;

                        case 4:
                            Console.Clear();
                            return;
                            break;
                        default:
                            Console.WriteLine("oops something went wrong");
                            break;
                    }
                }
            } while (!done);
        }
    }
}
