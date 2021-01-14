using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Create_GivenValidFilePath_CreateFileLogger()
        {
            // Arrange
            FileLogger fileLogger = new FileLogger();
        }
        [TestMethod]
        public void Log_GivenNullFilePath_ReturnUnsuccesfulLog()
        {
            // Arrange
            FileLogger fileLogger = new FileLogger();

            // Act
            fileLogger.Log(LogLevel.Error, "Who knows");
        }
    }
}
