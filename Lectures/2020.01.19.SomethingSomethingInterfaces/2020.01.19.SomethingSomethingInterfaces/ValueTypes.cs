using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._01._19.SomethingSomethingInterfaces
{
    public struct MyValueType
    {
        public int Value { get; set; }
    }

    public class MyRefType
    {
        public int Value { get; set; }
    }

    [TestClass]
    public class Foo
    {
        [TestMethod]
        public void DoStuff()
        {
            int a = 1, b = 2;
            // Add value so we adjust for dailight savings for customers in EU
            AddValue(ref a, b);
            Assert.AreEqual(3, a);

            MyRefType cl = new();
            Incriment(cl);
            Assert.AreEqual(1, cl.Value);

            MyValueType t = new();
            Foo2(t);
            Assert.AreEqual(1, t.Value);
        }

        public int Foo2(MyValueType x)
        {
            x.Value += 1;
            return 0;
        }

        public void Incriment(MyRefType x)
        {
            x.Value += 1;
        }

        public void AddValue(ref int a, int b)
        {
            a += b;
        }


    }
}
