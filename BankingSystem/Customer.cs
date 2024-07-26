using Newtonsoft.Json;

namespace BankingSystem
{
    public class Customer
    {
        public class Users
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public static void Login()
        {
            String email;
            String password;

            string filePath = "users.json";
            List<Users> users = new List<Users>();
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<Users>>(text) ?? new List<Users>();
            }

            Console.Clear();
            Utils.NavBar();

            Console.WriteLine("LogIn".PadLeft(76, ' '));
            Console.WriteLine("-----".PadLeft(76, ' ') + "\n\n");
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
                else if (email.EndsWith(".com") && (email.Contains('@')) && (!email.StartsWith('@')))
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
                            SignUp();
                        }
                        break;
                    }

                }


            }


            Console.WriteLine("New Customer ...");
            Console.Write("Press Enter to Continue");
            Console.ReadLine();
        }

        public static void SignUp()
        {


            String name;
            String email;
            String password;
            String confirmPassword;

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
                if (name == "\t")
                {
                    Console.WriteLine("Tabbbbbbbbbbbbb");
                    Console.SetCursorPosition(57, 19);
                    break;
                }
                else if (name.Length == 0)
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
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(57, 19);
                    Console.WriteLine("                           ");

                }
                else if (email.EndsWith(".com") && (email.Contains('@')) && (!email.StartsWith('@')))
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
                        Login();
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

            // storing data in json file 


            Users user = new Users
            {
                Name = name,
                Email = email,
                Password = password,
            };

            users.Add(user);

            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);


            Console.Write("\nPress Enter to Continue");
            Console.ReadLine();
        }

        public static void AdminLogin()
        {
            Console.Clear();
            Utils.NavBar();

            Console.WriteLine("Service ...");
            Console.Write("Press Enter to Continue");
            Console.ReadLine();
        }

        public static void Exit()
        {

            Console.WriteLine("Reparation ...");
            Console.Write("Press Enter to Continue");
            Console.ReadLine();
        }
        static bool IsEmailExist(List<Users> user, string email)
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

        static bool IsPasswordMatched(List<Users> user, string password)
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
    }

}



// use REgex