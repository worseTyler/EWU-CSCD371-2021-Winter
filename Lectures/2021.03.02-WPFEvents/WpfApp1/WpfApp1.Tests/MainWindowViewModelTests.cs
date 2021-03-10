using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WpfApp1.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void LoginCommand_ValidCreds_DoesLogin()
        {
            //Arrange
            var vm = new MainWindowViewModel();
            var command = vm.LoginCommand;
            vm.UserName = "kevin";

            //Act
            command.Execute(null);

            //Assert
            Assert.IsTrue(vm.IsLoggedIn);
        }

        [TestMethod]
        public void LoginCommand_InvalidCreds_DoesNotLogin()
        {
            //Arrange
            var vm = new MainWindowViewModel();
            var command = vm.LoginCommand;

            //Act
            command.CanExecute(null);

            //Assert
            Assert.IsFalse(vm.IsLoggedIn);
        }

        [TestMethod]
        public void NewCharacterCommand_CreatesCharacter()
        {
            //Arrange
            var vm = new MainWindowViewModel();
            var command = vm.NewCharacterCommand;
            int initialCount = vm.Characters.Count;

            //Act
            command.Execute(null);

            //Assert
            Assert.AreEqual(initialCount + 1, vm.Characters.Count);
            Assert.AreEqual(vm.SelectedCharacter, vm.Characters.Last());
        }
    }
}
