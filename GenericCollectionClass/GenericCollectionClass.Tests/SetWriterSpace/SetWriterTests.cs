using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using GenericCollectionClass.SetWriterSpace;

namespace GenericCollectionClass.Tests.SetWriterSpace
{
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
            NumSet testMessage = new(1,2,3,4,5);
            string filePath = Path.GetTempFileName();
            try
            {
                using (SetWriter setWriter = new(filePath))
                {
                    setWriter.WriteToStream(testMessage);
                }
                string returnValue = File.ReadAllText(filePath);
                Assert.AreEqual("1, 2, 3, 4, 5", returnValue);
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
