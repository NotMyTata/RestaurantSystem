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
            Console.WriteLine("\n\t" + curReceipt.dateTime);
            Console.WriteLine("\t-------------------------------------");
            Console.WriteLine($"\tCustomer Name: {curReceipt.name}");
            for (int i = 0; i < curReceipt.menu.Length; i++)
            {
                Console.WriteLine($"\t{MenuList.Find(curReceipt.menu[i]).name} x{curReceipt.menuQuantity[i]}: " +
                    $"Rp.{curReceipt.menuPrice[i] * curReceipt.menuQuantity[i]:n}");
            }
            Console.WriteLine("\t-------------------------------------");
            Console.WriteLine($"\tTotal Price: Rp.{curReceipt.totalPrice:n}\n");
        }

        static internal void ListAll()
        {
            var curr = tail;
            if (curr == null)
            {
                Console.WriteLine("\tThere is no history".ToUpper());
            }
            while (curr != null)
            {
                Print(curr);
                curr = curr.prev;
            }
        }

        static internal void ListFirstN()
        {
            Console.Write("Print how much: ");
            string temp = Console.ReadLine();
            int n;
            if (!int.TryParse(temp, out n))
            {
                Console.WriteLine("\tInput is not an integer"); return;
            }

            var curr = head;
            if (curr == null)
            {
                Console.WriteLine("\tThere is no history".ToUpper());
            }
            while (curr != null && n-- > 0)
            {
                Print(curr);
                curr = curr.next;
            }
        }

        static internal void ListLastN()
        {
            Console.Write("Print how much: ");
            string temp = Console.ReadLine();
            int n;
            if (!int.TryParse(temp, out n))
            {
                Console.WriteLine("\tInput is not an integer"); return;
            }

            var curr = tail;
            if (curr == null)
            {
                Console.WriteLine("\tThere is no history".ToUpper());
            }
            while (curr != null && n-- > 0)
            {
                Print(curr);
                curr = curr.prev;
            }
        }

        static internal void AddRevenue(double sell, double cost) { revenue += sell - cost; }
        static internal double GetRevenue() { return revenue; }
    }

    internal class ReceiptNode : OrderNode
    {
        internal string[] menu;
        internal int[] menuQuantity;
        internal double[] menuPrice, menuCost;
        internal double totalPrice, totalCost;
        internal new ReceiptNode next, prev;

        internal ReceiptNode(OrderNode node) : base(node.name, node.description)
        {
            menu = description.Split(',');
            menuQuantity = new int[menu.Length];
            menuPrice = new double[menu.Length];
            menuCost = new double[menu.Length];
            totalPrice = 0; totalCost = 0;
            for (int i = 0; i < menu.Length; i++)
            {
                string[] temp = menu[i].Split(':');
                menu[i] = temp[0];
                menuQuantity[i] = int.Parse(temp[1]);
                menuPrice[i] = MenuList.PriceOf(menu[i]);
                menuCost[i] = MenuList.CostOf(menu[i]);
                totalPrice += menuPrice[i]*menuQuantity[i];
                totalCost += menuCost[i]*menuQuantity[i];
            }
            ReceiptHistoryList.AddRevenue(totalPrice, totalCost);
            this.next = null;
            this.prev = null;
        }   
    }
}
