using BankingSystem.Models;
using static BankingSystem.Customers.Customer;

namespace BankingSystem.Customers
{
    public class Login
    {

        private static bool IsPasswordMatched(Users user, string password)
        {

            if (user.Password == Utils.HashPassword(password))
            {
                return true;
            }

            return false;
        }

        public static void CustomerLogin(String loginFormName = "", int headingPadding = 76)
        {

            string email;
            string password;

            List<Users> users = Utils.LoadUsers();


            Console.Clear();
            Utils.NavBar();

            Console.WriteLine($"{loginFormName} LogIn".PadLeft(headingPadding, ' '));
            Utils.LineMaker((loginFormName.Length + 6), headingPadding);
            Console.WriteLine("\n");
            Utils.boxMaker2(40, 55, "Email ID");
            Utils.boxMaker2(40, 55, "Password");

            Console.SetCursorPosition(0, 23);
            Utils.button(20, 65, "    Login ");

            Console.CursorVisible = true;

            while (true)
            {
                Console.SetCursorPosition(57, 14);
                email = Utils.OnlyStringInput();
                if (email == null)
                {
                    return;
                }
                else if (email.Length == 0)
                {
                    string msg = "!! Email is a required field!!";
                    Utils.DisplayError(57, 14, msg);
                }
                else if (Utils.IsValidEmail(email))
                {
                    if (!Utils.IsEmailExist(users, email))
                    {
                        string msg = "!! You Are Not Registered !! ";
                        Utils.DisplayError(57, 14, msg);
                    }
                    else
                    {
                        break;
                    }

                }

                else
                {
                    string msg = "!! Please enter Valid Email !!";
                    Utils.DisplayError(57, 14, msg);
                }
            }

            //Password
            while (true)
            {
                //password
                while (true)
                {
                    Console.SetCursorPosition(57, 19);
                    password = Utils.OnlyStringInputHidden();

                    Console.CursorVisible = false;

                    if (password == null)
                    {
                        return;
                    }
                    Console.SetCursorPosition(0, 23);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Utils.button(20, 65, "    Login ");
                    Console.ResetColor();

                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        if (password.Length == 0 || password.Length < 8)
                        {
                            string msg = "!! Incorrect Password !!";
                            Utils.DisplayError(57, 19, msg);
                        }
                        else
                        {
                            Users user = users.FirstOrDefault(user => user.Email == email);

                            if (IsPasswordMatched(user, password))
                            {
                                Utils.whoIsLoggedIn = email;
                                Utils.LoggedUserName = user.Name;
                                CustomerMainMenu();
                            }
                            break;
                        }
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Utils.NavBar();
                        return;
                    }
                }


            }
        }
    }
}
