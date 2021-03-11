using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void LoginCommand_ValidCreds_DoesLogin()
        {
            //Arrange'
            ITaskScheduler taskScheduler = Mock.Of<ITaskScheduler>();
            var vm = new MainWindowViewModel(taskScheduler);
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
            ITaskScheduler taskScheduler = Mock.Of<ITaskScheduler>();
            var vm = new MainWindowViewModel(taskScheduler);
            var command = vm.LoginCommand;

            //Act
            command.CanExecute(null);

            //Assert
            Assert.IsFalse(vm.IsLoggedIn);
        }

        [TestMethod]
        public async Task NewCharacterCommand_CreatesCharacter()
        {
            //ManualResetEventSlim mre = new();
            //Arrange
            Mock<ITaskScheduler> taskScheduler = new();
            taskScheduler.Setup(x => x.Run(It.IsAny<Func<Task>>()))
                .Callback(async (Func<Task> @delegate) =>
                {
                    Task t = @delegate.Invoke();
                    await t;
                    //mre.Set();
                })
                .Returns(Task.CompletedTask);
            taskScheduler.Setup(x => x.Delay(It.IsAny<int>()))
                .Returns(Task.CompletedTask);

            var vm = new MainWindowViewModel(taskScheduler.Object);
            var command = vm.NewCharacterCommand;
            int initialCount = vm.Characters.Count;

            //Act
            command.Execute(null);
            //Need to wait here until callback is done...
            //await Task.Run(() => mre.Wait());

            //Assert
            Assert.AreEqual(initialCount + 1, vm.Characters.Count);
            Assert.AreEqual(vm.SelectedCharacter, vm.Characters.Last());
        }

        [TestMethod]
        public async Task NewCharacterCommand_CreatesCharacter_NoCheating()
        {
            var mre = new ManualResetEventSlim();
            //Arrange
            var vm = new MainWindowViewModel(new TaskScheduler());
            var command = vm.NewCharacterCommand;
            int initialCount = vm.Characters.Count;

            vm.PropertyChanged += (sender, e) => 
            {
                if (e.PropertyName == nameof(MainWindowViewModel.SelectedCharacter))
                {
                    mre.Set();
                }
            };
            vm.Characters.CollectionChanged += (sender, e) =>
            {

            }

            //Act
            command.Execute(null);
            //Need to wait here until callback is done...
            await Task.Run(() => mre.Wait());

            //Assert
            Assert.AreEqual(initialCount + 1, vm.Characters.Count);
            Assert.AreEqual(vm.SelectedCharacter, vm.Characters.Last());
        }

        
    }
}
