using System;
using System.Runtime.ConstrainedExecution;

namespace final_project
{
    internal class MainUI
    {
        static bool isRunning = true;
        internal static void Run()
        {
            Console.WriteLine("\n\tWelcome to the Restaurant\n".ToUpper());
            new OrderQueue(); new MenuList(); new ReceiptHistoryList();
            while (isRunning)
            {
                showMainMenu();
                handleInput();
                pause();
            }
        }

        static void pause()
        {
            Console.Write("Press enter to continue...");
            Console.ReadLine();
            Console.WriteLine();
        }

        static void showMainMenu()
        {
            Console.WriteLine("What can I help you?\n");
            Console.WriteLine("1. Input new order");
            Console.WriteLine("2. View order");
            Console.WriteLine("3. Print receipt");
            Console.WriteLine("4. View menu");
            Console.WriteLine("5. View revenue");
            Console.WriteLine("6. View receipt history");
            Console.WriteLine("0. Exit");
            Console.Write("\nCommand Number: ");
        }

        static void handleInput()
        {
            int command;
            bool input = int.TryParse(Console.ReadLine(), out command);
            if (input is false)
            {
                throw new ArgumentException("Input is not an integer");
            }
            switch (command)
            {
                case 0: isRunning = false; break;
                case 1: setNewOrder(); break;
                case 2: viewCurOrder(); break;
                case 3: printReceipt(); break;
                case 4: viewMenu(); break;
                case 5: viewRevenue(); break;
                case 6: viewReceiptHistory(); break;
                default: throw new ArgumentOutOfRangeException($"{command} is not within the choices");
            }
        }

        static void setNewOrder()
        {
            string[] input = new string[2];
            Console.Write("Customer Name: "); input[0] = Console.ReadLine();
            Console.WriteLine("[ Use (,) to separate menus and (:) for quantity ]");
            Console.Write("Orders: "); input[1] = Console.ReadLine();
            if (OrderQueue.Validate(input[0], input[1]) == true)
            {
                OrderQueue.Enqueue(input[0], input[1]);
            }
        }

        static void viewCurOrder()
        {
            Console.WriteLine("1. Show current order");
            Console.WriteLine("2. List all order");
            Console.WriteLine("0. Return");
            Console.Write("\nCommand Number: ");
            string input = Console.ReadLine();
            int Case;
            if (!int.TryParse(input, out Case))
            {
                throw new ArgumentException("Input is not an integer");
            }
            switch (Case)
            {
                case 0: break;
                case 1:
                    OrderQueue.ShowCurrentOrder();
                    break;
                case 2:
                    OrderQueue.ListAll();
                    break;
                default: throw new ArgumentOutOfRangeException($"{input} is not within choices");
            }
        }
        
        static void printReceipt()
        {
            var curOrder = OrderQueue.Dequeue();
            if (curOrder == null)
            {
                return;
            }
            var curReceipt = new ReceiptNode(curOrder);
            ReceiptHistoryList.Print(curReceipt);
            ReceiptHistoryList.Add(curReceipt);
        }

        static void viewMenu()
        {
            MenuList.ListAll();
            Console.WriteLine("1. Add new menu");
            Console.WriteLine("2. Delete existing menu");
            Console.WriteLine("0. Return");
            Console.Write("\nCommand Number: ");
            string input = Console.ReadLine();
            int Case;
            if (!int.TryParse(input, out Case))
            {
                throw new ArgumentException("Input is not an integer");
            }
            switch (Case)
            {
                case 0: break;
                case 1:
                    string[] newMenu= new string[3];
                    Console.Write("New menu's name: "); newMenu[0] = Console.ReadLine().TrimEnd();
                    Console.Write("New menu's price: "); newMenu[1] = Console.ReadLine();
                    Console.Write("New menu's cost: "); newMenu[2] = Console.ReadLine();
                    if (MenuList.Validate(newMenu) == true)
                    {
                        MenuList.Add(newMenu[0], double.Parse(newMenu[1]), double.Parse(newMenu[2]));
                        Console.WriteLine("\tNew Menu has been added".ToUpper());
                    }
                    break;
                case 2:
                    string delete;
                    Console.Write("Menu keyword: "); delete = Console.ReadLine();
                    MenuList.Remove(delete);
                    break;
                default: throw new ArgumentOutOfRangeException($"{input} is not within choices");
            }
        }

        static void viewRevenue()
        {
            Console.WriteLine($"\tCurrent Revenue: Rp.{ReceiptHistoryList.GetRevenue():n}");
        }

        static void viewReceiptHistory()
        {
            Console.WriteLine("1. Show all");
            Console.WriteLine("2. First n Orders");
            Console.WriteLine("3. Last n Orders");
            Console.WriteLine("0. Return");
            Console.Write("\nHow do you want to print it: ");
            string input = Console.ReadLine();
            int Case;
            if (!int.TryParse(input, out Case))
            {
                throw new ArgumentException("Input is not an integer");
            }
            switch (Case)
            {
                case 0: break;
                case 1: ReceiptHistoryList.ListAll(); break;
                case 2:
                    Console.Write("Print how much: ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out Case))
                    {
                        throw new ArgumentException("Input is not an integer");
                    }
                    ReceiptHistoryList.ListFirstN(Case);
                    break;
                case 3:
                    Console.Write("Print how much: ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out Case))
                    {
                        throw new ArgumentException("Input is not an integer");
                    }
                    ReceiptHistoryList.ListLastN(Case); 
                    break;
                default: throw new ArgumentOutOfRangeException($"{input} is not within choices");
            }
        }
    }
}
