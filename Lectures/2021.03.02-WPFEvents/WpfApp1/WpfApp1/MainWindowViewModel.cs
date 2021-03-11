using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand LoginCommand { get; }
        public RelayCommand LogoutCommand { get; } 
        public RelayCommand NewCharacterCommand { get; }

        public ObservableCollection<CharacterViewModel> Characters { get; } = new();

        private string _UserName;
        public string UserName
        {
            get => _UserName;
            set
            {
                if (SetProperty(ref _UserName, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _Password = "S3cr3t";
        public string Password
        {
            get => _Password;
            set
            {
                if (SetProperty(ref _Password, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private bool _IsLoggedIn;
        public bool IsLoggedIn
        {
            get => _IsLoggedIn;
            set
            {
                if (SetProperty(ref _IsLoggedIn, value))
                {
                    LogoutCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private CharacterViewModel _SelectedCharacter;
        public CharacterViewModel SelectedCharacter
        {
            get => _SelectedCharacter;
            set => SetProperty(ref _SelectedCharacter, value);
        }

        private ITaskScheduler TaskScheduler { get; }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        public MainWindowViewModel(ITaskScheduler taskScheduler)
        {
            TaskScheduler = taskScheduler ?? throw new ArgumentNullException(nameof(taskScheduler));
            BindingOperations.EnableCollectionSynchronization(Characters, new object());

            LoginCommand = new RelayCommand(DoLogin, CanLogin);
            LogoutCommand = new RelayCommand(DoLogout, CanLogout);
            NewCharacterCommand = new RelayCommand(DoNewCharacter, () => true);

            Characters.Add(new()
            {
                Name = "Markopolis",
                Age = 42
            });
            Characters.Add(new()
            {
                Name = "Stokeberry",
                Age = 21
            });
        }

        private async void DoNewCharacter()
        {
            try
            {
                await DoNewCharacterAsync();
            }
            catch(Exception e)
            {
                //TODO: 
            }
        }

        private async Task DoNewCharacterAsync()
        {
            await TaskScheduler.Run(async () =>
            {
                await TaskScheduler.Delay(100);
                CharacterViewModel newCharacter = new() { Name = "TODO" };
                Characters.Add(newCharacter);
                SelectedCharacter = newCharacter;
            });
        }

        //We do login here... trust me
        private void DoLogin()
        {
            if (string.Equals(UserName, "Kevin", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(Password, "S3cr3t", StringComparison.Ordinal))
            {
                IsLoggedIn = true;
                return;
            }
            IsLoggedIn = false;
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(UserName) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

        private void DoLogout()
        {
            IsLoggedIn = false;
        }

        private bool CanLogout()
        {
            return IsLoggedIn;
        }
    }

    public class TaskScheduler : ITaskScheduler
    {
        public Task Delay(int millisecondsDelay) => Task.Delay(millisecondsDelay);
        public Task Run(Func<Task> action) => Task.Run(action);
    }

    public interface ITaskScheduler
    {
        Task Run(Func<Task> action);
        Task Delay(int millisecondsDelay);
    }
}
