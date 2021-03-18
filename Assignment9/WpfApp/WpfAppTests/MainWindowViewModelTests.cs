using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfApp.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void NewContactCommand_CreatesNewContactInList()
        {
            MainWindowViewModel mainWindowViewModel = new();

            int expected = mainWindowViewModel.Contacts.Count + 1;

            mainWindowViewModel.NewContactCommand.Action();

            int actual = mainWindowViewModel.Contacts.Count;

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void NewContactCommand_SetsIsEditTrue()
        {
            MainWindowViewModel mainWindowViewModel = new();
            mainWindowViewModel.NewContactCommand.Action();
            Assert.IsTrue(mainWindowViewModel.IsEditContact);
        }
    }
}
