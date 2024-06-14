using System;
using System.Reflection.Metadata.Ecma335;

namespace final_project
{
    internal class MenuList
    {
        static private MenuNode head;
        static private double profitPercentage = 0.1;
        static private double minimumPriceCost = 1000;

        internal MenuList()
        {
            head = null;
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
            }
            else
            {
                var curr = head;
                int temp = Compare(name, curr.name);
                while (temp >= 0 && curr.next != null)
                {
                    curr = curr.next;
                    temp = Compare(name, curr.name);
                }
                if (temp >= 0)
                {
                    newNode.next = curr.next;
                    curr.next = newNode;
                    newNode.prev = curr;
                }
                else
                {
                    newNode.next = curr;
                    if (curr.prev != null)
                    {
                        curr.prev.next = newNode;
                        newNode.prev = curr.prev;
                    }
                    curr.prev = newNode;
                    if (curr == head)
                    {
                        head = newNode;
                    }
                }
            }
        }

        static internal int Compare(string a, string b)
        {
            a = a.ToLower().Replace(" ", string.Empty);
            b = b.ToLower().Replace(" ", string.Empty);
            for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
            {
                if (i == a.Length)
                {
                    return -1;
                }
                else if (i == b.Length)
                {
                    return 1;
                }
                if (a[i] > b[i])
                {
                    return 1;
                }
                else if (a[i] < b[i])
                {
                    return -1;
                }
            }
            return 0;
        }

        static internal void Remove(string name)
        {
            var curr = head;
            while (curr != null)
            {
                if (Compare(name, curr.name) == 0)
                {
                    if (curr == head)
                    {
                        head = curr.next;
                    }
                    else
                    {
                        curr.prev.next = curr.next;
                        curr.next.prev = curr.prev;
                    }
                    Console.WriteLine("-------- Menu has been REMOVED --------");
                    return;
                }
                curr = curr.next;
            }
            Console.WriteLine($"\t{name} is not found");
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
            Console.WriteLine("\tCurrent Menus".ToUpper());
            while (cur != null)
            {
                Console.WriteLine($"\t{cur.name}: Rp {cur.price:n}");
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

        static internal bool Validate(string[] newMenu)
        {
            if (string.IsNullOrEmpty(newMenu[0]))
            {
                Console.WriteLine("\tNew menu's name is empty".ToUpper());
                return false;
            }
            double tempPrice;
            if (double.TryParse(newMenu[1], out tempPrice) == false)
            {
                Console.WriteLine("\tNew menu's price is invalid".ToUpper());
                return false;
            }
            double tempCost;
            if (double.TryParse(newMenu[2], out tempCost) == false)
            {
                Console.WriteLine("\tNew menu's cost is invalid".ToUpper());
                return false;
            }
            if (tempPrice < tempCost+(tempCost*profitPercentage))
            {
                Console.WriteLine($"\tPrice can't be less than Cost * {Math.Round(profitPercentage * 100, 2)}%");
                return false;
            }
            if (tempPrice <= minimumPriceCost || tempCost <= minimumPriceCost)
            {
                Console.WriteLine($"Price or Cost must be above Rp.{minimumPriceCost:n}");
                return false;
            }
            return true;
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