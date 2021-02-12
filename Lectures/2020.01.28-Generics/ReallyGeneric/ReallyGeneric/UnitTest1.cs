using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Moq;

namespace ReallyGeneric
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Int32 number = 42;
            object boxed = number;
            int backOut = (int)boxed;

            Foo(42);

            var list = new List<int>();
            var dictionary = new Dictionary<int, string>();

            var graph = new Graph<City>(new City(), new BigCity());
            graph.GetValue<string>("");
            graph.ConnectNodes(new City(), new BigCity());

            var graph2 = new Graph<BigCity>();
            //double result = graph.Add<double>(3.0, 2);
        }

        [TestMethod]
        public void GenericsWithMock()
        {
            var mock = new Mock<ICity>();
        }

        public static void Foo(object p)
        {

        }
    }

    public interface IGraph<TOutNode>
    {
        TOutNode GetNode();
    }

    public class CCClass : IGraph<City>
    {
        public City GetNode()
        {
            return new InternalCity();
        }

        private record InternalCity : City
        { }
    }

    public class Graph<TNode> where TNode : City, new()
    {
        private List<TNode> Nodes { get; }

        public Graph(params TNode[] cities)
        {
            Nodes = new List<TNode>(cities);
        }

        public TNode ConnectNodes(TNode first, TNode second)
        {
            //var foo = new InternalCity();
            //return foo;

            var tnode = new TNode();
            return tnode;
        }

        public T GetValue<T>(T input)
        {
            return default;
        }

        public T Add<T>(T first, T second) where T : IGetValue
        {
            double rv =  first.Value + second.Value;
            return default;
        }

        private record InternalCity : City
        { }
    }

    public interface IGetValue
    {
        double Value { get; }
    }

    public interface ICity { }

    public record City() : ICity
    {
        public string Name { get; }
    }

    public record BigCity() : City 
    {
        public int Population { get; }
    }
}
