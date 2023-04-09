namespace CollectionsAndLinq
{
    class Node
    {
        public Node Next { get; set; }
        public string Item { get; set; }
    }

    class LinkList 
    {
        private Node head;
        private Node tail;

        public void AddFirst(Node node)
        {
            node.Next = head;
            head = node;
        }

        public void AddLast(Node node)
        {
            tail.Next = node;
            tail = tail.Next;
        }

        public void Add(string item)
        {
            Node node = new Node();
            node.Item = item;

            this.AddNode(node);
        }

        private void AddNode(Node node)
        {
            if(head == null)
            {
                head = node;
            }
            //else
            //{
            //    Node prev = head;
            //    Node next = head;
            //    while(next != null)
            //    {
            //        prev = next;
            //        next = next.Next;
            //    }

            //    prev.Next = node;
            //    tail = node;
            //}

            tail.Next = node;
            tail = tail.Next;
        }


    }
}
