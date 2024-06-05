using System;

namespace final_project
{
    internal class MenuList
    {
        static private MenuNode head, tail;

        internal MenuList()
        {
            head = null;
            tail = null;
            DefaultMenu();
        }

        static internal void DefaultMenu()
        {
            List<string> name = new List<string> {"Nasi Goreng", "Ayam Bakar", "Bakso", "Soto Ayam", "Mie Goreng"};
            List<double> price = new List<double> {15000, 18000, 14000, 16000, 11000};
            List<double> cost = new List<double> {8000, 10000, 6000, 7000, 4000};
            for (int i = 0; i < name.Count; i++)
            {
                Add(name[i], price[i], cost[i]);
            }
        }

        static internal void Add(string name, double price, double cost)
        {
            var newNode = new MenuNode(name, price, cost);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
        }

        static internal void Remove(string name)
        {
            var cur = head;
            while (cur != null)
            {
                if (cur.name == name)
                {
                    cur.prev.next = cur.next;
                    cur.next.prev = cur.prev;
                    Console.WriteLine("-------- Menu has been REMOVED --------");
                    return;
                }
            }
            Console.WriteLine("-------- Menu FAILED to REMOVE --------");
        }

        static internal MenuNode Find(string name)
        {
            var cur = head;
            while (cur != null)
            {
                if (cur.name == name)
                {
                    Console.WriteLine("-------- Menu has been FOUND --------");
                    return cur;
                }
            }
            Console.WriteLine("-------- Menu FAILED to FIND --------");
            return null;
        }

        static internal bool Contains(string menu)
        {
            var cur = head;
            while (cur != null)
            {
                if (cur.name == menu)
                {
                    return true;
                }
                cur = cur.next;
            }
            return false;
        }

        static internal void ListAll()
        {
            var cur = head;
            Console.WriteLine("Current Menus".ToUpper());
            while (cur != null)
            {
                Console.WriteLine($"{cur.name}: Rp {cur.price:n}");
                cur = cur.next;
            }
        }

        static internal double PriceOf(string desc)
        {
            var cur = head;
            while (cur != null)
            {
                if (cur.name == desc)
                {
                    return cur.price;
                }
                cur = cur.next;
            }
            throw new ArgumentException($"{desc} is not in the menu");
        }

        static internal double CostOf(string desc)
        {
            var cur = head;
            while (cur != null)
            {
                if (cur.name == desc)
                {
                    return cur.cost;
                }
                cur = cur.next;
            }
            throw new ArgumentException($"{desc} is not in the menu");
        }
    }

    internal class MenuNode
    {
        internal string name;
        internal double price, cost;
        internal MenuNode next, prev;

        internal MenuNode(string name, double price, double cost)
        {
            this.name = name;
            this.price = price;
            this.cost = cost;
            next = null;
            prev = null;
        }
    }
}