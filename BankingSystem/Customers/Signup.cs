using BankingSystem.Models;
using Newtonsoft.Json;

namespace BankingSystem.Customers
{
    public class Signup
    {
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

            Utils.boxMaker2(40, 55, "Name");
            Utils.boxMaker2(40, 55, "Email");
            Utils.boxMaker2(40, 55, "Password (Minmum 8 Characters)");
            Utils.boxMaker2(40, 55, "Confirm Password");

            Utils.button(15, 67, "  Sign Up");

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
                Console.SetCursorPosition(57, 14);
                name = Utils.OnlyStringInput();

                if (name == null)
                {
                    return;
                }
                else if (name.Length == 0)
                {
                    string msg = "!! Please Enter Your Name. !!";
                    Utils.DisplayError(57, 14, msg);
                }
                else
                {
                    break;
                }
            }

            //Email label and input box.
            while (true)
            {
                Console.SetCursorPosition(57, 19);
                email = Utils.OnlyStringInput();
                email = email.ToLower();

                if (email == null)
                {
                    return;
                }
                else if (email.Length == 0)
                {
                    string msg = "!! Email is a required field !!";
                    Utils.DisplayError(57, 19, msg);
                }
                else if (Utils.IsValidEmail(email))
                {
                    //Console.WriteLine("TEST test ");
                    if (Utils.IsEmailExist(users, email))
                    {
                        string msg = "! You Are Already Registered !";
                        Utils.DisplaySuccess(57, 19, msg);

                        Login.CustomerLogin("Customer");
                    }
                    break;
                }

                else
                {
                    string msg = "!! Please enter Valid Email !!";
                    Utils.DisplayError(57, 19, msg);
                }
            }

            //Password 
            while (true)
            {

                //password label and input box.
                while (true)
                {
                    Console.SetCursorPosition(57, 24);
                    password = Utils.OnlyStringInputHidden();
                    if (password == null)
                    {
                        return;
                    }
                    else if (password.Length == 0 || password.Length < 8)
                    {
                        string msg = "!! Please Enter Valid Password !!";
                        Utils.DisplayError(57, 24, msg);
                    }
                    else
                    {
                        break;
                    }

                }
                //confirm password label and input box.
                while (true)
                {
                    Console.SetCursorPosition(57, 29);
                    confirmPassword = Utils.OnlyStringInputHidden();

                    if (confirmPassword == null)
                    {
                        return;
                    }
                    else if (confirmPassword.Length == 0 || confirmPassword.Length < 8)
                    {
                        string msg = "!! Please Enter Valid Password !!";
                        Utils.DisplayError(57, 29, msg);
                    }
                    else
                    {
                        break;
                    }
                }

                if (password != confirmPassword)
                {
                    Utils.EraseText(25, 57, 31);
                    Utils.EraseText(25, 57, 24);
                    Utils.EraseText(25, 57, 29);

                    string msg = "!! Password Does't match !!";
                    Utils.DisplayError(57, 31, msg);
                }
                else
                {
                    break;
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
                transactionHistories = transactionHistory
            };


            // Adding data to list
            users.Add(user);

            // writing updated data back to json file.
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

            string successMsg = "~~ Signup Successfull ~~";
            Utils.DisplaySuccess(57, 24, successMsg);

            Console.ReadLine();
            return;
        }
    }
}