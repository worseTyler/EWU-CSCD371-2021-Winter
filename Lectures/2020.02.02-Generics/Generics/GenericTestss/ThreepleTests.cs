using Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericTestss
{
    [TestClass]
    public class ThreepleTests
    {
        [TestMethod]
        public void CreateThreeple()
        {
            _ = new Threeple<int, string, Guid>(42, "Inigo", Guid.NewGuid());
            _ = new Threeple<string, int, Guid>("Inigo", 42, Guid.NewGuid());
        }

        [TestMethod]
        public void VerifyProperties()
        {
            Threeple<int, string, Guid> threeple = new (42, "Inigo", Guid.NewGuid());
            Assert.AreEqual<int>(42, threeple.First);
        }

        [TestMethod]
        public void GivenThreeple_Description()
        {
            Guid guid = new ();
            string expectedOutput = $"First: 42\nSecond: Inigo\nThird: {guid}";
            Threeple<int, string, Guid> threeple = new (42, "Inigo", guid);
            Assert.IsTrue(threeple.Description.Length > 0);
            Assert.AreEqual<string>(expectedOutput, threeple.Description);
        }

        [TestMethod]
        public void GivenThreepleDescription_ReturnsCorrectString()
        {
            // don't want to write code
        }
        [TestMethod]
        public void GenericMethod()
        {
           // _ = Threeple.Deconstruct<int, string, Guid>(new Threeple<int, string, Guid>(42, "Inigo", Guid.NewGuid()));
        }

        [TestMethod]
        public void Serialization()
        {
           // string output = Serializer.Deserialize<string>(42);
        }

        [TestMethod]
        public void Variance()
        {
            Threeple<int, int, int> threepleOne = new (42, 43, 44);
            Threeple<object, object, object> threepleTwo;
           // threepleOne = threepleTwo;
        }

        [TestMethod]
        public void Serialize()
        {
            Serializer<object> serializerOne = default;
            serializerOne.Serialize(42);
            Serializer<int> serializerTwo = default;
            serializerTwo.Serialize(new object());

            //object output = Serializer.Deserialize<string>(42);
        }
    }
}
