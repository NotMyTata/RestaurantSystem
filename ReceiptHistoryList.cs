using System;

namespace final_project
{
    internal class ReceiptHistoryList
    {
        static private ReceiptNode head, tail;
        static private double revenue;

        internal ReceiptHistoryList()
        {
            head = null;
            tail = null;
            revenue = 0;
        }

        static internal void Add(ReceiptNode node)
        {
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
                tail = node;
            }
        }

        static internal void Print(ReceiptNode curReceipt)
        {
            Console.WriteLine(curReceipt.dateTime);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Customer Name: {curReceipt.name}");
            for (int i = 0; i < curReceipt.menu.Length; i++)
            {
                Console.WriteLine($"{curReceipt.menu[i]}: Rp.{curReceipt.menuPrice[i]:n}");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total Price: Rp.{curReceipt.totalPrice:n}");
            Console.WriteLine("\n");
        }

        static internal void ListAll()
        {
            var curr = tail;
            if (curr == null)
            {
                Console.WriteLine("There is no history");
            }
            while (curr != null)
            {
                Print(curr);
                curr = curr.prev;
            }
        }

        static internal void ListLastN(int n)
        {
            var curr = tail;
            if (curr == null)
            {
                Console.WriteLine("There is no history");
            }
            while (curr != null && n-- > 0)
            {
                Print(curr);
                curr = curr.prev;
            }
        }

        static internal void AddRevenue(double sell, double cost)
        {
            revenue += sell - cost;
        }

        static internal double GetRevenue()
        {
            return revenue;
        }
    }

    internal class ReceiptNode
    {
        internal DateTime dateTime;
        internal string name;
        internal string[] menu;
        internal double[] menuPrice, menuCost;
        internal double totalPrice;
        internal ReceiptNode next, prev;

        internal ReceiptNode(OrderNode node)
        {
            dateTime = DateTime.Now;
            name = node.name;
            menu = node.description.Split(',');
            menuPrice = new double[menu.Length];
            menuCost = new double[menu.Length];
            totalPrice = 0;
            for (int i = 0; i < menu.Length; i++)
            {
                menuPrice[i] = MenuList.PriceOf(menu[i]);
                menuCost[i] = MenuList.CostOf(menu[i]);
                totalPrice += menuPrice[i];
                ReceiptHistoryList.AddRevenue(menuPrice[i], menuCost[i]);
            }
            next = null;
            prev = null;
        }
    }
}
