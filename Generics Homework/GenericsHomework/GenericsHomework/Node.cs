namespace GenericsHomework
{
    using System;

    public class Node<T>
    {
        private Node<T> _Next;

        public Node(T value)
        {
            this.Value = value;
            this._Next = this;
        }

        public T Value { get; private set; }

        public Node<T> Next
        {
            get
            {
                return this._Next;
            }

            private set
            {
                this._Next = value ?? throw new ArgumentNullException($"{nameof(value)} can't be set to Node's Next property because it is null");
            }
        }

        public override string ToString()
        {
            return this.Value?.ToString() ?? throw new ArgumentNullException($"{nameof(Node<T>)}'s value is null");
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
            if (this.Next == this)
            {
                this.Next = new Node<T>(value);
            }
            else
            {
                Node<T> temp = this.Next;
                this.Next = new Node<T>(value);
                this.Next.Next = temp;
            }
        }

        public void Clear()
        {
            this.Next = this;
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