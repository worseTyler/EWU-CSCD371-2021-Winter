namespace GenericCollectionClass.Tests.SetWriterSpace
{
    using System;
    using System.IO;
    using GenericCollectionClass.SetWriterSpace;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SetWriterTests
    {
        [TestMethod]
        public void Create_GivenValidFilePath_CreateSetWriter()
        {
            string filePath = Path.GetTempFileName();
            try
            {
                using (SetWriter setWriter = new (filePath))
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
            NumSet testMessage = new (1, 2, 3, 4, 5);
            string filePath = Path.GetTempFileName();
            try
            {
                using (SetWriter setWriter = new (filePath))
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
#pragma warning disable SA1312 // Discarding, naming doesn't matter
            SetWriter _ = new (null!);
#pragma warning restore SA1312 // Discarding, naming doesn't matter
        }
    }
}
