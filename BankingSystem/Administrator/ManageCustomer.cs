namespace BankingSystem.Administrator
{
    public class ManageCustomer
    {
        public static void CreateNewUser()
        {

        }
        public static void DeleteUser()
        {

        }

        public static void UpdateUser()
        {

        }

        public static void ResetUserPassword()
        {

        }


        public static void ManageUsers()
        {
            /* Manage Users

                View All Users: Display a list of all users, including their usernames and account statuses.
                Create New User: Add a new user to the system. This may involve entering user details such as username, password, and account information.
                Delete User: Remove a user from the system. Ensure that associated accounts and data are handled appropriately.
                Update User Information: Modify existing user details, including personal information and account settings.
                Reset User Password: Allow admins to reset a user's password, often sending a temporary password or initiating a password reset process.
            */

            string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Create New User", "\n\t\t\t\t\t\t\t     2. Delete User", "\n\t\t\t\t\t\t\t     3. Update User", "\n\t\t\t\t\t\t\t     4. Reset User Password" };
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
                            CreateNewUser();
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 1:
                            Console.Clear();
                            DeleteUser();
                            Console.Clear();
                            Utils.NavBar();
                            break;
                        case 2:
                            Console.Clear();
                            UpdateUser();
                            Console.Clear();
                            Utils.NavBar();
                            break;


                        case 3:
                            Console.Clear();
                            ResetUserPassword();
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
