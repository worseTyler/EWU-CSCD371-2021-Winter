using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_GivenValidFileLoggerWrites()
        {
            // Arrange
            string filePath = Path.GetFileName("Test.txt");
            string loggerName = "TestingLogger";
            string loggerMessage = "Testing Message On The Logger";
            LogLevel logLevel = LogLevel.Debug;
            FileStream fileStream = new FileStream(filePath, FileMode.Append);

            // Act
            LogFactory.ConfigureFileLogger(filePath);
            FileLogger fileLogger = LogFactory.CreateLogger(loggerName);
            fileStream.Close();
            fileLogger.Log(logLevel, loggerMessage);
            string lastLine = File.ReadLines(filePath).Last();

            // Assert
            Assert.AreEqual($"{DateTime.Now} {loggerName} {logLevel} : {loggerMessage} ", lastLine);
        }

    }
}
