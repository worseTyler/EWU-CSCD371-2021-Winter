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

        [TestMethod]
        public void RemoveContactCommand_RemovesSelectedContact()
        {
            MainWindowViewModel mainWindowViewModel = new();
            int initialContactLength = mainWindowViewModel.Contacts.Count;
            ContactViewModel contact = new()
            {
                FirstName = "Not",
                LastName = "Jones",
                EmailAddress = "notme@gmail.com",
                PhoneNumber = "509-999-1234"
            };


            mainWindowViewModel.Contacts.Add(contact);
            //mainWindowViewModel.SelectedContact = contact;


            Assert.IsTrue(mainWindowViewModel.Contacts.Contains(contact));
            mainWindowViewModel.RemoveContactCommand.Action();


            Assert.AreEqual<int>(initialContactLength, mainWindowViewModel.Contacts.Count);
            Assert.IsFalse(mainWindowViewModel.Contacts.Contains(contact));
           
        }
    }
}
