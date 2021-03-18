using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfApp.Tests
{
    [TestClass]
    public class EmptyStringConverterTests
    {
        [TestMethod]
        public void Convert_GivenEmptyString_ReturnsCollapsed()
        {
            EmptyStringConverter emptyStringConverter = new();

            var actual = emptyStringConverter.Convert(string.Empty, null, null, null);

            Assert.AreEqual<string>("Collapsed", actual.ToString());
        }

        public void Convert_GivenNonEmptyString_ReturnsVisible()
        {
            EmptyStringConverter emptyStringConverter = new();

            var actual = emptyStringConverter.Convert("This Isn't Empty", null, null, null);

            Assert.AreEqual<string>("Visible", actual.ToString());
        }

    }
}
