using BankingSystem.Models;
using Newtonsoft.Json;

namespace BankingSystem.Customers
{
    public class Signup
    {
        public static void CustomerSignup(string heading = "Signup", int padding = 65)
        {
            string name;
            string email;
            string password;
            string confirmPassword;

            Console.Clear();
            Utils.NavBar();

            Utils.HeadingUnderlined(heading, padding);
            Utils.boxMaker2(40, 55, "Name");
            Utils.boxMaker2(40, 55, "Email");
            Utils.boxMaker2(40, 55, "Password (Minmum 8 Characters)");
            Utils.boxMaker2(40, 55, "Confirm Password");

            Console.SetCursorPosition(0, 34);
            Utils.button(20, 65, "    SignUp");

            Console.CursorVisible = true;

            // fetching data from json file and if file does not exist creating new one.
            string filePath = "users.json";
            List<Users> users = new List<Users>();
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<Users>>(text) ?? new List<Users>();
            }

            // Name label and input box.
            while (true)
            {
                Console.SetCursorPosition(57, 15);
                name = Utils.OnlyStringInput();

                if (name == null)
                {
                    return;
                }
                else if (name.Length == 0)
                {
                    string msg = "!! Please Enter Your Name. !!";
                    Utils.DisplayError(57, 15, msg);
                }
                else
                {
                    break;
                }
            }

            //Email label and input box.
            while (true)
            {
                Console.SetCursorPosition(57, 20);
                email = Utils.OnlyStringInput();
                email = email.ToLower();

                if (email == null)
                {
                    return;
                }
                else if (email.Length == 0)
                {
                    string msg = "!! Email is a required field !!";
                    Utils.DisplayError(57, 20, msg);
                }
                else if (Utils.IsValidEmail(email))
                {
                    //Console.WriteLine("TEST test ");
                    if (Utils.IsEmailExist(users, email))
                    {
                        string msg = "! You Are Already Registered !";
                        Utils.DisplaySuccess(57, 20, msg);

                        Login.CustomerLogin("Customer");
                    }
                    break;
                }

                else
                {
                    string msg = "!! Please enter Valid Email !!";
                    Utils.DisplayError(57, 20, msg);
                }
            }

            //Password 
            while (true)
            {

                //password label and input box.
                while (true)
                {
                    Console.SetCursorPosition(57, 25);
                    password = Utils.OnlyStringInputHidden();
                    if (password == null)
                    {
                        return;
                    }
                    else if (password.Length == 0 || password.Length < 8)
                    {
                        string msg = "!! Please Enter Valid Password !!";
                        Utils.DisplayError(57, 25, msg);
                    }
                    else
                    {
                        break;
                    }

                }
                //confirm password label and input box.
                while (true)
                {
                    Console.SetCursorPosition(57, 30);
                    confirmPassword = Utils.OnlyStringInputHidden();

                    if (confirmPassword == null)
                    {
                        return;
                    }
                    else if (confirmPassword.Length == 0 || confirmPassword.Length < 8)
                    {
                        string msg = "!! Please Enter Valid Password !!";
                        Utils.DisplayError(57, 30, msg);
                    }
                    else
                    {
                        break;
                    }
                }

                Console.SetCursorPosition(0, 34);
                Console.ForegroundColor = ConsoleColor.Green;
                Utils.button(20, 65, "    SignUp");
                Console.ResetColor();

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    if (password != confirmPassword)
                    {
                        Utils.EraseText(25, 57, 32);
                        Utils.EraseText(25, 57, 25);
                        Utils.EraseText(25, 57, 30);

                        string msg = "!! Password Does't match !!";
                        Utils.DisplayError(57, 32, msg);

                        Console.SetCursorPosition(0, 34);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Utils.button(20, 65, "    SignUp");
                        Console.ResetColor();
                    }
                    else
                    {
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

            //  fetching json file to fetch the last account number.
            long accountNumber = users.Any() ? users.Last().AccountNumber + 1 : 789456;

            List<TransactionHistory> transactionHistory = new List<TransactionHistory>();

            Users user = new Users
            {
                Name = name,
                Email = email,
                Password = Utils.HashPassword(password),
                IsNewUser = true,
                Pin = 0,
                AccountNumber = accountNumber,
                BankBalance = 0,
                IsBlocked = false,
                transactionHistories = transactionHistory
            };


            // Adding data to list
            users.Add(user);

            // writing updated data back to json file.
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

            string successMsg = "     ~~ Signup Successfull ~~";
            Utils.DisplaySuccess(57, 32, successMsg);
            Console.Clear();
            Login.CustomerLogin();

            Console.ReadLine();
            return;
        }
    }
}