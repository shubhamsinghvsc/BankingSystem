using BankingSystem.Models;
using Newtonsoft.Json;
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


            string filePath = "users.json";
            List<Users> users = new List<Users>();
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<Users>>(text) ?? new List<Users>();
            }


            Console.Clear();
            Utils.NavBar();

            Console.WriteLine($"{loginFormName} LogIn".PadLeft(headingPadding, ' '));
            Utils.LineMaker((loginFormName.Length + 6), headingPadding);
            Console.WriteLine("\n");
            Utils.boxMaker2(40, 55, "Email ID");
            Utils.boxMaker2(40, 55, "Password");
            Utils.button(15, 67, "  Log In");
            Console.CursorVisible = true;

            while (true)
            {
                Console.SetCursorPosition(57, 14);
                email = Utils.OnlyStringInput();
                if (email == null)
                {
                    return;
                }
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

                    if (!Utils.IsEmailExist(users, email))
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
                    Console.SetCursorPosition(57, 16);
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
                    password = Utils.OnlyStringInputHidden();

                    if (password.Length == 0 || password.Length < 8)
                    {
                        string msg = "!! Please Enter Valid Password !!";
                        Utils.DisplayError(57, 19, msg);
                    }
                    else
                    {
                        Users user = users.FirstOrDefault(user => user.Email == email);

                        if (IsPasswordMatched(user, password))
                        {
                            Utils.whoIsLoggedIn = email;
                            int index = 0;
                            for (int i = 0; i < users.Count; i++)
                            {
                                if (users[i].Email == email)
                                {
                                    index = i;
                                    break;
                                }
                            }
                            Utils.LoggedUserName = users[index].Name;
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
    }
}
