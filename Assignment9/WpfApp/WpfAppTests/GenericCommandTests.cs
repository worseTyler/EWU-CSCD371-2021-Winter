using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WpfApp.Tests
{
    [TestClass]
    public class GenericCommandsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_GivenNullParameterThrowsException()
        {
            GenericCommand genericCommand = new(null!);
        }

        [TestMethod]
        public void Execute_InvokesTheActionPassedIntoConstructor()
        {
            int actual = 10;
            GenericCommand genericCommand = new(() => actual++);

            genericCommand.Execute(this);

            Assert.IsTrue(actual == 11);
        }

        [TestMethod]
        public void CanExecute_ReturnsTrue()
        {
            int actual = 10;
            GenericCommand genericCommand = new(() => actual++);

            Assert.IsTrue(genericCommand.CanExecute(this));
        }
    }
}
