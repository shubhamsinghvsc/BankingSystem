using Newtonsoft.Json;
using static BankingSystem.Customers.Customer;

namespace BankingSystem.Customers
{
    public class Signup
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
        public static void CustomerSignup()
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
                if (name.Length == 0)
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
                    Thread.Sleep(1500);
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
                        Login.CustomerLogin("Customer");
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

            //  fetching json file to check last account number.
            string json = File.ReadAllText("users.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            long accountNumber;
            if (jsonObj != null)
            {
                accountNumber = jsonObj[jsonObj.Count - 1]["AccountNumber"] + 1;
            }
            else
            {
                accountNumber = 789456;
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
                AccountNumber = accountNumber,
                BankBalance = 0,
                transactionHistories = transactionHistory
            };



            users.Add(user);

            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);


            Console.Write("\nPress Enter to Continue");
            Console.ReadLine();

        }
    }
}
