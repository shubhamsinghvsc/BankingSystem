namespace BankingSystem
{
    public class Customer
    {
        public static void Login()
        {
            Console.Clear();
            Utils.NavBar();

            Console.WriteLine("LogIn".PadLeft(76, ' '));
            Console.WriteLine("-----".PadLeft(76, ' ') + "\n\n");
            Utils.boxMaker2(40, 55, "Email ID");
            Utils.boxMaker2(40, 55, "Password");
            Utils.button(15, 67, "  Log In");
            Console.CursorVisible = true;

            Console.WriteLine("New Customer ...");
            Console.Write("Press Enter to Continue");
            Console.ReadLine();
        }

        public static void SignUp()
        {
            Console.Clear();
            Utils.NavBar();
            Console.WriteLine("Signup".PadLeft(77, ' '));
            Console.WriteLine("------".PadLeft(77, ' ') + "\n\n");
            Utils.boxMaker(40, 55, "Name");
            Utils.boxMaker2(40, 55, "Email");
            Utils.boxMaker2(40, 55, "Password (Minmum 8 Characters)");
            Utils.boxMaker2(40, 55, "Confirm Password");

            Utils.button(15, 67, "  Sign Up");

            Utils.button(30, 50, "button99");


            Console.CursorVisible = true;

            //Name
            while (true)
            {
                Console.SetCursorPosition(57, 14);


                Console.SetCursorPosition(57, 14);

                String name = Console.ReadLine();
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
                String email = Console.ReadLine();
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

                    Console.WriteLine("VaLID email");
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
                String password;
                String confirmPassword;
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
    }
}
