using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        //[TestMethod]
        //public void Create_GivenNoFilePath_GivenConfigurtion_CreateFileLogger()
        //{
        //    // Arrange
        //    string filePath = Path.GetRandomFileName();
        //    FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        //    try
        //    {
        //        LogFactory.ConfigureFileLogger(filePath);
        //        FileLogger fileLogger = new FileLogger();
        //        Assert.IsNotNull(fileLogger);
        //    }
        //    finally
        //    {
        //        fileStream.Close();
        //        File.Delete(filePath);
        //    }

        //}
        //[TestMethod]
        //public void Create_GivenNoFilePath_GivenNoConfiguration_CreateNullFileLogger()
        //{
        //    FileLogger fileLogger = new FileLogger();
        //    Assert.IsNull(fileLogger);
        //}

        //[TestMethod]
        //public void Create_GivenValidFilePath_CreateNullFileLogger()
        //{
        //    string filePath = Path.GetRandomFileName();
        //    FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        //    try
        //    {
        //        FileLogger fileLogger = new FileLogger(filePath);
        //    }
        //    finally
        //    {
        //        fileStream.Close();
        //        File.Delete(filePath);
        //    }
        [TestMethod]
        public void Log_GivenValidFileLoggerWrites()
        {
            string filePath = Path.GetFileName("Test.txt");
            FileStream fileStream = new FileStream(filePath, FileMode.Append);
            try
            {
                LogFactory.ConfigureFileLogger(filePath);
                FileLogger fileLogger = LogFactory.CreateLogger("Testing Logger");
                fileStream.Close();
                fileLogger.Log(LogLevel.Debug, "This is a test");
            }
            finally
            {

                File.ReadLines(filePath).Last();
            }
        }

    }
}
