using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GenericCollectionClass.Tests
{
    [TestClass]
    public class NumSetTests
    {
        [TestMethod]
        public void Create_GivenParamArrayInput_CreateNumSet()
        {
            NumSet numSet = new(1, 2, 3, 4, 5);
            Assert.IsInstanceOfType(numSet, typeof(NumSet));
        }

        [TestMethod]
        public void ToString_WithNumSetObject_DisplayAllNumbers()
        {
            NumSet numSet = new (1, 2, 3, 4, 5);
            
            string returnValue = numSet.ToString();

            Assert.AreEqual("1, 2, 3, 4, 5", returnValue);
        }

        [TestMethod]
        public void GetHashCode_WithSameNumDiffOrder_SameHashCode()
        {
            (NumSet numSetOne, NumSet numSetTwo) = CreateSameNumSet();

            int hashOne = numSetOne.GetHashCode();
            int hashTwo = numSetTwo.GetHashCode();

            Assert.AreEqual(hashOne, hashTwo);
        }

        [TestMethod]
        public void TestingMyOwnThing()
        {
            List<int> one = new List<int>();
            List<int> two = new List<int>();

            bool result = one.Equals(two);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_WithSameNumSet_ReturnTrue()
        {
            (NumSet numSetOne, NumSet numSetTwo) = CreateSameNumSet();

            bool result = numSetOne.Equals(numSetTwo);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_GivenNullNumSet_ReturnsFalse()
        {
            NumSet numSetOne = new(1, 2, 3, 4, 5);

            bool result = numSetOne.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_GivenDifferentNumSets_ReturnsFalse()
        {
            (NumSet numSetOne, NumSet numSetTwo) = CreateSameNumSet();

            bool result = numSetOne.Equals(numSetTwo);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsOperator_GivenSameNumSet_ReturnTrue()
        {
            (NumSet numSetOne, NumSet numSetTwo) = CreateSameNumSet();

            bool result = numSetOne == numSetTwo;

            Assert.IsTrue(result);

        }
        private (NumSet, NumSet) CreateSameNumSet() 
                => (new NumSet(1, 2, 3, 4, 5), new NumSet(5, 4, 3, 2, 1));
    }
}
