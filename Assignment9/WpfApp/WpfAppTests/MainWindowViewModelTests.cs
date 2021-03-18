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
        public void NewContactCommand_SetsIsEditFalse()
        {
            MainWindowViewModel mainWindowViewModel = new();
            mainWindowViewModel.NewContactCommand.Action();
            Assert.IsFalse(mainWindowViewModel.IsEditContact);
        }

        [TestMethod]
        public void RemoveContactCommand_RemovesSelectedContact()
        {
            MainWindowViewModel mainWindowViewModel = new();
            int initialContactLength = mainWindowViewModel.Contacts.Count;
            ContactViewModel contact = new()
            {
                FirstName = "AAA",
                LastName = "Jones",
                EmailAddress = "notme@gmail.com",
                PhoneNumber = "509-999-1234"
            };


            mainWindowViewModel.Contacts.Add(contact);
            mainWindowViewModel.SelectedContact = contact;


            Assert.IsTrue(mainWindowViewModel.Contacts.Contains(contact));
            mainWindowViewModel.RemoveContactCommand.Action();


            Assert.AreEqual<int>(initialContactLength, mainWindowViewModel.Contacts.Count);
            Assert.IsFalse(mainWindowViewModel.Contacts.Contains(contact));
        }

        [TestMethod]
        public void EditContactCommand_SetsIsEditToOppositeOfCurrent()
        {
            MainWindowViewModel mainWindowViewModel = new();
            mainWindowViewModel.SelectedContact = mainWindowViewModel.Contacts[0];

            Assert.IsFalse(mainWindowViewModel.IsEditContact);
            Assert.AreEqual<string>("Edit", mainWindowViewModel.EditSaveText);

            mainWindowViewModel.EditContactCommand.Action();

            Assert.IsTrue(mainWindowViewModel.IsEditContact);
            Assert.AreEqual<string>("Save", mainWindowViewModel.EditSaveText);

            mainWindowViewModel.NewContactCommand.Action();

            Assert.IsFalse(mainWindowViewModel.IsEditContact);
            Assert.AreEqual<string>("Edit", mainWindowViewModel.EditSaveText);



        }

        [TestMethod]
        public void EditContactCommand_AddingNewContactSetsEditToFalse()
        {
            MainWindowViewModel mainWindowViewModel = new();
            mainWindowViewModel.SelectedContact = mainWindowViewModel.Contacts[0];

            Assert.IsFalse(mainWindowViewModel.IsEditContact);
            Assert.AreEqual<string>("Edit", mainWindowViewModel.EditSaveText);

            mainWindowViewModel.EditContactCommand.Action();

            mainWindowViewModel.NewContactCommand.Action();

            Assert.IsFalse(mainWindowViewModel.IsEditContact);
            Assert.AreEqual<string>("Edit", mainWindowViewModel.EditSaveText);
        }
    }
}
