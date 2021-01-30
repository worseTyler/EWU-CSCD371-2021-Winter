using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

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
        public void Equals_StartingNullNumSet_ReturnsFalse()
        {
            NumSet? emptySet = null;
            NumSet numSetOne = new(1, 2, 3, 4, 5);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            bool results = emptySet.Equals(numSetOne);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            Assert.IsFalse(results);
        }
        [TestMethod]
        public void Equals_GivenDifferentNumSets_ReturnsFalse()
        {
            (NumSet numSetOne, NumSet numSetTwo) = CreateDifferentNumSet();

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

        [TestMethod]
        public void EqualsOperator_GivenDifferentNumSet_ReturnFalse()
        {
            (NumSet numSetOne, NumSet numSetTwo) = CreateDifferentNumSet();

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
            (NumSet numSetOne, NumSet numSetTwo) = CreateDifferentNumSet();

            bool result = numSetOne != numSetTwo;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotEqualsOperator_GivenSameNumSet_ReturnFalse()
        {
            (NumSet numSetOne, NumSet numSetTwo) = CreateSameNumSet();

            bool result = numSetOne != numSetTwo;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetArray_WithValidNumSet_ReturnsCorrectArray()
        {
            NumSet numSet = new(1, 2, 3, 4, 5);
            int expected = 1;

            int[] outArray = numSet.GetArray();

            foreach(int num in outArray)
            {
                Assert.AreEqual(expected, num);
                expected++;
            }
        }
        private (NumSet, NumSet) CreateSameNumSet() 
                => (new NumSet(1, 2, 3, 4, 5), new NumSet(5, 4, 3, 2, 1));

        private (NumSet, NumSet) CreateDifferentNumSet()
                => (new NumSet(1, 2, 3, 4, 5), new NumSet(6, 7, 8, 9, 10));

    }

    [TestClass]
    public class SetWriterTests
    {
        [TestMethod]
        public void Create_GivenValidFilePath_CreateSetWriter()
        {
            string filePath = Path.GetTempFileName();
            try
            {
                using (SetWriter setWriter = new(filePath))
                {
                    Assert.IsNotNull(setWriter);
                }
            }
            finally
            {
                File.Delete(filePath);
            }
        }
        [TestMethod]
        public void WriteToStream_GivenMessage_WritesToStream()
        {
            string testMessage = "This is a test message";
            string filePath = Path.GetTempFileName();
            try
            {
                using (SetWriter setWriter = new (filePath))
                {
                    setWriter.WriteToStream(testMessage);
                }
                string returnValue = File.ReadAllText(filePath);
                Assert.AreEqual(testMessage, returnValue);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_GivenInvalidFilePath_ThrowException()
        {
            SetWriter _ = new(null!);
        }
    }
}
