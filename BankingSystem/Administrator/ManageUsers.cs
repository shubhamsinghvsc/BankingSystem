using BankingSystem.Models;

namespace BankingSystem.Administrator
{
    public class ManageUsers : Admin
    {
        public static void BlockUnblockUser()
        {
            Console.Clear();
            Utils.NavBar();

            //Console.WriteLine("Global properti : " + Admin.GloabalAccountNumber);


            List<Users> users = Utils.LoadUsers();
            Users user = users.FirstOrDefault(user => user.AccountNumber == Admin.GloabalAccountNumber);
            string isBlocked = user.IsBlocked ? "Blocked" : "Not Blocked";
            Console.WriteLine($"            Account Number : {Admin.GloabalAccountNumber} is {isBlocked}");

            string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Block User", "\n\t\t\t\t\t\t\t     2. UnBlock User", "\n\t\t\t\t\t\t\t     3. Go Back" };
            int menuSelector = 0;
            bool done = false;

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
                            user.IsBlocked = true;
                            Utils.SaveUsers(users);
                            // Console.Clear();
                            BlockUnblockUser();

                            break;
                        case 1:
                            user.IsBlocked = false;
                            Utils.SaveUsers(users);
                            // Console.Clear();
                            BlockUnblockUser();
                            break;

                        case 2:
                            Console.Clear();

                            Admin.AdminMainMenu();
                            break;
                        default:
                            Console.WriteLine("oops something went wrong");
                            break;
                    }
                }
            } while (!done);


            Console.ReadLine();


        }

        //public static void SetTransactionLimit()
        //{

        //}

        public static void ResetUserPassword()
        {
            Console.Clear();
            Utils.NavBar();

            string password;
            string confirmPassword;

            List<Users> users = Utils.LoadUsers();
            int userIndex = users.IndexOf(users.FirstOrDefault(user => user.AccountNumber == Admin.GloabalAccountNumber));
            string heading = $"Reset {users[userIndex].AccountNumber} Password ";
            Utils.HeadingUnderlined(heading, 65);
            Utils.boxMaker2(40, 55, "Password (Minmum 8 Characters)");
            Utils.boxMaker2(40, 55, "Confirm Password");
            Console.CursorVisible = true;
            while (true)
            {

                //password label and input box.
                while (true)
                {
                    Console.SetCursorPosition(57, 15);
                    password = Utils.OnlyStringInputHidden();
                    if (password == null)
                    {
                        return;
                    }
                    else if (password.Length == 0 || password.Length < 8)
                    {
                        string msg = "!! Please Enter Valid Password !!";
                        Utils.DisplayError(57, 15, msg);
                    }
                    else
                    {
                        break;
                    }

                }
                //confirm password label and input box.
                while (true)
                {
                    Console.SetCursorPosition(57, 20);
                    confirmPassword = Utils.OnlyStringInputHidden();

                    if (confirmPassword == null)
                    {
                        return;
                    }
                    else if (confirmPassword.Length == 0 || confirmPassword.Length < 8)
                    {
                        string msg = "!! Please Enter Valid Password !!";
                        Utils.DisplayError(57, 20, msg);
                    }
                    else
                    {
                        break;
                    }
                }

                if (password != confirmPassword)
                {
                    Utils.EraseText(25, 57, 22);
                    Utils.EraseText(25, 57, 15);
                    Utils.EraseText(25, 57, 20);

                    string msg = "!! Password Does't match !!";
                    Utils.DisplayError(57, 22, msg);
                }
                else
                {
                    break;
                }

            }
            users[userIndex].Password = Utils.HashPassword(password);
            SaveUsers(users);

            Utils.EraseText(25, 57, 22);
            Utils.EraseText(25, 57, 15);
            Utils.EraseText(25, 57, 20);

            string sucessMsg = "! Password Reset Succesfull !";
            Utils.DisplaySuccess(57, 22, sucessMsg);

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
                Utils.DisplayError(57, 23, errorMsg);
            }
            else
            {
                users.Remove(user);

                Utils.EraseText(10, 57, 15);
                Utils.EraseText(10, 57, 20);

                string msg = "!! User Deleted Successfully !!";
                Utils.DisplaySuccess(57, 23, msg);
            }
            SaveUsers(users);
            Console.ReadLine();
        }


        public static void ManageUserMenu()
        {

            string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Block / UnBlock User", "\n\t\t\t\t\t\t\t     2. Reset User Password", "\n\t\t\t\t\t\t\t     3. Delete User", "\n\t\t\t\t\t\t\t     4. Go Back" };
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
                            ResetUserPassword();
                            break;

                        case 2:
                            Console.Clear();
                            DeleteUser();
                            Console.Clear();
                            Utils.NavBar();
                            break;

                        case 3:
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
