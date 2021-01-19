namespace Logger.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_CreateFileLoggerObject_FilePathValid()
        {
            // Arrange
            string filePath = Path.GetRandomFileName();
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            try
            {
                LogFactory.ConfigureFileLogger(filePath);
                string name = "Name";

                // Act
                FileLogger fileLogger = LogFactory.CreateLogger(name);
                Assert.IsNotNull(fileLogger);
            }
            finally
            {
                fileStream.Close();
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void CreateLogger_ReturnNullGivenNoConfiguration()
        {
            // LogFactory logFactory = new LogFactory();
            string name = "Name";
            FileLogger fileLogger = LogFactory.CreateLogger(name);

            Assert.IsNull(fileLogger);
        }
    }
}
