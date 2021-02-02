namespace GenericCollectionClass.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NumSetTests
    {
        public TestContext? TestContext { get; set; }

        [TestMethod]
        public void Create_GivenParamArrayInput_CreateNumSet()
        {
            NumSet numSet = new (1, 2, 3, 4, 5);
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
            (NumSet numSetOne, NumSet numSetTwo) = this.CreateSameNumSet();

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
            (NumSet numSetOne, NumSet numSetTwo) = this.CreateSameNumSet();

            bool result = numSetOne.Equals(numSetTwo);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_GivenNullNumSet_ReturnsFalse()
        {
            NumSet numSetOne = new (1, 2, 3, 4, 5);

            bool result = numSetOne.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_GivenDifferentNumSets_ReturnsFalse()
        {
            (NumSet numSetOne, NumSet numSetTwo) = this.CreateDifferentNumSet();

            bool result = numSetOne.Equals(numSetTwo);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsOperator_GivenSameNumSet_ReturnTrue()
        {
            (NumSet numSetOne, NumSet numSetTwo) = this.CreateSameNumSet();

            bool result = numSetOne == numSetTwo;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsOperator_GivenDifferentNumSet_ReturnFalse()
        {
            (NumSet numSetOne, NumSet numSetTwo) = this.CreateDifferentNumSet();

            bool result = numSetOne == numSetTwo;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualOperator_GivenBothNull_ReturnTrue()
        {
            NumSet? emptyOne = null;
            NumSet? emptyTwo = null;

            Assert.IsTrue(emptyOne == emptyTwo);
        }

        [TestMethod]
        public void NotEqualsOperator_GivenDifferentNumSet_ReturnTrue()
        {
            (NumSet numSetOne, NumSet numSetTwo) = this.CreateDifferentNumSet();

            bool result = numSetOne != numSetTwo;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotEqualsOperator_GivenSameNumSet_ReturnFalse()
        {
            (NumSet numSetOne, NumSet numSetTwo) = this.CreateSameNumSet();

            bool result = numSetOne != numSetTwo;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetArray_WithValidNumSet_ReturnsCorrectArray()
        {
            NumSet numSet = new (1, 2, 3, 4, 5);
            int expected = 1;

            int[] outArray = numSet.GetArray();

            foreach (int num in outArray)
            {
                Assert.AreEqual(expected, num);
                expected++;
            }
        }

        [TestMethod]
        public void CastToArray_AfterCreatingNumSet_CanGetArray()
        {
            NumSet numSet = new (1, 2, 3, 4, 5);
            int[] funcArray = numSet.GetArray();
            int[] castArray = numSet;

            for (int i = 0; i < castArray.Length; i++)
            {
                Assert.AreEqual(castArray[i], funcArray[i]);
            }
        }

        private (NumSet, NumSet) CreateSameNumSet()
                => (new NumSet(1, 2, 3, 4, 5), new NumSet(5, 4, 3, 2, 1));

        private (NumSet, NumSet) CreateDifferentNumSet()
                => (new NumSet(1, 2, 3, 4, 5), new NumSet(6, 7, 8, 9, 10));
    }
}
