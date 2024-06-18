using System;

namespace final_project
{
    internal class OrderQueue
    {
        static private OrderNode head, tail;

        internal OrderQueue()
        {
            head = null;
            tail = null;
        }

        static internal void QueueNewOrder()
        {
            string[] input = new string[2];
            Console.Write("Customer Name: "); input[0] = Console.ReadLine();
            Console.WriteLine("[ Use (,) to separate menus and (:) for quantity of each menu ]");
            Console.Write("Orders: "); input[1] = Console.ReadLine();
            if (Validate(input[0], input[1]))
            {
                Enqueue(input[0], input[1]);
            }
        }

        static internal void Enqueue(string name, string description)
        {
            var newNode = new OrderNode(name, description);
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
            Console.WriteLine("\t------ Order has been ENQUEUED ------");
        }

        static internal OrderNode Dequeue()
        {
            if (head == null)
            {
                Console.WriteLine("\tQueue is empty".ToUpper());
                return null;
            }
            var returnNode = head;
            head = head.next;
            Console.WriteLine("\t------ Order has been DEQUEUED ------");
            return returnNode;
        }

        static internal void ListAll()
        {
            if (head == null)
            {
                Console.WriteLine("\tQueue is empty".ToUpper());
                return;
            }
            var cur = head;
            while (cur != null)
            {
                Console.WriteLine($"\t{cur.id}) {cur.name}: {cur.description}");
                cur = cur.next;
            }
        }

        static internal void ShowCurrentOrder()
        {
            if (head == null)
            {
                Console.WriteLine("\tQueue is empty".ToUpper());
                return;
            }
            Console.WriteLine($"\t{head.dateTime}\n\tID: {head.id}\n\tCustomer Name: {head.name}\n\tOrders: {head.description}");
        }

        static internal bool Validate(string name, string desc)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("\tCustomer name is empty".ToUpper());
                return false;
            }
            string[] menus = desc.Split(',');
            foreach (string menu in menus)
            {
                if (string.IsNullOrEmpty(menu))
                {
                    Console.WriteLine("\tOrder is empty".ToUpper());
                    return false;
                }
                string[] temp = menu.Split(':');
                if (!MenuList.Contains(temp[0]))
                {
                    Console.WriteLine($"\t{menu} is not in the menu");
                    return false;
                }
                int QuantityTemp;
                if (temp.Length == 1 || int.TryParse(temp[1], out QuantityTemp) == false || QuantityTemp <= 0)
                {
                    Console.WriteLine("\tQuantity is invalid");
                    return false;
                }
            }
            return true;
        }
    }

    internal class OrderNode
    {
        static int counterId;
        internal DateTime dateTime;
        internal int id;
        internal string name, description;
        internal OrderNode next, prev;

        internal OrderNode(string name, string description)
        {
            dateTime = DateTime.Now;
            id = ++counterId;
            this.name = name;
            this.description = description;
            next = null;
            prev = null;
        }
    }
}
