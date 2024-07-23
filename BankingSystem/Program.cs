namespace BankingSystem
{
    internal class Program
    {

        public static void Login()
        {
            Console.WriteLine("New Customer ...");
            Console.Write("Press Enter to Continue");
            Console.ReadLine();
        }

        public static void SignUp()
        {
            Console.WriteLine("New Staff ...");
            Console.Write("Press Enter to Continue");
            Console.ReadLine();
        }

        public static void AdminLogin()
        {
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

        static void Paint(int x, int y, String[] mainMenuOption, int menuSelector)
        {
            for (int i = 0; i < mainMenuOption.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);

                var color = menuSelector == i ? ConsoleColor.Yellow : ConsoleColor.Gray;

                Console.ForegroundColor = color;
                Console.WriteLine(mainMenuOption[i]);
            }
        }


        // NavBar
        static void NavBar()
        {
            DateTime dateTime = DateTime.Now;
            string userName = "shubham";
            Console.WriteLine("\n");
            Console.WriteLine("             ----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("             |                                                  State Bank Of Bharat                                                    |");
            Console.WriteLine($"             | Date: {dateTime.Day}-{dateTime.Month}-{dateTime.Year}                                                                                            User: {userName} |");
            Console.WriteLine("             ----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n");

        }

        //Main Menu


        static void MainMenu()
        {
            string[] mainMenuOption = new string[] { "\n\t\t\t\t\t\t\t     1. Login", "\n\t\t\t\t\t\t\t     2. SignUp", "\n\t\t\t\t\t\t\t     3. Admin Login", "\n\t\t\t\t\t\t\t     4. Exit" };
            int menuSelector = 0;
            bool done = false;

            Console.WriteLine("\t\t\t\t\t\t\t  WelCome to State Bank of Bharat");
            Console.WriteLine("\n\n\t\t\t\t\t\t\t     Choose a Option to continue");
            do
            {
                //Console.Clear();

                //NavBar();
                Console.CursorVisible = false;

                Paint(61, 13, mainMenuOption, menuSelector);

                //for (int i = 0; i < mainMenuOption.Length; i++)
                //{
                //    //Console.ForegroundColor = ConsoleColor.Yellow;
                //    if (menuSelector == i)
                //    {
                //        Console.ForegroundColor = ConsoleColor.Green;
                //    }
                //    Console.WriteLine($"{mainMenuOption[i]}");
                //    Console.ResetColor();
                //}

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelector != mainMenuOption.Length - 1)
                {
                    menuSelector++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelector >= 1)
                {
                    menuSelector--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelector)
                    {
                        case 0:
                            Login();
                            break;
                        case 1:
                            SignUp();
                            break;
                        case 2:
                            AdminLogin();
                            break;
                        case 3:

                            break;
                        default:
                            Console.WriteLine("oops something went wrong");
                            break;
                    }
                }
            } while (!done);
        }

        static void Main(string[] args)
        {
            NavBar();
            MainMenu();
            Console.ReadLine();

        }
    }
}

