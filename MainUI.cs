using System;

namespace final_project
{
    internal class MainUI
    {
        static bool isRunning = true;

        internal static void Run()
        {
            while (isRunning)
            {
                showMainMenu();
                handleInput();
            }
        }

        static void showMainMenu()
        {
            Console.WriteLine("\n\tWelcome to the Restaurant\n".ToUpper());
            Console.WriteLine("What can I help you?\n");
            Console.WriteLine("1. Input new order");
            Console.WriteLine("2. View current order");
            Console.WriteLine("3. View menu");
            Console.WriteLine("4. View revenue");
            Console.WriteLine("5. View receipt history");
            Console.WriteLine("0. Exit");
            Console.Write("\nCommand Number: ");
        }

        static void handleInput()
        {
            int command;
            bool input = int.TryParse(Console.ReadLine(), out command);
            if (input is false)
            {
                throw new ArgumentException("Input type is not an integer");
            }
            switch (command)
            {
                case 0: isRunning = false; break;
                case 1: setNewOrder(); break;
                case 2: viewCurOrder(); break;
                case 3: viewMenu(); break;
                case 4: viewRevenue(); break;
                case 5: viewReceiptHistory(); break;
                default:
                    throw new ArgumentOutOfRangeException("Input is not within the choices");
            }
        }

        static void setNewOrder()
        {

        }

        static void viewCurOrder()
        {

        }

        static void viewMenu()
        {

        }

        static void viewRevenue()
        {

        }

        static void viewReceiptHistory()
        {

        }
    }
}
