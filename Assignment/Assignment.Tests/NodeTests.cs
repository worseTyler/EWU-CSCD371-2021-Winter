using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        public void CraeteNode_GivenValidInput_CreatesNode()
        {
            _ = new Node<int>(42);
        }

        [TestMethod]

        public void ToString_GivenValidNode_ReturnsCorrectString()
        {
            Node<int> node = new(42);
            Assert.AreEqual<string>("42", node.ToString());
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))] // If ToString throws an exception
        public void ToString_GivenInvalidValue_ThrowsException()
        {
            Node<int?> node = new(null);
            string output = node.ToString();
            Assert.AreEqual<string>(string.Empty, output);
        }

        [TestMethod]
        public void Next_GivenNoOtherNodes_ReferencesSelf()
        {
            Node<int> node = new(42);
            Node<int> alsoNode = node.Next;
            Assert.AreEqual<Node<int>>(node, node.Next);
        }

        [TestMethod]
        public void InsertAtEnd_GivenNewNode_AddsToList()
        {
            Node<int> node = new(42);
            node.InsertAtEnd(43);
            Assert.AreEqual<int>(43, node.Next.Value);
        }

        [TestMethod]
        public void InsertAtEnd_GivenMultipleNodes_AddsLastToEnd()
        {
            Node<int> node = new(42);
            node.InsertAtEnd(43);
            node.InsertAtEnd(44);
            node.InsertAtEnd(45);

            Assert.AreEqual<int>(43, node.Next.Value);
            Assert.AreEqual<int>(44, node.Next.Next.Value);
            Assert.AreEqual<int>(45, node.Next.Next.Next.Value);
        }

        [TestMethod]
        public void Insert_GivenSingleNewNode_AddsToFrontList()
        {
            Node<int> node = new(42);
            node.Insert(43);

            Assert.AreEqual<int>(43, node.Next.Value);
            Assert.AreEqual<int>(42, node.Next.Next.Value);
        }

        [TestMethod]
        public void Insert_GivenMultipleNodes_LastNodeInsertedIsAfterFirstNode()
        {
            Node<int> node = new(42);
            node.Insert(43);
            node.Insert(44);
            node.Insert(45);
            node.Insert(46);

            Assert.AreEqual<int>(43, node.Next.Value);
            Assert.AreEqual<int>(44, node.Next.Next.Value);
            Assert.AreEqual<int>(45, node.Next.Next.Next.Value);
            Assert.AreEqual<int>(46, node.Next.Next.Next.Next.Value);
            Assert.AreEqual<int>(42, node.Next.Next.Next.Next.Next.Value);
        }

        [TestMethod]
        public void Clear_ListWillPointBackToSelf()
        {
            Node<int> node = new(42);
            node.Insert(43);
            node.Insert(44);
            Assert.IsFalse(node.Equals(node.Next));
            node.Clear();
            Assert.IsTrue(node.Equals(node.Next));
        }

        [TestMethod]
        public void GetEnumerator_GivenListofNodes_ReturnsAppropriateEnumerator()
        {
            Node<int> node = new(1);
            for (int i = 2; i < 8; i++)
                node.Insert(i);
            IEnumerator<int> enumerator = node.GetEnumerator();
            for(int i = 1; i < 8; i++)
            {
                enumerator.MoveNext();
                Assert.AreEqual<int>(i, enumerator.Current);
            }
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void ChildItems_GivenInputSmallerThanList_ReturnsCorrectEnumerable ()
        {
            Node<int> node = new(1);
            int counter = 0;
            for (int i = 2; i < 8; i++)
                node.Insert(i);
            IEnumerable<int> child = node.ChildItems(5);
            foreach(int num in child)
            {
                Console.WriteLine(num);
                Assert.AreEqual<int>(++counter, num);
            }
            Assert.AreEqual(5, counter);
        }

        [TestMethod]
        public void ChildItems_GivenInputLargerThanList_ReturnsEnumerableSmallerThanMax()
        {
            Node<int> node = new(1);
            int counter = 0;
            for (int i = 2; i < 8; i++)
                node.Insert(i);
            IEnumerable<int> child = node.ChildItems(15);
            foreach (int num in child)
            {
                Assert.AreEqual<int>(++counter, num);
            }
            Assert.AreEqual(7, counter);
        }
    }
}
