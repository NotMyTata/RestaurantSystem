using System;

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
                Console.WriteLine("\tInput is not an integer"); return;
            }
            switch (command)
            {
                case 0: isRunning = false; break;
                case 1: setNewOrder(); break;
                case 2: viewOrder(); break;
                case 3: printReceipt(); break;
                case 4: viewMenu(); break;
                case 5: viewRevenue(); break;
                case 6: viewReceiptHistory(); break;
                default: Console.WriteLine($"\t{command} is not within the choices"); break;
            }
        }

        static void setNewOrder()
        {
            OrderQueue.QueueNewOrder();
        }

        static void viewOrder()
        {
            Console.WriteLine("1. Show current order");
            Console.WriteLine("2. List all order");
            Console.WriteLine("0. Return");
            Console.Write("\nCommand Number: ");
            string input = Console.ReadLine();
            int Case;
            if (!int.TryParse(input, out Case))
            {
                Console.WriteLine("\tInput is not an integer"); return;
            }
            switch (Case)
            {
                case 0: break;
                case 1: OrderQueue.ShowCurrentOrder(); break;
                case 2: OrderQueue.ListAll(); break;
                default: Console.WriteLine($"\t{input} is not within choices"); break;
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
                Console.WriteLine("\tInput is not an integer"); return;
            }
            switch (Case)
            {
                case 0: break;
                case 1: MenuList.AddNewMenu(); break;
                case 2: MenuList.RemoveMenu(); break;
                default: Console.WriteLine($"\t{input} is not within choices"); break;
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
                Console.WriteLine("\tInput is not an integer"); return;
            }
            switch (Case)
            {
                case 0: break;
                case 1: ReceiptHistoryList.ListAll(); break;
                case 2: ReceiptHistoryList.ListFirstN(); break;
                case 3: ReceiptHistoryList.ListLastN(); break;
                default: Console.WriteLine($"\t{input} is not within choices"); break;
            }
        }
    }
}
