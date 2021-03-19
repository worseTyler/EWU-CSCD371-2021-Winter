using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WpfApp.Tests
{
    [TestClass]
    public class EmptyStringConverterTests
    {
        [TestMethod]
        public void Convert_GivenEmptyString_ReturnsCollapsed()
        {
            EmptyStringConverter emptyStringConverter = new();

            var actual = emptyStringConverter.Convert(string.Empty, null!, null!, null!);

            Assert.AreEqual<string>("Collapsed", actual.ToString()!);
        }

        [TestMethod]
        public void Convert_GivenNonEmptyString_ReturnsVisible()
        {
            EmptyStringConverter emptyStringConverter = new();

            var actual = emptyStringConverter.Convert("This Isn't Empty", null!, null!, null!);

            Assert.AreEqual<string>("Visible", actual.ToString()!);
        }

        [TestMethod]
        public void ConvertBack_GivenVisibleVisibility_ReturnsStringVisible()
        {
            EmptyStringConverter emptyStringConverter = new();

            string actual = (string)emptyStringConverter.ConvertBack(System.Windows.Visibility.Visible, null!, null!, null!);

            Assert.AreEqual<string>("Visible", actual);
        }

        [TestMethod]
        public void ConvertBack_GivenCollapsedVisbility_ReturnsStringCollapsed()
        {
            EmptyStringConverter emptyStringConverter = new();

            string actual = (string)emptyStringConverter.ConvertBack(System.Windows.Visibility.Collapsed, null!, null!, null!);

            Assert.AreEqual<string>("Collapsed", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertBack_GivenArgumentWithNoConversion_ThrowsException()
        {
            EmptyStringConverter emptyStringConverter = new();

            _ = emptyStringConverter.ConvertBack(new object(), null!, null!, null!);
        }

    }
}
