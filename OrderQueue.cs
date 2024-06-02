using System;

namespace final_project
{
    internal class OrderQueue
    {
        private OrderNode head, tail;

        internal OrderQueue()
        {
            head = null;
            tail = null;
        }

        internal void Enqueue(string name, string description)
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
            Console.WriteLine("-------- Order has been ENQUEUED --------");
        }

        internal OrderNode Dequeue()
        {
            if (head == null)
            {
                return null;
            }
            var returnNode = head;
            head = head.next;
            Console.WriteLine("-------- Order has been DEQUEUED --------");
            return returnNode;
        }

        internal OrderNode Peek()
        {
            if (head == null)
            {
                return null;
            }
            return head;
        }

        internal bool isEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }

        internal void ListAll()
        {
            var cur = head;
            while (cur != null)
            {
                Console.WriteLine($"{cur.id}) {cur.name}: {cur.description}");
                cur = cur.next;
            }
        }
    }

    internal class OrderNode
    {
        static int counterId;
        internal int id;
        internal string name, description;
        internal OrderNode next, prev;

        internal OrderNode(string name, string description)
        {
            id = ++counterId;
            this.name = name;
            this.description = description;
            next = null;
            prev = null;
        }
    }
}
