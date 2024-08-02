using Newtonsoft.Json;
using static BankingSystem.Customers.Customer;

namespace BankingSystem.Customers
{
    public class Login
    {
        private static bool IsEmailExist(List<Users> user, string email)
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

        private static bool IsPasswordMatched(List<Users> user, string password)
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
