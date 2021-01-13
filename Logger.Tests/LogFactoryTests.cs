using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        public TestContext TestContext {get; set;}
        public virtual string TestDir { get; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }


        public void ConfigureFileLogger_GivenValidFile_ReturnsFileLogger()
        {
            //Arrange
            //Act

            //Assert
        }
        [TestMethod]
        public void CreateLogger_GivenFilePath_ReturnsFileLogger()
        {

        }
    }
}
