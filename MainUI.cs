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
            Console.WriteLine("2. View current order");
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
                default:
                    throw new ArgumentOutOfRangeException($"{command} is not within the choices");
            }
        }

        static void setNewOrder()
        {
            string[] input = new string[2];
            Console.Write("Customer Name: "); input[0] = Console.ReadLine();
            Console.Write("Orders ( use (,) to separate menus ): "); input[1] = Console.ReadLine();
            OrderQueue.validate(input[1]);
            OrderQueue.Enqueue(input[0], input[1]);
        }

        static void viewCurOrder()
        {
            var curOrder = OrderQueue.Peek();
            Console.WriteLine($"id: {curOrder.id}, Customer Name: {curOrder.name}, Orders: {curOrder.description}");
        }
        
        static void printReceipt()
        {
            var curReceipt = new ReceiptNode(OrderQueue.Dequeue());
            ReceiptHistoryList.Print(curReceipt);
            ReceiptHistoryList.Add(curReceipt);
        }

        static void viewMenu()
        {
            MenuList.ListAll();
        }

        static void viewRevenue()
        {
            Console.WriteLine($"Current Revenue: Rp.{ReceiptHistoryList.GetRevenue():n}");
        }

        static void viewReceiptHistory()
        {
            Console.WriteLine("1) Show all");
            Console.WriteLine("2) Last n Orders");
            Console.Write("How do you want to print it: ");
            string input = Console.ReadLine();
            int Case;
            if (!int.TryParse(input, out Case))
            {
                throw new ArgumentException("Input is not an integer");
            }
            switch (Case)
            {
                case 1: ReceiptHistoryList.ListAll(); break;
                case 2:
                    Console.Write("Print how much: ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out Case))
                    {
                        throw new ArgumentException("Input is not an integer");
                    }
                    ReceiptHistoryList.ListLastN(Case); break;
                default:
                    throw new ArgumentOutOfRangeException($"{input} is not within choices");
            }
        }
    }
}
