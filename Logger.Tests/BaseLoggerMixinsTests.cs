namespace Logger.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange
            TestLogger? logger = null;

            // Act
#pragma warning disable CS8604 // Want to make sure that null is caught
            logger.Error(string.Empty);
#pragma warning restore CS8604 // Want to make sure that null is caught

            // Assert
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Arrange
            TestLogger? logger = null;

            // Act
#pragma warning disable CS8604 // Want to make sure that null is caught
            logger.Warning(string.Empty);
#pragma warning restore CS8604 // Want to make sure that null is caught

            // Assert
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Warning("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange
            TestLogger? logger = null;

            // Act
#pragma warning disable CS8604 // Want to make sure that null is caught
            logger.Information(string.Empty);
#pragma warning restore CS8604 // Want to make sure that null is caught

            // Assert
        }

        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Information("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange
            TestLogger? logger = null;

            // Act
#pragma warning disable CS8604 // Want to make sure that null is caught
            logger.Debug(string.Empty);
#pragma warning restore CS8604 // Want to make sure that null is caught

            // Assert
        }

        [TestMethod]
        public void Debug_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Debug("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }
    }

#pragma warning disable SA1402 // File Was Given To Me Like This
    public class TestLogger : BaseLogger
#pragma warning restore SA1402 // Should Probably Keep it the Same
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            this.LoggedMessages.Add((logLevel, message));
        }
    }
}