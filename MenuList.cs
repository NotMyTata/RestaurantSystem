using System;

namespace final_project
{
    internal class MenuList
    {
        private MenuNode head, tail;

        internal MenuList()
        {
            head = null;
            tail = null;
        }

        internal void Add(string name, double price, double cost)
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
            Console.WriteLine("-------- Menu has been ADDED --------");
        }

        internal void Remove(string name)
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

        internal MenuNode Find(string name)
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

        internal void ListAll()
        {
            var cur = head;
            while (cur != null)
            {
                Console.WriteLine($"{cur.name}: Rp {cur.price:n}");
                cur = cur.next;
            }
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