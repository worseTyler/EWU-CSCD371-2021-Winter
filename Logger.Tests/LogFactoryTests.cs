using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void ConfigureFileLogger_GivenValidInputSavesPath()
        {
            string filePath = Path.GetRandomFileName();
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            try
            {
                bool results = LogFactory.ConfigureFileLogger(filePath);
                Assert.IsTrue(results);
            }
            finally
            {
                fileStream.Close();
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void ConfigureFileLogger_GivenInvalidInput_ReturnsFalse()
        {
            string filePath = "This Is A Bad File Path";
            bool results = LogFactory.ConfigureFileLogger(filePath);
            
            Assert.IsFalse(results);
        }

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
            //LogFactory logFactory = new LogFactory();
            string name = "Name";
            FileLogger fileLogger = LogFactory.CreateLogger(name);

            Assert.IsNull(fileLogger);

        }
    }
}
