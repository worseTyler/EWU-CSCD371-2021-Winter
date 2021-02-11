namespace GenericsHomework
{
    using System;

    public class Node<T>
    {
        private Node<T> _Next;

        public Node(T value)
        {
            Value = value;
            _Next = this;
        }

        public T Value { get; private set; }

        public Node<T> Next
        {
            get
            {
                return _Next;
            }

            private set
            {
                _Next = value ?? throw new ArgumentNullException($"{nameof(value)} can't be set to Node's Next property because it is null");
            }
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "Null"; //throw new ArgumentNullException($"{nameof(Node<T>)}'s value is null"); Unsure if ToString should ever throw an exception
        }

        public void InsertAtEnd(T value)
        {
            Node<T> traverse = this;
            while (traverse.Next != traverse)
            {
                traverse = traverse.Next;
            }

            traverse.Next = new Node<T>(value);
        }

        public void Insert(T value)
        {
            if (Next == this)
            {
                Next = new Node<T>(value);
                // To circle back to first node
                // Next.Next = this;
            }
            else
            {
                Node<T> temp = Next;
                while (temp != temp.Next)
                {
                    temp = Next.Next;
                }
                temp.Next = new Node<T>(value);
                // To circle back to first node
                // temp.Next.Next = this;
            }
        }

        public void Clear()
        {
            Next = this;
            /* As long as there are no other references
             * to any of the nodes from other sources (I.E)
             * Node<T> node = definedNode.Next;
             * then all of the nodes would be inaccessable
             * and the garbage collector SHOULD eventually
             * see they can't be accessed and remove them
             */
        }
    }
}