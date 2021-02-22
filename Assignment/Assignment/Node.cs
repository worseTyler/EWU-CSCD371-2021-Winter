﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Node<T> : IEnumerable<T>
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
                Next.Next = this;
            }
            else
            {
                Node<T> temp = Next;
                while (temp.Next != this)
                {
                    temp = temp.Next.Next;
                }
                temp.Next = new Node<T>(value);
                // To circle back to first node
                temp.Next.Next = this;
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> traverse = this;
            do
            {
                yield return traverse.Value;
                traverse = traverse.Next;
            } while (traverse != this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> ChildItems(int maximum)
        {
            Node<T> traverse = this;
            int counter = 0;
            do
            {
                yield return traverse.Value;
                traverse = traverse.Next;
                counter++;
            } while (traverse != this && counter < maximum);
        }
    }
} 

