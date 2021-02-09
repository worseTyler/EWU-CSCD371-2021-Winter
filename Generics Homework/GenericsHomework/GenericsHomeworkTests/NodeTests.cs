using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToString_GivenInvalidValue_ThrowsException()
        {
            Node<int?> node = new(null);
            node.ToString();
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
        }

        [TestMethod]
        public void Insert_GivenMultipleNodes_LastNodeInsertedIsAfterFirstNode()
        {
            Node<int> node = new(42);
            node.Insert(44);
            node.Insert(43);

            Assert.AreEqual<int>(43, node.Next.Value);
            Assert.AreEqual<int>(44, node.Next.Next.Value);
        }

        [TestMethod]
        public void Clear_()
        {
            Node<string>? node = new("Yes");
            node.Insert("No");
            node.Insert("Why");
            WeakReference weakReference = new(node.Next.Next.Next, true);
            node.Clear();
            node = null;
            GC.Collect();

            Assert.IsNotNull(weakReference);
            // I have tried so many different things and none of them
            // Are actually getting the garbage collector to remove
            // any of the nodes
        }

        [TestMethod]
        public void TestingGarbageCollection_ThisShouldWork()
        {
            Node<string> node = new("yes");

            WeakReference<Node<string>> weakReference = new(node, true);
            node = new("no");

            GC.Collect();

            Assert.IsNotNull(weakReference);
            // I remove the reference to the node that contains yes 
            // But when I call the garbage collector it still doesn't
            // Get rid of the first node

            // This is like my 10th attempt at a function that will
            // use WeakReference and the GC.Collect()
        }
    }
}

