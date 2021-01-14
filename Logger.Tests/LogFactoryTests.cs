using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        public TestContext TestContext
        {
            get => _TestContext!;
            set => _TestContext = value ?? throw new System.ArgumentNullException(nameof(value));
        }
        private TestContext? _TestContext;

        [ClassInitialize]
        static public void ClassInitialize(TestContext testContext)
        {
            //Console.WriteLine($"Inside ClassInitialize in directory '{ testContext.TestDir }'");
        }

        [TestMethod]
        public void ConfigureFileLogger_GivenValidFilePath()
        {
            //string filePath;
            //LogFactory.ConfigureFileLogger(filePath);
        }

        //public void ConfigureFileLogger_GivenValidFile_ReturnsFileLogger()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}
        //[TestMethod]
        //public void CreateLogger_GivenFilePath_ReturnsFileLogger()
        //{

        //}
        [TestMethod]
        public void CreateLogger_CreateFileLoggerObject_FilePathValid()
        {
            // Arrange
            //LogFactory logFactory = new LogFactory();
            string filePath = "Yes";
            LogFactory.ConfigureFileLogger(filePath);

            // Act
            FileLogger fileLogger = LogFactory.CreateLogger();
            Assert.IsNotNull(fileLogger);
        }

        [TestMethod]
        public void CreateLogger_ReturnNullGivenNoConfiguration()
        {
            //LogFactory logFactory = new LogFactory();

            FileLogger fileLogger = LogFactory.CreateLogger();

            Assert.IsNull(fileLogger);

        }
    }
}
