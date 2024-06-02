using System;

namespace final_project
{
    internal class ReceiptHistoryList
    {

    }

    internal class ReceiptNode
    {
        internal DateTime dateTime;
        internal string name;
        internal string[] description, descPrice;
        internal double totalPrice;
        internal ReceiptNode next, prev;

        internal ReceiptNode(OrderNode orderNode)
        {
            dateTime = DateTime.Now;
            name = orderNode.name;
            description = orderNode.description.Split(',');
            next = null;
            prev = null;
        }
    }
}
